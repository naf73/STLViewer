﻿namespace STLViewer
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
            this.File_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenModel_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportPicture_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Settings_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.View_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ResetViiew_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OptimizateView_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Help_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowHelp_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.About_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusLine = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.SelectLanguage = new System.Windows.Forms.ToolStripDropDownButton();
            this.Rus_SelectItem = new System.Windows.Forms.ToolStripMenuItem();
            this.English_SelectItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SceneWidget = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.saveFileModelDialog = new System.Windows.Forms.SaveFileDialog();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.ColorModel_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ColorBackground_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Close_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu.SuspendLayout();
            this.statusLine.SuspendLayout();
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
            this.Help_MenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(930, 24);
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
            // 
            // OptimizateView_MenuItem
            // 
            this.OptimizateView_MenuItem.Name = "OptimizateView_MenuItem";
            this.OptimizateView_MenuItem.Size = new System.Drawing.Size(182, 22);
            this.OptimizateView_MenuItem.Text = "Optimizate View";
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
            // 
            // About_MenuItem
            // 
            this.About_MenuItem.Name = "About_MenuItem";
            this.About_MenuItem.Size = new System.Drawing.Size(152, 22);
            this.About_MenuItem.Text = "About ...";
            // 
            // statusLine
            // 
            this.statusLine.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.SelectLanguage});
            this.statusLine.Location = new System.Drawing.Point(0, 508);
            this.statusLine.Name = "statusLine";
            this.statusLine.Size = new System.Drawing.Size(930, 22);
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
            this.Rus_SelectItem.Size = new System.Drawing.Size(152, 22);
            this.Rus_SelectItem.Text = "Русский";
            // 
            // English_SelectItem
            // 
            this.English_SelectItem.Name = "English_SelectItem";
            this.English_SelectItem.Size = new System.Drawing.Size(152, 22);
            this.English_SelectItem.Text = "English";
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
            // ColorModel_MenuItem
            // 
            this.ColorModel_MenuItem.Name = "ColorModel_MenuItem";
            this.ColorModel_MenuItem.Size = new System.Drawing.Size(182, 22);
            this.ColorModel_MenuItem.Text = "Color Model ...";
            // 
            // ColorBackground_MenuItem
            // 
            this.ColorBackground_MenuItem.Name = "ColorBackground_MenuItem";
            this.ColorBackground_MenuItem.Size = new System.Drawing.Size(182, 22);
            this.ColorBackground_MenuItem.Text = "Color Background ...";
            // 
            // Close_MenuItem
            // 
            this.Close_MenuItem.Name = "Close_MenuItem";
            this.Close_MenuItem.Size = new System.Drawing.Size(159, 22);
            this.Close_MenuItem.Text = "Close";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(930, 530);
            this.Controls.Add(this.SceneWidget);
            this.Controls.Add(this.treeView1);
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
        private System.Windows.Forms.TreeView treeView1;
        private Tao.Platform.Windows.SimpleOpenGlControl SceneWidget;
        private System.Windows.Forms.ToolStripMenuItem Close_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem ColorModel_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem ColorBackground_MenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileModelDialog;
        private System.Windows.Forms.ColorDialog colorDialog;
    }
}

