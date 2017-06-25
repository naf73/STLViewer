using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STLViewer
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SettingsForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public SettingsForm(string title)
        {
            InitializeComponent();
            Text = title;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            txtPathRootDirDB.Text = Properties.Settings.Default.RootDirDB;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowBrowser_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.Cancel)
                return;

            txtPathRootDirDB.Text = folderBrowserDialog.SelectedPath;


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtPathRootDirDB.Text) || string.IsNullOrEmpty(txtPathRootDirDB.Text))
            {
                Properties.Settings.Default.RootDirDB = txtPathRootDirDB.Text;
                Properties.Settings.Default.Save();
                Close();
            }
            else 
            {
                MessageBox.Show("Не правильно указан путь", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
