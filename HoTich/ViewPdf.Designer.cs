
namespace xD
{
    partial class ViewPdf
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gdViewer1 = new GdPicture14.GdViewer();
            this.thumbnailEx1 = new GdPicture14.ThumbnailEx();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.64151F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.35849F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 211F));
            this.tableLayoutPanel1.Controls.Add(this.gdViewer1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.thumbnailEx1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox1, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.85077F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.14923F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1272, 583);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gdViewer1
            // 
            this.gdViewer1.AllowDropFile = false;
            this.gdViewer1.AnimateGIF = true;
            this.gdViewer1.AnnotationDropShadow = true;
            this.gdViewer1.AnnotationEnableMultiSelect = true;
            this.gdViewer1.AnnotationResizeRotateHandlesColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.gdViewer1.AnnotationResizeRotateHandlesScale = 1F;
            this.gdViewer1.AnnotationSelectionLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gdViewer1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.gdViewer1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.gdViewer1.BackColor = System.Drawing.Color.White;
            this.gdViewer1.BackgroundImage = null;
            this.gdViewer1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.gdViewer1.ClipAnnotsToPageBounds = true;
            this.gdViewer1.ClipRegionsToPageBounds = true;
            this.gdViewer1.ContinuousViewMode = true;
            this.gdViewer1.DisplayQuality = GdPicture14.DisplayQuality.DisplayQualityAutomatic;
            this.gdViewer1.DisplayQualityAuto = true;
            this.gdViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdViewer1.DocumentAlignment = GdPicture14.ViewerDocumentAlignment.DocumentAlignmentMiddleCenter;
            this.gdViewer1.DocumentPosition = GdPicture14.ViewerDocumentPosition.DocumentPositionMiddleCenter;
            this.gdViewer1.DrawPageBorders = true;
            this.gdViewer1.EnableDeferredPainting = true;
            this.gdViewer1.EnabledProgressBar = true;
            this.gdViewer1.EnableICM = false;
            this.gdViewer1.EnableMenu = true;
            this.gdViewer1.EnableMouseWheel = true;
            this.gdViewer1.EnableTextSelection = true;
            this.gdViewer1.ForceScrollBars = false;
            this.gdViewer1.ForceTemporaryMode = false;
            this.gdViewer1.ForeColor = System.Drawing.Color.Black;
            this.gdViewer1.Gamma = 1F;
            this.gdViewer1.HQAnnotationRendering = true;
            this.gdViewer1.IgnoreDocumentResolution = false;
            this.gdViewer1.KeepDocumentPosition = false;
            this.gdViewer1.Location = new System.Drawing.Point(561, 3);
            this.gdViewer1.LockViewer = false;
            this.gdViewer1.MagnifierHeight = 90;
            this.gdViewer1.MagnifierWidth = 160;
            this.gdViewer1.MagnifierZoomX = 2F;
            this.gdViewer1.MagnifierZoomY = 2F;
            this.gdViewer1.MouseButtonForMouseMode = GdPicture14.MouseButton.MouseButtonLeft;
            this.gdViewer1.MouseMode = GdPicture14.ViewerMouseMode.MouseModePan;
            this.gdViewer1.MouseWheelMode = GdPicture14.ViewerMouseWheelMode.MouseWheelModeZoom;
            this.gdViewer1.Name = "gdViewer1";
            this.gdViewer1.PageBordersColor = System.Drawing.Color.Black;
            this.gdViewer1.PageBordersPenSize = 1;
            this.gdViewer1.PageDisplayMode = GdPicture14.PageDisplayMode.MultiplePagesView;
            this.gdViewer1.PdfDisplayFormField = true;
            this.gdViewer1.PdfEnableFileLinks = true;
            this.gdViewer1.PdfEnableLinks = true;
            this.gdViewer1.PdfIncreaseTextContrast = false;
            this.gdViewer1.PdfShowDialogForPassword = true;
            this.gdViewer1.PdfShowOpenFileDialogForDecryption = true;
            this.gdViewer1.PdfVerifyDigitalCertificates = false;
            this.gdViewer1.PreserveViewRotation = true;
            this.gdViewer1.RectBorderColor = System.Drawing.Color.Black;
            this.gdViewer1.RectBorderSize = 1;
            this.gdViewer1.RectIsEditable = true;
            this.gdViewer1.RegionsAreEditable = true;
            this.gdViewer1.RenderGdPictureAnnots = true;
            this.gdViewer1.ScrollBars = true;
            this.gdViewer1.ScrollLargeChange = ((short)(50));
            this.gdViewer1.ScrollSmallChange = ((short)(1));
            this.gdViewer1.SilentMode = true;
            this.gdViewer1.Size = new System.Drawing.Size(496, 511);
            this.gdViewer1.TabIndex = 0;
            this.gdViewer1.ViewRotation = System.Drawing.RotateFlipType.RotateNoneFlipNone;
            this.gdViewer1.Zoom = 1D;
            this.gdViewer1.ZoomCenterAtMousePosition = false;
            this.gdViewer1.ZoomMode = GdPicture14.ViewerZoomMode.ZoomMode100;
            this.gdViewer1.ZoomStep = 25;
            // 
            // thumbnailEx1
            // 
            this.thumbnailEx1.AllowDropFiles = false;
            this.thumbnailEx1.AllowMoveItems = false;
            this.thumbnailEx1.BackColor = System.Drawing.SystemColors.Control;
            this.thumbnailEx1.CheckBoxes = false;
            this.thumbnailEx1.CheckBoxesMarginLeft = 0;
            this.thumbnailEx1.CheckBoxesMarginTop = 0;
            this.thumbnailEx1.DefaultItemCheckState = false;
            this.thumbnailEx1.DefaultItemTextPrefix = "";
            this.thumbnailEx1.DisplayAnnotations = true;
            this.thumbnailEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.thumbnailEx1.EnableDropShadow = true;
            this.thumbnailEx1.HorizontalTextAlignment = GdPicture14.TextAlignment.TextAlignmentCenter;
            this.thumbnailEx1.HotTracking = false;
            this.thumbnailEx1.Location = new System.Drawing.Point(3, 3);
            this.thumbnailEx1.LockGdViewerEvents = false;
            this.thumbnailEx1.MultiSelect = false;
            this.thumbnailEx1.Name = "thumbnailEx1";
            this.thumbnailEx1.OwnDrop = false;
            this.thumbnailEx1.PauseThumbsLoading = false;
            this.thumbnailEx1.PdfIncreaseTextContrast = false;
            this.thumbnailEx1.PreloadAllItems = true;
            this.thumbnailEx1.RotateExif = true;
            this.thumbnailEx1.SelectedThumbnailBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(160)))), ((int)(((byte)(218)))));
            this.thumbnailEx1.SelectedThumbnailBackColorAlpha = 100;
            this.thumbnailEx1.ShowText = true;
            this.thumbnailEx1.Size = new System.Drawing.Size(552, 511);
            this.thumbnailEx1.TabIndex = 0;
            this.thumbnailEx1.TextMarginLeft = 0;
            this.thumbnailEx1.TextMarginTop = 0;
            this.thumbnailEx1.ThumbnailAlignment = GdPicture14.ThumbnailAlignment.ThumbnailAlignmentVertical;
            this.thumbnailEx1.ThumbnailBackColor = System.Drawing.Color.Transparent;
            this.thumbnailEx1.ThumbnailBorder = false;
            this.thumbnailEx1.ThumbnailForeColor = System.Drawing.Color.Black;
            this.thumbnailEx1.ThumbnailSize = new System.Drawing.Size(128, 128);
            this.thumbnailEx1.ThumbnailSpacing = new System.Drawing.Size(0, 0);
            this.thumbnailEx1.VerticalTextAlignment = GdPicture14.TextAlignment.TextAlignmentCenter;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(1063, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(206, 511);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // ViewPdf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 583);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ViewPdf";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ViewPdf";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private GdPicture14.GdViewer gdViewer1;
        private GdPicture14.ThumbnailEx thumbnailEx1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}