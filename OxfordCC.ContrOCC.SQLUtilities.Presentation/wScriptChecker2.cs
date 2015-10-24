using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace OxfordCC.ContrOCC.SQLUtilities.Presentation
{
	public partial class wScriptChecker2 : OxfordCC.ContrOCC.SQLUtilities.Presentation.wScriptBase
	{
		public wScriptChecker2()
		{
			InitializeComponent();
		}

		#region Base class overrides

		protected override void ClearWindow()
		{
			lvwIssues.Items.Clear();
        }

		protected override void DisplayScript(TSqlFragment rootFragment)
		{
			CheckTemporaryTableCharacterColumnCollations(rootFragment);
		}

		protected override void DisplayParseErrors(IList<ParseError> parseErrors)
		{
			base.DisplayParseErrors(parseErrors);
		}

		protected override void DisplayException(Exception ex)
		{
			base.DisplayException(ex);
		}

		#endregion

		#region Private implementation

		private void AddIssue(string issueType, int line, string sqlText, bool isSerious)
		{
			ListViewItem lvi = lvwIssues.Items.Add(issueType);

			if (isSerious)
				lvi.ForeColor = Color.Red;
			else
				lvi.ForeColor = Color.Blue;

			lvi.SubItems.Add(line.ToString());
			lvi.SubItems.Add(sqlText);
		}

		private void CheckTemporaryTableCharacterColumnCollations(TSqlFragment rootFragment)
		{
			List<TSqlFragment> createTableFragements = ScriptParser.GetFragmentChildren(rootFragment, new oVisitorCreateTableStatement());
			List<TSqlFragment> columnDefinitionFragments;
			string columnDefinitionSQL;
			List<TSqlFragment> sqlDataTypeDefinitionFragments;
			string sqlDataTypeDefinitionSQL;

			foreach (TSqlFragment createTableFragment in createTableFragements)
			{
				columnDefinitionFragments = ScriptParser.GetFragmentChildren(createTableFragment, new oVisitorColumnDefinition());

				foreach (TSqlFragment columnDefinitionFragment in columnDefinitionFragments)
				{
					columnDefinitionSQL = columnDefinitionSQL = ScriptParser.GetFragmentSQL(columnDefinitionFragment);
					sqlDataTypeDefinitionFragments = ScriptParser.GetFragmentChildren(columnDefinitionFragment, new oVisitorSQLDataTypeReference());

					foreach (TSqlFragment sqlDataTypeDefinitionFragment in sqlDataTypeDefinitionFragments)
					{
						sqlDataTypeDefinitionSQL = ScriptParser.GetFragmentSQL(sqlDataTypeDefinitionFragment);

						if ((sqlDataTypeDefinitionSQL.ToLower().Contains("char")) && (!columnDefinitionSQL.Contains("database_default")))
							AddIssue("Temporary table missing collation for character column", columnDefinitionFragment.StartLine, columnDefinitionSQL, true);
					}
				}
			}
		}

		private void CheckTableVariableCharacterColumnCollations(TSqlFragment rootFragment)
		{
			List<TSqlFragment> createTableFragements = ScriptParser.GetFragmentChildren(rootFragment, new oVisitorCreateTableStatement());
			List<TSqlFragment> columnDefinitionFragments;
			string columnDefinitionSQL;
			List<TSqlFragment> sqlDataTypeDefinitionFragments;
			string sqlDataTypeDefinitionSQL;

			foreach (TSqlFragment createTableFragment in createTableFragements)
			{
				columnDefinitionFragments = ScriptParser.GetFragmentChildren(createTableFragment, new oVisitorColumnDefinition());

				foreach (TSqlFragment columnDefinitionFragment in columnDefinitionFragments)
				{
					columnDefinitionSQL = columnDefinitionSQL = ScriptParser.GetFragmentSQL(columnDefinitionFragment);
					sqlDataTypeDefinitionFragments = ScriptParser.GetFragmentChildren(columnDefinitionFragment, new oVisitorSQLDataTypeReference());

					foreach (TSqlFragment sqlDataTypeDefinitionFragment in sqlDataTypeDefinitionFragments)
					{
						sqlDataTypeDefinitionSQL = ScriptParser.GetFragmentSQL(sqlDataTypeDefinitionFragment);

						if ((sqlDataTypeDefinitionSQL.ToLower().Contains("char")) && (!columnDefinitionSQL.Contains("database_default")))
							AddIssue("Temporary table missing collation for character column", columnDefinitionFragment.StartLine, columnDefinitionSQL, true);
					}
				}
			}
		}

		#endregion
	}
}
