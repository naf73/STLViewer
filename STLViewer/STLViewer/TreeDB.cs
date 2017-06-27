using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;

namespace STLViewer
{
    public partial class FormMain : Form
    {
        #region События TeeDBView

        /// <summary>
        /// Событие после выбора узла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeDBView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ShowNameModelStatusLine();
            // ================================================================================
            #region Настройка отображения пунктов главного и контектсного меню
            // ================================================================================

            if (File.Exists(TreeDBView.SelectedNode.Name))
            {
                // === Контекстное меню
                AddGroup_ContextMenuTreeDBView.Enabled = false;
                RemoveGroup_ContextMenuTreeDBView.Enabled = false;
                RemoveModel_ContextMenuTreeDBView.Enabled = true;
                // === Главное меню
                AddGroup_MenuItem.Enabled = AddGroup_ContextMenuTreeDBView.Enabled;
                RemoveGroup_MenuItem.Enabled = RemoveGroup_ContextMenuTreeDBView.Enabled;
                RemoveModel_MenuItem.Enabled = RemoveModel_ContextMenuTreeDBView.Enabled;
            }
            else
            {
                // === Контекстное меню
                AddGroup_ContextMenuTreeDBView.Enabled = true;
                RemoveGroup_ContextMenuTreeDBView.Enabled = true;
                RemoveModel_ContextMenuTreeDBView.Enabled = false;
                // === Главное меню
                AddGroup_MenuItem.Enabled = AddGroup_ContextMenuTreeDBView.Enabled;
                RemoveGroup_MenuItem.Enabled = RemoveGroup_ContextMenuTreeDBView.Enabled;
                RemoveModel_MenuItem.Enabled = RemoveModel_ContextMenuTreeDBView.Enabled;
            }

            // --- Запрещаем удалять и переименовывать корневой узел
            if (TreeDBView.SelectedNode.Name == pathDataModel)
            {
                RemoveGroup_ContextMenuTreeDBView.Enabled = false;
                Rename_ContextMenuTreeDBView.Enabled = false;
                ExportModelBase_ContextMenuTreeDBView.Enabled = true;
                ImportModelBase_ContextMenuTreeDBView.Enabled = true;
                RemoveGroup_MenuItem.Enabled = RemoveGroup_ContextMenuTreeDBView.Enabled;
                Rename_MenuItem.Enabled = Rename_ContextMenuTreeDBView.Enabled;
                ExportModelBase_MenuItem.Enabled = ExportModelBase_ContextMenuTreeDBView.Enabled;
                ImportModelBase_MenuItem.Enabled = ImportModelBase_ContextMenuTreeDBView.Enabled;
            } else 
            {
                Rename_ContextMenuTreeDBView.Enabled = true;
                ExportModelBase_ContextMenuTreeDBView.Enabled = false;
                ImportModelBase_ContextMenuTreeDBView.Enabled = false;
                Rename_MenuItem.Enabled = Rename_ContextMenuTreeDBView.Enabled;
                ExportModelBase_MenuItem.Enabled = ExportModelBase_ContextMenuTreeDBView.Enabled;
                ImportModelBase_MenuItem.Enabled = ImportModelBase_ContextMenuTreeDBView.Enabled;
            }

            #endregion

            // ================================================================================
            #region Добавление и переименование узла
            // ================================================================================

            // можно использовать под загрузку картинки
            if (TreeDBView.SelectedNode == null)
                return;

            if (TreeDBView.SelectedNode.ImageIndex == 2)
            {
                SceneWidget.Show();
                Init();
                string name; // имя модели
                model = STLFormat.LoadBinary(TreeDBView.SelectedNode.Name, out name);
                //NameLoadModel.Text = name; // получаем имя модели
                ShowNameModelStatusLine();
                offset_model = ModelCenter(model); // получаем центр модели
                DrawScene();
            }
            else
            {
                Init();
                model.Clear();
                SceneWidget.Hide();
            }
            GetBackground();
            // -- To Do 
            // Добавить реакцию на переименование модели

            #endregion
        }

