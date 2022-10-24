using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using Vintasoft.Barcode;
using Vintasoft.Barcode.Gdi;
using Vintasoft.Barcode.SymbologySubsets;

namespace BarcodeDemo.Controls
{
    /// <summary>
    /// A control that allows to display a barcode image.
    /// </summary>
    [ToolboxBitmap(typeof(BarcodeWriterControl), "BarcodeWriterControl.icon.bmp")]
    public class BarcodeWriterControl : Control, ISupportInitialize
    {

        #region Fields

        /// <summary>
        /// A barcode image.
        /// </summary>
        Image _barcodeImage = null;

        /// <summary>
        /// A PictureBox control that displays barcode image.
        /// </summary>
        PictureBox _pictureBox;

        /// <summary>
        /// A parent panel for PictureBox control.
        /// </summary>
        Panel _pictureBoxPanel;

        /// <summary>
        /// A value indicating whether the initialization of this control is started.
        /// </summary>
        bool _isInitializationStarted = false;

        /// <summary>
        /// A value indicating whether the control parameters were changed during initialization.
        /// </summary>
        bool _areSettingsChanged = false;

        /// <summary>
        /// A value indicating whether the barcode writer encodes the barcode subset.
        /// </summary>
        bool _isBarcodeSubsetEncoding = false;

        /// <summary>
        /// A value indicating whether the barcode renderer is changing.
        /// </summary>
        bool _isBarcodeRendererChanging = false;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BarcodeWriterControl"/> class. 
        /// </summary>
        public BarcodeWriterControl()
            : base()
        {
            _pictureBox = new PictureBox();
            _pictureBoxPanel = new Panel();
            _pictureBoxPanel.AutoScroll = true;
            _pictureBoxPanel.Controls.Add(_pictureBox);
            Controls.Add(_pictureBoxPanel);
            _pictureBoxPanel.Dock = DockStyle.Fill;
            _pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            _pictureBoxPanel.Resize += new EventHandler(_pictureBoxPanel_Resize);

            _writer = new BarcodeWriter();
            _writer.Settings.Barcode = BarcodeType.Code128;
            _writer.Settings.PixelFormat = BarcodeImagePixelFormat.Bgr24;
            _writer.Settings.Value = "123456";
            _writer.Settings.Changed += new EventHandler(_writer_Settings_Changed);

            GenerateBarcode();
        }

        #endregion



        #region Properties

        double _barcodeImageWidth = 0;
        /// <summary>
        /// Gets or sets the width of the barcode image, in <see cref="BarcodeImageSizeUnits"/>.
        /// </summary>
        /// <value>
        /// <b>0</b> - barcode image size is calculated automatically.
        /// </value>
        /// <seealso cref="BarcodeImageSizeUnits"/>
        public double BarcodeImageWidth
        {
            get
            {
                return _barcodeImageWidth;
            }
            set
            {
                if (_barcodeImageWidth != value)
                {
                    _barcodeImageWidth = value;
                    OnSettingsChanged();
                }
            }
        }

        double _barcodeImageHeight = 0;
        /// <summary>
        /// Gets or sets the height of the barcode image, in <see cref="BarcodeImageSizeUnits"/>.
        /// </summary>
        /// <value>
        /// <b>0</b> - barcode image size is calculated automatically.
        /// </value>
        /// <seealso cref="BarcodeImageSizeUnits"/>
        public double BarcodeImageHeight
        {
            get
            {
                return _barcodeImageHeight;
            }
            set
            {
                if (_barcodeImageHeight != value)
                {
                    _barcodeImageHeight = value;
                    OnSettingsChanged();
                }
            }
        }

        UnitOfMeasure _barcodeImageSizeUnits = UnitOfMeasure.Pixels;
        /// <summary>
        /// Gets or sets the units of measure of barcode image size.
        /// </summary>
        /// <seealso cref="BarcodeImageWidth"/>
        /// <seealso cref="BarcodeImageHeight"/>
        /// <see cref="WriterSettings.Resolution"/>
        public UnitOfMeasure BarcodeImageSizeUnits
        {
            get
            {
                return _barcodeImageSizeUnits;
            }
            set
            {
                if (_barcodeImageSizeUnits != value)
                {
                    _barcodeImageSizeUnits = value;
                    OnSettingsChanged();
                }
            }
        }

        BarcodeSymbologySubset _barcodeSymbologySubset = null;
        /// <summary>
        /// Gets or sets the barcode symbology subset to encode.
        /// </summary>
        public BarcodeSymbologySubset BarcodeSymbologySubset
        {
            get
            {
                return _barcodeSymbologySubset;
            }
            set
            {
                if (_barcodeSymbologySubset != value)
                {
                    _barcodeSymbologySubset = value;
                    OnSettingsChanged();
                }

            }
        }

