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
        // =================================================
        // Глобальные переменные
        // =================================================

        /// <summary>
        /// Текуща модель STL модель
        /// </summary>
        List<Face> model = new List<Face>();

        /// <summary>
        /// Констуктор формы
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
            // Инициализация виджета OpenGL
            SceneWidget.InitializeContexts();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // Инициализация сцены
            InitScene();

            // Загружаем stl модель
            // тестовый пример
            string name; // имя модели
            model = STLFormat.LoadBinary("C:\\Users\\naf\\Documents\\Visual Studio 2015\\Projects\\STLViewer\\test_cube.stl", out name);
            this.Text = name;
            
            // Отрисовка модели
            DrawModel();
        }

        private void FormMain_Paint(object sender, PaintEventArgs e)
        {
            DrawModel();
        }
    }
}
