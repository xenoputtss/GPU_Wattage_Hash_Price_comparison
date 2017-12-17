namespace GPU_Wattage_Hash_Price_comparison
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearCacheFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hardwareStatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liveMarketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.slushPoolStatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1051, 513);
            this.dataGridView1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.debugToolStripMenuItem,
            this.statsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1051, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearCacheFilesToolStripMenuItem});
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.debugToolStripMenuItem.Text = "Debug";
            // 
            // clearCacheFilesToolStripMenuItem
            // 
            this.clearCacheFilesToolStripMenuItem.Name = "clearCacheFilesToolStripMenuItem";
            this.clearCacheFilesToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.clearCacheFilesToolStripMenuItem.Text = "Clear Cache Files";
            this.clearCacheFilesToolStripMenuItem.Click += new System.EventHandler(this.clearCacheFilesToolStripMenuItem_Click);
            // 
            // statsToolStripMenuItem
            // 
            this.statsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hardwareStatsToolStripMenuItem,
            this.liveMarketToolStripMenuItem,
            this.slushPoolStatsToolStripMenuItem});
            this.statsToolStripMenuItem.Name = "statsToolStripMenuItem";
            this.statsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.statsToolStripMenuItem.Text = "Stats";
            // 
            // hardwareStatsToolStripMenuItem
            // 
            this.hardwareStatsToolStripMenuItem.Name = "hardwareStatsToolStripMenuItem";
            this.hardwareStatsToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.hardwareStatsToolStripMenuItem.Text = "Hardware Stats";
            this.hardwareStatsToolStripMenuItem.Click += new System.EventHandler(this.hardwareStatsToolStripMenuItem_Click);
            // 
            // liveMarketToolStripMenuItem
            // 
            this.liveMarketToolStripMenuItem.Name = "liveMarketToolStripMenuItem";
            this.liveMarketToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.liveMarketToolStripMenuItem.Text = "Live Market";
            this.liveMarketToolStripMenuItem.Click += new System.EventHandler(this.liveMarketToolStripMenuItem_Click);
            // 
            // slushPoolStatsToolStripMenuItem
            // 
            this.slushPoolStatsToolStripMenuItem.Name = "slushPoolStatsToolStripMenuItem";
            this.slushPoolStatsToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.slushPoolStatsToolStripMenuItem.Text = "SlushPool Stats";
            this.slushPoolStatsToolStripMenuItem.Click += new System.EventHandler(this.slushPoolStatsToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 537);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearCacheFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hardwareStatsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem liveMarketToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem slushPoolStatsToolStripMenuItem;
    }
}

