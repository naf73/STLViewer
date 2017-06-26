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
    /// Форма настроек приложения
    /// </summary>
    public partial class SettingsForm : Form
    {
        /// <summary>
        /// Конструктор формы
        /// </summary>
        public SettingsForm(string title)
        {
            InitializeComponent();
            Text = title;
            switch (Properties.Settings.Default.Language)
            {
                case "English":
                    TranslateToEn();
                    break;
                case "Russian":
                    TranslateToRu();
                    break;
            }
        }

        /// <summary>
        /// Событие загрузки формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            txtPathRootDirDB.Text = Properties.Settings.Default.RootDirDB;
        }

        /// <summary>
        /// Выводим диалоговое окно "Выбор папки"
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
        /// Сохраняем новый путь к папке ModelBase
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Path.Combine(txtPathRootDirDB.Text, "ModelBase")))
            {
                Properties.Settings.Default.RootDirDB = Path.Combine(txtPathRootDirDB.Text, "ModelBase");
                Properties.Settings.Default.Save();
                Close();
            }
            else if(string.IsNullOrEmpty(txtPathRootDirDB.Text))
            {
                Properties.Settings.Default.RootDirDB = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ModelBase");
                Properties.Settings.Default.Save();
                if (!Directory.Exists(Properties.Settings.Default.RootDirDB))
                {
                    Directory.CreateDirectory(Properties.Settings.Default.RootDirDB);
                }
                Close();
            }
            else 
            {
                MessageBox.Show("Не правильно указан путь", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =======================================================================================
        #region Реализация вспомогательных методов
        // =======================================================================================

        /// <summary>
        /// Перевод интерфейса на английский язык
        /// </summary>
        private void TranslateToEn()
        {
            label1.Text = "Folder containing the database of models";
            btnShowBrowser.Text = "Browser ...";
            btnSave.Text = "Save";
        }

        /// <summary>
        /// Перевод интерфейса на русский язык
        /// </summary>
        private void TranslateToRu()
        {
            label1.Text = "Папка содержащая базу моделей";
            btnShowBrowser.Text = "Обзор ...";
            btnSave.Text = "Сохранить";
        }

        #endregion
    }
}
