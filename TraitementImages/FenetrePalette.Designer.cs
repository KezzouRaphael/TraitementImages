namespace TraitementImages
{
    partial class FenetrePalette
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FenetrePalette));
            this.label2 = new System.Windows.Forms.Label();
            this.BoutonArrive = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(277, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Choix de la couleur de remplacement :";
            // 
            // BoutonArrive
            // 
            this.BoutonArrive.BackColor = System.Drawing.Color.Black;
            this.BoutonArrive.Location = new System.Drawing.Point(328, 146);
            this.BoutonArrive.Name = "BoutonArrive";
            this.BoutonArrive.Size = new System.Drawing.Size(40, 40);
            this.BoutonArrive.TabIndex = 3;
            this.BoutonArrive.UseVisualStyleBackColor = false;
            this.BoutonArrive.Click += new System.EventHandler(this.BoutonArrive_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(215, 336);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(273, 40);
            this.button1.TabIndex = 4;
            this.button1.Text = "Valider";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FenetrePalette
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 388);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BoutonArrive);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FenetrePalette";
            this.Text = "FenetrePalette";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BoutonArrive;
        private System.Windows.Forms.Button button1;
    }
}