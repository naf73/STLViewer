using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


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

            // === Аргументы переданные приложению

            // --- To Do
            if(args.Length == 1)
            {
                string name; // имя модели
                model = STLFormat.LoadBinary(args[0], out name);
                this.Text = name; // получаем имя модели
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
            #region Тестовый кусок (нужно убрать на release)
            //string path_to_model;
            //path_to_model = @"C:\\Users\\naf\\Documents\\Visual Studio 2015\\Projects\\STLViewer\\test_cube.stl";
            //path_to_model = @"C:\\Users\\naf\\Documents\\Visual Studio 2015\\Projects\\STLViewer\\test_part.stl";
            //// Загружаем stl модель
            //// тестовый пример
            //string name; // имя модели
            //model = STLFormat.LoadBinary(path_to_model, out name);
            //this.Text = name; // получаем имя модели
            //offset_model = ModelCenter(model); // получаем центр модели
            
            //// Отрисовка модели
            //DrawScene();
            #endregion
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
        #endregion

        #region Пункт меню "Help"

        /// <summary>
        /// Показать справку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowHelp_MenuItem_Click(object sender, EventArgs e)
        {

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
        }

        /// <summary>
        /// Выбран язык Русский
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rus_SelectItem_Click(object sender, EventArgs e)
        {
            SelectLanguage.Text = Rus_SelectItem.Text;
        }


        #endregion
    }
}
