using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerDir
{
    class ScanDirs
    {
        //Fields
        private List<Folder> dirs;
        private int level;

        //Constructor
        public ScanDirs()
        {
            dirs = new List<Folder>();
            level = 1;
        }


        //Functions
        //рекурсивный проход по дереву каталога
        public void scanDirectories(string path)
        {
            System.IO.DirectoryInfo DI = new System.IO.DirectoryInfo(path);
            if (!DI.Exists) return;
            
            //получение списка поддиректорий
            try
            {
                System.IO.DirectoryInfo[] SubDir = DI.GetDirectories();
                for (int i = 0; i < SubDir.Length; ++i)
                {
                    level++;
                    this.scanDirectories(SubDir[i].FullName);
                }
            }
            catch{}

            System.IO.FileInfo[] fileInfo = null;
            try
            {
                fileInfo = DI.GetFiles();
            }
            catch{}

            bool isContains = false;

            if (fileInfo != null)
            {
                //поиск файлов с расширение ".stl"
                for (int i = 0; i < fileInfo.Length; ++i)
                {
                    if (fileInfo[i].Name.Contains(".stl"))
                    {
                        isContains = true;
                        break;
                    }
                }
            }

            //добавление в List текущей папки
            dirs.Add(new Folder(DI.Parent.FullName, DI.FullName, level, isContains ? PropertiesDir.contain : PropertiesDir.empty));
            level--;
        }

        //для теста
        static void Main(string[] args)
        {
            ScanDirs scaner = new ScanDirs();
            scaner.scanDirectories(@"E:\");//<-- путь для теста!!!

            foreach(Folder es in scaner.dirs)
            {
                Console.WriteLine("Абсолютный путь папки - " + es.getAbsolutePath());
                Console.WriteLine("Родитель - " + es.getParent());
                Console.WriteLine("Наличие файла с расширением \".stl\" - " + es.getProp());
                Console.WriteLine("Уровень - " + es.getLevel());
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
