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
        #region События TeeDBView

        /// <summary>
        /// Событие после выбора узла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeDBView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // --- To Do
            // можно использовать под загрузку картинки
            if (TreeDBView.SelectedNode == null)
                return;

            if (TreeDBView.SelectedNode.ImageIndex == 2)
            {
                SceneWidget.Show();
                Init();
                string name; // имя модели
                model = STLFormat.LoadBinary(TreeDBView.SelectedNode.Name, out name);
                NameLoadModel.Text = name; // получаем имя модели
                offset_model = ModelCenter(model); // получаем центр модели
                DrawScene();
            }
            else
            {
                Init();
                model.Clear();
                SceneWidget.Hide();
            }
        }

        private void TreeDBView_AfterCheck(object sender, TreeViewEventArgs e)
        {

        }

        /// <summary>
        /// Событие после завершения переименования узла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeBDView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            TreeDBView.LabelEdit = false;
            // ====
            if (TreeDBView.SelectedNode.ImageIndex == 1)
            {
                if (Directory.Exists(e.Node.Name))
                {
                    string last_name = e.Node.Name;
                    e.Node.Name = Path.Combine(e.Node.Parent.Name, e.Label);
                    TreeDBView.SelectedNode = e.Node;
                    Directory.Move(last_name, e.Node.Name);
                    
                    // === Меняем все дочерним элементам поле Name



                    // ===

                }
                else
                { 
                    e.Node.Name = Path.Combine(e.Node.Parent.Name, e.Label);
                    TreeDBView.SelectedNode = e.Node;
                    Directory.CreateDirectory(e.Node.Name);
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
            if (e.KeyCode == Keys.F2)
            {
                RenameNode();
            }
        }

        #endregion

        /// <summary>
        /// Метод переименовывает элемент дерева
        /// </summary>
        private void RenameNode()
        {
            if (TreeDBView.SelectedNode == null)
                return;

            TreeDBView.LabelEdit = true;
            TreeDBView.SelectedNode.BeginEdit();
        }

        /// <summary>
        /// Метод перемещает выделенный узел на 1 уровень вверх
        /// </summary>
        private void UpLevelNode()
        {
            if (TreeDBView.SelectedNode != null
                && TreeDBView.SelectedNode.Parent != null)
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

                // move node
                TreeDBView.SelectedNode.Parent.Nodes.Remove(selectedNode);
                editNodes.Insert(indexParentNode + 1, selectedNode);

                // select node
                TreeDBView.SelectedNode = selectedNode;
            }
        }

        /// <summary>
        /// Метод перемещает выделенный узел на 1 уровень вниз
        /// </summary>
        private void DownLevelNode()
        {
            if (TreeDBView.SelectedNode != null
                && TreeDBView.SelectedNode.PrevNode != null)
            {

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
            node.ImageIndex = 1;
            if (TreeDBView.SelectedNode != null)
            {
                TreeDBView.SelectedNode.Nodes.Add(node);
                TreeDBView.SelectedNode.Expand();
            }
            else
            {
                TreeDBView.Nodes.Add(node);
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
                if (MessageBox.Show("Удалить группу?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Directory.Delete(TreeDBView.SelectedNode.Name, true);
                    TreeDBView.SelectedNode.Remove();
                }
            }
            catch (Exception ex)
            {
                TreeDBView.SelectedNode = FindNodeByName(TreeDBView.SelectedNode.Name);
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SceneWidget.Show();

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
            // --- Дерево
            if (TreeDBView.SelectedNode == null)
                return;
            
            // Удаляем только узлы только типа модель
            if (TreeDBView.SelectedNode.ImageIndex == 2)
            {
                
                SceneWidget.Hide();
                if (MessageBox.Show("Удалить модель?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    File.Delete(TreeDBView.SelectedNode.Name);
                    TreeDBView.SelectedNode.Remove();
                }
                SceneWidget.Show();
            }
        }

        /// <summary>
        /// Метод возвращает по имени объект узел
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
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        TreeNode FindNodeByName(string name)
        {
            return FindNodeByName(TreeDBView.TopNode, name);
        }
    }
}
