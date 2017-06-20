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
        
        /// <summary>
        /// Инициализация виджета
        /// </summary>
        private void InitScene()
        {
            // инициализация Glut 
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
            // отчитка окна 
            Gl.glClearColor(0, 0, 0, 1);
            // установка порта вывода в соответствии с размерами элемента anT 
            Gl.glViewport(0, 0, SceneWidget.Width, SceneWidget.Height);
            // настройка проекции 
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(45, (float)SceneWidget.Width / (float)SceneWidget.Height, 0.1, 210);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            // настройка параметров OpenGL для визуализации 
            Gl.glEnable(Gl.GL_DEPTH_TEST);
        }

        private void DrawModel()
        {
            // Выходим, если модель не загружена
            if (model.Count == 0) return;

            //
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT); Gl.glLoadIdentity();
            
            // описываем свойства материала модели
            float[] color = new float[4] { 1, 0, 0, 1 };
            // красный цвет   
            float[] shininess = new float[1] { 30 };
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, color); // цвет модели 
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, color); // отраженный свет   
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SHININESS, shininess); // степень отраженного света   

            // описываем источник света в сцене
            float[] ambient = { 255, 0, 0, 1 };
            float[] pos = { 0, 0, 0, 1 };
            float[] dir = { 0.5f, 0.0f, 1.0f };
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, pos);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_SPOT_DIRECTION, dir);

            //----------------------------   
            Gl.glPushMatrix();
            Gl.glTranslated(0, 0, -100);

            Gl.glRotatef(45, 0.0f, 1.0f, 0.0f);
            Gl.glRotatef(5, 1.0f, 0.0f, 0.0f);

            Gl.glScalef(0.5f, 0.5f, 0.5f);


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
    }
}
