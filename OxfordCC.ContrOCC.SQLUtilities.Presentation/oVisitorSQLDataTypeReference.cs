using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace OxfordCC.ContrOCC.SQLUtilities.Presentation
{
	public class oVisitorSQLDataTypeReference : oVisitorBase
	{
		public override void ExplicitVisit(SqlDataTypeReference fragment) { _fragments.Add(fragment); }
	}
}
