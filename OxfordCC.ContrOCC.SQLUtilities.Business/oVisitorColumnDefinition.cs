﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace OxfordCC.ContrOCC.SQLUtilities.Business
{
	public class oVisitorColumnDefinition : oVisitorBase
	{
		public override void ExplicitVisit(ColumnDefinition fragment) { _fragments.Add(fragment); }
	}
}