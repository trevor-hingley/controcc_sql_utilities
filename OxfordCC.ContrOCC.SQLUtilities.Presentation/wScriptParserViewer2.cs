using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.IO;
using OxfordCC.ContrOCC.SQLUtilities.Business;

namespace OxfordCC.ContrOCC.SQLUtilities.Presentation
{
	public partial class wScriptParserViewer2 : OxfordCC.ContrOCC.SQLUtilities.Presentation.wScriptBase
	{
		public wScriptParserViewer2()
		{
			InitializeComponent();
		}

		#region Base class overrides

		protected override void ClearWindow()
		{
			tvwFragmentTree.Nodes.Clear();
			txtFragmentSQL.Text = string.Empty;
		}

		protected override void DisplayScript(TSqlFragment rootFragment)
		{
			TreeNode rootTreeNode = CreateNewTreeNodeForFragment(rootFragment);

			tvwFragmentTree.Nodes.Add(rootTreeNode);
			AddTreeNodeChildren(rootTreeNode);
			ExpandTreeNode(rootTreeNode);
		}

		protected override void DisplayParseErrors(IList<ParseError> parseErrors)
		{
			StringBuilder sb = new StringBuilder();

			foreach (ParseError pe in parseErrors)
			{
				sb.AppendLine(pe.Message);
				sb.AppendLine();
			}

			txtFragmentSQL.Text = sb.ToString();
		}

		protected override void DisplayException(Exception ex)
		{
			txtFragmentSQL.Text = ex.Message;
		}

		#endregion

		#region Treeview methods

		private void ExpandTreeNode(TreeNode treeNode)
		{
			TreeNode child = treeNode.FirstNode;

			while (child != null)
			{
				AddTreeNodeChildren(child);
				child = child.NextNode;
			}
		}

		private void AddTreeNodeChildren(TreeNode treeNode)
		{
			if (treeNode.GetNodeCount(false) == 0)
			{
				TSqlFragment parentFragment = (TSqlFragment)treeNode.Tag;
				List<TSqlFragment> children = ScriptParser.GetFragmentChildren(parentFragment);

				foreach (TSqlFragment f in children)
				{
					treeNode.Nodes.Add(CreateNewTreeNodeForFragment(f));
				}
			}
		}

		private TreeNode CreateNewTreeNodeForFragment(TSqlFragment fragment)
		{
			TreeNode tn = new TreeNode();

			tn.Text = ScriptParser.GetFragmentTypeName(fragment);
			tn.Tag = fragment;

			return tn;
		}

		#endregion

		#region Treeview events

		private void tvwFragmentTree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			ExpandTreeNode(e.Node);
		}

		private void tvwFragmentTree_AfterSelect(object sender, TreeViewEventArgs e)
		{
			TSqlFragment fragment = (TSqlFragment)e.Node.Tag;
			txtFragmentSQL.Text = ScriptParser.GetFragmentSQL(fragment);
		}

		#endregion
	}
}
