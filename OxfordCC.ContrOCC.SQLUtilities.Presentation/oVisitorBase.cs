using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace OxfordCC.ContrOCC.SQLUtilities.Presentation
{
	public class oVisitorBase : TSqlFragmentVisitor
	{
		protected List<TSqlFragment> _fragments;

		public List<TSqlFragment> Fragments { get { return _fragments; } }

		public oVisitorBase()
		{
			_fragments = new List<TSqlFragment>();
		}

	}
}