        /// <summary>
        /// Gets the barcode writer settings.
        /// </summary>
        [Description("Settings of barcode writer.")]
        [Category("VintaSoft")]
        public WriterSettings Settings
        {
            get
            {
                return _writer.Settings;
            }
        }

        /// <summary>
        /// Gets or sets a value that indicates how the barcode image is displayed.
        /// </summary>
        /// <returns>
        /// Default value is <see cref="PictureBoxSizeMode"/>.CenterImage.
        /// </returns>
        [Description("Indicates how the barcode image is displayed.")]
        [Category("VintaSoft")]
        [DefaultValue(PictureBoxSizeMode.CenterImage)]
        public PictureBoxSizeMode SizeMode
        {
            get
            {
                return _pictureBox.SizeMode;
            }
            set
            {
                _pictureBox.SizeMode = value;
                UpdateScrolls();
            }
        }

        /// <summary>
        /// Gets an encoded value.
        /// </summary>
        /// <remarks>
        /// This value can not coincide with <see cref="WriterSettings.Value"/>
        /// because reader can add checksum or another system info to the initial
        /// value of barcode.
        /// </remarks>
        [Browsable(false)]
        public string EncodedValue
        {
            get
            {
                return _writer.EncodedValue;
            }
        }

        BarcodeGraphicsRenderer _barcodeRenderer = null;
        /// <summary>
        /// Gets or sets the renderer of barcode.
        /// </summary>
        /// <value>
        /// Default value is <b>null</b>.
        /// </value>
        [Browsable(false)]
        public BarcodeGraphicsRenderer BarcodeRenderer
        {
            get
            {
                return _barcodeRenderer;
            }
            set
            {
                _barcodeRenderer = value;

                _isBarcodeRendererChanging = true;
                try
                {
                    GenerateBarcode();
                }
                finally
                {
                    _isBarcodeRendererChanging = false;
                }
            }
        }

        BarcodeWriter _writer;
        /// <summary>
        /// Gets the barcode writer.
        /// </summary>
        [Browsable(false)]
        public BarcodeWriter Writer
        {
            get
            {
                return _writer;
            }
        }

        #endregion



        #region Methods

        #region PUBLIC

        /// <summary>
        /// Returns barcode as an <see cref="Image"/>.
        /// </summary>
        /// <returns>A barcode as an <see cref="Image"/>.</returns>
        public Image GetBarcodeAsImage()
        {
            return (Image)_barcodeImage.Clone();
        }

        /// <summary>
        /// Returns barcode as a <see cref="GraphicsPath"/>.
        /// </summary>
        /// <returns>A barcode as a <see cref="GraphicsPath"/>.</returns>
        public GraphicsPath GetBarcodeAsGraphicsPath()
        {
            return _writer.GetBarcodeAsGraphicsPath();
        }

        /// <summary>
        /// Signals the object that initialization is starting.
        /// </summary>
        public virtual void BeginInit()
        {
            _areSettingsChanged = false;
            _isInitializationStarted = true;
        }

        /// <summary>
        /// Signals the object that initialization is complete.
        /// </summary>
        public virtual void EndInit()
        {
            _isInitializationStarted = false;
            if (_areSettingsChanged)
                GenerateBarcode();
        }

        #endregion


        #region PROTECTED

        /// <summary>
        /// Releases the unmanaged resources used by the<see cref="BarcodeWriterControl"/>.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _pictureBoxPanel.Dispose();
            _pictureBox.Dispose();
            if (_barcodeImage != null)
            {
                _barcodeImage.Dispose();
                _barcodeImage = null;
            }
        }

        #endregion


        #region PRIVATE

