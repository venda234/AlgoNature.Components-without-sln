namespace AlgoNature.Components
{
    partial class Leaf
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelNature = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelNature
            // 
            this.panelNature.Location = new System.Drawing.Point(0, 0);
            this.panelNature.Name = "panelNature";
            this.panelNature.Size = new System.Drawing.Size(272, 246);
            this.panelNature.TabIndex = 0;
            this.panelNature.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLeaf_Paint);
            // 
            // Leaf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelNature);
            this.Name = "Leaf";
            this.Size = new System.Drawing.Size(272, 246);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panelNature;
    }
}
