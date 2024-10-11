using SQLEConnect.Parsers.Base;
using SQLEConnect.Relations.Bases;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace SQLEConnect.Entities
{
	internal class Entity<TModel> : BaseObjectParser<TModel> where TModel : new()
	{
		private readonly List<BaseRelation> _memberEntities;
		private readonly List<Func<TModel, TModel>> _initializers = null;

		private readonly Func<TModel> _newFunc;
		private readonly Dictionary<string, Func<TModel, DbDataReader, int, TModel>> _funcByNames = new Dictionary<string, Func<TModel, DbDataReader, int, TModel>>();

		private BaseEntityRelation<TModel> _wrapper = null;
		private TModel _value;
		private Dictionary<int, Func<TModel, DbDataReader, int, TModel>> _cachedFuncByPosition = null;

		internal Entity()
		{
			this._memberEntities = new List<BaseRelation>();
			this._initializers = new List<Func<TModel, TModel>>();

			this._newFunc = base.BuildNewFunc();
			this._funcByNames = base.BuildObjectPropertiesExpressions();

			if (this._funcByNames.Count == 0)
			{
				this._funcByNames = base.BuildObjectFieldsExpressions();
			}
		}

		internal BaseEntityRelation<TModel> Wrapper { set { this._wrapper = value; } }

		internal TModel Value => this._value;

		internal List<BaseRelation> ChildRelations => this._memberEntities;

		internal HashSet<string> Aliases => this._wrapper.Aliases;

		internal void AddInitializer(Func<TModel, TModel> initializer)
		{
			if (initializer == null)
			{
				throw new ArgumentNullException();
			}

			this._initializers.Add(initializer);
		}

		internal void AddMember(BaseRelation member)
		{
			if (member == null)
			{
				throw new ArgumentNullException();
			}

			this._memberEntities.Add(member);
		}

		internal TModel ParseRow(DbDataReader rowDataReader)
		{
			this._value = this._newFunc();

			if (this._initializers != null)
			{
				foreach (Func<TModel, TModel> initializer in this._initializers)
				{
					this._value = initializer(this._value);
				}
			}

			if (this._cachedFuncByPosition == null)
			{
				this._cachedFuncByPosition = new Dictionary<int, Func<TModel, DbDataReader, int, TModel>>();

				string name;

				for (int i = 0; i < rowDataReader.FieldCount; i++)
				{
					name = rowDataReader.GetName(i)?.ToLower();

					if (!string.IsNullOrWhiteSpace(name) && !this._wrapper.DoesAliasExists(name) && this._funcByNames.TryGetValue(name, out Func<TModel, DbDataReader, int, TModel> propertySetterFunc))
					{
						this._value = propertySetterFunc(this._value, rowDataReader, i);
						this._cachedFuncByPosition.Add(i, propertySetterFunc);
						this._wrapper.AddAlias(name);
					}
				}
			}
			else
			{
				foreach (int index in this._cachedFuncByPosition.Keys)
				{
					this._value = this._cachedFuncByPosition[index](this._value, rowDataReader, index);
				}
			}

			this._value = this._wrapper.GetValue(this._value);

			if (this._memberEntities.Count > 0)
			{
				foreach (BaseRelation child in this._memberEntities)
				{
					child.UpdateModel(rowDataReader);
				}
			}

			this._wrapper.SetValue(this._value);

			return this._value;
		}
	}
}