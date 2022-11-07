namespace CG_5
{
    partial class Form1
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
            this.sim = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.SuspendLayout();
            // 
            // sim
            // 
            this.sim.AccumBits = ((byte)(0));
            this.sim.AutoCheckErrors = false;
            this.sim.AutoFinish = false;
            this.sim.AutoMakeCurrent = true;
            this.sim.AutoSwapBuffers = true;
            this.sim.BackColor = System.Drawing.Color.Black;
            this.sim.ColorBits = ((byte)(32));
            this.sim.DepthBits = ((byte)(16));
            this.sim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sim.Location = new System.Drawing.Point(0, 0);
            this.sim.Name = "sim";
            this.sim.Size = new System.Drawing.Size(659, 636);
            this.sim.StencilBits = ((byte)(0));
            this.sim.TabIndex = 0;
            this.sim.Load += new System.EventHandler(this.sim_Load);
            this.sim.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sim_KeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 636);
            this.Controls.Add(this.sim);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl sim;
    }
}

