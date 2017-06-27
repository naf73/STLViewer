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

namespace STLViewer
{
    public partial class FormMain : Form
    {
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
    }
}
