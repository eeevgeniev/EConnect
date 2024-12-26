using SQLEConnect.Entities;
using System;
using System.Collections.Generic;

namespace SQLEConnect.Relations.Bases
{
	internal abstract class BaseEntityRelation<TChild> : BaseRelation
		where TChild : new()
	{
		private readonly Entity<TChild> _child;
		
		protected BaseEntityRelation(Entity<TChild> child)
		{
			this._child = child ?? throw new ArgumentNullException();
		}

		internal Entity<TChild> Child => this._child;

		internal abstract TChild GetValue(TChild value);

		internal abstract bool IsValueAdded(TChild value);

		internal abstract void SetValue(TChild value);

		internal abstract bool DoesAliasExists(string alias);

		internal abstract void AddAlias(string alias);

		internal abstract HashSet<string> Aliases { get; }
	}
}