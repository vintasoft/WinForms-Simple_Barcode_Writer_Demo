namespace SimpleBarcodeWriterDemo
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel3 = new System.Windows.Forms.Panel();
            this.mainMenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barcodeImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barcodeImageSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.centerImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stretchImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.barcodeWriterControl = new BarcodeDemo.Controls.BarcodeWriterControl();
            this.panel4 = new System.Windows.Forms.Panel();
            this.barcodeWriterSettingsControl1 = new BarcodeDemo.Controls.BarcodeWriterSettingsControl();
            this.saveBarcodeImageDialog = new System.Windows.Forms.SaveFileDialog();
            this.saveAsSVGFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSvgFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.panel3.SuspendLayout();
            this.mainMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barcodeWriterControl)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.mainMenuStrip1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(784, 26);
            this.panel3.TabIndex = 2;
            // 
            // mainMenuStrip1
            // 
            this.mainMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.barcodeImageToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.mainMenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip1.Name = "mainMenuStrip1";
            this.mainMenuStrip1.Size = new System.Drawing.Size(784, 24);
            this.mainMenuStrip1.TabIndex = 0;
            this.mainMenuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // barcodeImageToolStripMenuItem
            // 
            this.barcodeImageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barcodeImageSizeToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.saveAsSVGFileToolStripMenuItem});
            this.barcodeImageToolStripMenuItem.Name = "barcodeImageToolStripMenuItem";
            this.barcodeImageToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.barcodeImageToolStripMenuItem.Text = "Barcode Image";
            // 
            // barcodeImageSizeToolStripMenuItem
            // 
            this.barcodeImageSizeToolStripMenuItem.Name = "barcodeImageSizeToolStripMenuItem";
            this.barcodeImageSizeToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.barcodeImageSizeToolStripMenuItem.Text = "Set Image Size...";
            this.barcodeImageSizeToolStripMenuItem.Click += new System.EventHandler(this.barcodeImageSizeToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.saveAsToolStripMenuItem.Text = "Save Image As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.centerImageToolStripMenuItem,
            this.autoSizeToolStripMenuItem,
            this.normalToolStripMenuItem,
            this.zoomToolStripMenuItem,
            this.stretchImageToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // centerImageToolStripMenuItem
            // 
            this.centerImageToolStripMenuItem.Checked = true;
            this.centerImageToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.centerImageToolStripMenuItem.Name = "centerImageToolStripMenuItem";
            this.centerImageToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.centerImageToolStripMenuItem.Text = "Center Image";
            this.centerImageToolStripMenuItem.Click += new System.EventHandler(this.sizeModeToolStripMenuItem_Click);
            // 
            // autoSizeToolStripMenuItem
            // 
            this.autoSizeToolStripMenuItem.CheckOnClick = true;
            this.autoSizeToolStripMenuItem.Name = "autoSizeToolStripMenuItem";
            this.autoSizeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.autoSizeToolStripMenuItem.Text = "Auto Size";
            this.autoSizeToolStripMenuItem.Click += new System.EventHandler(this.sizeModeToolStripMenuItem_Click);
            // 
            // normalToolStripMenuItem
            // 
            this.normalToolStripMenuItem.CheckOnClick = true;
            this.normalToolStripMenuItem.Name = "normalToolStripMenuItem";
            this.normalToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.normalToolStripMenuItem.Text = "Normal";
            this.normalToolStripMenuItem.Click += new System.EventHandler(this.sizeModeToolStripMenuItem_Click);
            // 
            // zoomToolStripMenuItem
            // 
            this.zoomToolStripMenuItem.CheckOnClick = true;
            this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            this.zoomToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.zoomToolStripMenuItem.Text = "Zoom";
            this.zoomToolStripMenuItem.Click += new System.EventHandler(this.sizeModeToolStripMenuItem_Click);
            // 
            // stretchImageToolStripMenuItem
            // 
            this.stretchImageToolStripMenuItem.CheckOnClick = true;
            this.stretchImageToolStripMenuItem.Name = "stretchImageToolStripMenuItem";
            this.stretchImageToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.stretchImageToolStripMenuItem.Text = "Stretch Image";
            this.stretchImageToolStripMenuItem.Click += new System.EventHandler(this.sizeModeToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 26);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(784, 560);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.barcodeWriterControl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(500, 556);
            this.panel2.TabIndex = 3;
            // 
            // barcodeWriterControl
            // 
            this.barcodeWriterControl.BarcodeImageHeight = 0;
            this.barcodeWriterControl.BarcodeImageSizeUnits = Vintasoft.Barcode.UnitOfMeasure.Pixels;
            this.barcodeWriterControl.BarcodeImageWidth = 0;
            this.barcodeWriterControl.BarcodeRenderer = null;
            this.barcodeWriterControl.BarcodeSymbologySubset = null;
            this.barcodeWriterControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barcodeWriterControl.Location = new System.Drawing.Point(0, 0);
            this.barcodeWriterControl.Name = "barcodeWriterControl";
            this.barcodeWriterControl.Size = new System.Drawing.Size(498, 554);
            this.barcodeWriterControl.TabIndex = 1;
            this.barcodeWriterControl.Text = "barcodeWriterControl1";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.barcodeWriterSettingsControl1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(502, 2);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.panel4.Size = new System.Drawing.Size(280, 556);
            this.panel4.TabIndex = 2;
            // 
            // barcodeWriterSettingsControl1
            // 
            this.barcodeWriterSettingsControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barcodeWriterSettingsControl1.Location = new System.Drawing.Point(2, 0);
            this.barcodeWriterSettingsControl1.Name = "barcodeWriterSettingsControl1";
            this.barcodeWriterSettingsControl1.SelectedBarcodeSubset = null;
            this.barcodeWriterSettingsControl1.Size = new System.Drawing.Size(278, 556);
            this.barcodeWriterSettingsControl1.TabIndex = 0;
            // 
            // saveBarcodeImageDialog
            // 
            this.saveBarcodeImageDialog.Filter = "PNG files|*.png";
            // 
            // saveAsSVGFileToolStripMenuItem
            // 
            this.saveAsSVGFileToolStripMenuItem.Name = "saveAsSVGFileToolStripMenuItem";
            this.saveAsSVGFileToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.saveAsSVGFileToolStripMenuItem.Text = "Save As SVG File...";
            this.saveAsSVGFileToolStripMenuItem.Click += new System.EventHandler(this.saveAsSVGFileToolStripMenuItem_Click);
            // 
            // saveSvgFileDialog
            // 
            this.saveSvgFileDialog.DefaultExt = "svg";
            this.saveSvgFileDialog.Filter = "SVG (*.svg)|*.svg";
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 586);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.mainMenuStrip1.ResumeLayout(false);
            this.mainMenuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barcodeWriterControl)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.MenuStrip mainMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private BarcodeDemo.Controls.BarcodeWriterControl barcodeWriterControl;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.SaveFileDialog saveBarcodeImageDialog;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem centerImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stretchImageToolStripMenuItem;
        private BarcodeDemo.Controls.BarcodeWriterSettingsControl barcodeWriterSettingsControl1;
        private System.Windows.Forms.ToolStripMenuItem barcodeImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem barcodeImageSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsSVGFileToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveSvgFileDialog;



    }
}
