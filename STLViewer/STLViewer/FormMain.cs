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

namespace STLViewer
{
    public partial class FormMain : Form
    {
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

            // === Аргументы переданные приложению

            // --- To Do
            if (args.Length == 1)
            {
                string name; // имя модели
                model = STLFormat.LoadBinary(args[0], out name);
                NameLoadModel.Text = name; // получаем имя модели
                offset_model = ModelCenter(model); // получаем центр модели
            }
            // ===

            DrawScene();
        }

        /// <summary>
        /// Событие происходит при загрузке формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            string pathDataModel = Path.Combine(Application.StartupPath, "test_db_models");
            ScanRootDir(pathDataModel);
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
            OpenModel();
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
            // --- To Do
        }

        /// <summary>
        /// Удаление выбранного узла в дереве тип модель
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveModel_MenuItem_Click(object sender, EventArgs e)
        {
            // --- To Do
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
            SelectLanguage.Text = English_SelectItem.Text;
            TranslateToEn();
        }

        /// <summary>
        /// Выбран язык Русский
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rus_SelectItem_Click(object sender, EventArgs e)
        {
            SelectLanguage.Text = Rus_SelectItem.Text;
            TranslateToRu();
        }

        #endregion

        #region Методы реализации

        /// <summary>
        /// Метод вызывает файл справки
        /// </summary>
        private void ShowHelp()
        {
            String helpPath = Path.Combine(Application.StartupPath, "helperStl.chm");
            if (File.Exists(helpPath))
            {
                Process.Start(helpPath);
            }
        }




        #endregion

        
    }
}
