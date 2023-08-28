using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

using Vintasoft.Barcode;
using Vintasoft.Barcode.Gdi;

namespace SimpleBarcodeWriterDemo
{
    /// <summary>
    /// The main form of Simple Barcode Writer Demo.
    /// </summary>
    public partial class MainForm : Form
    {

        #region Fields

        ToolStripMenuItem _lastSelectedViewMode;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes the <see cref="MainForm"/> class.
        /// </summary>
        static MainForm()
        {
            // register the evaluation license for VintaSoft Barcode .NET SDK
            Vintasoft.Barcode.BarcodeGlobalSettings.Register("REG_USER", "REG_EMAIL", "EXPIRATION_DATE", "REG_CODE");

#if NETCOREAPP
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
#endif

            // initialize Vintasoft.Barcode.Gdi assembly
            Vintasoft.Barcode.GdiAssembly.Init();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
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
            barcodeWriterControl.Settings.Changed += new EventHandler(BarcodeWriterSettings_Changed);

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

        #region "File" menu

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion


        #region "Barcode Image" menu

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveBarcodeImageDialog.ShowDialog() == DialogResult.OK)
            {
                using (Image barcodeImage = barcodeWriterControl.GetBarcodeAsImage())
                {
                    barcodeImage.Save(saveBarcodeImageDialog.FileName);
                }
            }
        }

        /// <summary>
        /// Saves image with barcode as SVG file.
        /// </summary>
        private void saveAsSVGFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (barcodeWriterSettingsControl1.EncodeValue())
            {
                if (saveSvgFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (BarcodeGlobalSettings.IsDemoVersion)
                    {
                        MessageBox.Show("The evaluation version adds noise to the barcode image.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    try
                    {
                        string svgFile = barcodeWriterControl.Writer.GetBarcodeAsSvgFile();
                        File.WriteAllText(saveSvgFileDialog.FileName, svgFile);

                        ProcessStartInfo processInfo = new ProcessStartInfo(saveSvgFileDialog.FileName);
                        processInfo.UseShellExecute = true;
                        Process.Start(processInfo);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void barcodeImageSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (BarcodeDemo.GetSizeForm form = new BarcodeDemo.GetSizeForm())
            {
                form.WidthValue = (float)barcodeWriterControl.BarcodeImageWidth;
                form.HeightValue = (float)barcodeWriterControl.BarcodeImageHeight;
                form.UnitsValue = barcodeWriterControl.BarcodeImageSizeUnits;
                form.ResolutionValue = (float)barcodeWriterControl.Settings.Resolution;

                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (BarcodeGlobalSettings.IsDemoVersion)
                    {
                        MessageBox.Show("The evaluation version adds noise to the barcode image.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    barcodeWriterControl.BeginInit();
                    barcodeWriterControl.BarcodeImageWidth = form.WidthValue;
                    barcodeWriterControl.BarcodeImageHeight = form.HeightValue;
                    barcodeWriterControl.BarcodeImageSizeUnits = form.UnitsValue;
                    barcodeWriterControl.Settings.Resolution = form.ResolutionValue;
                    barcodeWriterControl.EndInit();
                }
            }
        }

        #endregion


        #region "View" menu

        private void sizeModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _lastSelectedViewMode.Checked = false;
            _lastSelectedViewMode = (ToolStripMenuItem)sender;
            _lastSelectedViewMode.Checked = true;
            barcodeWriterControl.SizeMode = (PictureBoxSizeMode)_lastSelectedViewMode.Tag;
        }

        #endregion


        #region Events

        private void barcodeWriterControl_BarcodeImageChanged(object sender, BarcodeImageChangedEventArgs e)
        {
            barcodeWriterSettingsControl1.BarcodeImage = e.Image;
            barcodeWriterSettingsControl1.UpdateBarcodeWriterSettings();
        }

        private void BarcodeWriterSettings_Changed(object sender, EventArgs e)
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
