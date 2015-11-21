using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.IO;
using System.Reflection;

namespace OxfordCC.ContrOCC.SQLUtilities.Business.Test
{
	[TestClass]
	public class UnitTests
	{
		[TestMethod]
		public void StandardsChecker_CheckProcedureName_Test1()
		{
			RunTest("Script2.txt", "CheckProcedureName", 2);
		}

		[TestMethod]
		public void StandardsChecker_CheckProcedureSchemaPrefixes_Test1()
		{
			RunTest("Script2.txt", "CheckProcedureSchemaPrefixes", 3);
		}

		[TestMethod]
		public void StandardsChecker_CheckTableVariableCharacterColumnCollations_Test1()
		{
			RunTest("Script1.txt", "CheckTableVariableCharacterColumnCollations", 1);
		}

		[TestMethod]
		public void StandardsChecker_CheckTemporaryTableCharacterColumnCollations_Test1()
		{
			RunTest("Script1.txt", "CheckTemporaryTableCharacterColumnCollations", 2);
		}

		#region Private implementation

		private void RunTest(string sqlScriptFileName, string methodName, int expectedIssueCount)
		{
			oScriptParser scriptParser = new oScriptParser();
			TSqlFragment rootFragment;

			using (TextReader textReader = new StringReader(ReadSQLScript(sqlScriptFileName)))
			{
				IList<ParseError> parseErrors;
				rootFragment = scriptParser.GetRootFragment(textReader, out parseErrors);
			}

			oSQLStandardsChecker _standardsChecker = new oSQLStandardsChecker(scriptParser, rootFragment);
			MethodInfo testMethodInfo = _standardsChecker.GetType().GetMethod(methodName);
			List<oIssue> issuesFound = (List<oIssue>) testMethodInfo.Invoke(_standardsChecker, new object[] { });

			Assert.AreEqual(expectedIssueCount, issuesFound.Count, "An unexpected number of issues were found.");
		}

		private string ReadSQLScript(string sqlScriptFileName)
		{
			string sqlScript = string.Empty;
			Assembly assembly = Assembly.GetExecutingAssembly();
			string resourceName = assembly.GetName().Name + @".SQLScripts." + sqlScriptFileName;
			Stream stream = assembly.GetManifestResourceStream(resourceName);

			if (stream != null)
			{
				using (StreamReader reader = new StreamReader(stream))
				{
					sqlScript = reader.ReadToEnd();
				}
			}

			return sqlScript;
		}

		#endregion
	}
}
