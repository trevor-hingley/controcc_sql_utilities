using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace OxfordCC.ContrOCC.SQLUtilities.Business
{
	public class oSQLStandardsChecker
	{
		#region Private members

		private const string VALID_SCHEMA_PATTERN = @"AHR_A|AHR_C|dbo|ProtocolSync";

		// Taken from [dbo].[ContrOCC_StoredProcedurePrefixes]
		private const string VALID_PROCEDURE_NAME_PREFIX_PATTERN = @"^(AdHoc|CacheAdHocReportingViews|Controcc|ControccRemote|Interface|LiquidLogic|OCC|PERF|RetrieveAndExecute|SYS|TEST)_.*";

		// Taken from [dbo].[ContrOCC_TableNamePrefixes]
		private const string VALID_TABLE_NAME_PREFIX_PATTERN = @"^(LL|OCC|T|TAudit|TImport|TImportExport|TRef|TRefSys|TSys|TTemp|TTest)_.*";

		private oScriptParser _scriptParser;
		private TSqlFragment _rootFragment;

		#endregion

		public oSQLStandardsChecker(oScriptParser scriptParser, TSqlFragment rootFragment)
		{
			_scriptParser = scriptParser;
			_rootFragment = rootFragment;
		}

		#region Public check methods

		public List<oIssue> CheckProcedureName()
		{
			List<oIssue> issuesFound = new List<oIssue>();
			List<TSqlFragment> executableProcedureReferenceFragments = _scriptParser.GetFragmentChildren(_rootFragment, new oVisitorExecutableProcedureReference());
			string executableProcedureReferenceSQL;
			string server;
			string database;
			string schema;
			string procedure;

			foreach (TSqlFragment executableProcedureReferenceFragment in executableProcedureReferenceFragments)
			{
				executableProcedureReferenceSQL = _scriptParser.GetFragmentSQL(executableProcedureReferenceFragment);
				SplitEntityReference(executableProcedureReferenceSQL, out server, out database, out schema, out procedure);

				if (!HasValidProcedureNamePrefix(procedure))
					issuesFound.Add(new oIssue("Procedure has invalid prefix", executableProcedureReferenceFragment.StartLine, executableProcedureReferenceSQL, true));
			}

			return issuesFound;
		}

		public List<oIssue> CheckProcedureSchemaPrefixes()
		{
			List<oIssue> issuesFound = new List<oIssue>();
			List<TSqlFragment> executableProcedureReferenceFragments = _scriptParser.GetFragmentChildren(_rootFragment, new oVisitorExecutableProcedureReference());

			string executableProcedureReferenceSQL;
			string server;
			string database;
			string schema;
			string procedure;

			foreach (TSqlFragment executableProcedureReferenceFragment in executableProcedureReferenceFragments)
			{
				executableProcedureReferenceSQL = _scriptParser.GetFragmentSQL(executableProcedureReferenceFragment);
				SplitEntityReference(executableProcedureReferenceSQL, out server, out database, out schema, out procedure);

				if (string.IsNullOrEmpty(schema))
					issuesFound.Add(new oIssue("Procedure schema has not been specified", executableProcedureReferenceFragment.StartLine, executableProcedureReferenceSQL, true));
				else if (!IsValidProcedureSchema(schema))
					issuesFound.Add(new oIssue("Procedure has unrecognised schema", executableProcedureReferenceFragment.StartLine, executableProcedureReferenceSQL, true));
			}

			return issuesFound;
		}

		public List<oIssue> CheckTemporaryTableCharacterColumnCollations()
		{
			List<oIssue> issuesFound = new List<oIssue>();
            List<TSqlFragment> createTemporaryTableFragments = _scriptParser.GetFragmentChildren(_rootFragment, new oVisitorCreateTableStatement());

			foreach (TSqlFragment createTableFragment in createTemporaryTableFragments)
			{
				List<TSqlFragment> columnDefinitionFragments = _scriptParser.GetFragmentChildren(createTableFragment, new oVisitorColumnDefinition());

				foreach (TSqlFragment columnDefinitionFragment in columnDefinitionFragments)
				{
					string columnDefinitionSQL = columnDefinitionSQL = _scriptParser.GetFragmentSQL(columnDefinitionFragment);
					List<TSqlFragment> sqlDataTypeDefinitionFragments = _scriptParser.GetFragmentChildren(columnDefinitionFragment, new oVisitorSQLDataTypeReference());

					foreach (TSqlFragment sqlDataTypeDefinitionFragment in sqlDataTypeDefinitionFragments)
					{
						string sqlDataTypeDefinitionSQL = _scriptParser.GetFragmentSQL(sqlDataTypeDefinitionFragment);

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

			foreach (TSqlFragment createTableFragment in declareTableVariableFragements)
			{
				List<TSqlFragment> columnDefinitionFragments = _scriptParser.GetFragmentChildren(createTableFragment, new oVisitorColumnDefinition());

				foreach (TSqlFragment columnDefinitionFragment in columnDefinitionFragments)
				{
					string columnDefinitionSQL = columnDefinitionSQL = _scriptParser.GetFragmentSQL(columnDefinitionFragment);
					List<TSqlFragment> sqlDataTypeDefinitionFragments = _scriptParser.GetFragmentChildren(columnDefinitionFragment, new oVisitorSQLDataTypeReference());

					foreach (TSqlFragment sqlDataTypeDefinitionFragment in sqlDataTypeDefinitionFragments)
					{
						string sqlDataTypeDefinitionSQL = _scriptParser.GetFragmentSQL(sqlDataTypeDefinitionFragment);

						if ((sqlDataTypeDefinitionSQL.ToLower().Contains("char")) && (!columnDefinitionSQL.Contains("database_default")))
							issuesFound.Add(new oIssue("Table variable missing collation for character column", columnDefinitionFragment.StartLine, columnDefinitionSQL, false));
					}
				}
			}

			return issuesFound;
		}

		#endregion

		#region Private implementation

		private bool SplitEntityReference(string entityReference, out string server, out string database, out string schema, out string entity)
		{
			string pattern = @"\[?(\w*)\]?\.\[?(\w*)\]?\.\[?(\w*)\]?\.\[?(\w+)\]?";
			Regex regex = new Regex(pattern);
			int dotCount = entityReference.Length - entityReference.Replace(".", string.Empty).Length;

			if (dotCount < 3)
				entityReference = "...".Substring(0 + dotCount) + entityReference;

			Match m = regex.Match(entityReference);

			if (m.Success)
			{
				server = m.Groups[1].Value;
				database = m.Groups[2].Value;
				schema = m.Groups[3].Value;
				entity = m.Groups[4].Value;
			}
			else
			{
				server = string.Empty;
				database = string.Empty;
				schema = string.Empty;
				entity = string.Empty;
			}

			return m.Success;
		}

		private bool PatternMatch(string text, string pattern, RegexOptions options = RegexOptions.None)
		{
			Regex regex = new Regex(pattern, options);
			Match m = regex.Match(text);

			return m.Success;
		}

		private bool IsValidProcedureSchema(string schema)
		{
			return PatternMatch(schema, VALID_SCHEMA_PATTERN);
		}

		private bool HasValidProcedureNamePrefix(string procedureName)
		{
			return PatternMatch(procedureName, VALID_PROCEDURE_NAME_PREFIX_PATTERN);
		}

		private bool HasValidTableNamePrefix(string tableName)
		{
			return PatternMatch(tableName, VALID_TABLE_NAME_PREFIX_PATTERN);
		}

		#endregion
	}
}
