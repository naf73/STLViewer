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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddItem_ContextMenuTreeDBView_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveItem_ContextMenuTreeDBView_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpLevel_ContextMenuTreeDBView_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownLevel_ContextMenuTreeDBView_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rename_ContextMenuTreeDBView_Click(object sender, EventArgs e)
        {
            RenameNode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeBDView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            TreeBDView.LabelEdit = false;
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
            if (TreeBDView.SelectedNode == null)
                return;

            TreeBDView.LabelEdit = true;
            TreeBDView.SelectedNode.BeginEdit();
        }

    }
}
