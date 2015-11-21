using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Microsoft.SqlServer.TransactSql.ScriptDom;
using OxfordCC.ContrOCC.SQLUtilities.Business;

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
			List<oIssue> issuesFound = new List<oIssue>();
			oSQLStandardsChecker sqlStandardsChecker = new oSQLStandardsChecker(ScriptParser, rootFragment);

			issuesFound.AddRange(sqlStandardsChecker.CheckProcedureName());
			issuesFound.AddRange(sqlStandardsChecker.CheckProcedureSchemaPrefixes());
			issuesFound.AddRange(sqlStandardsChecker.CheckTableVariableCharacterColumnCollations());
			issuesFound.AddRange(sqlStandardsChecker.CheckTemporaryTableCharacterColumnCollations());

			DisplayIssues(issuesFound);
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

		private void DisplayIssues(List<oIssue> issuesFound)
		{
			ListViewItem lvi;

			foreach (oIssue i in issuesFound)
			{
				lvi = lvwIssues.Items.Add(i.IssueType);

				if (i.IsSerious)
					lvi.ForeColor = Color.Red;
				else
					lvi.ForeColor = Color.Blue;

				lvi.SubItems.Add(i.LineNumber.ToString());
				lvi.SubItems.Add(i.SQLText);
			}
		}

		#endregion
	}
}
