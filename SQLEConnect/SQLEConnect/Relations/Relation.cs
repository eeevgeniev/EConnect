using SQLEConnect.Entities;
using SQLEConnect.Relations.Bases;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace SQLEConnect.Relations
{
	internal class Relation<TModel, TChild> : BaseEntityRelation<TChild>
		where TModel : new()
		where TChild : new()
    {
        private readonly Entity<TModel> _parent;
		
		private readonly Func<TModel, TChild, TModel> _assignChildToParent = null;
        private readonly Func<TModel, ICollection<TChild>> _modelCollectionMemberGetter = null;
        private readonly Func<TModel, TChild> _modelMemberGetter = null;
		private readonly Func<TChild, TChild, bool> _equalityComparer = null;
		private readonly bool _isCollection = false;
		private readonly bool _collectionHasComparer = false;

		internal Relation(Entity<TModel> parent,
            Entity<TChild> child,
            Func<TModel, TChild, TModel> assignChildToParent,
            Func<TModel, ICollection<TChild>> collectionMember,
            Func<TChild, TChild, bool> equalityComparer)
            : this(parent, child, assignChildToParent, null)
        {
            this._modelCollectionMemberGetter = collectionMember ?? throw new ArgumentNullException(nameof(collectionMember));
			this._equalityComparer = equalityComparer ?? null;
			
			this._isCollection = true;
			this._collectionHasComparer = this._equalityComparer != null;
		}

        internal Relation(Entity<TModel> parent,
            Entity<TChild> child,
            Func<TModel, TChild, TModel> assignChildToParent,
			Func<TModel, TChild> modelMemberGetter)
            : base (child)
        {
            this._parent = parent ?? throw new ArgumentNullException();
            this._assignChildToParent = assignChildToParent ?? throw new ArgumentNullException();
            this._modelMemberGetter = modelMemberGetter;

			base.Child.Wrapper = this;
		}

        internal override List<BaseRelation> Children => this.Child.ChildRelations;

		internal override HashSet<string> Aliases => this._parent.Aliases;

		internal override void UpdateModel(DbDataReader rowDataReader) => base.Child.ParseRow(rowDataReader);

		internal override TChild GetValue(TChild value)
		{
            if (!this._isCollection)
			{
				return this._modelMemberGetter(this._parent.Value) ?? value;
			}

			return !this._collectionHasComparer ? value : this._modelCollectionMemberGetter(this._parent.Value).FirstOrDefault(ch => this._equalityComparer(value, ch)) ?? value;
		}

		internal override void SetValue(TChild value)
		{
			if (value == null)
			{
				return;
			}
			
			if (!this._isCollection)
			{
				this._assignChildToParent(this._parent.Value, value);
				return;
			}

			if (!this.IsValueAdded(value))
			{
				this._assignChildToParent(this._parent.Value, value);
			}
		}

		internal override bool DoesAliasExists(string alias) => this.Aliases.Contains(alias);

		internal override void AddAlias(string alias) => this.Aliases.Add(alias);

		internal override bool IsValueAdded(TChild value)
		{
			if (!this._isCollection)
			{
				return false;
			}

			return !this._collectionHasComparer ? false : this._modelCollectionMemberGetter(this._parent.Value).Any(ch => this._equalityComparer(value, ch));
		}
	}
}
