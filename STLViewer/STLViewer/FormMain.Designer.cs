namespace STLViewer
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TreeDBView = new System.Windows.Forms.TreeView();
            this.contextMenuTreeView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddGroup_ContextMenuTreeDBView = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveGroup_ContextMenuTreeDBView = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.AddModel_ContextMenuTreeDBView = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveModel_ContextMenuTreeDBView = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.UpLevel_ContextMenuTreeDBView = new System.Windows.Forms.ToolStripMenuItem();
            this.DownLevel_ContextMenuTreeDBView = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.Rename_ContextMenuTreeDBView = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListDB = new System.Windows.Forms.ImageList(this.components);
            this.panelLegend = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SceneWidget = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.openFileModelDialog = new System.Windows.Forms.OpenFileDialog();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.File_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenModel_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportPicture_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Settings_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Close_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.View_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ResetViiew_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OptimizateView_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ColorModel_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ColorBackground_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HideLegend_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowLegend_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Database_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddGroup_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveGroup_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.AddModel_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveModel_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.UpLevel_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DownLevel_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.Rename_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Help_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowHelp_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.About_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusLine = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.SelectLanguage = new System.Windows.Forms.ToolStripDropDownButton();
            this.Rus_SelectItem = new System.Windows.Forms.ToolStripMenuItem();
            this.English_SelectItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.NameLoadModel = new System.Windows.Forms.ToolStripStatusLabel();
            this.saveFileModelDialog = new System.Windows.Forms.SaveFileDialog();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuTreeView.SuspendLayout();
            this.panelLegend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.MainMenu.SuspendLayout();
            this.statusLine.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TreeDBView);
            this.splitContainer1.Panel1.Controls.Add(this.panelLegend);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.SceneWidget);
            this.splitContainer1.Size = new System.Drawing.Size(920, 521);
            this.splitContainer1.SplitterDistance = 234;
            this.splitContainer1.TabIndex = 5;
            // 
            // TreeDBView
            // 
            this.TreeDBView.ContextMenuStrip = this.contextMenuTreeView;
            this.TreeDBView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeDBView.ImageIndex = 0;
            this.TreeDBView.ImageList = this.imageListDB;
            this.TreeDBView.Location = new System.Drawing.Point(0, 0);
            this.TreeDBView.Name = "TreeDBView";
            this.TreeDBView.SelectedImageIndex = 0;
            this.TreeDBView.Size = new System.Drawing.Size(234, 435);
            this.TreeDBView.TabIndex = 5;
            this.TreeDBView.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.TreeBDView_AfterLabelEdit);
            this.TreeDBView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeDBView_AfterSelect);
            this.TreeDBView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TreeBDView_KeyUp);
            // 
            // contextMenuTreeView
            // 
            this.contextMenuTreeView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddGroup_ContextMenuTreeDBView,
            this.RemoveGroup_ContextMenuTreeDBView,
            this.toolStripSeparator1,
            this.AddModel_ContextMenuTreeDBView,
            this.RemoveModel_ContextMenuTreeDBView,
            this.toolStripSeparator2,
            this.UpLevel_ContextMenuTreeDBView,
            this.DownLevel_ContextMenuTreeDBView,
            this.toolStripSeparator3,
            this.Rename_ContextMenuTreeDBView});
            this.contextMenuTreeView.Name = "contextMenuTreeView";
            this.contextMenuTreeView.Size = new System.Drawing.Size(160, 176);
            // 
            // AddGroup_ContextMenuTreeDBView
            // 
            this.AddGroup_ContextMenuTreeDBView.Name = "AddGroup_ContextMenuTreeDBView";
            this.AddGroup_ContextMenuTreeDBView.Size = new System.Drawing.Size(159, 22);
            this.AddGroup_ContextMenuTreeDBView.Text = "Add group";
            this.AddGroup_ContextMenuTreeDBView.Click += new System.EventHandler(this.AddGroup_ContextMenuTreeDBView_Click);
            // 
            // RemoveGroup_ContextMenuTreeDBView
            // 
            this.RemoveGroup_ContextMenuTreeDBView.Name = "RemoveGroup_ContextMenuTreeDBView";
            this.RemoveGroup_ContextMenuTreeDBView.Size = new System.Drawing.Size(159, 22);
            this.RemoveGroup_ContextMenuTreeDBView.Text = "Remove group";
            this.RemoveGroup_ContextMenuTreeDBView.Click += new System.EventHandler(this.RemoveGroup_ContextMenuTreeDBView_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(156, 6);
            // 
            // AddModel_ContextMenuTreeDBView
            // 
            this.AddModel_ContextMenuTreeDBView.Name = "AddModel_ContextMenuTreeDBView";
            this.AddModel_ContextMenuTreeDBView.Size = new System.Drawing.Size(159, 22);
            this.AddModel_ContextMenuTreeDBView.Text = "Add model";
            this.AddModel_ContextMenuTreeDBView.Click += new System.EventHandler(this.AddModel_ContextMenuTreeDBView_Click);
            // 
            // RemoveModel_ContextMenuTreeDBView
            // 
            this.RemoveModel_ContextMenuTreeDBView.Name = "RemoveModel_ContextMenuTreeDBView";
            this.RemoveModel_ContextMenuTreeDBView.Size = new System.Drawing.Size(159, 22);
            this.RemoveModel_ContextMenuTreeDBView.Text = "Remove model";
            this.RemoveModel_ContextMenuTreeDBView.Click += new System.EventHandler(this.RemoveModel_ContextMenuTreeDBView_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(156, 6);
            // 
            // UpLevel_ContextMenuTreeDBView
            // 
            this.UpLevel_ContextMenuTreeDBView.Name = "UpLevel_ContextMenuTreeDBView";
            this.UpLevel_ContextMenuTreeDBView.Size = new System.Drawing.Size(159, 22);
            this.UpLevel_ContextMenuTreeDBView.Text = "Up level item";
            this.UpLevel_ContextMenuTreeDBView.Click += new System.EventHandler(this.UpLevel_ContextMenuTreeDBView_Click);
            // 
            // DownLevel_ContextMenuTreeDBView
            // 
            this.DownLevel_ContextMenuTreeDBView.Name = "DownLevel_ContextMenuTreeDBView";
            this.DownLevel_ContextMenuTreeDBView.Size = new System.Drawing.Size(159, 22);
            this.DownLevel_ContextMenuTreeDBView.Text = "Down level item";
            this.DownLevel_ContextMenuTreeDBView.Click += new System.EventHandler(this.DownLevel_ContextMenuTreeDBView_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(156, 6);
            // 
            // Rename_ContextMenuTreeDBView
            // 
            this.Rename_ContextMenuTreeDBView.Name = "Rename_ContextMenuTreeDBView";
            this.Rename_ContextMenuTreeDBView.Size = new System.Drawing.Size(159, 22);
            this.Rename_ContextMenuTreeDBView.Text = "Rename";
            this.Rename_ContextMenuTreeDBView.Click += new System.EventHandler(this.Rename_ContextMenuTreeDBView_Click);
            // 
            // imageListDB
            // 
            this.imageListDB.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListDB.ImageStream")));
            this.imageListDB.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListDB.Images.SetKeyName(0, "Ярлык16.png");
            this.imageListDB.Images.SetKeyName(1, "assembly.png");
            this.imageListDB.Images.SetKeyName(2, "part.png");
            // 
            // panelLegend
            // 
            this.panelLegend.Controls.Add(this.pictureBox1);
            this.panelLegend.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelLegend.Location = new System.Drawing.Point(0, 435);
            this.panelLegend.Name = "panelLegend";
            this.panelLegend.Size = new System.Drawing.Size(234, 86);
            this.panelLegend.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(234, 86);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // SceneWidget
            // 
            this.SceneWidget.AccumBits = ((byte)(0));
            this.SceneWidget.AutoCheckErrors = false;
            this.SceneWidget.AutoFinish = false;
            this.SceneWidget.AutoMakeCurrent = true;
            this.SceneWidget.AutoSwapBuffers = true;
            this.SceneWidget.BackColor = System.Drawing.Color.White;
            this.SceneWidget.ColorBits = ((byte)(32));
            this.SceneWidget.DepthBits = ((byte)(16));
            this.SceneWidget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SceneWidget.Location = new System.Drawing.Point(0, 0);
            this.SceneWidget.Name = "SceneWidget";
            this.SceneWidget.Size = new System.Drawing.Size(682, 521);
            this.SceneWidget.StencilBits = ((byte)(0));
            this.SceneWidget.TabIndex = 5;
            this.SceneWidget.Paint += new System.Windows.Forms.PaintEventHandler(this.SceneWidget_Paint);
            this.SceneWidget.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SceneWidget_KeyDown);
            this.SceneWidget.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SceneWidget_MouseMove);
            this.SceneWidget.Resize += new System.EventHandler(this.SceneWidget_Resize);
            // 
            // openFileModelDialog
            // 
            this.openFileModelDialog.FileName = "openFileDialog1";
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File_MenuItem,
            this.View_MenuItem,
            this.Database_MenuItem,
            this.Help_MenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(920, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip1";
            // 
            // File_MenuItem
            // 
            this.File_MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenModel_MenuItem,
            this.ExportPicture_MenuItem,
            this.Settings_MenuItem,
            this.Close_MenuItem});
            this.File_MenuItem.Name = "File_MenuItem";
            this.File_MenuItem.Size = new System.Drawing.Size(37, 20);
            this.File_MenuItem.Text = "File";
            // 
            // OpenModel_MenuItem
            // 
            this.OpenModel_MenuItem.Name = "OpenModel_MenuItem";
            this.OpenModel_MenuItem.Size = new System.Drawing.Size(159, 22);
            this.OpenModel_MenuItem.Text = "Open...";
            this.OpenModel_MenuItem.Click += new System.EventHandler(this.OpenModel_MenuItem_Click);
            // 
            // ExportPicture_MenuItem
            // 
            this.ExportPicture_MenuItem.Name = "ExportPicture_MenuItem";
            this.ExportPicture_MenuItem.Size = new System.Drawing.Size(159, 22);
            this.ExportPicture_MenuItem.Text = "Export Picture ...";
            this.ExportPicture_MenuItem.Click += new System.EventHandler(this.ExportPicture_MenuItem_Click);
            // 
            // Settings_MenuItem
            // 
            this.Settings_MenuItem.Name = "Settings_MenuItem";
            this.Settings_MenuItem.Size = new System.Drawing.Size(159, 22);
            this.Settings_MenuItem.Text = "Settings ...";
            this.Settings_MenuItem.Click += new System.EventHandler(this.Settings_MenuItem_Click);
            // 
            // Close_MenuItem
            // 
            this.Close_MenuItem.Name = "Close_MenuItem";
            this.Close_MenuItem.Size = new System.Drawing.Size(159, 22);
            this.Close_MenuItem.Text = "Close";
            this.Close_MenuItem.Click += new System.EventHandler(this.Close_MenuItem_Click);
            // 
            // View_MenuItem
            // 
            this.View_MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ResetViiew_MenuItem,
            this.OptimizateView_MenuItem,
            this.ColorModel_MenuItem,
            this.ColorBackground_MenuItem,
            this.HideLegend_MenuItem,
            this.ShowLegend_MenuItem});
            this.View_MenuItem.Name = "View_MenuItem";
            this.View_MenuItem.Size = new System.Drawing.Size(44, 20);
            this.View_MenuItem.Text = "View";
            // 
            // ResetViiew_MenuItem
            // 
            this.ResetViiew_MenuItem.Name = "ResetViiew_MenuItem";
            this.ResetViiew_MenuItem.Size = new System.Drawing.Size(182, 22);
            this.ResetViiew_MenuItem.Text = "Reset View";
            this.ResetViiew_MenuItem.Click += new System.EventHandler(this.ResetViiew_MenuItem_Click);
            // 
            // OptimizateView_MenuItem
            // 
            this.OptimizateView_MenuItem.Name = "OptimizateView_MenuItem";
            this.OptimizateView_MenuItem.Size = new System.Drawing.Size(182, 22);
            this.OptimizateView_MenuItem.Text = "Centering View";
            this.OptimizateView_MenuItem.Click += new System.EventHandler(this.OptimizateView_MenuItem_Click);
            // 
            // ColorModel_MenuItem
            // 
            this.ColorModel_MenuItem.Name = "ColorModel_MenuItem";
            this.ColorModel_MenuItem.Size = new System.Drawing.Size(182, 22);
            this.ColorModel_MenuItem.Text = "Color Model ...";
            this.ColorModel_MenuItem.Click += new System.EventHandler(this.ColorModel_MenuItem_Click);
            // 
            // ColorBackground_MenuItem
            // 
            this.ColorBackground_MenuItem.Name = "ColorBackground_MenuItem";
            this.ColorBackground_MenuItem.Size = new System.Drawing.Size(182, 22);
            this.ColorBackground_MenuItem.Text = "Color Background ...";
            this.ColorBackground_MenuItem.Click += new System.EventHandler(this.ColorBackground_MenuItem_Click);
            // 
            // HideLegend_MenuItem
            // 
            this.HideLegend_MenuItem.Name = "HideLegend_MenuItem";
            this.HideLegend_MenuItem.Size = new System.Drawing.Size(182, 22);
            this.HideLegend_MenuItem.Text = "Hide legend";
            this.HideLegend_MenuItem.Click += new System.EventHandler(this.HideLegend_MenuItem_Click);
            // 
            // ShowLegend_MenuItem
            // 
            this.ShowLegend_MenuItem.Name = "ShowLegend_MenuItem";
            this.ShowLegend_MenuItem.Size = new System.Drawing.Size(182, 22);
            this.ShowLegend_MenuItem.Text = "Show legend";
            this.ShowLegend_MenuItem.Visible = false;
            this.ShowLegend_MenuItem.Click += new System.EventHandler(this.ShowLegend_MenuItem_Click);
            // 
            // Database_MenuItem
            // 
            this.Database_MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddGroup_MenuItem,
            this.RemoveGroup_MenuItem,
            this.toolStripSeparator4,
            this.AddModel_MenuItem,
            this.RemoveModel_MenuItem,
            this.toolStripSeparator5,
            this.UpLevel_MenuItem,
            this.DownLevel_MenuItem,
            this.toolStripSeparator6,
            this.Rename_MenuItem});
            this.Database_MenuItem.Name = "Database_MenuItem";
            this.Database_MenuItem.Size = new System.Drawing.Size(77, 20);
            this.Database_MenuItem.Text = "ModelBase";
            // 
            // AddGroup_MenuItem
            // 
            this.AddGroup_MenuItem.Name = "AddGroup_MenuItem";
            this.AddGroup_MenuItem.Size = new System.Drawing.Size(159, 22);
            this.AddGroup_MenuItem.Text = "Add group";
            this.AddGroup_MenuItem.Click += new System.EventHandler(this.AddGroup_MenuItem_Click);
            // 
            // RemoveGroup_MenuItem
            // 
            this.RemoveGroup_MenuItem.Name = "RemoveGroup_MenuItem";
            this.RemoveGroup_MenuItem.Size = new System.Drawing.Size(159, 22);
            this.RemoveGroup_MenuItem.Text = "Remove group";
            this.RemoveGroup_MenuItem.Click += new System.EventHandler(this.RemoveGroup_MenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(156, 6);
            // 
            // AddModel_MenuItem
            // 
            this.AddModel_MenuItem.Name = "AddModel_MenuItem";
            this.AddModel_MenuItem.Size = new System.Drawing.Size(159, 22);
            this.AddModel_MenuItem.Text = "Add model";
            this.AddModel_MenuItem.Click += new System.EventHandler(this.AddModel_MenuItem_Click);
            // 
            // RemoveModel_MenuItem
            // 
            this.RemoveModel_MenuItem.Name = "RemoveModel_MenuItem";
            this.RemoveModel_MenuItem.Size = new System.Drawing.Size(159, 22);
            this.RemoveModel_MenuItem.Text = "Remove model";
            this.RemoveModel_MenuItem.Click += new System.EventHandler(this.RemoveModel_MenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(156, 6);
            // 
            // UpLevel_MenuItem
            // 
            this.UpLevel_MenuItem.Name = "UpLevel_MenuItem";
            this.UpLevel_MenuItem.Size = new System.Drawing.Size(159, 22);
            this.UpLevel_MenuItem.Text = "Up level item";
            this.UpLevel_MenuItem.Click += new System.EventHandler(this.UpLevel_MenuItem_Click);
            // 
            // DownLevel_MenuItem
            // 
            this.DownLevel_MenuItem.Name = "DownLevel_MenuItem";
            this.DownLevel_MenuItem.Size = new System.Drawing.Size(159, 22);
            this.DownLevel_MenuItem.Text = "Down level item";
            this.DownLevel_MenuItem.Click += new System.EventHandler(this.DownLevel_MenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(156, 6);
            // 
            // Rename_MenuItem
            // 
            this.Rename_MenuItem.Name = "Rename_MenuItem";
            this.Rename_MenuItem.Size = new System.Drawing.Size(159, 22);
            this.Rename_MenuItem.Text = "Rename";
            // 
            // Help_MenuItem
            // 
            this.Help_MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowHelp_MenuItem,
            this.About_MenuItem});
            this.Help_MenuItem.Name = "Help_MenuItem";
            this.Help_MenuItem.Size = new System.Drawing.Size(44, 20);
            this.Help_MenuItem.Text = "Help";
            // 
            // ShowHelp_MenuItem
            // 
            this.ShowHelp_MenuItem.Name = "ShowHelp_MenuItem";
            this.ShowHelp_MenuItem.Size = new System.Drawing.Size(143, 22);
            this.ShowHelp_MenuItem.Text = "Show Help ...";
            this.ShowHelp_MenuItem.Click += new System.EventHandler(this.ShowHelp_MenuItem_Click);
            // 
            // About_MenuItem
            // 
            this.About_MenuItem.Name = "About_MenuItem";
            this.About_MenuItem.Size = new System.Drawing.Size(143, 22);
            this.About_MenuItem.Text = "About ...";
            this.About_MenuItem.Click += new System.EventHandler(this.About_MenuItem_Click);
            // 
            // statusLine
            // 
            this.statusLine.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.SelectLanguage,
            this.toolStripStatusLabel2,
            this.NameLoadModel});
            this.statusLine.Location = new System.Drawing.Point(0, 545);
            this.statusLine.Name = "statusLine";
            this.statusLine.Size = new System.Drawing.Size(920, 22);
            this.statusLine.TabIndex = 1;
            this.statusLine.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(65, 17);
            this.toolStripStatusLabel1.Text = "Language: ";
            // 
            // SelectLanguage
            // 
            this.SelectLanguage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SelectLanguage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Rus_SelectItem,
            this.English_SelectItem});
            this.SelectLanguage.Image = ((System.Drawing.Image)(resources.GetObject("SelectLanguage.Image")));
            this.SelectLanguage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SelectLanguage.Name = "SelectLanguage";
            this.SelectLanguage.Size = new System.Drawing.Size(58, 20);
            this.SelectLanguage.Text = "English";
            // 
            // Rus_SelectItem
            // 
            this.Rus_SelectItem.Name = "Rus_SelectItem";
            this.Rus_SelectItem.Size = new System.Drawing.Size(119, 22);
            this.Rus_SelectItem.Text = "Русский";
            this.Rus_SelectItem.Click += new System.EventHandler(this.Rus_SelectItem_Click);
            // 
            // English_SelectItem
            // 
            this.English_SelectItem.Name = "English_SelectItem";
            this.English_SelectItem.Size = new System.Drawing.Size(119, 22);
            this.English_SelectItem.Text = "English";
            this.English_SelectItem.Click += new System.EventHandler(this.English_SelectItem_Click);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(89, 17);
            this.toolStripStatusLabel2.Text = "Loaded model: ";
            // 
            // NameLoadModel
            // 
            this.NameLoadModel.Name = "NameLoadModel";
            this.NameLoadModel.Size = new System.Drawing.Size(41, 17);
            this.NameLoadModel.Text = "Empty";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(920, 567);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusLine);
            this.Controls.Add(this.MainMenu);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "STLViewer";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuTreeView.ResumeLayout(false);
            this.panelLegend.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.statusLine.ResumeLayout(false);
            this.statusLine.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.OpenFileDialog openFileModelDialog;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem File_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenModel_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExportPicture_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Settings_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem View_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Help_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowHelp_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem About_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem ResetViiew_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem OptimizateView_MenuItem;
        private System.Windows.Forms.StatusStrip statusLine;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripDropDownButton SelectLanguage;
        private System.Windows.Forms.ToolStripMenuItem Rus_SelectItem;
        private System.Windows.Forms.ToolStripMenuItem English_SelectItem;
        private System.Windows.Forms.ToolStripMenuItem Close_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem ColorModel_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem ColorBackground_MenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileModelDialog;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Tao.Platform.Windows.SimpleOpenGlControl SceneWidget;
        private System.Windows.Forms.ToolStripMenuItem Database_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddGroup_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveGroup_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddModel_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveModel_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem UpLevel_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem DownLevel_MenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuTreeView;
        private System.Windows.Forms.ToolStripMenuItem AddGroup_ContextMenuTreeDBView;
        private System.Windows.Forms.ToolStripMenuItem RemoveGroup_ContextMenuTreeDBView;
        private System.Windows.Forms.ToolStripMenuItem UpLevel_ContextMenuTreeDBView;
        private System.Windows.Forms.ToolStripMenuItem DownLevel_ContextMenuTreeDBView;
        private System.Windows.Forms.ToolStripMenuItem Rename_ContextMenuTreeDBView;
        private System.Windows.Forms.ToolStripMenuItem Rename_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddModel_ContextMenuTreeDBView;
        private System.Windows.Forms.ToolStripMenuItem RemoveModel_ContextMenuTreeDBView;
        private System.Windows.Forms.ImageList imageListDB;
        private System.Windows.Forms.ToolStripStatusLabel NameLoadModel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.TreeView TreeDBView;
        private System.Windows.Forms.Panel panelLegend;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem ShowLegend_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem HideLegend_MenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
    }
}

