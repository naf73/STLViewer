using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace STLViewer
{
    public static class STLFormat
    {
        /// <summary>
        /// Метод заполняет список граней модели из бинарного файла
        /// </summary>
        /// <param name="path">Абсолютный путь к бинарному файлу</param>
        /// <returns>Возвращает список граней модели тип Face</returns>
        public static List<Face> LoadBinary(string path)
        {
                // Создаем список граней модели
                List<Face> model = new List<Face>();
            try
            {
                // Проверяем существование файла
                if (File.Exists(path))
                {
                    // Читаем файл
                    using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                    {
                        // название модели
                        char[] name_char;
                        name_char = reader.ReadChars(80);
                        string name = new string(name_char); // название модели

                        // количество граней 
                        byte[] count_bytes;
                        int count; // количество граней
                        count_bytes = reader.ReadBytes(4);
                        count = BitConverter.ToInt32(count_bytes, 0);

                        // Заполняем список граней
                        for (int i = 0; i < count; i++)
                        {
                            Face face = new Face();

                            // нормаль грани
                            face.normal[0] = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                            face.normal[1] = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                            face.normal[2] = BitConverter.ToSingle(reader.ReadBytes(4), 0);

                            // первая вершина треугольника
                            face.vertex1[0] = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                            face.vertex1[1] = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                            face.vertex1[2] = BitConverter.ToSingle(reader.ReadBytes(4), 0);

                            // вторая вершина треугольника
                            face.vertex2[0] = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                            face.vertex2[1] = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                            face.vertex2[2] = BitConverter.ToSingle(reader.ReadBytes(4), 0);

                            // третья вершина треугольника
                            face.vertex3[0] = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                            face.vertex3[1] = BitConverter.ToSingle(reader.ReadBytes(4), 0);
                            face.vertex3[2] = BitConverter.ToSingle(reader.ReadBytes(4), 0);

                            // пропускаем 2 пустых байта
                            reader.ReadBytes(2);

                            // добавляем грань в модель
                            model.Add(face);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            // Возвращаем полученный результат
            return model; 
        }
    }
}