        /// <summary>
        /// Generates barcode.
        /// </summary>
        private void GenerateBarcode()
        {
            if (!_isBarcodeRendererChanging && _barcodeSymbologySubset != null)
            {
                try
                {
                    _isBarcodeSubsetEncoding = true;
                    if (Settings.ValueItems != null && Settings.ValueItems.Length == 1)
                        _barcodeSymbologySubset.Encode(Settings.ValueItems[0], Settings);
                    else
                        _barcodeSymbologySubset.Encode(Settings.Value, Settings);
                }
                finally
                {
                    _isBarcodeSubsetEncoding = false;
                }
            }

            // save reference to the previous barcode image
            Image previoudImage = _barcodeImage;
            // reference to the new barcode image
            Image newImage = null;

            if (_barcodeImageWidth > 0 && _barcodeImageHeight > 0)
            {
                // if barcode renderer exists using barcode renderer
                if (_barcodeRenderer != null)
                {
                    try
                    {
                        // generate new barcode image using barcode renderer
                        newImage = _barcodeRenderer.GetBarcodeAsBitmap(_writer, BarcodeImageWidth, BarcodeImageHeight, BarcodeImageSizeUnits);
                    }
                    catch (NotSupportedException)
                    {
                    }
                }

                // if new barcode image was not generated earlier
                if (newImage == null)
                {
                    // generate new barcode image using barcode writer
                    newImage = _writer.GetBarcodeAsBitmap(BarcodeImageWidth, BarcodeImageHeight, BarcodeImageSizeUnits);
                }
            }
            else
            {
                // if barcode renderer exists using barcode renderer
                if (_barcodeRenderer != null)
                {
                    try
                    {
                        // generate new barcode image using barcode renderer
                        newImage = _barcodeRenderer.GetBarcodeAsBitmap(_writer);
                    }
                    catch (NotSupportedException)
                    {
                    }
                }

                // if new barcode image was not generated earlier
                if (newImage == null)
                {
                    // generate new barcode image using barcode writer
                    newImage = _writer.GetBarcodeAsBitmap();
                }
            }

            // set new barcode image as current barcode image in this control
            _barcodeImage = newImage;

            // update scrolls in the control
            UpdateScrolls();

            // display new barcode image in picture box
            _pictureBox.Image = _barcodeImage;

            // if previous barcode image exists
            if (previoudImage != null)
                // destroy previous barcode image
                previoudImage.Dispose();

            OnBarcodeImageChanged(_barcodeImage);
        }

        /// <summary>
        /// Picture box panel is resizing.
        /// </summary>
        private void _pictureBoxPanel_Resize(object sender, EventArgs e)
        {
            // update scrolls in the control
            UpdateScrolls();
        }

        /// <summary>
        /// Updates scrolls in the control.
        /// </summary>
        private void UpdateScrolls()
        {
            // if barcode image exists
            if (_barcodeImage != null)
            {
                // if scroll bars are necessary for scrolling the control content
                if (SizeMode != PictureBoxSizeMode.Zoom && SizeMode != PictureBoxSizeMode.StretchImage &&
                    (_pictureBoxPanel.Width < _barcodeImage.Width || _pictureBoxPanel.Height < _barcodeImage.Height))
                {
                    // specify that control must display scrool bars
                    _pictureBoxPanel.AutoScroll = true;

                    // if horizontal and vertical scroll bars are necessary
                    if (_pictureBoxPanel.Width < _barcodeImage.Width && _pictureBoxPanel.Height < _barcodeImage.Height)
                    {
                        _pictureBox.Dock = DockStyle.None;
                        _pictureBox.Width = _barcodeImage.Width;
                        _pictureBox.Height = _barcodeImage.Height;
                    }
                    // if only vertical scroll bar is necessary
                    else if (_pictureBoxPanel.Width < _barcodeImage.Width)
                    {
                        _pictureBox.Width = _barcodeImage.Width;
                        _pictureBox.Dock = DockStyle.Left;
                    }
                    // if only horizontal scroll bar is necessary
                    else
                    {
                        _pictureBox.Height = _barcodeImage.Height;
                        _pictureBox.Dock = DockStyle.Top;
                    }
                }
                // if scroll bars are NOT necessary for scrolling the control content
                else
                {
                    _pictureBoxPanel.AutoScroll = false;
                    _pictureBox.Dock = DockStyle.None;
                    _pictureBox.Width = _pictureBoxPanel.Width;
                    _pictureBox.Height = _pictureBoxPanel.Height;
                }
            }
        }

        /// <summary>
        /// The settings of barcode writer are changed.
        /// </summary>
        private void _writer_Settings_Changed(object sender, EventArgs e)
        {
            OnSettingsChanged();
        }

        /// <summary>
        /// The settings of this control are changed.
        /// </summary>
        private void OnSettingsChanged()
        {
            if (_isInitializationStarted)
                _areSettingsChanged = true;
            else
            {
                if (!_isBarcodeSubsetEncoding)
                    GenerateBarcode();
            }
        }

        /// <summary>
        /// Raises the BarcodeImageChanged event.
        /// </summary>
        private void OnBarcodeImageChanged(Image image)
        {
            if (BarcodeImageChanged != null)
                BarcodeImageChanged(this, new BarcodeImageChangedEventArgs(image));
        }

        #endregion

        #endregion



        #region Events

        /// <summary>
        /// Occurs when barcode image is changed.
        /// </summary>
        public event EventHandler<BarcodeImageChangedEventArgs> BarcodeImageChanged;

        #endregion

    }
}