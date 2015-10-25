using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace OxfordCC.ContrOCC.SQLUtilities.Business
{
	public class oSQLStandardsChecker
	{
		private oScriptParser _scriptParser;
		private TSqlFragment _rootFragment;

		public oSQLStandardsChecker(oScriptParser scriptParser, TSqlFragment rootFragment)
		{
			_scriptParser = scriptParser;
			_rootFragment = rootFragment;
		}

		public List<oIssue> CheckTemporaryTableCharacterColumnCollations()
		{
			List<oIssue> issuesFound = new List<oIssue>();
            List<TSqlFragment> createTemporaryTableFragments = _scriptParser.GetFragmentChildren(_rootFragment, new oVisitorCreateTableStatement());
			List<TSqlFragment> columnDefinitionFragments;
			string columnDefinitionSQL;
			List<TSqlFragment> sqlDataTypeDefinitionFragments;
			string sqlDataTypeDefinitionSQL;

			foreach (TSqlFragment createTableFragment in createTemporaryTableFragments)
			{
				columnDefinitionFragments = _scriptParser.GetFragmentChildren(createTableFragment, new oVisitorColumnDefinition());

				foreach (TSqlFragment columnDefinitionFragment in columnDefinitionFragments)
				{
					columnDefinitionSQL = columnDefinitionSQL = _scriptParser.GetFragmentSQL(columnDefinitionFragment);
					sqlDataTypeDefinitionFragments = _scriptParser.GetFragmentChildren(columnDefinitionFragment, new oVisitorSQLDataTypeReference());

					foreach (TSqlFragment sqlDataTypeDefinitionFragment in sqlDataTypeDefinitionFragments)
					{
						sqlDataTypeDefinitionSQL = _scriptParser.GetFragmentSQL(sqlDataTypeDefinitionFragment);

						if ((sqlDataTypeDefinitionSQL.ToLower().Contains("char")) && (!columnDefinitionSQL.Contains("database_default")))
							issuesFound.Add(new oIssue("Temporary table missing collation for character column", columnDefinitionFragment.StartLine, columnDefinitionSQL, true));
					}
				}
			}

			return issuesFound;
		}

		public List<oIssue> CheckTableVariableCharacterColumnCollations()
		{
			List<oIssue> issuesFound = new List<oIssue>();
			List<TSqlFragment> declareTableVariableFragements = _scriptParser.GetFragmentChildren(_rootFragment, new oVisitorDeclareTableVariableStatement());
			List<TSqlFragment> columnDefinitionFragments;
			string columnDefinitionSQL;
			List<TSqlFragment> sqlDataTypeDefinitionFragments;
			string sqlDataTypeDefinitionSQL;

			foreach (TSqlFragment createTableFragment in declareTableVariableFragements)
			{
				columnDefinitionFragments = _scriptParser.GetFragmentChildren(createTableFragment, new oVisitorColumnDefinition());

				foreach (TSqlFragment columnDefinitionFragment in columnDefinitionFragments)
				{
					columnDefinitionSQL = columnDefinitionSQL = _scriptParser.GetFragmentSQL(columnDefinitionFragment);
					sqlDataTypeDefinitionFragments = _scriptParser.GetFragmentChildren(columnDefinitionFragment, new oVisitorSQLDataTypeReference());

					foreach (TSqlFragment sqlDataTypeDefinitionFragment in sqlDataTypeDefinitionFragments)
					{
						sqlDataTypeDefinitionSQL = _scriptParser.GetFragmentSQL(sqlDataTypeDefinitionFragment);

						if ((sqlDataTypeDefinitionSQL.ToLower().Contains("char")) && (!columnDefinitionSQL.Contains("database_default")))
							issuesFound.Add(new oIssue("Table variable missing collation for character column", columnDefinitionFragment.StartLine, columnDefinitionSQL, false));
					}
				}
			}

			return issuesFound;
		}
	}
}
