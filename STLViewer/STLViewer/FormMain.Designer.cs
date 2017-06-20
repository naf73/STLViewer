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
            this.SceneWidget = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.SuspendLayout();
            // 
            // SceneWidget
            // 
            this.SceneWidget.AccumBits = ((byte)(0));
            this.SceneWidget.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SceneWidget.AutoCheckErrors = false;
            this.SceneWidget.AutoFinish = false;
            this.SceneWidget.AutoMakeCurrent = true;
            this.SceneWidget.AutoSwapBuffers = true;
            this.SceneWidget.BackColor = System.Drawing.Color.Black;
            this.SceneWidget.ColorBits = ((byte)(32));
            this.SceneWidget.DepthBits = ((byte)(16));
            this.SceneWidget.Location = new System.Drawing.Point(12, 12);
            this.SceneWidget.Name = "SceneWidget";
            this.SceneWidget.Size = new System.Drawing.Size(493, 442);
            this.SceneWidget.StencilBits = ((byte)(0));
            this.SceneWidget.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 627);
            this.Controls.Add(this.SceneWidget);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormMain_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl SceneWidget;
    }
}