        /// <summary>
        /// Событие после завершения переименования узла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeBDView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            TreeDBView.LabelEdit = false;
            string name;
            // ===
            if (string.IsNullOrEmpty(e.Label))
            {
                name = e.Node.Text;
            }
            else
            {
                name = e.Label;
            }
            // ==== группа
            if(TreeDBView.SelectedNode.ImageIndex == 3)
            {
                TreeDBView.SelectedNode.ImageIndex = 1;
            }
            if (TreeDBView.SelectedNode.ImageIndex == 1)
            {
                if (Directory.Exists(e.Node.Name))
                {
                    string last_name = e.Node.Name;
                    e.Node.Name = Path.Combine(e.Node.Parent.Name, name);
                    TreeDBView.SelectedNode = e.Node;
                    Directory.Move(last_name, e.Node.Name);

                    // === Меняем все дочерним элементам поле Name

                    foreach (TreeNode node in TreeDBView.SelectedNode.Nodes)
                    {
                        if (node.ImageIndex == 1)
                        {
                            node.Name = Path.Combine(node.Parent.Name, node.Text);
                        }
                        else
                        {
                            node.Name = Path.Combine(node.Parent.Name, node.Text + ".stl");
                        }
                    }
                    // ===
                }
                else
                { 
                    e.Node.Name = Path.Combine(e.Node.Parent.Name, name);
                    TreeDBView.SelectedNode = e.Node;
                    if (!Directory.Exists(e.Node.Name))
                    {
                        Directory.CreateDirectory(e.Node.Name);
                    }
                    else 
                    {
                        MessageBox.Show(Language.Error("this_group_exists"), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Node.Remove();
                    }
                }
             }
            // ==== модель
            if (TreeDBView.SelectedNode.ImageIndex == 2)
            {
                string last_name = e.Node.Name;
                e.Node.Name = Path.Combine(e.Node.Parent.Name, name + ".stl");
                TreeDBView.SelectedNode = e.Node;
                if (!File.Exists(e.Node.Name))
                {
                    File.Move(last_name, e.Node.Name);
                }
            }

        }

        /// <summary>
        /// Событие добавления нового узла тип группа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddGroup_ContextMenuTreeDBView_Click(object sender, EventArgs e)
        {
            AddNodeGroup();
        }

        /// <summary>
        /// Событие удаление выбранного узла тип группа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveGroup_ContextMenuTreeDBView_Click(object sender, EventArgs e)
        {
            RemoveNodeGroup();
        }

        /// <summary>
        /// Событие добавления нового узла тип модель
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddModel_ContextMenuTreeDBView_Click(object sender, EventArgs e)
        {
            AddNodeModel();
        }

        /// <summary>
        /// Событие удаление выбранного узла тип модель
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveModel_ContextMenuTreeDBView_Click(object sender, EventArgs e)
        {
            RemoveNodeModel();
        }

        /// <summary>
        /// Событие перемещения узла на 1 уровень вверх
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpLevel_ContextMenuTreeDBView_Click(object sender, EventArgs e)
        {
            UpLevelNode();            
        }

        /// <summary>
        /// Событие перемещение узла на 1 уровень вниз
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownLevel_ContextMenuTreeDBView_Click(object sender, EventArgs e)
        {
            DownLevelNode();
        }

        /// <summary>
        /// Событие переименования узла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rename_ContextMenuTreeDBView_Click(object sender, EventArgs e)
        {
            RenameNode();
        }

        /// <summary>
        /// Горячие клавиши дерева БД
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeBDView_KeyUp(object sender, KeyEventArgs e)
        {
            // ---
            if (e.KeyCode == Keys.F1)
            {
                ShowHelp();
            }
            // ---
            if (e.KeyCode == Keys.Enter)
            {
                TreeDBView.SelectedNode.EndEdit(true);
            }
        }

