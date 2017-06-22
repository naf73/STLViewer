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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Узел1");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Узел11");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Узел7", new System.Windows.Forms.TreeNode[] {
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Узел8");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Узел10");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Узел9", new System.Windows.Forms.TreeNode[] {
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Узел2", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Узел3");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Узел6");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Узел5", new System.Windows.Forms.TreeNode[] {
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Узел4", new System.Windows.Forms.TreeNode[] {
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Узел0", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode7,
            treeNode8,
            treeNode11});
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
            this.Database_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddGroup_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveGroup_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddModel_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveModel_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpLevel_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DownLevel_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Help_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowHelp_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.About_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusLine = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.SelectLanguage = new System.Windows.Forms.ToolStripDropDownButton();
            this.Rus_SelectItem = new System.Windows.Forms.ToolStripMenuItem();
            this.English_SelectItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileModelDialog = new System.Windows.Forms.SaveFileDialog();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TreeBDView = new System.Windows.Forms.TreeView();
            this.SceneWidget = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.MainMenu.SuspendLayout();
            this.statusLine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
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
            this.MainMenu.Size = new System.Drawing.Size(777, 24);
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
            this.ColorBackground_MenuItem});
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
            this.OptimizateView_MenuItem.Text = "Optimizate View";
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
            // Database_MenuItem
            // 
            this.Database_MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddGroup_MenuItem,
            this.RemoveGroup_MenuItem,
            this.AddModel_MenuItem,
            this.RemoveModel_MenuItem,
            this.UpLevel_MenuItem,
            this.DownLevel_MenuItem});
            this.Database_MenuItem.Name = "Database_MenuItem";
            this.Database_MenuItem.Size = new System.Drawing.Size(67, 20);
            this.Database_MenuItem.Text = "Database";
            // 
            // AddGroup_MenuItem
            // 
            this.AddGroup_MenuItem.Name = "AddGroup_MenuItem";
            this.AddGroup_MenuItem.Size = new System.Drawing.Size(159, 22);
            this.AddGroup_MenuItem.Text = "Add group";
            // 
            // RemoveGroup_MenuItem
            // 
            this.RemoveGroup_MenuItem.Name = "RemoveGroup_MenuItem";
            this.RemoveGroup_MenuItem.Size = new System.Drawing.Size(159, 22);
            this.RemoveGroup_MenuItem.Text = "Remove group";
            // 
            // AddModel_MenuItem
            // 
            this.AddModel_MenuItem.Name = "AddModel_MenuItem";
            this.AddModel_MenuItem.Size = new System.Drawing.Size(159, 22);
            this.AddModel_MenuItem.Text = "Add model";
            // 
            // RemoveModel_MenuItem
            // 
            this.RemoveModel_MenuItem.Name = "RemoveModel_MenuItem";
            this.RemoveModel_MenuItem.Size = new System.Drawing.Size(159, 22);
            this.RemoveModel_MenuItem.Text = "Remove model";
            // 
            // UpLevel_MenuItem
            // 
            this.UpLevel_MenuItem.Name = "UpLevel_MenuItem";
            this.UpLevel_MenuItem.Size = new System.Drawing.Size(159, 22);
            this.UpLevel_MenuItem.Text = "Up level item";
            // 
            // DownLevel_MenuItem
            // 
            this.DownLevel_MenuItem.Name = "DownLevel_MenuItem";
            this.DownLevel_MenuItem.Size = new System.Drawing.Size(159, 22);
            this.DownLevel_MenuItem.Text = "Down level item";
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
            this.ShowHelp_MenuItem.Size = new System.Drawing.Size(152, 22);
            this.ShowHelp_MenuItem.Text = "Show Help ...";
            this.ShowHelp_MenuItem.Click += new System.EventHandler(this.ShowHelp_MenuItem_Click);
            // 
            // About_MenuItem
            // 
            this.About_MenuItem.Name = "About_MenuItem";
            this.About_MenuItem.Size = new System.Drawing.Size(152, 22);
            this.About_MenuItem.Text = "About ...";
            this.About_MenuItem.Click += new System.EventHandler(this.About_MenuItem_Click);
            // 
            // statusLine
            // 
            this.statusLine.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.SelectLanguage});
            this.statusLine.Location = new System.Drawing.Point(0, 426);
            this.statusLine.Name = "statusLine";
            this.statusLine.Size = new System.Drawing.Size(777, 22);
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TreeBDView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.SceneWidget);
            this.splitContainer1.Size = new System.Drawing.Size(777, 402);
            this.splitContainer1.SplitterDistance = 259;
            this.splitContainer1.TabIndex = 5;
            // 
            // TreeBDView
            // 
            this.TreeBDView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeBDView.Location = new System.Drawing.Point(0, 0);
            this.TreeBDView.Name = "TreeBDView";
            treeNode1.Name = "Узел1";
            treeNode1.Text = "Узел1";
            treeNode2.Name = "Узел11";
            treeNode2.Text = "Узел11";
            treeNode3.Name = "Узел7";
            treeNode3.Text = "Узел7";
            treeNode4.Name = "Узел8";
            treeNode4.Text = "Узел8";
            treeNode5.Name = "Узел10";
            treeNode5.Text = "Узел10";
            treeNode6.Name = "Узел9";
            treeNode6.Text = "Узел9";
            treeNode7.Name = "Узел2";
            treeNode7.Text = "Узел2";
            treeNode8.Name = "Узел3";
            treeNode8.Text = "Узел3";
            treeNode9.Name = "Узел6";
            treeNode9.Text = "Узел6";
            treeNode10.Name = "Узел5";
            treeNode10.Text = "Узел5";
            treeNode11.Name = "Узел4";
            treeNode11.Text = "Узел4";
            treeNode12.Name = "Узел0";
            treeNode12.Text = "Узел0";
            this.TreeBDView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode12});
            this.TreeBDView.Size = new System.Drawing.Size(259, 402);
            this.TreeBDView.TabIndex = 3;
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
            this.SceneWidget.Size = new System.Drawing.Size(514, 402);
            this.SceneWidget.StencilBits = ((byte)(0));
            this.SceneWidget.TabIndex = 5;
            this.SceneWidget.Paint += new System.Windows.Forms.PaintEventHandler(this.SceneWidget_Paint);
            this.SceneWidget.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SceneWidget_KeyDown);
            this.SceneWidget.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SceneWidget_MouseMove);
            this.SceneWidget.Resize += new System.EventHandler(this.SceneWidget_Resize);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(777, 448);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusLine);
            this.Controls.Add(this.MainMenu);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.MainMenu;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.statusLine.ResumeLayout(false);
            this.statusLine.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
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
        private System.Windows.Forms.TreeView TreeBDView;
        private Tao.Platform.Windows.SimpleOpenGlControl SceneWidget;
        private System.Windows.Forms.ToolStripMenuItem Database_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddGroup_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveGroup_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddModel_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveModel_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem UpLevel_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem DownLevel_MenuItem;
    }
}

