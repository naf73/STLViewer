using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


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
        // ============================================================================================
        // Глобальные переменные
        // ============================================================================================
        #region Глобальные переменные
        float zoom; // масштаб модели
        float xAxisRotation; // вращение вокруг оси x
        float yAxisRotation; // вращение вокруг оси y
        float far; // глубина перспективы
        int xAxisRotationLast;
        int yAxisRotationLast;
        List<Face> model = new List<Face>(); // Текуща модель STL модель
        float[] offset_model = new float[3]; // Смещение от центра модели
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
            offset_model[0] = 0;
            offset_model[1] = 0;
            offset_model[2] = 0;

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
            // Выходим, если модель не загружена
            if (model.Count == 0) return;

            //
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            Gl.glPushMatrix();

            // описываем свойства материала модели
            float[] color = new float[4] { 1, 0, 0, 1 };
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
            for(int i=0; i<3; i++)
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
            Init(); // обнуляем переменные сцены
            offset_model = ModelCenter(model); // получаем центр модели
            DrawScene(); // отрисовываем модель
        }

        /// <summary>
        /// * Метод возвращает модель на центр экрана
        /// </summary>
        private void ViewOptimizate()
        { 
        
        }

        /// <summary>
        /// Метод открывает диалоговое окно "Окрыт файл" и загружает файл модели в 3D движек
        /// </summary>
        private void OpenModel()
        {
            openFileModelDialog.Filter = "STL files(*.stl)|*.stl|All files(*.*)|*.*";
            openFileModelDialog.FileName = "";
            if (openFileModelDialog.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string name; // имя модели
            model.Clear(); // очищаем текущую модель
            model = STLFormat.LoadBinary(openFileModelDialog.FileName, out name);
            this.Text = name; // получаем имя модели
            offset_model = ModelCenter(model); // получаем центр модели
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
            saveFileModelDialog.Filter = "BMP files(*.bmp)|*.bmp|All files(*.*)|*.*";
            saveFileModelDialog.FileName = "";
            if (saveFileModelDialog.ShowDialog() == DialogResult.Cancel)
                return;
            ExportBMP(saveFileModelDialog.FileName);
        }

        // ============================================================================================
        // События виджета
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
            MainMenu.Refresh();
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
            if (e.Button == MouseButtons.Left)
            {
                xAxisRotation += (180 * (e.X - xAxisRotationLast) / SceneWidget.Width);
                yAxisRotation += (180 * (e.Y - yAxisRotationLast) / SceneWidget.Height);
                xAxisRotationLast = e.X;
                yAxisRotationLast = e.Y;
                DrawScene();
            }
            else
            {
                xAxisRotationLast = e.X;
                yAxisRotationLast = e.Y;
            }
        }

        /// <summary>
        /// Событие нажатой клавиши на виджите
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SceneWidget_KeyDown(object sender, KeyEventArgs e)
        {
            float speed = 10;
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

            if(e.KeyCode == Keys.A)
            {
                xAxisRotation -= (180 * speed / SceneWidget.Width);
                DrawScene();
            }

            if (e.KeyCode == Keys.D)
            {
                xAxisRotation += (180 * speed / SceneWidget.Width);
                DrawScene();
            }
        }
    }
}
