using System.Collections.Generic;
using System.Data.Common;

namespace SQLEConnect.Relations.Bases
{
    internal abstract class BaseRelation
    {
        internal abstract List<BaseRelation> Children { get; }

        internal abstract void UpdateModel(DbDataReader rowDataReader);
	}
}
