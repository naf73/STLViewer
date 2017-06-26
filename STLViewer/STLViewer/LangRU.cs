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
        /// Перевод интерфейса на русский язык
        /// </summary>
        private void TranslateToRu()
        {
            Text = "STL Просмотрщик";
            File_MenuItem.Text = "Файл";
            OpenModel_MenuItem.Text = "Открыть ...";
            ExportPicture_MenuItem.Text = "Экспорт картинки ...";
            Settings_MenuItem.Text = "Настройки ...";
            Close_MenuItem.Text = "Выход";
            View_MenuItem.Text = "Вид";
            ResetViiew_MenuItem.Text = "Сброс вида";
            OptimizateView_MenuItem.Text = "Центрирование вида";
            ColorModel_MenuItem.Text = "Цвет модели ...";
            ColorBackground_MenuItem.Text = "Цвет фона ...";
            Database_MenuItem.Text = "База моделей";
            AddGroup_ContextMenuTreeDBView.Text = "Добавить группу";
            RemoveGroup_MenuItem.Text = "Удалить группу";
            AddModel_MenuItem.Text = "Добавить модель";
            RemoveModel_MenuItem.Text = "Удалить модель";
            UpLevel_MenuItem.Text = "Переместить вверх";
            DownLevel_MenuItem.Text = "Переместить вниз";
            Rename_MenuItem.Text = "Переименовать";
            Help_MenuItem.Text = "Помощь";
            ShowHelp_MenuItem.Text = "Показать справку ...";
            About_MenuItem.Text = "О программе ...";
            toolStripStatusLabel1.Text = "Язык";
            toolStripStatusLabel2.Text = "Загруженная модель: ";
            ShowLegend_MenuItem.Text = "Показать легенду";
            HideLegend_MenuItem.Text = "Скрыть легенду";
            AddGroup_MenuItem.Text = "Добавить группу";
            RemoveGroup_ContextMenuTreeDBView.Text = "Удалить группу";
            AddModel_ContextMenuTreeDBView.Text = "Добавить модель";
            RemoveModel_ContextMenuTreeDBView.Text = "Удалить модель";
            UpLevel_ContextMenuTreeDBView.Text = "Переместить вверх";
            DownLevel_ContextMenuTreeDBView.Text = "Переместить вниз";
            Rename_ContextMenuTreeDBView.Text = "Переименовать";
            // ===
            TreeNode last_node = null;
            if (TreeDBView.SelectedNode != null)
            {
                last_node = TreeDBView.SelectedNode;
            }
            TreeDBView.Focus();
            TreeDBView.SelectedNode = FindNodeByName("ModelBase");
            if (TreeDBView.SelectedNode != null) 
            {
                TreeDBView.SelectedNode.Text = "База моделей";
            }
            if (last_node != null)
            {
                TreeDBView.SelectedNode = last_node;
            }
            ExportModelBase_ContextMenuTreeDBView.Text = "Экспорт Базы Моделей ...";
            ImportModelBase_ContextMenuTreeDBView.Text = "Импорт Базы Моделей ...";
            ExportModelBase_MenuItem.Text = "Экспорт Базы Моделей ...";
            ImportModelBase_MenuItem.Text = "Импорт Базы Моделей ...";
        }
    }
}
