using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace OxfordCC.ContrOCC.SQLUtilities.Presentation
{
	public class oVisitorCreateTableStatements : oVisitorBase
	{
		public override void ExplicitVisit(CreateTableStatement fragment) { _fragments.Add(fragment); }
	}
}
