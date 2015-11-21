using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.Configuration;
using System.IO;

namespace OxfordCC.ContrOCC.SQLUtilities.Business
{
	public class oScriptParser
	{
		#region Public interface

		public TSqlFragment GetRootFragment(TextReader textReader, out IList<ParseError> parseErrors)
		{
			TSqlParser sqlParser = CreateSQLParser();

			return sqlParser.Parse(textReader, out parseErrors);
		}

		public List<TSqlFragment> GetFragmentChildren(TSqlFragment parentFragment)
		{
			oVisitorAll visitor = new oVisitorAll();

			parentFragment.AcceptChildren(visitor);

			return visitor.Fragments;
		}

		public List<TSqlFragment> GetFragmentChildren(TSqlFragment parentFragment, oVisitorBase visitor, bool recurseChildren = false)
		{
			parentFragment.AcceptChildren(visitor);

			List<TSqlFragment> children = visitor.Fragments;
			List<TSqlFragment> grandChildren;

			if (recurseChildren)
			{
				foreach (TSqlFragment f in children)
				{
					grandChildren = GetFragmentChildren(f, visitor, recurseChildren);

					if ((grandChildren != null) && (grandChildren.Count > 0))
						children.AddRange(grandChildren);
				}
			}

			return children;
		}

		#endregion

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
					//sql.Append(" ");
				}
			}

			return sql.ToString().Trim();
		}

		#endregion

		#region Private implementation

		private TSqlParser CreateSQLParser()
		{
			TSqlParser sqlParser;

			switch (ConfigurationManager.AppSettings["ParserCompatibilityLevel"])
			{
				case "90":
					sqlParser = new TSql90Parser(true);
					break;
				case "100":
					sqlParser = new TSql100Parser(true);
					break;
				case "110":
					sqlParser = new TSql110Parser(true);
					break;
				default:
					throw new ArgumentException("Invalid argument provided for [ParserCompatibilityLevel] configuration setting!");
			}

			return sqlParser;
		}

		#endregion
	}
}
