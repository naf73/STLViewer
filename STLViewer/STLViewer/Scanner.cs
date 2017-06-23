using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace STLViewer
{
    public partial class FormMain : Form
    {
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        private void ScanRootDir(string path)
        {
            //Отключаем любую перерисовку
            //иерархического представления.
            TreeDBView.BeginUpdate();

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
            //Разрешаем перерисовку иерархического представления.
            TreeDBView.EndUpdate();
        }

        /// <summary>
        /// Метод получает папки и файлы
        /// </summary>
        /// <param name="directoryInfo"></param>
        /// <param name="addInMe"></param>
        private void BuildTree(System.IO.DirectoryInfo directoryInfo, TreeNodeCollection addInMe)
        {
            //Добавляем новый узел в коллекцию Nodes
            //с именем текущей директории и указанием ключа 
            //со значением "Folder".
            TreeNode curNode = addInMe.Add("Folder", directoryInfo.Name);

            //addInMe.Add(directoryInfo.FullName, directoryInfo.Name, 
            //тут можно указать номер картинки для узла из imageCollection);

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
                curNode.Nodes.Add("File", file.Name);

                //curNode.Nodes.Add("File", file.Name, 
                //тут можно указать номер картинки для узла из imageCollection);  
            }
        }

    }
}
