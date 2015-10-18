using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.IO;

namespace OxfordCC.ContrOCC.SQLUtilities.Presentation
{
	public partial class wScriptParserViewer : Form
	{
		oScriptParser _scriptParser = new oScriptParser();

		public wScriptParserViewer()
		{
			InitializeComponent();
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();

			ofd.Filter = "(SQL Script) | *.sql";

			if (ofd.ShowDialog() == DialogResult.OK)
			{
				Cursor saveCursor = this.Cursor;

				try
				{
					this.Cursor = Cursors.WaitCursor;
					InitialiseDisplay(ofd.FileName);
				}
				catch
				{ }
				finally
				{
					this.Cursor = saveCursor;
				}
			}
		}

		#region Treeview methods

		private void InitialiseDisplay(string scriptFilePath)
		{
			IList<ParseError> parseErrors;
			TSqlFragment rootFragment;

			tvwFragmentTree.Nodes.Clear();
			txtFragmentSQL.Text = string.Empty;

			using (TextReader textReader = new StreamReader(scriptFilePath))
			{
				rootFragment = _scriptParser.GetRootFragment(textReader, out parseErrors);
			}

			if ((parseErrors == null) || (parseErrors.Count == 0))
			{
				TreeNode rootTreeNode = CreateNewTreeNodeForFragment(rootFragment);

				tvwFragmentTree.Nodes.Add(rootTreeNode);
				AddTreeNodeChildren(rootTreeNode);
				ExpandTreeNode(rootTreeNode);
			}
			else
			{
				StringBuilder sb = new StringBuilder();

				foreach (ParseError pe in parseErrors)
				{
					sb.AppendLine(pe.Message);
					sb.AppendLine();
				}

				txtFragmentSQL.Text = sb.ToString();
			}
		}

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
				List<TSqlFragment> children = _scriptParser.GetFragmentChildren(parentFragment);

				foreach (TSqlFragment f in children)
				{
					treeNode.Nodes.Add(CreateNewTreeNodeForFragment(f));
				}
			}
		}

		private TreeNode CreateNewTreeNodeForFragment(TSqlFragment fragment)
		{
			TreeNode tn = new TreeNode();

			tn.Text = _scriptParser.GetFragmentTypeName(fragment);
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
			txtFragmentSQL.Text = _scriptParser.GetFragmentSQL(fragment);
		}

		#endregion
	}
}
