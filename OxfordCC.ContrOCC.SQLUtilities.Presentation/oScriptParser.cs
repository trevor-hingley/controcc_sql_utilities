using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.IO;

namespace OxfordCC.ContrOCC.SQLUtilities.Presentation
{
	public class oScriptParser
	{
		public TSqlFragment GetRootFragment(TextReader textReader, out IList<ParseError> parseErrors)
		{
			TSqlParser parser = new TSql90Parser(true);
			TSqlFragment sqlFragment = parser.Parse(textReader, out parseErrors);

			return sqlFragment;
		}

		public List<TSqlFragment> GetFragmentChildren(TSqlFragment parentFragment)
		{
			oVisitorAll visitor = new oVisitorAll();

			parentFragment.AcceptChildren(visitor);

			return visitor.Fragments;
		}

		#region Helper methods

		public string GetFragmentTypeName(TSqlFragment fragment)
		{
			return fragment.GetType().Name;
		}

		public string GetFragmentSQL(TSqlFragment fragment)
		{
			StringBuilder sql = new StringBuilder();

			if (fragment.FirstTokenIndex != -1)
			{
				for (int counter = fragment.FirstTokenIndex; counter <= fragment.LastTokenIndex; counter++)
				{
					sql.Append(fragment.ScriptTokenStream[counter].Text);
					sql.Append(" ");
				}
			}

			return sql.ToString().Trim();
		}

		#endregion
	}
}