        /// <summary>
        /// Событие на дереве до редактирования лейбела
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeDBView_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            TreeDBView.SelectedNode = TreeDBView.SelectedNode;
        }

        /// <summary>
        /// Экспорт Базы Моделей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportModelBase_ContextMenuTreeDBView_Click(object sender, EventArgs e)
        {
            ExportModelBase();
        }

        /// <summary>
        /// Импорт Базы Моделей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportModelBase_ContextMenuTreeDBView_Click(object sender, EventArgs e)
        {
            ImportModelBase();
        }

        #endregion

        /// <summary>
        /// Метод переименовывает элемент дерева
        /// </summary>
        private void RenameNode()
        {
            if (TreeDBView.SelectedNode == null)
                return;         

            // --- Запрещаем удалять и переименовывать корневой узел
            if (TreeDBView.SelectedNode.Name == pathDataModel || TreeDBView.SelectedNode.Name == pathDataModel && File.Exists(TreeDBView.SelectedNode.Name))
            {
                Rename_ContextMenuTreeDBView.Enabled = false;
                Rename_MenuItem.Enabled = Rename_ContextMenuTreeDBView.Enabled;
            }
            else
            {
                Rename_ContextMenuTreeDBView.Enabled = true;
                Rename_MenuItem.Enabled = Rename_ContextMenuTreeDBView.Enabled;
                TreeDBView.LabelEdit = true;
                TreeDBView.SelectedNode.BeginEdit();
            }
        }

        /// <summary>
        /// Метод перемещает выделенный узел на 1 уровень вверх
        /// </summary>
        private void UpLevelNode()
        {
            if (TreeDBView.SelectedNode != null
                && TreeDBView.SelectedNode.Parent != null
                && TreeDBView.SelectedNode.Parent.Name != pathDataModel)
            {

                // define edit collection
                TreeNodeCollection editNodes;
                if (TreeDBView.SelectedNode.Parent.Parent != null)
                    editNodes = TreeDBView.SelectedNode.Parent.Parent.Nodes;
                else
                    editNodes = TreeDBView.Nodes;

                // store node
                TreeNode selectedNode = TreeDBView.SelectedNode;

                // define indexes
                int indexSelectedNode = TreeDBView.SelectedNode.Index;
                int indexParentNode = TreeDBView.SelectedNode.Parent.Index;

                // ==== 
                if (TreeDBView.SelectedNode.Parent.ImageIndex == 1 && TreeDBView.SelectedNode.Parent.Nodes.Count == 1)
                {
                    TreeDBView.SelectedNode.Parent.ImageIndex = 3;
                }
                // move node
                TreeDBView.SelectedNode.Parent.Nodes.Remove(selectedNode);
                editNodes.Insert(indexParentNode + 1, selectedNode);

                // select node
                TreeDBView.SelectedNode = selectedNode;

                // ==== Move item in OS
                MoveItem();
            }
        }

        /// <summary>
        /// Метод перемещает выделенный узел на 1 уровень вниз
        /// </summary>
        private void DownLevelNode()
        {
            if (TreeDBView.SelectedNode != null && TreeDBView.SelectedNode.PrevNode != null)
            {
                if (TreeDBView.SelectedNode.PrevNode != null && TreeDBView.SelectedNode.PrevNode.ImageIndex == 2)
                    return;
                // define edit collection
                TreeNodeCollection editNodes;
                if (TreeDBView.SelectedNode.Parent != null)
                    editNodes = TreeDBView.SelectedNode.Parent.Nodes;
                else
                    editNodes = TreeDBView.Nodes;

                // store node
                TreeNode selectedNode = TreeDBView.SelectedNode;
                TreeNode previousNode = selectedNode.PrevNode;

                // move node
                editNodes.Remove(selectedNode);
                previousNode.Nodes.Add(selectedNode);
 
                // select node
                TreeDBView.SelectedNode = selectedNode;

                // ==== 
                if(TreeDBView.SelectedNode.Parent.ImageIndex == 3 && TreeDBView.SelectedNode.Parent.Nodes.Count >0)
                {
                    TreeDBView.SelectedNode.Parent.ImageIndex = 1;
                }

                // ==== Move item in OS
                    MoveItem();
            }
        }

        #region Методы для объекта группа моделей

        /// <summary>
        /// Метод добавляет в дерево узел тип группа
        /// </summary>
        private void AddNodeGroup()
        {
            // --- Дерево
            TreeNode node = new TreeNode("Введите текст");
            node.ImageIndex = 3;
            if (TreeDBView.SelectedNode != null)
            {
                TreeDBView.SelectedNode.Nodes.Add(node);
                TreeDBView.SelectedNode.Expand();
            }
            else
            {
                if (TreeDBView.Nodes.Count > 0)
                {
                    TreeDBView.Nodes.Add(node);
                }
            }
            TreeDBView.LabelEdit = true;
            node.BeginEdit();
        }

        /// <summary>
        /// Метод удаляет выделенный узел тип группа
        /// </summary>
        private void RemoveNodeGroup()
        {
            Init();
            model.Clear();
            DrawScene();
            SceneWidget.Hide();
            try
            {
                // --- Дерево
                if (TreeDBView.SelectedNode == null)
                    return;
                if (TreeDBView.SelectedNode.ImageIndex == 1)
                {
                    if (MessageBox.Show(Language.Error("delete_group_with_files"), Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                }
                else
                {
                    if (MessageBox.Show(Language.Error("delete_group"), Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;
                }
                Directory.Delete(TreeDBView.SelectedNode.Name, true);
                TreeDBView.SelectedNode.Remove();
                if(TreeDBView.SelectedNode.Nodes.Count == 0)
                {
                    TreeDBView.SelectedNode.ImageIndex = 3;
                }
            }
            catch (Exception ex)
            {
                TreeDBView.SelectedNode = FindNodeByName(TreeDBView.SelectedNode.Name);
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SceneWidget.Show();
            }
        }
        #endregion

        /// <summary>
        /// Метод добавляет в дерево модель
        /// </summary>
        private void AddNodeModel()
        {
            // --- Поулчаем имя файла и путь к нему
            openFileModelDialog.Filter = "STL files(*.stl)|*.stl|All files(*.*)|*.*";
            openFileModelDialog.FileName = "";
            if (openFileModelDialog.ShowDialog() == DialogResult.Cancel)
                return;
            SceneWidget.Hide();
            string pathToModel = null;
            try
            {
                // --- Дерево
                if (TreeDBView.SelectedNode != null)
                {
                    if (File.Exists(TreeDBView.SelectedNode.Name))
                    {
                        pathToModel = Path.Combine(TreeDBView.SelectedNode.Parent.Name, Path.GetFileName(openFileModelDialog.FileName));
                        File.Copy(openFileModelDialog.FileName, pathToModel);
                        TreeDBView.SelectedNode.Parent.Nodes.Add(pathToModel, Path.GetFileNameWithoutExtension(pathToModel), 2);
                        TreeDBView.SelectedNode = FindNodeByName(TreeDBView.SelectedNode.Parent, Path.GetFileNameWithoutExtension(pathToModel));
                    }
                    else
                    {
                        pathToModel = Path.Combine(TreeDBView.SelectedNode.Name, Path.GetFileName(openFileModelDialog.FileName));
                        File.Copy(openFileModelDialog.FileName, pathToModel);
                        TreeDBView.SelectedNode.Nodes.Add(pathToModel, Path.GetFileNameWithoutExtension(pathToModel), 2);
                        TreeDBView.SelectedNode = FindNodeByName(TreeDBView.SelectedNode, Path.GetFileNameWithoutExtension(pathToModel));
                    }
                }
                else
                {
                    pathToModel = Path.Combine(pathDataModel, Path.GetFileName(openFileModelDialog.FileName));
                    File.Copy(openFileModelDialog.FileName, pathToModel);
                    TreeDBView.Nodes.Add(pathToModel, Path.GetFileNameWithoutExtension(pathToModel), 2);
                    TreeDBView.SelectedNode = FindNodeByName(TreeDBView.SelectedNode, Path.GetFileNameWithoutExtension(pathToModel));
                }
                if(TreeDBView.SelectedNode.Parent.ImageIndex == 3)
                {
                    TreeDBView.SelectedNode.Parent.ImageIndex = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SceneWidget.Show();
    }

        /// <summary>
        /// Метод удаляет выделенный узел тип модель
        /// </summary>
        private void RemoveNodeModel()
        { 
            SceneWidget.Hide();
            // --- Дерево
            if (TreeDBView.SelectedNode == null)
                return;
            try
            {
                // Удаляем только узлы только типа модель
                if (TreeDBView.SelectedNode.ImageIndex == 2)
                {
                    if (MessageBox.Show(Language.Error("delete_model"), Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        File.Delete(TreeDBView.SelectedNode.Name);
                        TreeDBView.SelectedNode.Remove();
                    }
                }
                if (TreeDBView.SelectedNode.ImageIndex == 1 && TreeDBView.SelectedNode.Nodes.Count == 0)
                {
                    TreeDBView.SelectedNode.ImageIndex = 3;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SceneWidget.Show();
            }
        }

        #region Реализация вспомогательных методов

        /// <summary>
        /// Метод возвращает по родительскому узлу и по имени объект узел
        /// </summary>
        /// <param name="root"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        TreeNode FindNodeByName(TreeNode root, string name)
        {
            if (root == null) return null;
            if (root.Text == name) return root;
            return FindNodeByName(root.FirstNode, name) ?? FindNodeByName(root.NextNode, name);
        }

        /// <summary>
        /// Метод возвращает по имени объект узел
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        TreeNode FindNodeByName(string name)
        {
            return FindNodeByName(TreeDBView.TopNode, name);
        }

        /// <summary>
        /// Пермещение объектов вверх/вниз
        /// </summary>
        private void MoveItem()
        {
            try
            {
                string last_name;
                // === Move group
                if (TreeDBView.SelectedNode.ImageIndex == 1)
                {
                    last_name = TreeDBView.SelectedNode.Name;
                    TreeDBView.SelectedNode.Name = Path.Combine(TreeDBView.SelectedNode.Parent.Name, TreeDBView.SelectedNode.Text);
                    Directory.Move(last_name, TreeDBView.SelectedNode.Name);
                }

                // === Move model
                if (TreeDBView.SelectedNode.ImageIndex == 2)
                {
                    last_name = TreeDBView.SelectedNode.Name;
                    TreeDBView.SelectedNode.Name = Path.Combine(TreeDBView.SelectedNode.Parent.Name, TreeDBView.SelectedNode.Text + ".stl");
                    File.Move(last_name, TreeDBView.SelectedNode.Name);
                }
            }
            catch (Exception ex)
            {
                ScanRootDir(pathDataModel);
                SceneWidget.Hide();
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                SceneWidget.Show();
            }

        }

        /// <summary>
        /// Выводим в статус линию имя загруженного файла
        /// </summary>
        private void ShowNameModelStatusLine()
        {
            NameLoadModel.Text = string.Empty;
            if (TreeDBView.SelectedNode.ImageIndex == 2)
            {
                NameLoadModel.Text = Path.GetFileName(TreeDBView.SelectedNode.Name); // получаем имя модели
            }
        }

        #endregion

        #region Экспорт/Импорт Базы Моделей

        /// <summary>
        /// Экспорт Базы Моделей
        /// </summary>
        private void ExportModelBase()
        {
            // ===
            SceneWidget.Hide();
            saveFileModelDialog.Filter = "ZIP files(*.zip)|*.zip|All files(*.*)|*.*";
            saveFileModelDialog.FileName = "";
            if (saveFileModelDialog.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            try
            {
               ZipFile.CreateFromDirectory(pathDataModel, saveFileModelDialog.FileName, CompressionLevel.Fastest, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SceneWidget.Show();
            }
        }

        /// <summary>
        /// Импорт Базы Моделей
        /// </summary>
        private void ImportModelBase()
        {
            // ===
            SceneWidget.Hide();
            openFileModelDialog.Filter = "ZIP files(*.zip)|*.zip|All files(*.*)|*.*";
            openFileModelDialog.FileName = "";
            if (openFileModelDialog.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            try
            {
                if (Directory.Exists(pathDataModel))
                {
                    Directory.Delete(pathDataModel, true);
                }
                ZipFile.ExtractToDirectory(openFileModelDialog.FileName, Path.GetDirectoryName(pathDataModel));
                ScanRootDir(pathDataModel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SceneWidget.Show();
            }
        }

        #endregion
    }
}
