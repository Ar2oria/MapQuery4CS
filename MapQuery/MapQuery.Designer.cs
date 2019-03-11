namespace MapQuery
{
    partial class MapQuery
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
            this.map = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // map
            // 
            this.map.Location = new System.Drawing.Point(12, 12);
            this.map.MinimumSize = new System.Drawing.Size(20, 20);
            this.map.Name = "map";
            this.map.ScrollBarsEnabled = false;
            this.map.Size = new System.Drawing.Size(927, 756);
            this.map.TabIndex = 0;
            this.map.TabStop = false;
            this.map.Url = new System.Uri("C:\\Users\\Ex1st\\Documents\\vsWorkspace\\MapQuery4CS\\MapQuery\\bin\\Debug\\map.htm", System.UriKind.Absolute);
            // 
            // MapQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1419, 780);
            this.Controls.Add(this.map);
            this.Name = "MapQuery";
            this.Text = "MapQuery";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser map;
    }
}