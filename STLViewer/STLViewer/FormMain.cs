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
        public FormMain()
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
            DrawScene();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            string path_to_model;
            path_to_model = @"C:\\Users\\naf\\Documents\\Visual Studio 2015\\Projects\\STLViewer\\test_cube.stl";
            path_to_model = @"C:\\Users\\naf\\Documents\\Visual Studio 2015\\Projects\\STLViewer\\test_part.stl";
            // Загружаем stl модель
            // тестовый пример
            string name; // имя модели
            model = STLFormat.LoadBinary(path_to_model, out name);
            this.Text = name; // получаем имя модели
            offset_model = ModelCenter(model); // получаем центр модели
            
            // Отрисовка модели
            DrawScene();
        }

        /// <summary>
        /// Возвращает модель в изначальное положение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            ViewReset(); // Сброс вида сцены
        }

        /// <summary>
        /// Открывает новую модель
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenModel();
        }
    }
}
