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
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Узел1");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Узел11");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Узел7", new System.Windows.Forms.TreeNode[] {
            treeNode14});
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Узел8");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Узел10");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Узел9", new System.Windows.Forms.TreeNode[] {
            treeNode17});
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Узел2", new System.Windows.Forms.TreeNode[] {
            treeNode15,
            treeNode16,
            treeNode18});
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Узел3");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Узел6");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Узел5", new System.Windows.Forms.TreeNode[] {
            treeNode21});
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Узел4", new System.Windows.Forms.TreeNode[] {
            treeNode22});
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Узел0", new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode19,
            treeNode20,
            treeNode23});
            this.openFileModelDialog = new System.Windows.Forms.OpenFileDialog();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportPictureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optimizateViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.SelectLanguage = new System.Windows.Forms.ToolStripDropDownButton();
            this.SelectRus = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectEng = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SceneWidget = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.MainMenu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileModelDialog
            // 
            this.openFileModelDialog.FileName = "openFileDialog1";
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(930, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exportPictureToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.openToolStripMenuItem.Text = "Open...";
            // 
            // exportPictureToolStripMenuItem
            // 
            this.exportPictureToolStripMenuItem.Name = "exportPictureToolStripMenuItem";
            this.exportPictureToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.exportPictureToolStripMenuItem.Text = "Export Picture ...";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetViewToolStripMenuItem,
            this.optimizateViewToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // resetViewToolStripMenuItem
            // 
            this.resetViewToolStripMenuItem.Name = "resetViewToolStripMenuItem";
            this.resetViewToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.resetViewToolStripMenuItem.Text = "Reset View";
            // 
            // optimizateViewToolStripMenuItem
            // 
            this.optimizateViewToolStripMenuItem.Name = "optimizateViewToolStripMenuItem";
            this.optimizateViewToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.optimizateViewToolStripMenuItem.Text = "Optimizate View";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.SelectLanguage});
            this.statusStrip1.Location = new System.Drawing.Point(0, 508);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(930, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
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
            this.SelectRus,
            this.SelectEng});
            this.SelectLanguage.Image = ((System.Drawing.Image)(resources.GetObject("SelectLanguage.Image")));
            this.SelectLanguage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SelectLanguage.Name = "SelectLanguage";
            this.SelectLanguage.Size = new System.Drawing.Size(58, 20);
            this.SelectLanguage.Text = "English";
            // 
            // SelectRus
            // 
            this.SelectRus.Name = "SelectRus";
            this.SelectRus.Size = new System.Drawing.Size(119, 22);
            this.SelectRus.Text = "Русский";
            // 
            // SelectEng
            // 
            this.SelectEng.Name = "SelectEng";
            this.SelectEng.Size = new System.Drawing.Size(119, 22);
            this.SelectEng.Text = "English";
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.Location = new System.Drawing.Point(0, 24);
            this.treeView1.Name = "treeView1";
            treeNode13.Name = "Узел1";
            treeNode13.Text = "Узел1";
            treeNode14.Name = "Узел11";
            treeNode14.Text = "Узел11";
            treeNode15.Name = "Узел7";
            treeNode15.Text = "Узел7";
            treeNode16.Name = "Узел8";
            treeNode16.Text = "Узел8";
            treeNode17.Name = "Узел10";
            treeNode17.Text = "Узел10";
            treeNode18.Name = "Узел9";
            treeNode18.Text = "Узел9";
            treeNode19.Name = "Узел2";
            treeNode19.Text = "Узел2";
            treeNode20.Name = "Узел3";
            treeNode20.Text = "Узел3";
            treeNode21.Name = "Узел6";
            treeNode21.Text = "Узел6";
            treeNode22.Name = "Узел5";
            treeNode22.Text = "Узел5";
            treeNode23.Name = "Узел4";
            treeNode23.Text = "Узел4";
            treeNode24.Name = "Узел0";
            treeNode24.Text = "Узел0";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode24});
            this.treeView1.Size = new System.Drawing.Size(257, 484);
            this.treeView1.TabIndex = 2;
            // 
            // SceneWidget
            // 
            this.SceneWidget.AccumBits = ((byte)(0));
            this.SceneWidget.AutoCheckErrors = false;
            this.SceneWidget.AutoFinish = false;
            this.SceneWidget.AutoMakeCurrent = true;
            this.SceneWidget.AutoSwapBuffers = true;
            this.SceneWidget.BackColor = System.Drawing.Color.Black;
            this.SceneWidget.ColorBits = ((byte)(32));
            this.SceneWidget.DepthBits = ((byte)(16));
            this.SceneWidget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SceneWidget.Location = new System.Drawing.Point(257, 24);
            this.SceneWidget.Name = "SceneWidget";
            this.SceneWidget.Size = new System.Drawing.Size(673, 484);
            this.SceneWidget.StencilBits = ((byte)(0));
            this.SceneWidget.TabIndex = 4;
            this.SceneWidget.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SceneWidget_KeyDown);
            this.SceneWidget.Resize += new System.EventHandler(this.SceneWidget_Resize);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(930, 530);
            this.Controls.Add(this.SceneWidget);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.MainMenu);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.MainMenu;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.OpenFileDialog openFileModelDialog;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportPictureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optimizateViewToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripDropDownButton SelectLanguage;
        private System.Windows.Forms.ToolStripMenuItem SelectRus;
        private System.Windows.Forms.ToolStripMenuItem SelectEng;
        private System.Windows.Forms.TreeView treeView1;
        private Tao.Platform.Windows.SimpleOpenGlControl SceneWidget;
    }
}

