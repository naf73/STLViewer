using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STLViewer
{
    public partial class FormMain : Form
    {
        #region События TeeDBView
        
        /// <summary>
        /// Событие добавления новго узла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddItem_ContextMenuTreeDBView_Click(object sender, EventArgs e)
        {
            AddNode();
        }

        /// <summary>
        /// Событие удаление выбранного узла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveItem_ContextMenuTreeDBView_Click(object sender, EventArgs e)
        {
            RemoveNode();
        }

        /// <summary>
        /// Событие перемещения узла на 1 уровень вверх
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpLevel_ContextMenuTreeDBView_Click(object sender, EventArgs e)
        {
            UpLevelNode();            
        }

        /// <summary>
        /// Событие перемещение узла на 1 уровень вниз
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownLevel_ContextMenuTreeDBView_Click(object sender, EventArgs e)
        {
            DownLevelNode();
        }

        /// <summary>
        /// Событие переименования узла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rename_ContextMenuTreeDBView_Click(object sender, EventArgs e)
        {
            RenameNode();
        }

        /// <summary>
        /// Событие после завершения переименования узла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeBDView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            TreeDBView.LabelEdit = false;
        }

        /// <summary>
        /// Горячие клавиши дерева БД
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeBDView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                RenameNode();
            }
        }

        #endregion

        /// <summary>
        /// Метод переименовывает элемент дерева
        /// </summary>
        private void RenameNode()
        {
            if (TreeDBView.SelectedNode == null)
                return;

            TreeDBView.LabelEdit = true;
            TreeDBView.SelectedNode.BeginEdit();
        }

        /// <summary>
        /// Метод перемещает выделенный узел на 1 уровень вверх
        /// </summary>
        private void UpLevelNode()
        {
            if (TreeDBView.SelectedNode != null
                && TreeDBView.SelectedNode.Parent != null)
            {

                // define edit collection
                TreeNodeCollection editNodes;
                if (TreeDBView.SelectedNode.Parent.Parent != null)
                    editNodes = TreeDBView.SelectedNode.Parent.Parent.Nodes;
                else
                    editNodes = TreeDBView.Nodes;

                // store node
                TreeNode selectedNode = TreeDBView.SelectedNode;

                // define indexes
                int indexSelectedNode = TreeDBView.SelectedNode.Index;
                int indexParentNode = TreeDBView.SelectedNode.Parent.Index;

                // move node
                TreeDBView.SelectedNode.Parent.Nodes.Remove(selectedNode);
                editNodes.Insert(indexParentNode + 1, selectedNode);

                // select node
                TreeDBView.SelectedNode = selectedNode;
            }
        }

        /// <summary>
        /// Метод перемещает выделенный узел на 1 уровень вниз
        /// </summary>
        private void DownLevelNode()
        {
            if (TreeDBView.SelectedNode != null
                && TreeDBView.SelectedNode.PrevNode != null)
            {

                // define edit collection
                TreeNodeCollection editNodes;
                if (TreeDBView.SelectedNode.Parent != null)
                    editNodes = TreeDBView.SelectedNode.Parent.Nodes;
                else
                    editNodes = TreeDBView.Nodes;

                // store node
                TreeNode selectedNode = TreeDBView.SelectedNode;
                TreeNode previousNode = selectedNode.PrevNode;

                // move node
                editNodes.Remove(selectedNode);
                previousNode.Nodes.Add(selectedNode);

                // select node
                TreeDBView.SelectedNode = selectedNode;
            }
        }

        /// <summary>
        /// Метод удаляет выделенный узел
        /// </summary>
        private void RemoveNode()
        {
            if (TreeDBView.SelectedNode == null)
                return;
            if (MessageBox.Show("Удалить элемент?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                TreeDBView.SelectedNode.Remove();
        }

        /// <summary>
        /// Метод добавляет узел в дерево
        /// </summary>
        private void AddNode()
        {
            TreeNode node = new TreeNode("Введите текст");

            if (TreeDBView.SelectedNode != null)
            {

                TreeDBView.SelectedNode.Nodes.Add(node);
                TreeDBView.SelectedNode.Expand();
            } else 
            {
                TreeDBView.Nodes.Add(node);
            }

            TreeDBView.LabelEdit = true;
            node.BeginEdit();
        }

    }
}
