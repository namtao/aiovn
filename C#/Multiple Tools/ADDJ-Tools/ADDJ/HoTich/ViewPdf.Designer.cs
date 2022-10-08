
namespace ADDJ
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
            this.gdViewer = new GdPicture14.GdViewer();
            this.thumbnailEx1 = new GdPicture14.ThumbnailEx();
            this.SuspendLayout();
            // 
            // gdViewer
            // 
            this.gdViewer.AllowDropFile = false;
            this.gdViewer.AnimateGIF = true;
            this.gdViewer.AnnotationDropShadow = true;
            this.gdViewer.AnnotationEnableMultiSelect = true;
            this.gdViewer.AnnotationResizeRotateHandlesColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.gdViewer.AnnotationResizeRotateHandlesScale = 1F;
            this.gdViewer.AnnotationSelectionLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gdViewer.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.gdViewer.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.gdViewer.BackColor = System.Drawing.Color.White;
            this.gdViewer.BackgroundImage = null;
            this.gdViewer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.gdViewer.ClipAnnotsToPageBounds = true;
            this.gdViewer.ClipRegionsToPageBounds = true;
            this.gdViewer.ContinuousViewMode = true;
            this.gdViewer.DisplayQuality = GdPicture14.DisplayQuality.DisplayQualityAutomatic;
            this.gdViewer.DisplayQualityAuto = true;
            this.gdViewer.DocumentAlignment = GdPicture14.ViewerDocumentAlignment.DocumentAlignmentMiddleCenter;
            this.gdViewer.DocumentPosition = GdPicture14.ViewerDocumentPosition.DocumentPositionMiddleCenter;
            this.gdViewer.DrawPageBorders = true;
            this.gdViewer.EnableDeferredPainting = true;
            this.gdViewer.EnabledProgressBar = true;
            this.gdViewer.EnableICM = false;
            this.gdViewer.EnableMenu = true;
            this.gdViewer.EnableMouseWheel = true;
            this.gdViewer.EnableTextSelection = true;
            this.gdViewer.ForceScrollBars = false;
            this.gdViewer.ForceTemporaryMode = false;
            this.gdViewer.ForeColor = System.Drawing.Color.Black;
            this.gdViewer.Gamma = 1F;
            this.gdViewer.HQAnnotationRendering = true;
            this.gdViewer.IgnoreDocumentResolution = false;
            this.gdViewer.KeepDocumentPosition = false;
            this.gdViewer.Location = new System.Drawing.Point(12, 12);
            this.gdViewer.LockViewer = false;
            this.gdViewer.MagnifierHeight = 90;
            this.gdViewer.MagnifierWidth = 160;
            this.gdViewer.MagnifierZoomX = 2F;
            this.gdViewer.MagnifierZoomY = 2F;
            this.gdViewer.MouseButtonForMouseMode = GdPicture14.MouseButton.MouseButtonLeft;
            this.gdViewer.MouseMode = GdPicture14.ViewerMouseMode.MouseModePan;
            this.gdViewer.MouseWheelMode = GdPicture14.ViewerMouseWheelMode.MouseWheelModeZoom;
            this.gdViewer.Name = "gdViewer";
            this.gdViewer.PageBordersColor = System.Drawing.Color.Black;
            this.gdViewer.PageBordersPenSize = 1;
            this.gdViewer.PageDisplayMode = GdPicture14.PageDisplayMode.MultiplePagesView;
            this.gdViewer.PdfDisplayFormField = true;
            this.gdViewer.PdfEnableFileLinks = true;
            this.gdViewer.PdfEnableLinks = true;
            this.gdViewer.PdfIncreaseTextContrast = false;
            this.gdViewer.PdfShowDialogForPassword = true;
            this.gdViewer.PdfShowOpenFileDialogForDecryption = true;
            this.gdViewer.PdfVerifyDigitalCertificates = false;
            this.gdViewer.PreserveViewRotation = true;
            this.gdViewer.RectBorderColor = System.Drawing.Color.Black;
            this.gdViewer.RectBorderSize = 1;
            this.gdViewer.RectIsEditable = true;
            this.gdViewer.RegionsAreEditable = true;
            this.gdViewer.RenderGdPictureAnnots = true;
            this.gdViewer.ScrollBars = true;
            this.gdViewer.ScrollLargeChange = ((short)(50));
            this.gdViewer.ScrollSmallChange = ((short)(1));
            this.gdViewer.SilentMode = true;
            this.gdViewer.Size = new System.Drawing.Size(776, 426);
            this.gdViewer.TabIndex = 0;
            this.gdViewer.ViewRotation = System.Drawing.RotateFlipType.RotateNoneFlipNone;
            this.gdViewer.Zoom = 1D;
            this.gdViewer.ZoomCenterAtMousePosition = false;
            this.gdViewer.ZoomMode = GdPicture14.ViewerZoomMode.ZoomMode100;
            this.gdViewer.ZoomStep = 25;
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
            this.thumbnailEx1.EnableDropShadow = true;
            this.thumbnailEx1.HorizontalTextAlignment = GdPicture14.TextAlignment.TextAlignmentCenter;
            this.thumbnailEx1.HotTracking = false;
            this.thumbnailEx1.Location = new System.Drawing.Point(381, 176);
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
            this.thumbnailEx1.Size = new System.Drawing.Size(407, 262);
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
            // ViewPdf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.thumbnailEx1);
            this.Controls.Add(this.gdViewer);
            this.Name = "ViewPdf";
            this.Text = "ViewPdf";
            this.ResumeLayout(false);

        }

        #endregion

        private GdPicture14.GdViewer gdViewer;
        private GdPicture14.ThumbnailEx thumbnailEx1;
    }
}