using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.Configuration;
using System.IO;

namespace OxfordCC.ContrOCC.SQLUtilities.Presentation
{
	public class oScriptParser
	{
		TSqlParser _parser;

		public oScriptParser()
		{
			switch (ConfigurationManager.AppSettings["ParserCompatibilityLevel"])
			{
				case "90":
					_parser = new TSql90Parser(true);
					break;
				case "100":
					_parser = new TSql100Parser(true);
					break;
				case "110":
					_parser = new TSql110Parser(true);
					break;
				default:
					if (!oApplication.InDesign())
					{
						throw new ArgumentException("Invalid argument provided for [ParserCompatibilityLevel] configuration setting!");
					}
					break;
			}
		}

		public TSqlFragment GetRootFragment(TextReader textReader, out IList<ParseError> parseErrors)
		{
			return _parser.Parse(textReader, out parseErrors);
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
