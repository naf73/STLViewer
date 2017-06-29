using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Resources;
using System.IO.Compression;

// для работы с библиотекой OpenGL 
using Tao.OpenGl;
// для работы с библиотекой FreeGLUT 
using Tao.FreeGlut;
// для работы с элементом управления SimpleOpenGLControl 
using Tao.Platform.Windows;

namespace STLViewer
{
    public partial class FormMain : Form
    {
        #region Глобальные переменные
        string pathDataModel; // Абсолютный путь к папке с базой моделей
        #endregion

        /// <summary>
        /// Констуктор формы
        /// </summary>
        public FormMain(string[] args)
        {
            InitializeComponent();
            // Инициализация переменных для 3D движка
            Init();
            // Инициализация виджета OpenGL
            SceneWidget.InitializeContexts();
            SceneWidget.MouseWheel += SceneWidget_MouseWheel;
            //SceneWidget.MouseUp += SceneWidget_MouseUp;
            SceneWidget.MouseMove += SceneWidget_MouseMove;
            // Инициализация сцены
            InitScene();
            ResizeScene();
            // === Инициализация цвета
            color_model = Color.Blue;
            color_background = Color.White;

            // === Загружаем настройки пользователя
            LoadUserSettings();

            // === Аргументы переданные приложению
            if (args.Length == 1)
            {
                try
                {
                    OpenModel(args[0]);
                    SceneWidget.Show();
                    if (model.Count > 0)
                    {
                        TreeDBView.Nodes.Add(args[0], Path.GetFileNameWithoutExtension(args[0]), 2);
                    }
                    contextMenuTreeView.Enabled = false;
                    Database_MenuItem.Enabled = false;
                }
                catch(Exception ex)
                {
                     MessageBox.Show(Language.Error("mistake_stl_format"), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                ScanRootDir(pathDataModel);
            }
            // === Назначаем локализацию
            switch (Properties.Settings.Default.Language)
            {
                case "Russian":
                    SelectLanguage.Text = SelectLanguage.DropDownItems[0].Text;
                    TranslateToRu();
                    break;
                case "English":
                    SelectLanguage.Text = SelectLanguage.DropDownItems[1].Text;
                    TranslateToEn();
                    break;
            }
            // ===

            DrawScene();
        }

        #region События элементов главного меню Main Menu

        #region Пункт меню "File"

        /// <summary>
        /// Окрыть модель
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenModel_MenuItem_Click(object sender, EventArgs e)
        {
            SceneWidget.Hide();
            openFileModelDialog.Filter = "STL files(*.stl)|*.stl";
            openFileModelDialog.FileName = "";
            if (openFileModelDialog.ShowDialog() == DialogResult.Cancel)
            {
                SceneWidget.Show();
                return;
            }
            // ===
            try
            {
                OpenModel(openFileModelDialog.FileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
            }
            SceneWidget.Show();
        }

        /// <summary>
        /// Экспорт в картинку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportPicture_MenuItem_Click(object sender, EventArgs e)
        {
            ExportPicture();
        }

        /// <summary>
        /// * Открыть окно настроек программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Settings_MenuItem_Click(object sender, EventArgs e)
        {
            GetBackground();
            SceneWidget.Hide();
            TreeDBView.Focus();
            TreeNode lastNode = null;
            if (TreeDBView.SelectedNode != null)
            {
                lastNode = TreeDBView.SelectedNode;
            }
            SettingsForm sf = new SettingsForm(Text);
            sf.ShowDialog();
            pathDataModel = Properties.Settings.Default.RootDirDB;
            ScanRootDir(pathDataModel);
            contextMenuTreeView.Enabled = true;
            Database_MenuItem.Enabled = true;
            TreeDBView.Focus();
            if (lastNode != null)
            {
                TreeDBView.SelectedNode = FindNodeByName(lastNode.Text);
            }
            SceneWidget.Show();
        }

        /// <summary>
        /// Закрыть приложение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Close_MenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Пункт меню "View"

        /// <summary>
        /// Сброс текущего вида сцены к первоначальному виду сцены
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetViiew_MenuItem_Click(object sender, EventArgs e)
        {
            ViewReset();
            ViewOptimizate();
        }

        /// <summary>
        /// Оптимизация текущего вида (возвращение модели на центр сцены)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OptimizateView_MenuItem_Click(object sender, EventArgs e)
        {
            ViewOptimizate();
        }

        /// <summary>
        /// Настройка цвета модели
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorModel_MenuItem_Click(object sender, EventArgs e)
        {
            SetColorModel();
        }

        /// <summary>
        /// Настройка цвета заднего фона
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorBackground_MenuItem_Click(object sender, EventArgs e)
        {
            SetColorBackground();
        }

        /// <summary>
        /// Скрывает легенду
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HideLegend_MenuItem_Click(object sender, EventArgs e)
        {
            panelLegend.Visible = false;
            HideLegend_MenuItem.Visible = false;
            ShowLegend_MenuItem.Visible = true;
            Properties.Settings.Default.ShowLegend = false;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Показать легенду
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowLegend_MenuItem_Click(object sender, EventArgs e)
        {
            panelLegend.Visible = true;
            HideLegend_MenuItem.Visible = true;
            ShowLegend_MenuItem.Visible = false;
            Properties.Settings.Default.ShowLegend = true;
            Properties.Settings.Default.Save();
        }

        #endregion

        #region Пункт меню "Database"

        /// <summary>
        /// Добавление нового узла в дерево тип группа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddGroup_MenuItem_Click(object sender, EventArgs e)
        {
            AddNodeGroup();
        }

        /// <summary>
        /// Удаление выбранного узла в дереве тип группа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveGroup_MenuItem_Click(object sender, EventArgs e)
        {
            RemoveNodeGroup();
        }

        /// <summary>
        /// Добавление нового узла в дерево тип модель
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddModel_MenuItem_Click(object sender, EventArgs e)
        {
            AddNodeModel();
        }

        /// <summary>
        /// Удаление выбранного узла в дереве тип модель
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveModel_MenuItem_Click(object sender, EventArgs e)
        {
            RemoveNodeModel();
        }

        /// <summary>
        /// Перемещение узла на 1 уровень вверх
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpLevel_MenuItem_Click(object sender, EventArgs e)
        {
            UpLevelNode();
        }

        /// <summary>
        /// Перемещение узла на 1 уровень ввниз
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownLevel_MenuItem_Click(object sender, EventArgs e)
        {
            DownLevelNode();
        }

        /// <summary>
        /// Событие переименовать выделенный элемент
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rename_MenuItem_Click(object sender, EventArgs e)
        {
            RenameNode();
        }

        /// <summary>
        /// Экспорт Базы Моделей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportModelBase_MenuItem_Click(object sender, EventArgs e)
        {
            ExportModelBase();
        }

        /// <summary>
        /// Импорт Базы Моделей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportModelBase_MenuItem_Click(object sender, EventArgs e)
        {
            ImportModelBase();
        }

        #endregion

        #region Пункт меню "Help"

        /// <summary>
        /// Показать справку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowHelp_MenuItem_Click(object sender, EventArgs e)
        {
            ShowHelp();
        }

        /// <summary>
        /// Показать окно о программе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void About_MenuItem_Click(object sender, EventArgs e)
        {
            AboutSTLViewer about = new AboutSTLViewer();
            about.ShowDialog();
        }

        #endregion

        #endregion

        #region Меню смены локализации

        /// <summary>
        /// Выбран язык English
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void English_SelectItem_Click(object sender, EventArgs e)
        {
            SelectLanguage.Text = SelectLanguage.DropDownItems[1].Text;
            Properties.Settings.Default.Language = "English";
            Properties.Settings.Default.Save();
            TranslateToEn();
        }

        /// <summary>
        /// Выбран язык Русский
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rus_SelectItem_Click(object sender, EventArgs e)
        {
            SelectLanguage.Text = SelectLanguage.DropDownItems[0].Text;
            Properties.Settings.Default.Language = "Russian";
            Properties.Settings.Default.Save();
            TranslateToRu();
        }

        #endregion

        #region Методы реализации

        /// <summary>
        /// Метод вызывает файл справки
        /// </summary>
        private void ShowHelp()
        {
            //Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Help");
            string helpPath = null;
            switch (Properties.Settings.Default.Language)
            {
                case "Russian":
                    helpPath = Path.Combine(Application.StartupPath, "Help", "helperStl.chm");
                    break;
                case "English":
                    helpPath = Path.Combine(Application.StartupPath, "Help", "helperStl_en.chm");
                    break;
            }


            if (File.Exists(helpPath))
            {
                Process.Start(helpPath);
            }
            else 
            {
                SceneWidget.Hide();
                MessageBox.Show(Language.Error("file_donot_find"), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                SceneWidget.Show();
            }
        }

        /// <summary>
        /// Загрузка настроек пользователя
        /// </summary>
        private void LoadUserSettings()
        {
            color_model = Properties.Settings.Default.ColorModel; // цвет модели
            color_background = Properties.Settings.Default.ColorBackground; // цвет заднего фона 3D виджета
            splitContainer1.Panel2.BackColor = color_background; // цвет заднего фона панели для 3D виджета
            // === Настройка пункта меню Показать/Скрыть легенду
            if (Properties.Settings.Default.ShowLegend)
            {
                ShowLegend_MenuItem.Visible = false;
                HideLegend_MenuItem.Visible = true;
                panelLegend.Visible = true;
            }
            else
            {
                ShowLegend_MenuItem.Visible = true;
                HideLegend_MenuItem.Visible = false;
                panelLegend.Visible = false;
            }
            // === Получаем путь к папке "Мои документы"
            if (string.IsNullOrEmpty(Properties.Settings.Default.RootDirDB))
            {
                pathDataModel = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ModelBase");
                Properties.Settings.Default.RootDirDB = pathDataModel;
                Properties.Settings.Default.Save();
            }
            else
            {
                pathDataModel = Properties.Settings.Default.RootDirDB;
            }
        }
        #endregion

        #region TreeDB

        #region События TeeDBView

        /// <summary>
        /// Событие после выбора узла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeDBView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ShowNameModelStatusLine();
            // ================================================================================
            #region Настройка отображения пунктов главного и контектсного меню
            // ================================================================================

            if (File.Exists(TreeDBView.SelectedNode.Name))
            {
                // === Контекстное меню
                AddGroup_ContextMenuTreeDBView.Enabled = false;
                RemoveGroup_ContextMenuTreeDBView.Enabled = false;
                RemoveModel_ContextMenuTreeDBView.Enabled = true;
                // === Главное меню
                AddGroup_MenuItem.Enabled = AddGroup_ContextMenuTreeDBView.Enabled;
                RemoveGroup_MenuItem.Enabled = RemoveGroup_ContextMenuTreeDBView.Enabled;
                RemoveModel_MenuItem.Enabled = RemoveModel_ContextMenuTreeDBView.Enabled;
            }
            else
            {
                // === Контекстное меню
                AddGroup_ContextMenuTreeDBView.Enabled = true;
                RemoveGroup_ContextMenuTreeDBView.Enabled = true;
                RemoveModel_ContextMenuTreeDBView.Enabled = false;
                // === Главное меню
                AddGroup_MenuItem.Enabled = AddGroup_ContextMenuTreeDBView.Enabled;
                RemoveGroup_MenuItem.Enabled = RemoveGroup_ContextMenuTreeDBView.Enabled;
                RemoveModel_MenuItem.Enabled = RemoveModel_ContextMenuTreeDBView.Enabled;
            }

            // --- Запрещаем удалять и переименовывать корневой узел
            if (TreeDBView.SelectedNode.Name == pathDataModel)
            {
                RemoveGroup_ContextMenuTreeDBView.Enabled = false;
                Rename_ContextMenuTreeDBView.Enabled = false;
                ExportModelBase_ContextMenuTreeDBView.Enabled = true;
                ImportModelBase_ContextMenuTreeDBView.Enabled = true;
                RemoveGroup_MenuItem.Enabled = RemoveGroup_ContextMenuTreeDBView.Enabled;
                Rename_MenuItem.Enabled = Rename_ContextMenuTreeDBView.Enabled;
                ExportModelBase_MenuItem.Enabled = ExportModelBase_ContextMenuTreeDBView.Enabled;
                ImportModelBase_MenuItem.Enabled = ImportModelBase_ContextMenuTreeDBView.Enabled;
            }
            else
            {
                Rename_ContextMenuTreeDBView.Enabled = true;
                ExportModelBase_ContextMenuTreeDBView.Enabled = false;
                ImportModelBase_ContextMenuTreeDBView.Enabled = false;
                Rename_MenuItem.Enabled = Rename_ContextMenuTreeDBView.Enabled;
                ExportModelBase_MenuItem.Enabled = ExportModelBase_ContextMenuTreeDBView.Enabled;
                ImportModelBase_MenuItem.Enabled = ImportModelBase_ContextMenuTreeDBView.Enabled;
            }

            #endregion

            // ================================================================================
            #region Добавление и переименование узла
            // ================================================================================

            // можно использовать под загрузку картинки
            if (TreeDBView.SelectedNode == null)
                return;

            if (TreeDBView.SelectedNode.ImageIndex == 2)
            {
                SceneWidget.Show();
                Init();
                model = STLFormat.LoadBinary(TreeDBView.SelectedNode.Name);
                ShowNameModelStatusLine();
                offset_model = ModelCenter(model); // получаем центр модели
                DrawScene();
            }
            else
            {
                Init();
                model.Clear();
                SceneWidget.Hide();
            }
            GetBackground();
            // -- To Do 
            // Добавить реакцию на переименование модели

            #endregion
        }

        /// <summary>
        /// Событие после завершения переименования узла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeBDView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            TreeDBView.LabelEdit = false;
            string name;
            // ===
            if (string.IsNullOrEmpty(e.Label))
            {
                name = e.Node.Text;
            }
            else
            {
                name = e.Label;
            }
            // ==== группа
            if (TreeDBView.SelectedNode.ImageIndex == 3)
            {
                TreeDBView.SelectedNode.ImageIndex = 1;
            }
            if (TreeDBView.SelectedNode.ImageIndex == 1)
            {
                if (Directory.Exists(e.Node.Name))
                {
                    string last_name = e.Node.Name;
                    e.Node.Name = Path.Combine(e.Node.Parent.Name, name);
                    TreeDBView.SelectedNode = e.Node;
                    Directory.Move(last_name, e.Node.Name);

                    // === Меняем все дочерним элементам поле Name

                    foreach (TreeNode node in TreeDBView.SelectedNode.Nodes)
                    {
                        if (node.ImageIndex == 1)
                        {
                            node.Name = Path.Combine(node.Parent.Name, node.Text);
                        }
                        else
                        {
                            node.Name = Path.Combine(node.Parent.Name, node.Text + ".stl");
                        }
                    }
                    // ===
                }
                else
                {
                    e.Node.Name = Path.Combine(e.Node.Parent.Name, name);
                    TreeDBView.SelectedNode = e.Node;
                    if (!Directory.Exists(e.Node.Name))
                    {
                        Directory.CreateDirectory(e.Node.Name);
                    }
                    else
                    {
                        MessageBox.Show(Language.Error("this_group_exists"), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Node.Remove();
                    }
                }
            }
            // ==== модель
            if (TreeDBView.SelectedNode.ImageIndex == 2)
            {
                string last_name = e.Node.Name;
                e.Node.Name = Path.Combine(e.Node.Parent.Name, name + ".stl");
                TreeDBView.SelectedNode = FindNodeByName(e.Node.Parent, e.Node.Name);
                if (!File.Exists(e.Node.Name))
                {
                    File.Copy(last_name, e.Node.Name);
                    File.Delete(last_name);
                }
                ScanRootDir(pathDataModel);
                
            }

        }

        /// <summary>
        /// Событие добавления нового узла тип группа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddGroup_ContextMenuTreeDBView_Click(object sender, EventArgs e)
        {
            AddNodeGroup();
        }

        /// <summary>
        /// Событие удаление выбранного узла тип группа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveGroup_ContextMenuTreeDBView_Click(object sender, EventArgs e)
        {
            RemoveNodeGroup();
        }

        /// <summary>
        /// Событие добавления нового узла тип модель
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddModel_ContextMenuTreeDBView_Click(object sender, EventArgs e)
        {
            AddNodeModel();
        }

        /// <summary>
        /// Событие удаление выбранного узла тип модель
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveModel_ContextMenuTreeDBView_Click(object sender, EventArgs e)
        {
            RemoveNodeModel();
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
        /// Горячие клавиши дерева БД
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeBDView_KeyUp(object sender, KeyEventArgs e)
        {
            // ---
            if (e.KeyCode == Keys.F1)
            {
                ShowHelp();
            }
        }

        /// <summary>
        /// Событие на дереве до редактирования лейбела
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeDBView_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            TreeDBView.SelectedNode = TreeDBView.SelectedNode;
        }

        /// <summary>
        /// Экспорт Базы Моделей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportModelBase_ContextMenuTreeDBView_Click(object sender, EventArgs e)
        {
            ExportModelBase();
        }

        /// <summary>
        /// Импорт Базы Моделей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportModelBase_ContextMenuTreeDBView_Click(object sender, EventArgs e)
        {
            ImportModelBase();
        }

        #endregion

        /// <summary>
        /// Метод переименовывает элемент дерева
        /// </summary>
        private void RenameNode()
        {
            if (TreeDBView.SelectedNode == null)
                return;

            // --- Запрещаем удалять и переименовывать корневой узел
            if (TreeDBView.SelectedNode.Name == pathDataModel || TreeDBView.SelectedNode.Name == pathDataModel && File.Exists(TreeDBView.SelectedNode.Name))
            {
                Rename_ContextMenuTreeDBView.Enabled = false;
                Rename_MenuItem.Enabled = Rename_ContextMenuTreeDBView.Enabled;
            }
            else
            {
                Rename_ContextMenuTreeDBView.Enabled = true;
                Rename_MenuItem.Enabled = Rename_ContextMenuTreeDBView.Enabled;
                TreeDBView.LabelEdit = true;
                TreeDBView.SelectedNode.BeginEdit();
            }
        }

        /// <summary>
        /// Метод перемещает выделенный узел на 1 уровень вверх
        /// </summary>
        private void UpLevelNode()
        {
            if (TreeDBView.SelectedNode != null
                && TreeDBView.SelectedNode.Parent != null
                && TreeDBView.SelectedNode.Parent.Name != pathDataModel)
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

                // ==== 
                if (TreeDBView.SelectedNode.Parent.ImageIndex == 1 && TreeDBView.SelectedNode.Parent.Nodes.Count == 1)
                {
                    TreeDBView.SelectedNode.Parent.ImageIndex = 3;
                }
                // move node
                TreeDBView.SelectedNode.Parent.Nodes.Remove(selectedNode);
                editNodes.Insert(indexParentNode + 1, selectedNode);

                // select node
                TreeDBView.SelectedNode = selectedNode;

                // ==== Move item in OS
                MoveItem();
            }
        }

        /// <summary>
        /// Метод перемещает выделенный узел на 1 уровень вниз
        /// </summary>
        private void DownLevelNode()
        {
            if (TreeDBView.SelectedNode != null && TreeDBView.SelectedNode.PrevNode != null)
            {
                if (TreeDBView.SelectedNode.PrevNode != null && TreeDBView.SelectedNode.PrevNode.ImageIndex == 2)
                    return;
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

                // ==== 
                if (TreeDBView.SelectedNode.Parent.ImageIndex == 3 && TreeDBView.SelectedNode.Parent.Nodes.Count > 0)
                {
                    TreeDBView.SelectedNode.Parent.ImageIndex = 1;
                }

                // ==== Move item in OS
                MoveItem();
            }
        }

        #region Методы для объекта группа моделей

        /// <summary>
        /// Метод добавляет в дерево узел тип группа
        /// </summary>
        private void AddNodeGroup()
        {
            // --- Дерево
            TreeNode node = new TreeNode("Введите текст");
            node.ImageIndex = 3;
            if (TreeDBView.SelectedNode != null)
            {
                TreeDBView.SelectedNode.Nodes.Add(node);
                TreeDBView.SelectedNode.Expand();
            }
            else
            {
                if (TreeDBView.Nodes.Count > 0)
                {
                    TreeDBView.Nodes.Add(node);
                }
            }
            TreeDBView.LabelEdit = true;
            node.BeginEdit();
        }

        /// <summary>
        /// Метод удаляет выделенный узел тип группа
        /// </summary>
        private void RemoveNodeGroup()
        {
            Init();
            model.Clear();
            DrawScene();
            SceneWidget.Hide();
            try
            {
                // --- Дерево
                if (TreeDBView.SelectedNode == null)
                    return;
                if (TreeDBView.SelectedNode.ImageIndex == 1)
                {
                    if (MessageBox.Show(Language.Error("delete_group_with_files"), Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;
                }
                else
                {
                    if (MessageBox.Show(Language.Error("delete_group"), Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;
                }
                Directory.Delete(TreeDBView.SelectedNode.Name, true);
                TreeDBView.SelectedNode.Remove();
                if (TreeDBView.SelectedNode.Nodes.Count == 0)
                {
                    TreeDBView.SelectedNode.ImageIndex = 3;
                }
            }
            catch (Exception ex)
            {
                TreeDBView.SelectedNode = FindNodeByName(TreeDBView.SelectedNode.Name);
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SceneWidget.Show();
            }
        }
        #endregion

        /// <summary>
        /// Метод добавляет в дерево модель
        /// </summary>
        private void AddNodeModel()
        {
            // --- Поулчаем имя файла и путь к нему
            //openFileModelDialog.Filter = "STL files(*.stl)|*.stl|All files(*.*)|*.*";
            openFileModelDialog.Filter = "STL files(*.stl)|*.stl";
            openFileModelDialog.FileName = "";
            if (openFileModelDialog.ShowDialog() == DialogResult.Cancel)
                return;
            SceneWidget.Hide();
            string pathToModel = null;
            try
            {

                // --- Дерево
                if (TreeDBView.SelectedNode != null)
                {
                    if (File.Exists(TreeDBView.SelectedNode.Name))
                    {
                        if (STLFormat.ValidateSTL(openFileModelDialog.FileName))
                        {
                            pathToModel = Path.Combine(TreeDBView.SelectedNode.Parent.Name, Path.GetFileName(openFileModelDialog.FileName));
                            File.Copy(openFileModelDialog.FileName, pathToModel);
                            TreeDBView.SelectedNode.Parent.Nodes.Add(pathToModel, Path.GetFileNameWithoutExtension(pathToModel), 2);
                            TreeDBView.SelectedNode = FindNodeByName(TreeDBView.SelectedNode.Parent, Path.GetFileNameWithoutExtension(pathToModel));
                        }
                        else
                        {
                            MessageBox.Show(Language.Error("mistake_stl_format"), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (STLFormat.ValidateSTL(openFileModelDialog.FileName))
                        {
                            pathToModel = Path.Combine(TreeDBView.SelectedNode.Name, Path.GetFileName(openFileModelDialog.FileName));
                            File.Copy(openFileModelDialog.FileName, pathToModel);
                            TreeDBView.SelectedNode.Nodes.Add(pathToModel, Path.GetFileNameWithoutExtension(pathToModel), 2);
                            TreeDBView.SelectedNode = FindNodeByName(TreeDBView.SelectedNode, Path.GetFileNameWithoutExtension(pathToModel));
                        }
                        else
                        {
                            MessageBox.Show(Language.Error("mistake_stl_format"), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    if (STLFormat.ValidateSTL(openFileModelDialog.FileName))
                    {
                        pathToModel = Path.Combine(pathDataModel, Path.GetFileName(openFileModelDialog.FileName));
                        File.Copy(openFileModelDialog.FileName, pathToModel);
                        TreeDBView.Nodes.Add(pathToModel, Path.GetFileNameWithoutExtension(pathToModel), 2);
                        TreeDBView.SelectedNode = FindNodeByName(TreeDBView.SelectedNode, Path.GetFileNameWithoutExtension(pathToModel));
                    }
                    else
                    {
                        MessageBox.Show(Language.Error("mistake_stl_format"), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (TreeDBView.SelectedNode != null && TreeDBView.SelectedNode.Parent != null)
                {
                    if (TreeDBView.SelectedNode.Parent.ImageIndex == 3)
                    {
                        TreeDBView.SelectedNode.Parent.ImageIndex = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SceneWidget.Show();
        }

        /// <summary>
        /// Метод удаляет выделенный узел тип модель
        /// </summary>
        private void RemoveNodeModel()
        {
            SceneWidget.Hide();
            // --- Дерево
            if (TreeDBView.SelectedNode == null)
                return;
            try
            {
                // Удаляем только узлы только типа модель
                if (TreeDBView.SelectedNode.ImageIndex == 2)
                {
                    if (MessageBox.Show(Language.Error("delete_model"), Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        File.Delete(TreeDBView.SelectedNode.Name);
                        TreeDBView.SelectedNode.Remove();
                    }
                }
                if (TreeDBView.SelectedNode.ImageIndex == 1 && TreeDBView.SelectedNode.Nodes.Count == 0)
                {
                    TreeDBView.SelectedNode.ImageIndex = 3;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SceneWidget.Show();
            }
        }

        #region Реализация вспомогательных методов

        /// <summary>
        /// Метод возвращает по родительскому узлу и по имени объект узел
        /// </summary>
        /// <param name="root"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private TreeNode FindNodeByName(TreeNode root, string name)
        {
            if (root == null) return null;
            if (root.Text == name) return root;
            return FindNodeByName(root.FirstNode, name) ?? FindNodeByName(root.NextNode, name);
        }

        /// <summary>
        /// Метод возвращает по имени объект узел
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private TreeNode FindNodeByName(string name)
        {
            return FindNodeByName(TreeDBView.TopNode, name);
        }

        /// <summary>
        /// Пермещение объектов вверх/вниз
        /// </summary>
        private void MoveItem()
        {
            try
            {
                string last_name;
                // === Move group
                if (TreeDBView.SelectedNode.ImageIndex == 1)
                {
                    last_name = TreeDBView.SelectedNode.Name;
                    TreeDBView.SelectedNode.Name = Path.Combine(TreeDBView.SelectedNode.Parent.Name, TreeDBView.SelectedNode.Text);
                    Directory.Move(last_name, TreeDBView.SelectedNode.Name);
                }

                // === Move model
                if (TreeDBView.SelectedNode.ImageIndex == 2)
                {
                    last_name = TreeDBView.SelectedNode.Name;
                    TreeDBView.SelectedNode.Name = Path.Combine(TreeDBView.SelectedNode.Parent.Name, TreeDBView.SelectedNode.Text + ".stl");
                    File.Move(last_name, TreeDBView.SelectedNode.Name);
                }
            }
            catch (Exception ex)
            {
                ScanRootDir(pathDataModel);
                SceneWidget.Hide();
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                SceneWidget.Show();
            }

        }

        /// <summary>
        /// Выводим в статус линию имя загруженного файла
        /// </summary>
        private void ShowNameModelStatusLine()
        {
            NameLoadModel.Text = string.Empty;
            if (TreeDBView.SelectedNode != null && TreeDBView.SelectedNode.ImageIndex == 2)
            {
                NameLoadModel.Text = Path.GetFileName(TreeDBView.SelectedNode.Name); // получаем имя модели
            }
        }

        #endregion

        #region Экспорт/Импорт Базы Моделей

        /// <summary>
        /// Экспорт Базы Моделей
        /// </summary>
        private void ExportModelBase()
        {
            // ===
            SceneWidget.Hide();
            saveFileModelDialog.Filter = "ZIP files(*.zip)|*.zip|All files(*.*)|*.*";
            saveFileModelDialog.FileName = "";
            if (saveFileModelDialog.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            try
            {
                ZipFile.CreateFromDirectory(pathDataModel, saveFileModelDialog.FileName, CompressionLevel.Fastest, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SceneWidget.Show();
            }
        }

        /// <summary>
        /// Импорт Базы Моделей
        /// </summary>
        private void ImportModelBase()
        {
            // ===
            SceneWidget.Hide();
            openFileModelDialog.Filter = "ZIP files(*.zip)|*.zip|All files(*.*)|*.*";
            openFileModelDialog.FileName = "";
            if (openFileModelDialog.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            try
            {
                if (Directory.Exists(pathDataModel))
                {
                    Directory.Delete(pathDataModel, true);
                }
                ZipFile.ExtractToDirectory(openFileModelDialog.FileName, Path.GetDirectoryName(pathDataModel));
                ScanRootDir(pathDataModel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SceneWidget.Show();
            }
        }

        #endregion

        #region Перетаскивание объектов мышью в дереве Базы моделей

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeDBView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            // Move the dragged node when the left mouse button is used.
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }

            // Copy the dragged node when the right mouse button is used.
            else if (e.Button == MouseButtons.Right)
            {
                DoDragDrop(e.Item, DragDropEffects.Copy);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeDBView_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void TreeDBView_DragDrop(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the drop location.
            Point targetPoint = TreeDBView.PointToClient(new Point(e.X, e.Y));

            // Retrieve the node at the drop location.
            TreeNode targetNode = TreeDBView.GetNodeAt(targetPoint);

            // Retrieve the node that was dragged.
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            // Запрещаем перетаскивать в узел модель
            if (targetNode.ImageIndex == 2) return;

            // Confirm that the node at the drop location is not 
            // the dragged node or a descendant of the dragged node.
            if (!draggedNode.Equals(targetNode) && !ContainsNode(draggedNode, targetNode))
            {
                // If it is a move operation, remove the node from its current 
                // location and add it to the node at the drop location.
                if (e.Effect == DragDropEffects.Move)
                {
                    // === Поверяем на одноименность элементов
                    if (targetNode.Nodes.Count > 0)
                    {
                        foreach (TreeNode node in targetNode.Nodes)
                        {
                            if (node.Text == draggedNode.Text && node.ImageIndex == draggedNode.ImageIndex) return;
                        }
                    }

                    string last_name;
                    // ==== Меняем картинку если группа опустошается
                    if (draggedNode.Parent.ImageIndex == 1 && draggedNode.Parent.Nodes.Count == 1)
                    {
                        draggedNode.Parent.ImageIndex = 3;
                    }

                    draggedNode.Remove();

                    last_name = draggedNode.Name;
                    // ====
                    if (draggedNode.ImageIndex == 1)
                    {
                        draggedNode.Name = Path.Combine(targetNode.Name, Path.GetFileName(draggedNode.Name));
                        Directory.Move(last_name, draggedNode.Name);
                    }
                    // ====
                    if (draggedNode.ImageIndex == 2)
                    {
                        draggedNode.Name = Path.Combine(targetNode.Name, Path.GetFileName(draggedNode.Name));
                        File.Move(last_name, draggedNode.Name);
                    }
                    // ====

                    if (draggedNode.ImageIndex == 3)
                    {
                        draggedNode.Name = Path.Combine(targetNode.Name, Path.GetFileName(draggedNode.Name));
                        Directory.Move(last_name, draggedNode.Name);
                    }

                    targetNode.Nodes.Add(draggedNode);
                }

                // If it is a copy operation, clone the dragged node 
                // and add it to the node at the drop location.
                else if (e.Effect == DragDropEffects.Copy)
                {
                    // === Поверяем на одноименность элементов
                    if (targetNode.Nodes.Count > 0)
                    {
                        foreach (TreeNode node in targetNode.Nodes)
                        {
                            if (node.Text == draggedNode.Text && node.ImageIndex == draggedNode.ImageIndex) return;
                        }
                    }

                    targetNode.Nodes.Add((TreeNode)draggedNode.Clone());

                    if (draggedNode.ImageIndex == 1 || draggedNode.ImageIndex == 3)
                    {
                        Text = draggedNode.Name;
                        Text = Path.Combine(targetNode.Name, draggedNode.Text);
                        CopyDir(draggedNode.Name, Path.Combine(targetNode.Name, Path.Combine(targetNode.Name, draggedNode.Text)));
                    }

                    if (draggedNode.ImageIndex == 2)
                    {
                        File.Copy(draggedNode.Name, Path.Combine(targetNode.Name, Path.GetFileName(draggedNode.Name)));
                    }

                }

                // Expand the node at the location 
                // to show the dropped node.
                targetNode.Expand();

                // ====
                TreeDBView.SelectedNode = targetNode;

                if (TreeDBView.SelectedNode.ImageIndex == 3)
                {
                    TreeDBView.SelectedNode.ImageIndex = 1;
                }
                ScanRootDir(pathDataModel);
            }
        }

        // Determine whether one node is a parent 
        // or ancestor of a second node.
        private bool ContainsNode(TreeNode node1, TreeNode node2)
        {
            // Check the parent node of the second node.
            if (node2.Parent == null) return false;
            if (node2.Parent.Equals(node1)) return true;

            // If the parent node is not null or equal to the first node, 
            // call the ContainsNode method recursively using the parent of 
            // the second node.
            return ContainsNode(node1, node2.Parent);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FromDir"></param>
        /// <param name="ToDir"></param>
        private void CopyDir(string FromDir, string ToDir)
        {
            Directory.CreateDirectory(ToDir);
            foreach (string s1 in Directory.GetFiles(FromDir))
            {
                string s2 = ToDir + "\\" + Path.GetFileName(s1);
                File.Copy(s1, s2);
            }
            foreach (string s in Directory.GetDirectories(FromDir))
            {
                CopyDir(s, ToDir + "\\" + Path.GetFileName(s));
            }
        }

        #endregion

        #endregion

        #region Scene
        // ============================================================================================
        // Глобальные переменные
        // ============================================================================================
        #region Глобальные переменные
        float zoom; // масштаб модели
        float xAxisRotation; // Угол вращение вокруг оси x
        float yAxisRotation; // Угол вращение вокруг оси y
        float xAxisTransport; // Расстояние перемещения вдоль оси x (экран)
        float yAxisTransport; // Расстояние перемещения вдоль оси y (экран)
        float far; // глубина перспективы
        int xAxisRotationLast; // Последнее положение мыши на экране по оси X (для вращения)
        int yAxisRotationLast; // Последнее положение мыши на экране по оси Y (для вращения)
        int xAxisTransportLast; // Последнее положение мыши на экране по оси X (для перемещения)
        int yAxisTransportLast; // Последнее положение мыши на экране по оси Y (для перемещения)
        public List<Face> model = new List<Face>(); // Текуща модель STL модель
        float[] offset_model = new float[3]; // Смещение от центра модели
        Color color_model = new Color(); // Цвет модели
        Color color_background = new Color(); // Цвет фона
        #endregion
        // ============================================================================================
        // Реализация методов
        // ============================================================================================

        /// <summary>
        /// Метод инициализации переменных
        /// </summary>
        private void Init()
        {
            zoom = 1;
            far = 200;
            // ===
            xAxisRotation = 0;
            yAxisRotation = 0;
            xAxisRotationLast = 0;
            yAxisRotationLast = 0;
            // ===
            xAxisTransport = 0;
            yAxisTransport = 0;
            xAxisTransportLast = 0;
            yAxisTransportLast = 0;
            // ===
            offset_model[0] = 0;
            offset_model[1] = 0;
            offset_model[2] = 0;
            // ===
        }

        /// <summary>
        /// Инициализация сцены
        /// </summary>
        private void InitScene()
        {
            // инициализация Glut
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGBA | Glut.GLUT_DEPTH | Glut.GLUT_DOUBLE);
            // Разрешить плавное цветовое сглаживание
            Gl.glShadeModel(Gl.GL_SMOOTH);
            // Разрешить тест глубины
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            // Разрешить очистку буфера глубины
            Gl.glClearDepth(1.0f);
            // Определение типа теста глубины 
            Gl.glDepthFunc(Gl.GL_LEQUAL);
            // Слегка улучшим вывод перспективы
            Gl.glHint(Gl.GL_PERSPECTIVE_CORRECTION_HINT, Gl.GL_NICEST);
            // Разрешаем смешивание
            Gl.glEnable(Gl.GL_BLEND);
            // Устанавливаем тип смешивания 
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
        }

        /// <summary>
        /// Метод изменяет размер сцены
        /// </summary>
        private void ResizeScene()
        {
            // Предупредим деление на нуль
            if (SceneWidget.Height == 0)
            {
                SceneWidget.Height = 1;
            }
            // Сбрасываем текущую область просмотра
            Gl.glViewport(0, 0, SceneWidget.Width, SceneWidget.Height);
            // Выбираем матрицу проекций
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            // Сбрасываем выбранную матрицу
            Gl.glLoadIdentity();
            // Вычисляем новые геометрические размеры сцены
            Glu.gluPerspective(45.0f, (float)SceneWidget.Width / (float)SceneWidget.Height, 0.1f, far);
            // Выбираем матрицу вида модели
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            // Сбрасываем ее; 
            Gl.glLoadIdentity();
        }

        /// <summary>
        /// Метод отрисовывает сцену
        /// </summary>
        private void DrawScene()
        {
            // Задаем цвет заднего фона
            Gl.glClearColor(color_background.R / 255, color_background.G / 255, color_background.B / 255, color_background.A / 255);
            // Очищаем 
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            // Выходим, если модель не загружена
            if (model.Count == 0) return;

            Gl.glPushMatrix();

            // описываем свойства материала модели
            float[] color = new float[4] { color_model.R / 255, color_model.G / 255, color_model.B / 255, color_model.A / 255 };
            // красный цвет   
            float[] shininess = new float[1] { 30 };
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, color); // цвет модели 
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, color); // отраженный свет   
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SHININESS, shininess); // степень отраженного света   

            // описываем источник света в сцене
            float[] ambient = { 255, 0, 0, 1 };
            float[] pos = { 0, 0, 0, 10 };
            float[] dir = { 0.7f, 0.3f, 0.7f };
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, pos);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_SPOT_DIRECTION, dir);

            //----------------------------   
            Gl.glPushMatrix();

            // Перемещение камеры
            Glu.gluLookAt(-xAxisTransport, yAxisTransport, 1, -xAxisTransport, yAxisTransport, 0, 0, 1, 0);

            // Выставляем модель по центру сцены
            Gl.glTranslated(offset_model[0] / zoom, offset_model[1] / zoom, -(((offset_model[2] * 4) + 50) / zoom));

            // Смещаем модель на центр вращения
            Gl.glTranslatef(-offset_model[0], -offset_model[1], -offset_model[2]);

            // Вращаем модель
            Gl.glRotatef(xAxisRotation, 0.0f, 1.0f, 0.0f);
            Gl.glRotatef(yAxisRotation, 1.0f, 0.0f, 0.0f);

            // Возвращаем модель на место
            Gl.glTranslatef(-offset_model[0], -offset_model[1], -offset_model[2]);

            // Масштабируем модель
            Gl.glScalef(zoom, zoom, zoom);

            // ===== рисуем модель =====
            foreach (var face in model)
            {
                // ===== рисуем треугольник ====
                Gl.glBegin(Gl.GL_TRIANGLES);
                Gl.glNormal3d(face.normal[0], face.normal[1], face.normal[2]);
                Gl.glVertex3d(face.vertex1[0], face.vertex1[1], face.vertex1[2]);
                Gl.glVertex3d(face.vertex2[0], face.vertex2[1], face.vertex2[2]);
                Gl.glVertex3d(face.vertex3[0], face.vertex3[1], face.vertex3[2]);
                Gl.glEnd();
            }
            Gl.glPopMatrix();
            Gl.glFlush();
            SceneWidget.Invalidate();
        }

        /// <summary>
        /// Метод возвращает центр модели
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private float[] ModelCenter(List<Face> model)
        {
            float[] offset = new float[3];
            float[] max = new float[3];
            float[] min = new float[3];

            // Обнуляем переменные
            for (int i = 0; i < 3; i++)
            {
                offset[i] = 0;
                max[i] = 0;
                min[i] = 0;
            }

            // Перебираем все грани модели
            foreach (var face in model)
            {
                // Перебираем по осям координат
                for (int i = 0; i < 3; i++)
                {
                    // max
                    if (face.vertex1[i] > max[i]) max[i] = face.vertex1[i];
                    if (face.vertex2[i] > max[i]) max[i] = face.vertex2[i];
                    if (face.vertex3[i] > max[i]) max[i] = face.vertex3[i];

                    // min
                    if (face.vertex1[i] < min[i]) min[i] = face.vertex1[i];
                    if (face.vertex2[i] < min[i]) min[i] = face.vertex2[i];
                    if (face.vertex3[i] < min[i]) min[i] = face.vertex3[i];
                }
            }

            // Получаем смещение по осям до центра модели
            for (int i = 0; i < 3; i++)
            {
                offset[i] = (max[i] - min[i]) / 2;
            }

            // Возвращаем полученный результат
            return offset;
        }

        /// <summary>
        /// Метод преобразует модель на сцене в начало состояние (как при загрузке файла)
        /// </summary>
        private void ViewReset()
        {
            zoom = 1;
            far = 200;
            // ===
            xAxisRotation = 0;
            yAxisRotation = 0;
            xAxisRotationLast = 0;
            yAxisRotationLast = 0;
            // ===
            offset_model[0] = 0;
            offset_model[1] = 0;
            offset_model[2] = 0;
            // ===
            offset_model = ModelCenter(model); // получаем центр модели
            DrawScene(); // отрисовываем модель
        }

        /// <summary>
        /// * Метод возвращает модель на центр экрана
        /// </summary>
        private void ViewOptimizate()
        {
            zoom = 1;
            far = 200;
            // ===
            xAxisTransport = 0;
            yAxisTransport = 0;
            xAxisTransportLast = 0;
            yAxisTransportLast = 0;
            // ===
            offset_model[0] = 0;
            offset_model[1] = 0;
            offset_model[2] = 0;
            // ===
            offset_model = ModelCenter(model); // получаем центр модели
            DrawScene(); // отрисовываем модель
        }

        /// <summary>
        /// Метод загружает файл модели в 3D движек
        /// </summary>
        public void OpenModel(string path)
        {

            if (STLFormat.ValidateSTL(path))
            {
                model.Clear(); // очищаем текущую модель
                model = STLFormat.LoadBinary(path);
                ShowNameModelStatusLine();
                offset_model = ModelCenter(model); // получаем центр модели
                DrawScene(); // отрисовываем модель
            }
            else
            {
                MessageBox.Show(Language.Error("mistake_stl_format"), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Метод устанавливает цвет модель
        /// </summary>
        private void SetColorModel()
        {
            if (model.Count > 0)
            {
                SceneWidget.Hide();
                if (colorDialog.ShowDialog() != DialogResult.Cancel)
                {
                    color_model = colorDialog.Color;
                    Properties.Settings.Default.ColorModel = colorDialog.Color;
                    Properties.Settings.Default.Save();
                }
                DrawScene(); // === Отрисовываем сцену
                SceneWidget.Show();
            }
        }

        /// <summary>
        /// Метод устанавливает цвет фона
        /// </summary>
        private void SetColorBackground()
        {
            if (model.Count > 0)
            {
                SceneWidget.Hide();
                if (colorDialog.ShowDialog() != DialogResult.Cancel)
                {
                    color_background = colorDialog.Color;
                    splitContainer1.Panel2.BackColor = color_background;
                    Properties.Settings.Default.ColorBackground = colorDialog.Color;
                    Properties.Settings.Default.Save();
                }
                DrawScene(); // === Отрисовываем сцену 
                SceneWidget.Show();
            }
        }

        /// <summary>
        /// Метод экпортирует текущий вид модели в файл bmp
        /// </summary>
        private void ExportBMP(string path)
        {
            int eHeigth = SceneWidget.Height;
            int eWidth = SceneWidget.Width;
            Rectangle area = new Rectangle(0, 0, eWidth, eHeigth);
            Bitmap bmp = new Bitmap(eWidth, eHeigth);
            System.Drawing.Imaging.BitmapData data = bmp.LockBits(area, System.Drawing.Imaging.ImageLockMode.WriteOnly,
                System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Gl.glReadBuffer(Gl.GL_FRONT);
            Gl.glReadPixels(0, 0, eWidth, eHeigth, Gl.GL_BGR, Gl.GL_UNSIGNED_BYTE, data.Scan0);
            bmp.UnlockBits(data);
            bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
            bmp.Save(path);
        }

        /// <summary>
        /// Метод экспорта текущего вида модели в картинки
        /// </summary>
        private void ExportPicture()
        {
            //saveFileModelDialog.Filter = "BMP files(*.bmp)|*.bmp|All files(*.*)|*.*";
            saveFileModelDialog.Filter = "BMP files(*.bmp)|*.bmp";
            saveFileModelDialog.FileName = "";
            if (saveFileModelDialog.ShowDialog() == DialogResult.Cancel)
                return;
            ExportBMP(saveFileModelDialog.FileName);
        }

        // ============================================================================================
        #region События виджета
        // ============================================================================================

        /// <summary>
        /// Событие изменения размера виджета
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SceneWidget_Resize(object sender, EventArgs e)
        {
            ResizeScene();
            DrawScene();
        }

        /// <summary>
        /// Событие отрисовки виджета
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SceneWidget_Paint(object sender, PaintEventArgs e)
        {
            DrawScene();
            // ====
            MainMenu.Refresh();
            statusLine.Refresh();
        }

        /// <summary>
        /// Событие происходит при покидании виджета
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SceneWidget_Leave(object sender, EventArgs e)
        {
            GetBackground();
        }

        /// <summary>
        /// Событие вращения колеси мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SceneWidget_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                zoom += (float)0.1;
            }
            else
            {
                zoom -= (float)0.1;
            }
            DrawScene();
        }

        /// <summary>
        /// Событие перемещения мыши по виджету
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SceneWidget_MouseMove(object sender, MouseEventArgs e)
        {
            // --- ЛКМ
            if (e.Button == MouseButtons.Left)
            {
                xAxisRotation += (180 * (e.X - xAxisRotationLast) / SceneWidget.Width);
                yAxisRotation += (180 * (e.Y - yAxisRotationLast) / SceneWidget.Height);
                xAxisRotationLast = e.X;
                yAxisRotationLast = e.Y;
                DrawScene();
            }

            // --- ПКМ
            if (e.Button == MouseButtons.Right)
            {
                xAxisTransport += (100 * (e.X - xAxisTransportLast) / SceneWidget.Width);
                yAxisTransport += (100 * (e.Y - yAxisTransportLast) / SceneWidget.Height);
                xAxisTransportLast = e.X;
                yAxisTransportLast = e.Y;
                DrawScene();
            }

            // --- Для расчетов запоминаем последнее положение мыши
            xAxisRotationLast = e.X;
            yAxisRotationLast = e.Y;
            xAxisTransportLast = e.X;
            yAxisTransportLast = e.Y;
        }

        /// <summary>
        /// Событие нажатой клавиши на виджите
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SceneWidget_KeyDown(object sender, KeyEventArgs e)
        {
            float speed = 10;

            #region Вращение модели
            if (e.KeyCode == Keys.W)
            {
                yAxisRotation -= (180 * speed / SceneWidget.Height);
                DrawScene();
            }

            if (e.KeyCode == Keys.S)
            {
                yAxisRotation += (180 * speed / SceneWidget.Height);
                DrawScene();
            }

            if (e.KeyCode == Keys.A)
            {
                xAxisRotation -= (180 * speed / SceneWidget.Width);
                DrawScene();
            }

            if (e.KeyCode == Keys.D)
            {
                xAxisRotation += (180 * speed / SceneWidget.Width);
                DrawScene();
            }
            #endregion

            #region Масштабирование модели
            if (e.KeyCode == Keys.E)
            {
                zoom += (float)0.01;
                DrawScene();
            }

            if (e.KeyCode == Keys.Q)
            {
                zoom -= (float)0.01;
                DrawScene();
            }

            #endregion

            #region Перемещение камеры

            if (e.KeyCode == Keys.R)
            {
                yAxisTransport -= (100 * speed / SceneWidget.Height);
                DrawScene();
            }

            if (e.KeyCode == Keys.F)
            {
                yAxisTransport += (100 * speed / SceneWidget.Height);
                DrawScene();
            }

            if (e.KeyCode == Keys.D1)
            {
                xAxisTransport -= (100 * speed / SceneWidget.Width);
                DrawScene();
            }

            if (e.KeyCode == Keys.D2)
            {
                xAxisTransport += (100 * speed / SceneWidget.Width);
                DrawScene();
            }

            #endregion

            #region Вызов справки по программе

            if (e.KeyCode == Keys.F1)
            {
                ShowHelp();
            }

            #endregion

        }

        #endregion

        /// <summary>
        /// Получаем картинку для заднего фона (костыль для WidgetScene)
        /// </summary>
        private void GetBackground()
        {
            int eHeigth = SceneWidget.Height;
            int eWidth = SceneWidget.Width;
            Rectangle area = new Rectangle(0, 0, eWidth, eHeigth);
            Bitmap bmp = new Bitmap(eWidth, eHeigth);
            System.Drawing.Imaging.BitmapData data = bmp.LockBits(area, System.Drawing.Imaging.ImageLockMode.WriteOnly,
                System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            //Gl.glReadBuffer(Gl.GL_FRONT);
            Gl.glReadBuffer(Gl.GL_BACK);
            Gl.glReadPixels(0, 0, eWidth, eHeigth, Gl.GL_BGR, Gl.GL_UNSIGNED_BYTE, data.Scan0);
            bmp.UnlockBits(data);
            bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
            if (model.Count > 0)
            {
                splitContainer1.Panel2.BackgroundImage = bmp;
            }
            else
            {
                splitContainer1.Panel2.BackgroundImage = null;
            }
        }
        #endregion

        #region Scanner        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        private void ScanRootDir(string path)
        {
            //Отключаем любую перерисовку
            //иерархического представления.
            TreeDBView.BeginUpdate();

            //Очищаем дерево
            TreeDBView.Nodes.Clear();

            //Инициализируем новую переменную предоставляющую методы экземпляра
            //класса для создания, перемещения и перечисления
            //в каталогах и подкаталогах.
            System.IO.DirectoryInfo di;
            try
            {
                //Вызываем метод GetDirectories с передачей в качестве параметра, пути к 
                //выбранной директории. Данный метод возвращает
                //массив имен подкаталогов.
                string[] root = System.IO.Directory.GetDirectories(path);

                if (root.Rank > 1)
                {
                    //Проходим по всем полученным подкаталогам.
                    foreach (string s in root)
                    {
                        try
                        {
                            //Заносим в переменную информацию
                            //о текущей директории.
                            di = new System.IO.DirectoryInfo(s);
                            //Вызов метода сканирования с
                            //передачей в качестве параметра, информации
                            //о текущей директории и объект 
                            //System.Windows.Forms.TreeNodeCollection,
                            //который предоставляет узлы
                            //дерева, назначенные элементу управления 
                            //иерархического представления.
                            BuildTree(di, TreeDBView.Nodes);
                        }
                        catch { }
                    }
                }
                else
                {
                    di = new System.IO.DirectoryInfo(path);
                    BuildTree(di, TreeDBView.Nodes);
                }
            }
            catch { }

            // Раскрываем все узлы
            TreeDBView.ExpandAll();
            //Разрешаем перерисовку иерархического представления.
            TreeDBView.EndUpdate();

            di = null;

        }

        /// <summary>
        /// Метод получает папки и файлы
        /// </summary>
        /// <param name="directoryInfo"></param>
        /// <param name="addInMe"></param>
        private void BuildTree(System.IO.DirectoryInfo directoryInfo, TreeNodeCollection addInMe)
        {

            int type_dir; // Тип папки

            if ((directoryInfo.GetDirectories()).Length > 0 || (directoryInfo.GetFiles()).Length > 0)
            {
                type_dir = 3;
                foreach (System.IO.FileInfo file in directoryInfo.GetFiles())
                {
                    if (STLFormat.ValidateSTL(file.FullName))
                    {
                        type_dir = 1;
                    }
                }

                if ((directoryInfo.GetDirectories()).Length > 0)
                {
                    type_dir = 1;
                }

            }
            else
            {
                type_dir = 3;
            }

            //Добавляем новый узел в коллекцию Nodes
            //с именем текущей директории и указанием ключа 
            //со значением "Folder".
            TreeNode curNode = null;
            if (directoryInfo.FullName == pathDataModel)
            {
                string name_root_dir = string.Empty;
                switch (Properties.Settings.Default.Language)
                {
                    case "English":
                        name_root_dir = "ModelBase";
                        break;
                    case "Russian":
                        name_root_dir = "База моделей";
                        break;
                }
                curNode = addInMe.Add(directoryInfo.FullName, name_root_dir, type_dir);
            }
            else
            {
                curNode = addInMe.Add(directoryInfo.FullName, directoryInfo.Name, type_dir);
            }

            //addInMe.Add("group", directoryInfo.Name);
            //Перебираем папки.
            foreach (System.IO.DirectoryInfo subdir in directoryInfo.GetDirectories())
            {
                //Запускам процесс получения папок и фалов 
                //с текущей найденной директории.
                BuildTree(subdir, curNode.Nodes);
            }

            //Перебираем файлы
            foreach (System.IO.FileInfo file in directoryInfo.GetFiles())
            {
                //Добавляем новый узел в коллекцию Nodes
                //С именем текущей директории и указанием ключа 
                //со значением "File".
                //curNode.Nodes.Add("Model", file.Name);
                if (file.Extension == ".stl")
                {
                    if (STLFormat.ValidateSTL(file.FullName))
                    {
                        curNode.Nodes.Add(file.FullName, Path.GetFileNameWithoutExtension(file.Name), 2);
                    }
                }
            }
        }
        #endregion

        #region Language
        /// <summary>
        /// Класс локализации
        /// </summary>
        public static class Language
        {
            /// <summary>
            /// Ошибки
            /// </summary>
            public static string Error(string code)
            {
                string res = null;
                switch (Properties.Settings.Default.Language)
                {
                    case "Russian":
                        switch (code)
                        {
                            case "file_donot_find":
                                return "Файл справки отсутствует";
                            case "mistake_set_path":
                                return "Не правильно указан путь";
                            case "mistake_stl_format":
                                return "Ошибка формата файла";
                            case "repeat_start_application":
                                return "Программа уже запущена!!!";
                            case "this_group_exists":
                                return "Такая группа уже существует";
                            case "delete_group":
                                return "Удалить группу?";
                            case "delete_group_with_files":
                                return "Группа содержит группы и модели!!!\nУдалить группу?";
                            case "delete_model":
                                return "Удалить модель?";
                        }
                        break;
                    case "English":
                        switch (code)
                        {
                            case "file_donot_find":
                                return "Don't find file Help";
                            case "mistake_set_path":
                                return "Mistake in set path";
                            case "mistake_stl_format":
                                return "Mistake stl format";
                            case "repeat_start_application":
                                return "Repeat start application!!!";
                            case "this_group_exists":
                                return "This group exists";
                            case "delete_group":
                                return "Delete group?";
                            case "delete_group_with_files":
                                return "Group contain groups and models!!!\nDelete group?";
                            case "delete_model":
                                return "Delete model?";
                        }
                        break;
                }
                return res;
            }
        }

        /// <summary>
        /// Перевод интерфейса на английский язык
        /// </summary>
        private void TranslateToEn()
        {
            Text = "STL Viewer";
            File_MenuItem.Text = "File";
            OpenModel_MenuItem.Text = "Open ...";
            ExportPicture_MenuItem.Text = "Export picture ...";
            Settings_MenuItem.Text = "Settings ...";
            Close_MenuItem.Text = "Exit";
            View_MenuItem.Text = "View";
            ResetViiew_MenuItem.Text = "Reset view";
            OptimizateView_MenuItem.Text = "Centering View";
            ColorModel_MenuItem.Text = "Color model ...";
            ColorBackground_MenuItem.Text = "Color background ...";
            Database_MenuItem.Text = "ModelBase";
            AddGroup_ContextMenuTreeDBView.Text = "Add group";
            RemoveGroup_MenuItem.Text = "Remove group";
            AddModel_MenuItem.Text = "Add model";
            RemoveModel_MenuItem.Text = "Remove model";
            UpLevel_MenuItem.Text = "Up level item";
            DownLevel_MenuItem.Text = "Down level item";
            Rename_MenuItem.Text = "Rename";
            Help_MenuItem.Text = "Help";
            ShowHelp_MenuItem.Text = "Show Help ...";
            About_MenuItem.Text = "About ...";
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
            TreeNode last_node = null;
            if (TreeDBView.SelectedNode != null)
            {
                last_node = TreeDBView.SelectedNode;
            }
            TreeDBView.SelectedNode = FindNodeByName("База моделей");
            if (TreeDBView.SelectedNode != null)
            {
                TreeDBView.SelectedNode.Text = "ModelBase";
            }
            if (last_node != null)
            {
                TreeDBView.SelectedNode = last_node;
            }
            ExportModelBase_ContextMenuTreeDBView.Text = "Export ModelBase ...";
            ImportModelBase_ContextMenuTreeDBView.Text = "Import ModelBase ...";
            ExportModelBase_MenuItem.Text = "Export ModelBase ...";
            ImportModelBase_MenuItem.Text = "Import ModelBase ...";
        }

        /// <summary>
        /// Перевод интерфейса на русский язык
        /// </summary>
        private void TranslateToRu()
        {
            Text = "STL Просмотрщик";
            File_MenuItem.Text = "Файл";
            OpenModel_MenuItem.Text = "Открыть ...";
            ExportPicture_MenuItem.Text = "Экспорт картинки ...";
            Settings_MenuItem.Text = "Настройки ...";
            Close_MenuItem.Text = "Выход";
            View_MenuItem.Text = "Вид";
            ResetViiew_MenuItem.Text = "Сброс вида";
            OptimizateView_MenuItem.Text = "Центрирование вида";
            ColorModel_MenuItem.Text = "Цвет модели ...";
            ColorBackground_MenuItem.Text = "Цвет фона ...";
            Database_MenuItem.Text = "База моделей";
            AddGroup_ContextMenuTreeDBView.Text = "Добавить группу";
            RemoveGroup_MenuItem.Text = "Удалить группу";
            AddModel_MenuItem.Text = "Добавить модель";
            RemoveModel_MenuItem.Text = "Удалить модель";
            UpLevel_MenuItem.Text = "Переместить вверх";
            DownLevel_MenuItem.Text = "Переместить вниз";
            Rename_MenuItem.Text = "Переименовать";
            Help_MenuItem.Text = "Помощь";
            ShowHelp_MenuItem.Text = "Показать справку ...";
            About_MenuItem.Text = "О программе ...";
            toolStripStatusLabel1.Text = "Язык";
            toolStripStatusLabel2.Text = "Загруженная модель: ";
            ShowLegend_MenuItem.Text = "Показать легенду";
            HideLegend_MenuItem.Text = "Скрыть легенду";
            AddGroup_MenuItem.Text = "Добавить группу";
            RemoveGroup_ContextMenuTreeDBView.Text = "Удалить группу";
            AddModel_ContextMenuTreeDBView.Text = "Добавить модель";
            RemoveModel_ContextMenuTreeDBView.Text = "Удалить модель";
            UpLevel_ContextMenuTreeDBView.Text = "Переместить вверх";
            DownLevel_ContextMenuTreeDBView.Text = "Переместить вниз";
            Rename_ContextMenuTreeDBView.Text = "Переименовать";
            // ===
            TreeNode last_node = null;
            if (TreeDBView.SelectedNode != null)
            {
                last_node = TreeDBView.SelectedNode;
            }
            TreeDBView.Focus();
            TreeDBView.SelectedNode = FindNodeByName("ModelBase");
            if (TreeDBView.SelectedNode != null)
            {
                TreeDBView.SelectedNode.Text = "База моделей";
            }
            if (last_node != null)
            {
                TreeDBView.SelectedNode = last_node;
            }
            ExportModelBase_ContextMenuTreeDBView.Text = "Экспорт Базы Моделей ...";
            ImportModelBase_ContextMenuTreeDBView.Text = "Импорт Базы Моделей ...";
            ExportModelBase_MenuItem.Text = "Экспорт Базы Моделей ...";
            ImportModelBase_MenuItem.Text = "Импорт Базы Моделей ...";
        }

        #endregion


    }
}
