using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OxfordCC.ContrOCC.SQLUtilities.Business
{
	public struct oIssue
	{
		private string _issueType;
		private int _lineNumber;
		private string _sqlText;
		private bool _isSerious;

		public string IssueType { get { return _issueType; } }
		public int LineNumber { get { return _lineNumber; } }
		public string SQLText { get { return _sqlText; } }
		public bool IsSerious { get { return _isSerious; } }

		public oIssue(string issueType, int lineNumber, string sqlText, bool isSerious)
		{
			_issueType = issueType;
			_lineNumber = lineNumber;
			_sqlText = sqlText;
			_isSerious = isSerious;
		}
	}
}
