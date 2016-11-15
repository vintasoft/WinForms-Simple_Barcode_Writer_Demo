using System;
using System.Drawing;
using System.Windows.Forms;

using Vintasoft.Barcode;


namespace SimpleBarcodeWriterDemo
{
    public partial class MainForm : Form
    {

        #region Fields

        ToolStripMenuItem _lastSelectedViewMode;

        #endregion



        #region Constructors

        public MainForm()
        {
            InitializeComponent();

            Text = "VintaSoft Simple Barcode Writer Demo v" + Vintasoft.Barcode.BarcodeGlobalSettings.ProductVersion;

            barcodeWriterControl.BarcodeImageChanged += new EventHandler<BarcodeImageChangedEventArgs>(barcodeWriterControl_BarcodeImageChanged);

            barcodeWriterControl.BeginInit();
            barcodeWriterControl.Settings.Barcode = Vintasoft.Barcode.BarcodeType.Code128;
            barcodeWriterControl.Settings.Value = "01234567";
            barcodeWriterControl.Settings.PixelFormat = Vintasoft.Barcode.BarcodeImagePixelFormat.Bgr24;
            barcodeWriterControl.EndInit();

            barcodeWriterControl.BeginInit();
            barcodeWriterControl.Settings.Changed += new EventHandler(Settings_Changed);

            barcodeWriterSettingsControl1.BarcodeWriterSettings = barcodeWriterControl.Settings;

            centerImageToolStripMenuItem.Tag = PictureBoxSizeMode.CenterImage;
            autoSizeToolStripMenuItem.Tag = PictureBoxSizeMode.AutoSize;
            zoomToolStripMenuItem.Tag = PictureBoxSizeMode.Zoom;
            stretchImageToolStripMenuItem.Tag = PictureBoxSizeMode.StretchImage;
            normalToolStripMenuItem.Tag = PictureBoxSizeMode.Normal;
            _lastSelectedViewMode = centerImageToolStripMenuItem;
        }       

        #endregion



        #region Methods

        #region File menu

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveBarcodeImageDialog.ShowDialog() == DialogResult.OK)
                using (Image barcodeImage = barcodeWriterControl.GetBarcodeAsImage())
                {
                    barcodeImage.Save(saveBarcodeImageDialog.FileName);
                }
        }

        #endregion


        #region View menu

        private void sizeModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _lastSelectedViewMode.Checked = false;
            _lastSelectedViewMode = (ToolStripMenuItem)sender;
            _lastSelectedViewMode.Checked = true;
            barcodeWriterControl.SizeMode = (PictureBoxSizeMode)_lastSelectedViewMode.Tag;
        }

        #endregion


        #region Events
        
        void barcodeWriterControl_BarcodeImageChanged(object sender, BarcodeImageChangedEventArgs e)
        {
            barcodeWriterSettingsControl1.BarcodeImage = e.Image;
            barcodeWriterSettingsControl1.UpdateBarcodeWriterSettings();
        }

        void Settings_Changed(object sender, EventArgs e)
        {
            try
            {
                barcodeWriterControl.EndInit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            barcodeWriterControl.BeginInit();
        }

        #endregion

        #endregion

    }
}
