using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STLViewer
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// 
        /// </summary>
        private void TranslateToRu()
        {
            Text = "STL Просмотрщик";
            File_MenuItem.Text = "Файл";
            OpenModel_MenuItem.Text = "Открыть ...";
            ExportPicture_MenuItem.Text = "Экспорт картинки ...";
            Settings_MenuItem.Text = "Настройки ...";
            Close_MenuItem.Text = "Закрыть";
            View_MenuItem.Text = "Вид";
            ResetViiew_MenuItem.Text = "Сброс вида";
            OptimizateView_MenuItem.Text = "Оптимизация вида";
            ColorModel_MenuItem.Text = "Цвет модели";
            ColorBackground_MenuItem.Text = "Цвет фона";
            Database_MenuItem.Text = "База моделей";
            AddGroup_ContextMenuTreeDBView.Text = "Добавить группу";
            RemoveGroup_MenuItem.Text = "Удалить группу";
            AddModel_MenuItem.Text = "Добавить модель";
            RemoveModel_MenuItem.Text = "Удалить модель";
            UpLevel_MenuItem.Text = "Переместить вверх";
            DownLevel_MenuItem.Text = "Переместить вниз";
            Rename_MenuItem.Text = "Переименовать";
            Help_MenuItem.Text = "Помощь";
            ShowHelp_MenuItem.Text = "Показать справку";
            About_MenuItem.Text = "О программе";
            toolStripStatusLabel1.Text = "Язык";
            toolStripStatusLabel2.Text = "Загруженная модель: ";
            ShowLegend_MenuItem.Text = "Показать легенду";
            HideLegend_MenuItem.Text = "Скрыть легенду";
        }
    }
}
