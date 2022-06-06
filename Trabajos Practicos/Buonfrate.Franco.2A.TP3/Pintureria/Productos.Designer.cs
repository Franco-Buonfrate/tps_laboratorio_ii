
namespace Pintureria
{
    partial class ProductosForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Pintura = new System.Windows.Forms.Button();
            this.btn_Vinilos = new System.Windows.Forms.Button();
            this.btn_Rodillo = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.facturarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Pintura
            // 
            this.btn_Pintura.Location = new System.Drawing.Point(12, 27);
            this.btn_Pintura.Name = "btn_Pintura";
            this.btn_Pintura.Size = new System.Drawing.Size(282, 156);
            this.btn_Pintura.TabIndex = 0;
            this.btn_Pintura.Text = "Pintura";
            this.btn_Pintura.UseVisualStyleBackColor = true;
            this.btn_Pintura.Click += new System.EventHandler(this.btn_Pintura_Click);
            // 
            // btn_Vinilos
            // 
            this.btn_Vinilos.Location = new System.Drawing.Point(12, 189);
            this.btn_Vinilos.Name = "btn_Vinilos";
            this.btn_Vinilos.Size = new System.Drawing.Size(282, 156);
            this.btn_Vinilos.TabIndex = 2;
            this.btn_Vinilos.Text = "Vinilos";
            this.btn_Vinilos.UseVisualStyleBackColor = true;
            this.btn_Vinilos.Click += new System.EventHandler(this.btn_Vinilos_Click);
            // 
            // btn_Rodillo
            // 
            this.btn_Rodillo.Location = new System.Drawing.Point(12, 350);
            this.btn_Rodillo.Name = "btn_Rodillo";
            this.btn_Rodillo.Size = new System.Drawing.Size(282, 156);
            this.btn_Rodillo.TabIndex = 3;
            this.btn_Rodillo.Text = "Rodillos";
            this.btn_Rodillo.UseVisualStyleBackColor = true;
            this.btn_Rodillo.Click += new System.EventHandler(this.btn_Rodillo_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.facturarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(306, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // facturarToolStripMenuItem
            // 
            this.facturarToolStripMenuItem.Name = "facturarToolStripMenuItem";
            this.facturarToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.facturarToolStripMenuItem.Text = "Facturar";
            this.facturarToolStripMenuItem.Click += new System.EventHandler(this.facturarToolStripMenuItem_Click);
            // 
            // ProductosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 507);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Rodillo);
            this.Controls.Add(this.btn_Vinilos);
            this.Controls.Add(this.btn_Pintura);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductosForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Productos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProductosForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Pintura;
        private System.Windows.Forms.Button btn_Vinilos;
        private System.Windows.Forms.Button btn_Rodillo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem facturarToolStripMenuItem;
    }
}

