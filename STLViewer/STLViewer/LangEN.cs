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
        /// <summary>
        /// 
        /// </summary>
        private void TranslateToEn()
        {
            Text = "STL Viewer";
            File_MenuItem.Text = "File";
            OpenModel_MenuItem.Text = "Open ...";
            ExportPicture_MenuItem.Text = "Export picture ...";
            Settings_MenuItem.Text = "Settings ...";
            Close_MenuItem.Text = "Close";
            View_MenuItem.Text = "View";
            ResetViiew_MenuItem.Text = "Reset view";
            OptimizateView_MenuItem.Text = "Centering View";
            ColorModel_MenuItem.Text = "Color model";
            ColorBackground_MenuItem.Text = "Color background";
            Database_MenuItem.Text = "ModelBase";
            AddGroup_ContextMenuTreeDBView.Text = "Add group";
            RemoveGroup_MenuItem.Text = "Remove group";
            AddModel_MenuItem.Text = "Add model";
            RemoveModel_MenuItem.Text = "Remove model";
            UpLevel_MenuItem.Text = "Up level item";
            DownLevel_MenuItem.Text = "Down level item";
            Rename_MenuItem.Text = "Rename";
            Help_MenuItem.Text = "Help";
            ShowHelp_MenuItem.Text = "Show";
            About_MenuItem.Text = "About";
            toolStripStatusLabel1.Text = "Language: ";
            toolStripStatusLabel2.Text = "Loaded model: ";
            ShowLegend_MenuItem.Text = "Show legend";
            HideLegend_MenuItem.Text = "Hide legend";
            AddGroup_MenuItem.Text = "Add Group";
            RemoveGroup_ContextMenuTreeDBView.Text = "Remove group";
            AddModel_ContextMenuTreeDBView.Text = "Add model";
            RemoveModel_ContextMenuTreeDBView.Text = "Remove model";
            UpLevel_ContextMenuTreeDBView.Text = "Up level item";
            DownLevel_ContextMenuTreeDBView.Text = "Down level item";
            Rename_ContextMenuTreeDBView.Text = "Rename";
            // ===
            TreeDBView.SelectedNode = FindNodeByName("База моделей");
            if (TreeDBView.SelectedNode != null)
            {
                TreeDBView.SelectedNode.Text = "ModelBase";
            }
        }
    }
}
