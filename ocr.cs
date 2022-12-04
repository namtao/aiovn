using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using GdPicture14;
using SOHOA_ADDJ.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SOHOA_ADDJ.Views
{
    public partial class CN_NenTepPDF_DPI_NEW : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        bool isChangeContrast = false;
        bool isChangeColor = false;
        int _Brightness = 0;
        int _Contrast = 0;
        int _Saturation = 0;
        int _Gamma = 0;
        int _redColor = 0;
        int _greenColor = 0;
        int _blueColor = 0;

        List<string> _danhSachXuLyERROR = new List<string>();
        List<string> _danhSachXuLy = new List<string>();
        int APP_ID = 0;

        bool giunguyencautructhumuc;
        bool boquaneutrung;
        bool tudongClose;
        string tenkhogiay;
        string tentientrinhAPP;
        public CN_NenTepPDF_DPI_NEW(List<string> _danhSachXuLy_, int APP_ID_ = 0, bool giunguyencautructhumuc_ = true, bool boquaneutrung_ = true, bool tudongClose_ = false, string tenkhogiay_ = "A4", string tentientrinhAPP_ = "")
        {
            InitializeComponent();
            _danhSachXuLy = _danhSachXuLy_;
            APP_ID = APP_ID_;
            giunguyencautructhumuc = giunguyencautructhumuc_;
            boquaneutrung = boquaneutrung_;
            tudongClose = tudongClose_;
            tenkhogiay = tenkhogiay_;
            tentientrinhAPP = tentientrinhAPP_;
        }
        private readonly Dictionary<InterpolationMode, string> _interPolationModes = new Dictionary<InterpolationMode, string>
        {
            {InterpolationMode.Low, "Low"},
            {InterpolationMode.High, "High"},
            {InterpolationMode.Bilinear, "Bilinear"},
            {InterpolationMode.Bicubic, "Bicubic"},
            {InterpolationMode.NearestNeighbor, "Nearest Neighbor"},
            {InterpolationMode.HighQualityBilinear, "High Quality Bilinear"},
            {InterpolationMode.HighQualityBicubic, "High Quality Bicubic"}
        };
        private int _currentImage;
        private readonly GdPictureImaging _gdPictureImaging = new GdPictureImaging();
        private readonly GdPicturePDF _nativePdf = new GdPicturePDF();
        private bool _cancellationPending;
        string path = "";
        string GUID_APP;
        string noiDungTEXT = "";
        string fileNamePageProgress = "";
        private void CN_NenTepPDF_DPI_NEW_Load(object sender, EventArgs e)
        {
            GUID_APP = Guid.NewGuid().ToString();
            if (tentientrinhAPP != "")
            {
                Text = Text + " - " + tentientrinhAPP + "(" + GUID_APP + ")";
            }
            GdPicture14.LicenseManager oLicenseManager = new GdPicture14.LicenseManager();
            oLicenseManager.RegisterKEY("211883860501001421116010749430779");
            path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            txtDictsPath.Text = "OCR";
            _nativePdf.OcrPagesProgress += this.OcrPagesProgress;
            _nativePdf.BeforePageOcr += this.BeforePageOcr;
            _nativePdf.OcrPagesDone += this.OcrPagesDone;
            _nativePdf.PageBitmapOcrReady += this.PageBitmapOcrReady;

            foreach (var item in _interPolationModes)
            {
                cbResampling.Items.Add(item.Value);
            }
            cbResampling.SelectedIndex = 6;

            string PATH_ASN = path + "\\A_SCANNER";
            Directory.CreateDirectory(PATH_ASN);
            txtPathPDF.Text = INI.READ(PATH_ASN + "\\Data.ini", "CN_NenTepPDF_DPI", "txtPathPDF");
            linkThuMucNguon.Text = INI.READ(PATH_ASN + "\\Data.ini", "CN_NenTepPDF_DPI", "txtPathPDF");
            txtThuMucKetQua.Text = INI.READ(PATH_ASN + "\\Data.ini", "CN_NenTepPDF_DPI", "txtPathURLKetQua");
            linkThuMucKetQua.Text = INI.READ(PATH_ASN + "\\Data.ini", "CN_NenTepPDF_DPI", "txtPathURLKetQua");

            if (_danhSachXuLy != null)
            {
                if (_danhSachXuLy.Count > 0)
                {
                    listBoxControl1.DataSource = _danhSachXuLy;
                    chkGiuNguyenCauTrucThuMuc.Checked = giunguyencautructhumuc;
                    toggleSwitch2.IsOn = boquaneutrung;
                    var thumucnguon = Path.GetDirectoryName(_danhSachXuLy[0]);
                    txtPathPDF.Text = thumucnguon;
                    linkThuMucNguon.Text = thumucnguon;
                    btnXuLy.PerformClick();
                }
            }
            else
            {
                _danhSachXuLy = new List<string>();
            }
        }
        private void PageBitmapOcrReady(int PageNo, int ImageID)
        {
            //we're doing nothing yet.
        }
        private void BeforePageOcr(int pageNo, ref bool cancel)
        {
            //we're doing nothing yet.
        }
        private void OcrPagesProgress(GdPictureStatus status, int pageNo, int processed, int count, ref bool cancel)
        {
            this.Invoke(new Action(() =>
            {
                barStaticItem1.Caption = processed + "/" + count;
                proTienTrinhOCR.Maximum = count;
                proTienTrinhOCR.Value1 = processed;
                proTienTrinhOCR.Text = processed + "/" + count;
                if (status != GdPictureStatus.OK)
                {
                    if (!_cancellationPending)
                    {
                        Invoke(new Action(() =>
                        {
                            if (XtraMessageBox.Show("An error occured on page " + pageNo + ". Do you want to cancel the process? Status: " + status, "error", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
                            {
                                //cancel = true;
                                _cancellationPending = true;
                            }
                        }));
                    }
                }
            }));
            cancel = _cancellationPending;
        }
        private void OcrPagesDone(GdPictureStatus status)
        {
            if (status == GdPictureStatus.OK)
            {
                this.Invoke(new Action(() =>
                {
                    proTienTrinhOCR.Value1 = 0;
                    barStaticItem1.Caption = "...";
                }));
                //_stopwatch.Stop();

                outputFilePath_OCR_PROGRESS = linkThuMucKetQua.Text + "\\" + GUID_APP + "\\TEMP_PROCESS\\" + Path.GetFileNameWithoutExtension(fileNamePageProgress) + txtTenHauToPhiaSau_OCR.Text.Trim() + ".pdf";
                status = chkIncSave.Checked ? _nativePdf.SaveToFileInc(outputFilePath_OCR_PROGRESS) : _nativePdf.SaveToFile(outputFilePath_OCR_PROGRESS, true, true);
                if (status != GdPictureStatus.OK)
                {
                    Invoke(new Action(() =>
                    {
                        XtraMessageBox.Show("Can't save file " + outputFilePath_OCR_PROGRESS + " . Error: " + status);
                    }));
                }
                else
                {
                    //Process.Start(outputFilePath);
                }

                FileInfo FileVol = new FileInfo(outputFilePath_OCR_PROGRESS);
                SIZE_FILE_PDF_OCR = (int)(FileVol).Length / 1024;
                SIZE_BETWEEN_PDF_JP2_IS_TEXT = SIZE_FILE_PDF_OCR - SIZE_FILE_JP2;
            }
            else
            {
                Invoke(new Action(() =>
                {
                    XtraMessageBox.Show("An error occured. Status: " + status);
                }));
                ThreadSafeFileWriter.WriteFile("nen_ocr_dpi_log_exception", linkThuMucKetQua.Text, "An error occured. Status: " + status);
            }
            noiDungTEXT = noiDungTEXT + _nativePdf.GetPageText();
            _nativePdf.CloseDocument();

            bool checkDeleteTemp = false;
            bool giucautructhumuc = false;
            this.Invoke(new Action(() =>
            {
                checkDeleteTemp = chkDeleteTempAfterFinished.Checked;
                giucautructhumuc = chkGiuNguyenCauTrucThuMuc.Checked;
            }));
        }

        private void btnChonTaiLieuKy_Click(object sender, EventArgs e)
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Các tệp JPG,PDF (*.jpg;*pdf)|*.jpg;*.pdf";
            open.Multiselect = true;
            if (txtPathPDF.Text != "")
            {
                open.InitialDirectory = txtPathPDF.Text;
            }
            if (open.ShowDialog() == DialogResult.OK)
            {
                string folderPath = Path.GetDirectoryName(open.FileName);
                txtPathPDF.Text = folderPath;
                linkThuMucNguon.Text = folderPath;
                string[] listfiles = open.FileNames;
                foreach (var item in listfiles)
                {
                    var tenTapTinXuLy = System.IO.Path.GetFileNameWithoutExtension(item);
                    _danhSachXuLy.Add(item);
                }
            }
            if (_danhSachXuLy.Count > 0)
            {
                lblTongSoXuLy.Text = "Tổng số: " + _danhSachXuLy.Count;

                listBoxControl1.DataSource = _danhSachXuLy;
                btnXuLy.Enabled = true;
            }
            else
            {
                btnXuLy.Enabled = false;
            }
        }
        public string luu_duong_dan_chon_thu_muc = string.Empty;
        private void btnChonThuMucKy_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog())
            {
                if (luu_duong_dan_chon_thu_muc != "")
                {
                    folderBrowserDialog1.SelectedPath = luu_duong_dan_chon_thu_muc;
                }
                if (txtPathPDF.Text != "")
                {
                    luu_duong_dan_chon_thu_muc = txtPathPDF.Text;
                    folderBrowserDialog1.SelectedPath = txtPathPDF.Text;
                }
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    luu_duong_dan_chon_thu_muc = folderBrowserDialog1.SelectedPath;
                    luu_duong_dan_chon_thu_muc_ket_qua = folderBrowserDialog1.SelectedPath;
                    linkThuMucNguon.Text = folderBrowserDialog1.SelectedPath;
                    linkThuMucKetQua.Text = folderBrowserDialog1.SelectedPath;
                    txtPathPDF.Text = folderBrowserDialog1.SelectedPath;
                    txtThuMucKetQua.Text = folderBrowserDialog1.SelectedPath;
                    xulydanhsach(folderBrowserDialog1.SelectedPath);
                }
            }
        }
        public bool IsHavingGUID(string input)
        {
            MatchCollection guids = Regex.Matches(input, @"(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}");
            return guids.Count > 0;
        }
        private void xulydanhsach(string path)
        {
            if (!Directory.Exists(path))
            {
                XtraMessageBox.Show("Đường dẫn thư mục không tồn tại thực tế, vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            string foldername = path;
            var files = Directory.GetFiles(foldername, "*.*", SearchOption.AllDirectories);
            try
            {
                //In the class scope:
                Object lockMe = new Object();
                String[] files___ = Directory.EnumerateFiles(foldername, "*.*", SearchOption.AllDirectories).ToArray();
                Parallel.For(0, files___.Length,
                             index =>
                             {
                                 // chỉ lấy danh sách các file excel thôi
                                 if (files___[index] != "" && !IsHavingGUID(files___[index]))
                                 {
                                     // chỉ lấy danh sách các file pdf hoặc ảnh
                                     if (Path.GetExtension(files___[index]).ToLower() == ".pdf" ||
                                     Path.GetExtension(files___[index]).ToLower() == ".jpg" ||
                                     Path.GetExtension(files___[index]).ToLower() == ".jpeg" ||
                                     Path.GetExtension(files___[index]).ToLower() == ".png")
                                     {
                                         //In the function
                                         lock (lockMe)
                                         {
                                             _danhSachXuLy.Add(files___[index]);
                                         }
                                     }
                                 }
                             });
                listBoxControl1.DataSource = _danhSachXuLy;
            }
            catch (Exception ex)
            {
                ThreadSafeFileWriter.WriteFile("nen_ocr_dpi_log_exception", linkThuMucKetQua.Text, path + " => " + ex.Message + ", " + ex.InnerException + ", " + ex.StackTrace);
            }
            if (_danhSachXuLy.Count > 0)
            {
                lblTongSoXuLy.Text = "Tổng số: " + _danhSachXuLy.Count;
                btnXuLy.Enabled = true;
            }
            else
            {
                btnXuLy.Enabled = false;
            }
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {

        }
        public string luu_duong_dan_chon_thu_muc_ket_qua = string.Empty;
        private void btnChonThuMucKetQua_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog())
            {
                if (luu_duong_dan_chon_thu_muc_ket_qua != "")
                {
                    folderBrowserDialog1.SelectedPath = luu_duong_dan_chon_thu_muc_ket_qua;
                }
                if (txtThuMucKetQua.Text != "")
                {
                    folderBrowserDialog1.SelectedPath = txtThuMucKetQua.Text;
                }
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    luu_duong_dan_chon_thu_muc_ket_qua = folderBrowserDialog1.SelectedPath;
                    linkThuMucKetQua.Text = folderBrowserDialog1.SelectedPath;
                    txtThuMucKetQua.Text = folderBrowserDialog1.SelectedPath;
                }
            }
        }

        private void linkThuMucKetQua_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (linkThuMucKetQua.Text != "...")
            {
                Process.Start("Explorer.exe", @"/select,""" + linkThuMucKetQua.Text + "\"");
            }
        }

        private void btnXuLy_Click(object sender, EventArgs e)
        {
            if (txtThuMucKetQua.Text == "")
            {
                XtraMessageBox.Show("Bạn phải chọn thư mục đầu ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Start the background worker
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
            }
            else
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
        List<string> lstPDF_OCR_Page;
        List<string> lstPDFJPGPage;
        List<string> lstPDFJPGPageONLY;
        List<string> lstJPGPDFPage;
        List<string> lstJPG_JP2_Page;
        private bool xulyChuyenPDFthanhJPG(string pathPDF)
        {
            bool success = true;
            string caption = "Example: ExtractPageImage";
            GdPicturePDF oGdPicturePDFSrc = new GdPicturePDF();
            if (oGdPicturePDFSrc.LoadFromFile(pathPDF, true) == GdPictureStatus.OK)
            {
                int pageCount = oGdPicturePDFSrc.GetPageCount();
                GdPictureStatus status = oGdPicturePDFSrc.GetStat();
                if ((status == GdPictureStatus.OK) && (pageCount > 0))
                {
                    //The first page is automatically selected as the current page.
                    int imageCount = oGdPicturePDFSrc.GetPageImageCount();
                    status = oGdPicturePDFSrc.GetStat();
                    if ((status == GdPictureStatus.OK) && (imageCount > 0))
                    {
                        GdPictureImaging oGdPicturePDFDest = new GdPictureImaging();
                        string message = "";
                        var nameIMG = "";
                        for (int i = 1; i <= pageCount; i++)
                        {
                            oGdPicturePDFSrc.SelectPage(i);
                            nameIMG = Path.GetDirectoryName(pathPDF) + "\\" + Path.GetFileNameWithoutExtension(pathPDF) + "_page" + i + ".jpg";
                            lstPDFJPGPage.Add(nameIMG);
                            lstPDFJPGPageONLY.Add(nameIMG);
                            //Rendering the selected page to an image.
                            int imageId = oGdPicturePDFSrc.RenderPageToGdPictureImage(300, true);
                            //Checking if the image has been rendered successfully.
                            if (oGdPicturePDFSrc.GetStat() == GdPictureStatus.OK)
                            {
                                //oGdPicturePDFDest.CropTop(imageId, 50);
                                //oGdPicturePDFDest.CropBottom(imageId, 50);
                                //oGdPicturePDFDest.CropLeft(imageId, 50);
                                //oGdPicturePDFDest.Scale(imageId, (float)70, InterpolationMode.NearestNeighbor);
                                //oGdPicturePDFDest.CropRight(imageId, 20);
                                //Saving the image to a file.
                                if (oGdPicturePDFDest.SaveAsJPEG(imageId, nameIMG) != GdPictureStatus.OK)
                                {
                                    success = false;
                                    message = message + "Error occurred when saving the image. Error: " + oGdPicturePDFSrc.GetStat().ToString();
                                    barStaticItem2.Caption = "Error occurred when saving the image. Error: " + oGdPicturePDFSrc.GetStat();
                                    ThreadSafeFileWriter.WriteFile("ocr_dpi_danh_sach_loi", linkThuMucKetQua.Text, GUID_APP + ": " + message);
                                }
                                else
                                    message = message + "Done!";
                                oGdPicturePDFDest.ReleaseGdPictureImage(imageId);
                            }
                            else
                            {
                                success = false;
                                message = message + "Error occurred when rendering the page to an image. Error: " + oGdPicturePDFSrc.GetStat().ToString();
                                barStaticItem2.Caption = "Error occurred when rendering the page to an image. Error: " + oGdPicturePDFSrc.GetStat();
                                ThreadSafeFileWriter.WriteFile("ocr_dpi_danh_sach_loi", linkThuMucKetQua.Text, GUID_APP + ": " + message);
                            }
                            //if (oGdPicturePDFDest.SaveAsJPEG(imageID, nameIMG) == GdPictureStatus.OK)
                            //    message = message + "The file has been saved successfully.";
                            //else
                            //    message = message + "The file can't be saved. Status: " + oGdPicturePDFDest.GetStat().ToString();
                        }
                        oGdPicturePDFDest.Dispose();
                    }
                    else
                    {
                        success = false;
                        Invoke(new Action(() =>
                        {
                            if (status == GdPictureStatus.OK)
                            {
                                //MessageBox.Show("The first page doesn't contain any image.", caption);
                                barStaticItem2.Caption = "The first page doesn't contain any image.";
                                ThreadSafeFileWriter.WriteFile("ocr_dpi_danh_sach_loi", linkThuMucKetQua.Text, GUID_APP + ": The first page doesn't contain any image");
                            }
                            else
                            {
                                //MessageBox.Show("The GetPageImageCount() method has failed with the status: " + status.ToString(), caption);
                                barStaticItem2.Caption = "The GetPageImageCount() method has failed with the status: " + status;
                                ThreadSafeFileWriter.WriteFile("ocr_dpi_danh_sach_loi", linkThuMucKetQua.Text, GUID_APP + ": " + "The GetPageImageCount() method has failed with the status: " + status.ToString());
                            }
                        }));
                    }
                }
                else
                {
                    success = false;
                    Invoke(new Action(() =>
                    {
                        if (status == GdPictureStatus.OK)
                        {
                            //MessageBox.Show("The first page doesn't contain any image.", caption);
                            barStaticItem2.Caption = "The first page doesn't contain any image.";
                            ThreadSafeFileWriter.WriteFile("ocr_dpi_danh_sach_loi", linkThuMucKetQua.Text, GUID_APP + ": The first page doesn't contain any image");
                        }
                        else
                        {
                            //MessageBox.Show("The GetPageImageCount() method has failed with the status: " + status.ToString(), caption);
                            barStaticItem2.Caption = "The GetPageImageCount() method has failed with the status: " + status;
                            ThreadSafeFileWriter.WriteFile("ocr_dpi_danh_sach_loi", linkThuMucKetQua.Text, GUID_APP + ": " + "The GetPageImageCount() method has failed with the status: " + status.ToString());
                        }
                    }));
                }
            }
            else
            {
                Invoke(new Action(() =>
                {
                    //MessageBox.Show("The file can't be loaded.", caption);
                    barStaticItem2.Caption = "The file can't be loaded: " + pathPDF;
                    ThreadSafeFileWriter.WriteFile("ocr_dpi_danh_sach_loi", linkThuMucKetQua.Text, GUID_APP + ": " + "The file can't be loaded: " + pathPDF);
                }));
            }
            oGdPicturePDFSrc.Dispose();
            return success;
        }
        private string xulyChuyenJPGthanhPDF(string pathJPG, string pathPDF)
        {
            using (GdPictureDocumentConverter gdpictureDocumentConverter = new GdPictureDocumentConverter())
            {
                using (Stream inputStream = File.Open(pathJPG, System.IO.FileMode.Open))
                {
                    using (Stream outputStream = File.Create(pathPDF))
                    {
                        try
                        {
                            gdpictureDocumentConverter.ConvertToPDF(inputStream, GdPicture14.DocumentFormat.DocumentFormatJPEG, outputStream, PdfConformance.PDF1_7);
                        }
                        catch (Exception ex)
                        {
                            ThreadSafeFileWriter.WriteFile("nen_ocr_dpi_log_exception", linkThuMucKetQua.Text, pathJPG + " => " + ex.Message + ", " + ex.InnerException + ", " + ex.StackTrace);
                        }
                    }
                }
            }
            return "";
        }
        private void showStack(int value)
        {
            Invoke(new Action(() =>
            {
                if (progressStack.Maximum < value)
                {
                    progressStack.Maximum = value;
                }
                progressStack.Value1 = value;
                progressStack.Text = value.ToString();
            }));
        }
        private bool checkIMAGE(string path)
        {
            bool result_img = false;
            GdPictureImaging oGdPictureImaging = new GdPictureImaging();
            int imageID = oGdPictureImaging.CreateGdPictureImageFromFile(path, true);
            if (oGdPictureImaging.GetStat() == GdPictureStatus.OK)
            //It stands for (imageID != 0), but feel free to check it.
            {
                result_img = true;
            }
            else
            {
                result_img = false;
            }
            oGdPictureImaging.ReleaseGdPictureImage(imageID);
            oGdPictureImaging.Dispose();
            return result_img;
        }
        private bool checkPDF(string path)
        {
            bool result_pdf = false;
            GdPicturePDF oGdPicturePDF = new GdPicturePDF();
            GdPictureStatus status = oGdPicturePDF.LoadFromFile(path, true);
            if (status != GdPictureStatus.OK)
            {
                result_pdf = false;
            }
            else
            {
                result_pdf = true;
            }
            oGdPicturePDF.Dispose();
            return result_pdf;
        }
        private void ghiFile(string path, string noidung)
        {
            string filepath = path;
            using (var stream = new FileStream(path: filepath, mode: FileMode.Create, access: FileAccess.Write, share: FileShare.ReadWrite))
            {
                //Write BOM - UTF8
                Encoding encoding = Encoding.UTF8;
                byte[] bom = encoding.GetPreamble();
                stream.Write(bom, 0, bom.Length);

                string s1 = noidung;

                // Encode chuỗi - lưu vào mảng bytes
                byte[] buffer = encoding.GetBytes(s1);
                stream.Write(buffer, 0, buffer.Length);  // lưu vào stream
            }

            //using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
            //using (StreamWriter sw = new StreamWriter(fs))
            //{
            //    sw.Write(noidung);
            //}
        }
        public bool ContainsUnicodeCharacter(string input)
        {
            const int MaxAnsiCode = 255;
            return input.Any(c => c > MaxAnsiCode);
        }
        public static void DeleteDirectory(string directory)
        {
            if (Directory.Exists(directory))
            {
                // First delete all the files, making sure they are not readonly
                var stackA = new Stack<DirectoryInfo>();
                stackA.Push(new DirectoryInfo(directory));

                var stackB = new Stack<DirectoryInfo>();
                while (stackA.Any())
                {
                    var dir = stackA.Pop();
                    foreach (var file in dir.GetFiles())
                    {
                        file.IsReadOnly = false;
                        file.Delete();
                    }
                    foreach (var subDir in dir.GetDirectories())
                    {
                        stackA.Push(subDir);
                        stackB.Push(subDir);
                    }
                }

                // Then delete the sub directories depth first
                while (stackB.Any())
                {
                    stackB.Pop().Delete();
                }

                Directory.Delete(directory, true);
            }
        }

        // hiển thị đồ thị trực quan
        List<DataPointType> lstTIME_PROC = new List<DataPointType>();
        List<DataPointType> lstTIME_PROC2 = new List<DataPointType>();
        List<DataPointType> lstTIME_PROC3 = new List<DataPointType>();

        string APP = "";
        string directory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

        string loaiKhoGiay = "";
        bool IS_XULY_LAI = false;
        // xử lý tự động
        int SIZE_FILE_JP2;                // kích thước jp2
        int SIZE_FILE_PDF_OCR;            // kích thước file đã OCR
        int SIZE_BETWEEN_PDF_JP2_IS_TEXT; // kích thước text trên file
        bool OCR = false;
        string outputFilePath_OCR_PROGRESS = "";
        string outputFilePath_JP2_PROGRESS = "";
        private Stopwatch _stopwatch = new Stopwatch();
        private void xuly()
        {
            DataPointType point_ = new DataPointType();
            DataPointType point2_ = new DataPointType();
            DataPointType point3_ = new DataPointType();
            point_.x = 0;
            point_.y = 0;
            lstTIME_PROC.Add(point_);
            lstTIME_PROC2.Add(point_);
            lstTIME_PROC3.Add(point_);

            SIZE_FILE_JP2 = 0;
            SIZE_FILE_PDF_OCR = 0;
            SIZE_BETWEEN_PDF_JP2_IS_TEXT = 0;

            // kiểm tra xem file có khác nhau (về dung lượng không?)
            bool IS_DEFRENCE = false;
            // lưu danh sách các tỷ lệ đã xử lý
            Stack<int> rateA234 = new Stack<int>();

            string loaiKhoGiayCheck = "";
            string loaiKhoGiay = "";
            int solanxuly = 0;

            // xử lý lần lượt từng file
            int stt_xulytep = 0;
            int _tongsotaptin = _danhSachXuLy.Count;
            Invoke(new Action(() =>
            {
                progressPanel1.Visible = true;
                proTongSoTepXL.Maximum = _danhSachXuLy.Count;
            }));
            ghiFile("auto_dpi\\" + APP_ID + ".txt", "0/" + _tongsotaptin); // khởi tạo
            foreach (var pathXuLy in _danhSachXuLy.ToList())
            {
                stt_xulytep++;
                Invoke(new Action(() =>
                {
                    proTongSoTepXL.Text = Path.GetFileNameWithoutExtension(pathXuLy);
                    proTongSoTepXL.Value1 = stt_xulytep;
                    lblDangXuLyTapTin.Text = stt_xulytep + "/" + _danhSachXuLy.Count;
                }));
                if (boquaneutrung)
                {
                    var tenkiemtra = tenfileKetQuaXuLy(pathXuLy);
                    if (File.Exists(tenkiemtra))
                    {
                        Invoke(new Action(() =>
                        {
                            lblTrangThai.Text = "Tệp đã được xử lý, bỏ qua...";
                        }));
                        ghiFile("auto_dpi\\" + APP_ID + ".txt", stt_xulytep + "/" + _tongsotaptin);
                        continue;
                    }
                }

                _stopwatch.Start();

                lstPDFJPGPage = new List<string>();
                lstPDFJPGPageONLY = new List<string>();
                lstJPGPDFPage = new List<string>();
                lstJPG_JP2_Page = new List<string>();

                if (Path.GetExtension(pathXuLy) == ".pdf")
                {
                    if (!checkPDF(pathXuLy))
                    {
                        _danhSachXuLyERROR.Add(pathXuLy);
                        _danhSachXuLy.RemoveAll(x => ((string)x) == pathXuLy);
                        _tongsotaptin = _danhSachXuLy.Count;
                        this.Invoke(new Action(() =>
                        {
                            lblStatusXemDanhSachERROR.Caption = _danhSachXuLyERROR.Count + " tệp lỗi";
                            lblStatusXemDanhSachERROR.ItemAppearance.Normal.BackColor = Color.Red;
                            proTongSoTepXL.Maximum = _tongsotaptin;
                        }));
                        ghiFile("auto_dpi\\" + APP_ID + ".txt", stt_xulytep + "/" + _tongsotaptin);
                        ThreadSafeFileWriter.WriteFile("ocr_dpi_danh_sach_loi", linkThuMucKetQua.Text, GUID_APP + ": " + pathXuLy);
                        continue;
                    }
                    // thực hiện chuyển tất cả file pdf sang các trang
                    var convert_result = xulyChuyenPDFthanhJPG(pathXuLy);
                    if (!convert_result)
                    {
                        ThreadSafeFileWriter.WriteFile("ocr_dpi_danh_sach_loi", linkThuMucKetQua.Text, GUID_APP + ": Lỗi k chuyển dc pdf sang jpg để xử lý: " + pathXuLy);
                        continue;
                    }
                }
                else // nếu chỉ có ảnh thì vẫn thêm vào danh sách
                {
                    if (!checkIMAGE(pathXuLy))
                    {
                        _danhSachXuLyERROR.Add(pathXuLy);
                        _danhSachXuLy.RemoveAll(x => ((string)x) == pathXuLy);
                        _tongsotaptin = _danhSachXuLy.Count;
                        this.Invoke(new Action(() =>
                        {
                            lblStatusXemDanhSachERROR.Caption = _danhSachXuLyERROR.Count + " tệp lỗi";
                            proTongSoTepXL.Maximum = _tongsotaptin;
                        }));
                        ghiFile("auto_dpi\\" + APP_ID + ".txt", stt_xulytep + "/" + _tongsotaptin);
                        ThreadSafeFileWriter.WriteFile("ocr_dpi_danh_sach_loi", linkThuMucKetQua.Text, GUID_APP + ": " + pathXuLy);
                        continue;
                    }
                    lstPDFJPGPage.Add(pathXuLy);
                }
                // thực hiện xử lý danh sách ảnh trên

                int dangxulytrang = 0;
                int rateA234_MUC_NEN = 0;

                lstPDF_OCR_Page = new List<string>();
                Invoke(new Action(() =>
                {
                    proTongSoTrangXL1Tep.Maximum = lstPDFJPGPage.Count;
                }));
                foreach (var danhSachAnh in lstPDFJPGPage)
                {
                    fileNamePageProgress = danhSachAnh;
                    dangxulytrang++;
                    Invoke(new Action(() =>
                    {
                        proTongSoTrangXL1Tep.Text = "Trang " + dangxulytrang + "/" + lstPDFJPGPage.Count;
                        proTongSoTrangXL1Tep.Value1 = dangxulytrang;
                    }));

                XULY_SIZE_PAGE:

                    _currentImage = _gdPictureImaging.CreateGdPictureImageFromFile(danhSachAnh, true);
                    GdPictureStatus status = _gdPictureImaging.GetStat();
                    if (status != GdPictureStatus.OK)
                    {
                        //XtraMessageBox.Show(this, "Cannot open file : " + status, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ThreadSafeFileWriter.WriteFile("ocr_dpi_danh_sach_loi", linkThuMucKetQua.Text, GUID_APP + ": " + "Cannot open file : " + danhSachAnh);
                        _danhSachXuLyERROR.Add(pathXuLy + ":=>" + danhSachAnh);
                        continue;
                    }
                    // tạo thư mục tạm để lưu ảnh đã được áp dụng xử lý biến đổi: thay đổi kích thước, độ sáng, tương phản,...
                    System.IO.Directory.CreateDirectory(linkThuMucKetQua.Text + "\\" + GUID_APP + "\\TEMP_PROCESS");
                    int SizeinKB = 0;
                    int sizeA4 = 150;
                    int rateJP = 400; //Specifies the compression rate [1(MaxQuality - Lossless) ... 512(Poor quality)]

                    int tham_so = 25;//tham số tính tỷ lệ
                    int xulylap = 2;//bước tính bắt đầu (phụ thuộc loại giấy sẽ khác nhau, để tăng tốc)

                    ResetSizeValues();

                    // tiêu chuẩn A4 làm gốc
                    int CHATLUONG_GIAY = Convert.ToInt32(txtDungLuongChuanA4.Text);

                    if (trackQuality.Maximum < CHATLUONG_GIAY)
                    {
                        trackQuality.Maximum = CHATLUONG_GIAY;
                        trackQualityNumber.Maximum = CHATLUONG_GIAY;
                    }
                    // nếu sử dụng chế độ nhận diện tự động
                    if (chkNhanDienTuDong.Checked)
                    {
                        decimal laychieurongnhonhat = nWidth.Value;
                        decimal laychieudailonnhat = nHeight.Value;
                        if (nWidth.Value > nHeight.Value)
                        {
                            laychieurongnhonhat = nHeight.Value;
                            laychieudailonnhat = nWidth.Value;
                        }

                        if (laychieurongnhonhat <= 2980 && laychieudailonnhat < 3800) // khổ A4 2980||3400||3990
                        {
                            Invoke(new Action(() =>
                            {
                                rdoKhoA4.IsChecked = true;
                            }));
                            if (!IS_XULY_LAI)
                            {
                                Invoke(new Action(() =>
                                {
                                    trackQuality.Value = CHATLUONG_GIAY;
                                    trackQualityNumber.Value = CHATLUONG_GIAY;
                                }));
                            }
                            loaiKhoGiay = "4";
                            tham_so = 15;
                            xulylap = 18;
                            if (SIZE_BETWEEN_PDF_JP2_IS_TEXT != 0)
                            {
                                sizeA4 = CHATLUONG_GIAY - SIZE_BETWEEN_PDF_JP2_IS_TEXT - 1;
                                if (!IS_XULY_LAI)
                                {
                                    Invoke(new Action(() =>
                                    {
                                        trackQuality.Value = sizeA4;
                                        trackQualityNumber.Value = sizeA4;
                                    }));
                                }
                            }
                        }
                        else
                        {
                            tham_so = 20;
                            xulylap = 9;
                            if (laychieurongnhonhat <= 5960 && laychieudailonnhat < 7500/* && laychieurongnhonhat * 2 > laychieudailonnhat*/) // khổ A3  5000
                            {
                                Invoke(new Action(() =>
                                {
                                    rdoKhoA3.IsChecked = true;
                                }));
                                if (!IS_XULY_LAI)
                                {
                                    Invoke(new Action(() =>
                                    {
                                        trackQuality.Value = CHATLUONG_GIAY * 2;
                                        trackQualityNumber.Value = CHATLUONG_GIAY * 2;
                                    }));
                                }
                                loaiKhoGiay = "3";
                            }
                            else // khổ A2
                            {
                                tham_so = 40;
                                xulylap = 4;
                                Invoke(new Action(() =>
                                {
                                    rdoKhoA2.IsChecked = true;
                                }));
                                if (!IS_XULY_LAI)
                                {
                                    Invoke(new Action(() =>
                                    {
                                        trackQuality.Value = CHATLUONG_GIAY * 4 + 50;
                                        trackQualityNumber.Value = CHATLUONG_GIAY * 4 + 50;
                                    }));
                                }
                                rateJP = 350;
                                loaiKhoGiay = "2";
                            }
                            if (SIZE_BETWEEN_PDF_JP2_IS_TEXT != 0)
                            {
                                if (loaiKhoGiay == "3")
                                {
                                    sizeA4 = CHATLUONG_GIAY * 2 - SIZE_BETWEEN_PDF_JP2_IS_TEXT - 1;
                                }
                                else
                                {
                                    sizeA4 = CHATLUONG_GIAY * 4 - SIZE_BETWEEN_PDF_JP2_IS_TEXT - 2;
                                }
                                if (!IS_XULY_LAI)
                                {
                                    Invoke(new Action(() =>
                                    {
                                        trackQuality.Value = sizeA4;
                                        trackQualityNumber.Value = sizeA4;
                                    }));
                                }
                            }
                        }
                        if (chkXuLyChuyenSau.Checked)
                        {
                            tham_so = 1;
                        }
                    }
                    else
                    {
                        if (rdoKhoA4.IsChecked)
                        {
                            if (!IS_XULY_LAI)
                            {
                                Invoke(new Action(() =>
                                {
                                    trackQuality.Value = CHATLUONG_GIAY;
                                    trackQualityNumber.Value = CHATLUONG_GIAY;
                                }));
                            }
                            loaiKhoGiay = "4";
                            tham_so = 15;
                            xulylap = 18;
                            if (SIZE_BETWEEN_PDF_JP2_IS_TEXT != 0)
                            {
                                sizeA4 = CHATLUONG_GIAY - SIZE_BETWEEN_PDF_JP2_IS_TEXT - 1;
                                if (!IS_XULY_LAI)
                                {
                                    Invoke(new Action(() =>
                                    {
                                        trackQuality.Value = sizeA4;
                                        trackQualityNumber.Value = sizeA4;
                                    }));
                                }
                            }
                        }
                        if (rdoKhoA3.IsChecked)
                        {
                            tham_so = 20;
                            xulylap = 9;
                            if (!IS_XULY_LAI)
                            {
                                Invoke(new Action(() =>
                                {
                                    trackQuality.Value = CHATLUONG_GIAY * 2;
                                    trackQualityNumber.Value = CHATLUONG_GIAY * 2;
                                }));
                            }
                            loaiKhoGiay = "3";
                        }
                        if (rdoKhoA2.IsChecked)
                        {
                            tham_so = 40;
                            xulylap = 4;
                            if (!IS_XULY_LAI)
                            {
                                Invoke(new Action(() =>
                                {
                                    trackQuality.Value = CHATLUONG_GIAY * 4 + 50;
                                    trackQualityNumber.Value = CHATLUONG_GIAY * 4 + 50;
                                }));
                            }
                            rateJP = 350;
                            loaiKhoGiay = "2";
                        }
                        if (SIZE_BETWEEN_PDF_JP2_IS_TEXT != 0)
                        {
                            if (loaiKhoGiay == "3")
                            {
                                sizeA4 = CHATLUONG_GIAY * 2 - SIZE_BETWEEN_PDF_JP2_IS_TEXT - 1;
                            }
                            else if (loaiKhoGiay == "2")
                            {
                                sizeA4 = CHATLUONG_GIAY * 4 - SIZE_BETWEEN_PDF_JP2_IS_TEXT - 2;
                            }
                            else
                            {
                                sizeA4 = CHATLUONG_GIAY - SIZE_BETWEEN_PDF_JP2_IS_TEXT;
                            }
                            if (!IS_XULY_LAI)
                            {
                                Invoke(new Action(() =>
                                {
                                    trackQuality.Value = sizeA4;
                                    trackQualityNumber.Value = sizeA4;
                                }));
                            }
                        }
                        if (chkXuLyChuyenSau.Checked)
                        {
                            tham_so = 1;
                        }
                    }
                    sizeA4 = (int)trackQualityNumber.Value;
                    //=======================================================================================
                    if (loaiKhoGiayCheck != loaiKhoGiay)// nếu là loại A23
                    {
                        loaiKhoGiayCheck = loaiKhoGiay;
                        rateA234.Clear();// reset lại stack
                        switch (loaiKhoGiayCheck)
                        {
                            case "4"://khổ A4
                                rateA234.Push(1);
                                rateA234.Push(2);
                                rateA234.Push(3);
                                rateA234.Push(4);
                                rateA234.Push(5);
                                rateA234.Push(6);
                                rateA234.Push(7);
                                rateA234.Push(8);
                                rateA234.Push(9);
                                rateA234.Push(10);
                                rateA234.Push(11);
                                rateA234.Push(12);
                                rateA234.Push(13);
                                rateA234.Push(14);
                                rateA234.Push(15);
                                rateA234.Push(16);
                                rateA234.Push(17);
                                rateA234.Push(18);
                                break;
                            case "3"://khổ A3
                                rateA234.Push(1);
                                rateA234.Push(2);
                                rateA234.Push(3);
                                rateA234.Push(4);
                                rateA234.Push(5);
                                rateA234.Push(6);
                                rateA234.Push(7);
                                rateA234.Push(8);
                                rateA234.Push(9);
                                break;
                            case "2"://khổ A2
                                rateA234.Push(1);
                                rateA234.Push(2);
                                rateA234.Push(3);
                                rateA234.Push(4);
                                break;
                            default:
                                break;
                        }
                        IS_XULY_LAI = false;
                        IS_DEFRENCE = true;
                        SIZE_BETWEEN_PDF_JP2_IS_TEXT = 0;
                    }
                    if (loaiKhoGiay != "")
                    {
                        Invoke(new Action(() =>
                        {
                            switch (loaiKhoGiay)
                            {
                                case "2":
                                    lblLoaiKhoGiay.Text = "Khổ A2";
                                    break;
                                case "3":
                                    lblLoaiKhoGiay.Text = "Khổ A3";
                                    break;
                                case "4":
                                    lblLoaiKhoGiay.Text = "Khổ A4";
                                    break;
                                default:
                                    lblLoaiKhoGiay.Text = "Khổ A?...";
                                    break;
                            }
                        }));
                    }
                    else
                    {
                        Invoke(new Action(() =>
                        {
                            lblLoaiKhoGiay.Text = "...";
                        }));
                    }

                    if (rateA234.Count > 0)
                    {
                        showStack(rateA234.Peek());
                    }
                    else
                    {
                        showStack(0);
                    }
                    //=======================================================================================

                    int tyleRate = 500;
                    if (dangxulytrang > 1 && !IS_DEFRENCE)
                    {
                        IS_XULY_LAI = true;
                    }
                    if (!IS_XULY_LAI)
                    {
                        if (dangxulytrang == 1)
                        {
                            Invoke(new Action(() =>
                            {
                                if (loaiKhoGiayCheck == "4")
                                {
                                    if (chkXuLyChuyenSau.Checked)
                                    {
                                        for (int i = 0; i < 300; i++)
                                        {
                                            xulylap++;
                                            // đẩy vào ds xử lý
                                            rateA234.Push(xulylap);
                                        }
                                    }
                                }
                                if (loaiKhoGiayCheck == "3")
                                {
                                    if (chkXuLyChuyenSau.Checked)
                                    {
                                        for (int i = 0; i < 200; i++)
                                        {
                                            xulylap++;
                                            // đẩy vào ds xử lý
                                            rateA234.Push(xulylap);
                                        }
                                    }
                                }
                                if (loaiKhoGiayCheck == "2")
                                {
                                    if (chkXuLyChuyenSau.Checked)
                                    {
                                        for (int i = 0; i < 100; i++)
                                        {
                                            xulylap++;
                                            // đẩy vào ds xử lý
                                            rateA234.Push(xulylap);
                                        }
                                    }
                                }
                            }));
                        }
                        do
                        {
                            solanxuly++;
                            FileInfo FileVol;
                            // Nếu xử lý tệp đầu tiên
                            outputFilePath_JP2_PROGRESS = linkThuMucKetQua.Text + "\\" + GUID_APP + "\\TEMP_PROCESS\\" + Path.GetFileNameWithoutExtension(danhSachAnh) + ".jp2";
                            if (dangxulytrang == 1)
                            {
                                xulylap++;
                                // đẩy vào ds xử lý
                                rateA234.Push(xulylap);
                                showStack(rateA234.Peek());
                                Invoke(new Action(() =>
                                {
                                    progressPanel1.Caption = xulylap.ToString();
                                    lblTrangThai3.Text = "Đang xử lý: " + SizeinKB + "KB (rate: " + (tyleRate - tham_so * rateA234.Peek()) + "/500)";
                                }));
                                var TYLE_XULY_CURREN = tyleRate - tham_so * rateA234.Peek(); // 512 - XXXX =>....1 (max)
                                if (TYLE_XULY_CURREN <= 0)
                                {
                                    TYLE_XULY_CURREN = 1;
                                }
                                // tỷ lệ < thì chất lượng tốt và ngược lại (poor 512, rich 1)
                                _gdPictureImaging.SaveAsJP2(_currentImage, outputFilePath_JP2_PROGRESS, TYLE_XULY_CURREN);
                                FileVol = new FileInfo(outputFilePath_JP2_PROGRESS);
                                SizeinKB = (int)(FileVol).Length / 1024;
                            }
                            else
                            // Nếu xử lý từ tệp thứ 2 trở đi
                            {
                                showStack(rateA234.Peek());
                                Invoke(new Action(() =>
                                {
                                    progressPanel1.Caption = rateA234.Peek().ToString();
                                }));
                                // lấy tỷ lệ đã sử dụng trước đó
                                var TYLE_XULY_CURREN = tyleRate - tham_so * rateA234.Peek();
                                if (TYLE_XULY_CURREN <= 0)
                                {
                                    TYLE_XULY_CURREN = 1;
                                }
                                _gdPictureImaging.SaveAsJP2(_currentImage, outputFilePath_JP2_PROGRESS, TYLE_XULY_CURREN);
                                FileVol = new FileInfo(outputFilePath_JP2_PROGRESS);
                                SizeinKB = (int)(FileVol).Length / 1024;
                                if (SizeinKB <= sizeA4)
                                {
                                    rateA234.Push(rateA234.Peek() + 1);
                                }
                                else
                                {
                                    //rateA234.Pop();                                   
                                }
                                showStack(rateA234.Peek());
                            }
                            Invoke(new Action(() =>
                            {
                                proTyLeNen.Text = "Rate:" + (tyleRate - tham_so * rateA234.Peek()) + "/500 (" + SizeinKB + " KB)";
                                if (proTyLeNen.Maximum < SizeinKB)
                                {
                                    proTyLeNen.Maximum = SizeinKB;
                                }
                                proTyLeNen.Value2 = rateJP;
                                lblDungLuongDaXuLy.Text = SizeinKB.ToString();
                            }));

                            //if (SizeinKB + 50 > sizeA4)
                            //{
                            //    break;
                            //}
                            if (tyleRate - tham_so * rateA234.Peek() < 0)
                            {
                                break;
                            }
                        } while (SizeinKB <= sizeA4);
                    }
                    else
                    {
                        solanxuly++;
                        if (rateA234.Count > 0)
                        {
                            rateA234.Pop();
                        }
                        if (rateA234.Count == 0)
                        {
                            rateA234_MUC_NEN = 0;
                            showStack(0);

                            Invoke(new Action(() =>
                            {
                                lblTrangThai2.Text = "ĐẠT MỨC NÉN TỐI ĐA...";
                                lblTrangThai3.Text = "-compress...";
                            }));
                        }
                        else
                        {
                            rateA234_MUC_NEN = rateA234.Peek();
                            showStack(rateA234.Peek());
                        }
                        Invoke(new Action(() =>
                        {
                            progressPanel1.Caption = rateA234_MUC_NEN.ToString();
                        }));
                        _gdPictureImaging.SaveAsJP2(_currentImage, outputFilePath_JP2_PROGRESS, tyleRate - tham_so * rateA234_MUC_NEN);
                        FileInfo FileVol = new FileInfo(outputFilePath_JP2_PROGRESS);
                        SizeinKB = (int)(FileVol).Length / 1024;
                        if (SizeinKB <= sizeA4)
                        {
                            rateA234.Push(rateA234_MUC_NEN + 1);
                        }
                        else
                        {
                            //rateA234.Pop();
                        }
                        if (tyleRate - tham_so * rateA234_MUC_NEN < 0)
                        {

                        }
                        showStack(rateA234_MUC_NEN);
                    }
                    SIZE_FILE_JP2 = SizeinKB;
                    string outputFilePath_PDF_PROGRESS = linkThuMucKetQua.Text + "\\" + GUID_APP + "\\TEMP_PROCESS\\" + Path.GetFileNameWithoutExtension(danhSachAnh) + ".pdf";
                    _gdPictureImaging.ReleaseGdPictureImage(_currentImage);

                    APP = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Programs\Python\Python38-32\Scripts\img2pdf.exe");
                    // thực hiện chuyển bình thường
                    ExecuteCommandSync(APP, "\"" + outputFilePath_JP2_PROGRESS + "\" -o \"" + outputFilePath_PDF_PROGRESS + "\"");

                    // kiểm tra chuyển jp2 sang pdf có thành công không?
                    if (!checkPDF(outputFilePath_PDF_PROGRESS))
                    {
                        ThreadSafeFileWriter.WriteFile("ocr_dpi_danh_sach_loi", linkThuMucKetQua.Text, GUID_APP + ": jp2 to pdf lỗi: " + pathXuLy + ": =>" + outputFilePath_PDF_PROGRESS);
                        barStaticItem2.Caption = "jp2 to pdf lỗi: " + pathXuLy + ": =>" + outputFilePath_PDF_PROGRESS;
                        _danhSachXuLyERROR.Add(pathXuLy + ":jp2 to pdf lỗi =>" + outputFilePath_PDF_PROGRESS);
                        continue;
                    }

                    // điều chỉnh tỷ lệ
                    string outputFilePath_PDF_PROGRESS_SCALE = dieuchinhtyle(outputFilePath_PDF_PROGRESS);

                    // thực hiện ocr
                    if (_nativePdf.LoadFromFile(outputFilePath_PDF_PROGRESS_SCALE, false) == GdPictureStatus.OK)
                    {
                        if (_nativePdf.IsEncrypted())
                        {   //PDF is encrypted, try to decrypt by using empty password
                            if (_nativePdf.SetPassword("") == GdPictureStatus.OK)
                            {
                                //Invoke(new Action(() =>
                                //{
                                //    XtraMessageBox.Show("This PDF is password protected", "operation cancelled", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                //}));
                                ThreadSafeFileWriter.WriteFile("nen_ocr_dpi_log_exception", linkThuMucKetQua.Text, "This PDF is password protected: " + outputFilePath_PDF_PROGRESS_SCALE);
                                _nativePdf.CloseDocument();
                                //return;
                                continue;
                            }
                        }
                        if (true)
                        {
                            float resolution = float.Parse(txtDPI.Text);
                            _cancellationPending = false;
                            int threadCount = chkMultithread.Checked ? 0 : 1;
                            OCRMode ocrMode = chkFavorSpeed.Checked ? OCRMode.FavorSpeed : OCRMode.FavorAccuracy;
                            //_stopwatch.Restart();  
                            if (chkTuDongXuLyTepMeo.Checked)
                                _nativePdf.AutoDeskew(15, true);
                            //_nativePdf.SetOcrPageOrientationDetection(chkEnablePageOrientationDetection.Checked);
                            _nativePdf.OcrPages("*", threadCount, cmbLang.Text, txtDictsPath.Text, "", resolution, ocrMode, 0, true);
                        }
                    }
                    else
                    {
                        //Invoke(new Action(() =>
                        //{
                        //    XtraMessageBox.Show("Can't open file: " + outputFilePath_PDF_PROGRESS_SCALE);
                        //}));
                        ThreadSafeFileWriter.WriteFile("nen_ocr_dpi_log_exception", linkThuMucKetQua.Text, "Can't open file: " + outputFilePath_PDF_PROGRESS_SCALE);
                        _nativePdf.CloseDocument();
                        continue;
                    }
                    _nativePdf.CloseDocument();

                    // thực hiện kiểm tra dung lượng file
                    // Kiểm tra dung lượng sau khi xử lý xong các bước
                    FileInfo FileVol_FINAL_PAGE = new FileInfo(outputFilePath_OCR_PROGRESS);
                    long SizeinKB_FINAL_PAGE = FileVol_FINAL_PAGE.Length / 1024;
                    int SizeinKB_FINAL_NEED_PAGE = 100;

                    // dung lượng file cần thiết
                    SizeinKB_FINAL_NEED_PAGE = Convert.ToInt32(txtDungLuongChuanA4.Text);

                    // nếu tự động nhận diện khổ giấy
                    if (chkNhanDienTuDong.Checked)
                    {
                        decimal laychieurongnhonhat = nWidth.Value;
                        decimal laychieudailonnhat = nHeight.Value;
                        if (nWidth.Value > nHeight.Value)
                        {
                            laychieurongnhonhat = nHeight.Value;
                            laychieudailonnhat = nWidth.Value;
                        }
                        if (laychieurongnhonhat <= 2980 && laychieudailonnhat < 3800) // khổ A4    2980- 2780 - điều chỉnh nhận kích thước||3400||3990
                        {
                            SizeinKB_FINAL_NEED_PAGE = Convert.ToInt32(txtDungLuongChuanA4.Text);
                        }
                        else
                        {
                            if (laychieurongnhonhat <= 5960 && laychieudailonnhat < 7500/*&& laychieurongnhonhat * 2 > laychieudailonnhat*/) // khổ A3  5000
                            {
                                SizeinKB_FINAL_NEED_PAGE = Convert.ToInt32(txtDungLuongChuanA4.Text) * 2;
                            }
                            else // khổ A2 = 4*A4
                            {
                                SizeinKB_FINAL_NEED_PAGE = Convert.ToInt32(txtDungLuongChuanA4.Text) * 4;
                            }
                        }
                    }
                    else
                    {
                        if (rdoKhoA4.IsChecked)
                        {
                            SizeinKB_FINAL_NEED_PAGE = Convert.ToInt32(txtDungLuongChuanA4.Text);
                        }
                        if (rdoKhoA3.IsChecked)
                        {
                            SizeinKB_FINAL_NEED_PAGE = Convert.ToInt32(txtDungLuongChuanA4.Text) * 2;
                        }
                        if (rdoKhoA2.IsChecked)
                        {
                            SizeinKB_FINAL_NEED_PAGE = Convert.ToInt32(txtDungLuongChuanA4.Text) * 4;
                        }
                    }
                    // lưu ý: Nếu dung lượng file sau khi nén tối đa vẫn lớn hơn dung lượng nhập vào thì vẫn lấy
                    // bao gồm cả OCR
                    // lưu ý dự trù thêm phần lưu thông tin bản quyền + fastwebivew
                    if (SizeinKB_FINAL_PAGE <= SizeinKB_FINAL_NEED_PAGE - 2 || (rateA234_MUC_NEN == 0 && rateA234.Count == 0))
                    {
                        this.Invoke(new Action(() =>
                        {
                            proTyLeNen.Text = proTyLeNen.Text + "/Final: " + SizeinKB_FINAL_PAGE;
                            lblDungLuongDaXuLy.Text = SizeinKB_FINAL_PAGE.ToString();
                        }));
                        IS_XULY_LAI = false;
                        this.Invoke(new Action(() =>
                        {
                            lblTrangThai.Text = "Chuyển đổi đạt yêu cầu!";
                        }));

                        // cho vào danh sách để xóa sau khi xử lý xong
                        lstPDF_OCR_Page.Add(outputFilePath_OCR_PROGRESS);
                        lstJPG_JP2_Page.Add(outputFilePath_JP2_PROGRESS);
                        lstJPG_JP2_Page.Add(outputFilePath_PDF_PROGRESS);
                        lstJPG_JP2_Page.Add(outputFilePath_PDF_PROGRESS_SCALE);
                    }
                    else
                    {
                        IS_XULY_LAI = true;
                        this.Invoke(new Action(() =>
                        {
                            proTyLeNen.Text = proTyLeNen.Text + "/Final: " + SizeinKB_FINAL_PAGE;
                            lblTrangThai.Text = "Chuyển đổi chưa đạt yêu cầu!, xử lý tiếp...";
                            lblDungLuongDaXuLy.Text = SizeinKB_FINAL_PAGE.ToString();

                            decimal laychieurongnhonhat = nWidth.Value;
                            decimal laychieudailonnhat = nHeight.Value;
                            if (nWidth.Value > nHeight.Value)
                            {
                                laychieurongnhonhat = nHeight.Value;
                                laychieudailonnhat = nWidth.Value; 
                            }
                            if (laychieurongnhonhat <= 2980 && laychieudailonnhat < 3800) // khổ A4     2980 - 2780 - điều chỉnh nhận kích thước||3400||4000||3990
                            {
                                trackQualityNumber.Value = trackQualityNumber.Value - 5;
                            }
                            else
                            {
                                if (laychieurongnhonhat <= 5960 && laychieudailonnhat < 7500/*&& laychieurongnhonhat * 2 > laychieudailonnhat*/) // khổ A3  5000
                                {
                                    trackQualityNumber.Value = trackQualityNumber.Value - 10;
                                }
                                else // khổ A2
                                {
                                    trackQualityNumber.Value = trackQualityNumber.Value - 10;
                                }
                            }
                        }));
                        goto XULY_SIZE_PAGE;
                    }
                }

                // thực hiện ghép PDF
                IEnumerable<string> inputFiles = new List<string>();
                inputFiles = lstPDF_OCR_Page;
                var tentepghep = tenfileKetQuaXuLy(pathXuLy);

                using (Stream dstStream = File.Create(tentepghep))
                {
                    using (GdPictureDocumentConverter gdpictureDocumentConverter = new GdPictureDocumentConverter())
                    {
                        try
                        {
                            gdpictureDocumentConverter.CombineToPDF(inputFiles, dstStream, PdfConformance.PDF1_7);
                        }
                        catch (Exception ex)
                        {
                            ThreadSafeFileWriter.WriteFile("nen_ocr_dpi_log_exception", linkThuMucKetQua.Text, tentepghep + " => " + ex.Message + ", " + ex.InnerException + ", " + ex.StackTrace);
                        }
                    }
                }

                string tentepghep_fastwebview = ghibanquyenvafastwebview(tentepghep);
                if (tentepghep_fastwebview != "")
                {
                    File.Delete(tentepghep);
                    File.Move(tentepghep_fastwebview, tentepghep);
                }

                _stopwatch.Stop();
                FileInfo FileVol_FINAL = new FileInfo(tentepghep);
                long SizeinKB_FINAL = FileVol_FINAL.Length / 1024;
                hienthithongtindothi(stt_xulytep, (int)_stopwatch.Elapsed.TotalSeconds, solanxuly, (int)SizeinKB_FINAL);
                Invoke(new Action(() =>
                {
                    lblTrangThai2.Text = (int)_stopwatch.Elapsed.TotalSeconds + " (s)";
                    proTongSoTrangXL1Tep.Value1 = 0;
                }));
                ghiFile("auto_dpi\\" + APP_ID + ".txt", stt_xulytep + "/" + _tongsotaptin);
                _stopwatch.Reset();
                solanxuly = 0;

                xoaDanhSach(lstPDF_OCR_Page);//xóa danh sách PDF sau ghép
                if (lstPDFJPGPageONLY != null)
                    xoaDanhSach(lstPDFJPGPageONLY);//xóa ảnh JPG trước xử lý, chỉ của file PDF, không xóa ảnh đầu vào nếu k là pdf
                xoaDanhSach(lstJPG_JP2_Page);//xóa JP2, PDF tạm
            }
            //xóa thư mục APP sau khi thực hiện xong
            DeleteDirectory(linkThuMucKetQua.Text + "\\" + GUID_APP);
        }

        private string tenfileKetQuaXuLy(string pathXuLy)
        {
            var tentepghep = linkThuMucKetQua.Text + "\\" + Path.GetFileNameWithoutExtension(pathXuLy) + ".pdf";
            if (chkGiuNguyenCauTrucThuMuc.Checked)
            {
                tentepghep = linkThuMucKetQua.Text + "\\" + giucautructhumuc(pathXuLy) + "\\" + Path.GetFileNameWithoutExtension(pathXuLy) + ".pdf";
                Directory.CreateDirectory(linkThuMucKetQua.Text + "\\" + giucautructhumuc(pathXuLy));
            }
            return tentepghep;
        }

        private void hienthithongtindothi(int dangxulytaptin, int thoigian, int solanxl, int kichthuoc)
        {
            // nếu vượt quá 20 điểm thì xóa điểm đầu
            if (lstTIME_PROC.Count > 20)
            {
                lstTIME_PROC.Remove(lstTIME_PROC[0]);
                lstTIME_PROC2.Remove(lstTIME_PROC2[0]);
                lstTIME_PROC3.Remove(lstTIME_PROC3[0]);
            }
            DataPointType point_ = new DataPointType();
            point_.x = dangxulytaptin;
            point_.y = thoigian;
            lstTIME_PROC.Add(point_);

            DataPointType point2_ = new DataPointType();
            point2_.x = dangxulytaptin;
            point2_.y = solanxl;
            lstTIME_PROC2.Add(point2_);

            DataPointType point3_ = new DataPointType();
            point3_.x = dangxulytaptin;
            point3_.y = kichthuoc;
            lstTIME_PROC3.Add(point3_);

            this.Invoke(new Action(() =>
            {
                //chart1.Series.Clear();
                //chart1.Series.Add("TIME");
                //chart1.Series[0].ChartType = SeriesChartType.Line;
                //chart1.Series[0].IsVisibleInLegend = false;

                //chart1.Series.Add("TIME2");
                //chart1.Series[1].ChartType = SeriesChartType.Bar;
                //chart1.Series[1].IsVisibleInLegend = false;

                //// Label
                //chart1.Series[0].IsValueShownAsLabel = true;
                //chart1.Series[0].SmartLabelStyle.Enabled = true;
                //chart1.Series[0].SmartLabelStyle.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.No;
                //chart1.Series[0].LabelForeColor = Color.Blue;
                //chart1.Series[0].Font = new Font("Arial", 9, FontStyle.Bold);


                //for (int i = 0; i < lstTIME_PROC.Count; i++)
                //{
                //    chart1.Series["TIME"].Points.AddXY(lstTIME_PROC[i].x, lstTIME_PROC[i].y);
                //}
                //for (int i = 0; i < lstTIME_PROC2.Count; i++)
                //{
                //    chart1.Series["TIME2"].Points.AddXY(lstTIME_PROC2[i].x, lstTIME_PROC2[i].y);
                //}

                chartControl1.Series.Clear();

                // Create two series.
                var series1 = new DevExpress.XtraCharts.Series("Bước", ViewType.Bar);
                var series3 = new DevExpress.XtraCharts.Series("Dung lượng (kb)", ViewType.Bar);
                var series2 = new DevExpress.XtraCharts.Series("Thời gian (s)", ViewType.Spline);

                for (int i = 0; i < lstTIME_PROC.Count; i++)
                {
                    series2.Points.Add(new SeriesPoint(lstTIME_PROC[i].x, lstTIME_PROC[i].y));
                }
                for (int i = 0; i < lstTIME_PROC2.Count; i++)
                {
                    series1.Points.Add(new SeriesPoint(lstTIME_PROC2[i].x, lstTIME_PROC2[i].y));
                }
                for (int i = 0; i < lstTIME_PROC3.Count; i++)
                {
                    series3.Points.Add(new SeriesPoint(lstTIME_PROC3[i].x, lstTIME_PROC3[i].y));
                }

                // Add both series to the chart.
                chartControl1.Series.AddRange(new DevExpress.XtraCharts.Series[] { series1, series3, series2 });
                // Hide the legend (optional).
                chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;

                // Cast the second series's view to the LineSeriesView type.
                BarSeriesView myView = (BarSeriesView)series3.View;

                // Hide the legend (optional).
                chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;

                // Cast the chart's diagram to the XYDiagram type, 
                // to access its axes and panes.
                XYDiagram diagram = (XYDiagram)chartControl1.Diagram;

                // Add a new additional pane to the diagram.
                if (diagram.Panes.Capacity == 0)
                {
                    diagram.Panes.Add(new XYDiagramPane("My Pane"));
                }

                // Note that the created pane has the zero index in the collection,
                // because the existing Default pane is a separate entity.
                myView.Pane = diagram.Panes[0];

                // Add titles to panes.
                diagram.DefaultPane.Title.Text = "Thời gian/bước";
                diagram.DefaultPane.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                diagram.Panes[0].Title.Text = "Dung lượng (kb)";
                diagram.Panes[0].Title.Visibility = DevExpress.Utils.DefaultBoolean.True;

                // Customize the pane layout.
                diagram.PaneDistance = 10;
                diagram.PaneLayout.AutoLayoutMode = PaneAutoLayoutMode.Linear;
                diagram.PaneLayout.Direction = PaneLayoutDirection.Horizontal;
                diagram.DefaultPane.LayoutOptions.ColumnSpan = 3;
                diagram.Panes[0].LayoutOptions.ColumnSpan = 2;

                ((XYDiagram)chartControl1.Diagram).SecondaryAxesX.Clear();
                ((XYDiagram)chartControl1.Diagram).SecondaryAxesY.Clear();

                // Add secondary axes to the diagram, and adjust their options.
                diagram.SecondaryAxesX.Add(new SecondaryAxisX("My Axis X"));
                diagram.SecondaryAxesY.Add(new SecondaryAxisY("My Axis Y"));
                diagram.SecondaryAxesX[0].Alignment = AxisAlignment.Near;
                diagram.SecondaryAxesY[0].Alignment = AxisAlignment.Near;
                diagram.SecondaryAxesY[0].GridLines.Visible = true;

                // Assign both the additional pane and, if required,
                // the secondary axes to the second series.             
                myView.AxisX = diagram.SecondaryAxesX[0];
                myView.AxisY = diagram.SecondaryAxesY[0];

                ConstantLine temperatureLine = new ConstantLine();
                temperatureLine.AxisValue = Convert.ToInt32(txtDungLuongChuanA4.Text);

                temperatureLine.Title.Text = "A4: " + txtDungLuongChuanA4.Text + " (kb)";
                temperatureLine.Title.ShowBelowLine = true;
                temperatureLine.Title.Alignment = ConstantLineTitleAlignment.Near;
                temperatureLine.Title.TextColor = Color.Blue;
                temperatureLine.Title.EnableAntialiasing = DevExpress.Utils.DefaultBoolean.True;
                temperatureLine.Title.Font = new Font("Tahoma", 8F, FontStyle.Bold);
                temperatureLine.Title.Visible = true;
                temperatureLine.Color = Color.Red;
                temperatureLine.Title.EnableAntialiasing = DevExpress.Utils.DefaultBoolean.True;
                temperatureLine.LineStyle.DashStyle = DevExpress.XtraCharts.DashStyle.Dash;
                temperatureLine.LineStyle.Thickness = 2;
                temperatureLine.ShowBehind = false;

                //ConstantLine temperatureLine = new ConstantLine("A4: "+ txtDungLuongChuanA4.Text, Convert.ToInt32(txtDungLuongChuanA4.Text));
                myView.AxisY.ConstantLines.Add(temperatureLine);

                //// Create two secondary axes, and add them to the chart's Diagram.
                //SecondaryAxisX myAxisX = new SecondaryAxisX("ảnh/pdf");
                //SecondaryAxisY myAxisY = new SecondaryAxisY("thời gian (giây)");
                //SecondaryAxisY myAxisY1 = new SecondaryAxisY("kích thước");

                //((XYDiagram)chartControl1.Diagram).SecondaryAxesX.Clear();
                //((XYDiagram)chartControl1.Diagram).SecondaryAxesY.Clear();

                //((XYDiagram)chartControl1.Diagram).SecondaryAxesX.Add(myAxisX);
                //((XYDiagram)chartControl1.Diagram).SecondaryAxesY.Add(myAxisY);

                //// Assign the series2 to the created axes.
                //((SplineSeriesView)series2.View).AxisX = myAxisX;
                //((SplineSeriesView)series2.View).AxisY = myAxisY;                 

                //((SplineSeriesView)series2.View).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;

                //// Cast the chart's diagram to the XYDiagram type, 
                //// to access its axes and panes.
                //XYDiagram diagram = (XYDiagram)chartControl1.Diagram;

                //// Add a new additional pane to the diagram.
                //diagram.Panes.Add(new XYDiagramPane("My Pane"));

                //// Note that the created pane has the zero index in the collection,
                //// because the existing Default pane is a separate entity.
                //((BarSeriesView)series3.View).Pane = diagram.Panes[0];

                //// Assign both the additional pane and, if required,
                //// the secondary axes to the second series.             
                //((BarSeriesView)series3.View).AxisX = diagram.SecondaryAxesX[0];
                //((BarSeriesView)series3.View).AxisY = diagram.SecondaryAxesY[0];

                //// Add titles to panes.
                //diagram.DefaultPane.Title.Text = "Sales by Region (Units)";
                //diagram.DefaultPane.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                //diagram.Panes[0].Title.Text = "Revenue (Millions of USD)";
                //diagram.Panes[0].Title.Visibility = DevExpress.Utils.DefaultBoolean.True;

                //// Customize the pane layout.
                //diagram.PaneDistance = 10;
                //diagram.PaneLayout.AutoLayoutMode = PaneAutoLayoutMode.Linear;
                //diagram.PaneLayout.Direction = PaneLayoutDirection.Horizontal;
                //diagram.DefaultPane.LayoutOptions.ColumnSpan = 3;
                //diagram.Panes[0].LayoutOptions.ColumnSpan = 2;

                //// Customize the appearance of the secondary axes (optional).
                //myAxisX.Title.Text = "ảnh/pdf";
                //myAxisX.Title.Visible = true;
                //myAxisX.Title.TextColor = Color.Red;
                //myAxisX.Label.TextColor = Color.Red;
                //myAxisX.Color = Color.Red;

                //myAxisY.Title.Text = "thời gian (giây)";
                //myAxisY.Title.Visible = true;
                //myAxisY.Title.TextColor = Color.Blue;
                //myAxisY.Label.TextColor = Color.Blue;
                //myAxisY.Color = Color.Blue;

            }));
        }


        private string ghibanquyenvafastwebview(string path)
        {
            string path_fastweb = "";
            APP = directory + "\\exiftool-12.40\\exiftool.exe";
            ExecuteCommandSync(APP, " -\"Producer\"=\"AScanner\" -\"Creator\"=\"AScanner\" -\"Author\"=\"ADDJ\" -overwrite_original \"" + path + "\"");
            if (chkUsingFastWebView.Checked)
            {
                path_fastweb = path + "_fastwebview.pdf";
                APP = directory + "\\binqpdf\\qpdf.exe";
                ExecuteCommandSync(APP, string.Format(" --linearize \"{0}\" \"{1}\"", path, path_fastweb));
            }
            return path_fastweb;
        }

        private string dieuchinhtyle(string path)
        {
            string path_scale = path + "_scale.pdf";
            string caption = "Example: Scale page";
            GdPicturePDF oGdPicturePDF = new GdPicturePDF();
            if (oGdPicturePDF.LoadFromFile(path, false) == GdPictureStatus.OK)
            {
                int count = oGdPicturePDF.GetPageCount();
                GdPictureStatus status2 = oGdPicturePDF.GetStat();
                if (status2 == GdPictureStatus.OK)
                {
                    if (count > 0)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            status2 = oGdPicturePDF.SelectPage(i + 1);
                            if (status2 == GdPictureStatus.OK)
                            {
                                float height = oGdPicturePDF.GetPageHeight();
                                status2 = oGdPicturePDF.GetStat();
                                if (status2 == GdPictureStatus.OK)
                                {
                                    float width = oGdPicturePDF.GetPageWidth();
                                    status2 = oGdPicturePDF.GetStat();
                                    if (status2 == GdPictureStatus.OK)
                                    {
                                        var dophangiai300 = true;
                                        this.Invoke(new Action(() =>
                                        {
                                            if (rdoDoPhanGiai400.Checked)
                                            {
                                                dophangiai300 = false;
                                            }
                                        }));
                                        if (dophangiai300)
                                        {
                                            oGdPicturePDF.ScalePage(0.320f, 0.320f);
                                        }
                                        else
                                        {
                                            oGdPicturePDF.ScalePage(0.240f, 0.240f);
                                        }

                                        if (status2 == GdPictureStatus.OK)
                                        {
                                            if (oGdPicturePDF.SaveToFile(path_scale) == GdPictureStatus.OK)
                                                this.Invoke(new Action(() =>
                                                {
                                                    barStaticItem2.Caption = "The page has been scale page successfully and the file has been saved.";
                                                }));
                                            else
                                                this.Invoke(new Action(() =>
                                                {
                                                    barStaticItem2.Caption = "The page has been scale page successfully, but the file can't be saved.";
                                                }));
                                        }
                                        else
                                        {
                                            this.Invoke(new Action(() =>
                                            {
                                                barStaticItem2.Caption = "The ScalePage() method has failed with the status: " + status2;
                                            }));
                                            status2 = GdPictureStatus.OK;
                                            ThreadSafeFileWriter.WriteFile("nen_ocr_dpi_log_exception", linkThuMucKetQua.Text, "The ScalePage() method has failed with the status: " + status2);
                                        }
                                    }
                                }
                                else
                                {
                                    barStaticItem2.Caption = "The ScalePage() method has failed with the status: " + status2;
                                    ThreadSafeFileWriter.WriteFile("nen_ocr_dpi_log_exception", linkThuMucKetQua.Text, "The ScalePage() method has failed with the status: " + status2);
                                }
                            }
                        }
                    }
                    else
                    {
                        status2 = GdPictureStatus.InvalidParameter;
                        barStaticItem2.Caption = "The ScalePage() method has failed with the status: " + status2;
                        ThreadSafeFileWriter.WriteFile("nen_ocr_dpi_log_exception", linkThuMucKetQua.Text, "The ScalePage() method has failed with the status: " + status2.ToString());
                    }
                }
                if (status2 != GdPictureStatus.OK)
                {
                    Invoke(new Action(() =>
                    {
                        //XtraMessageBox.Show("The example HAS NOT been followed successfully. The last error status is: " + status2.ToString(), caption);
                        barStaticItem2.Caption = "The example HAS NOT been followed successfully. The last error status is: " + status2;
                        ThreadSafeFileWriter.WriteFile("nen_ocr_dpi_log_exception", linkThuMucKetQua.Text, "The example HAS NOT been followed successfully. The last error status is: " + status2.ToString());
                    }));
                }
            }
            else
            {
                Invoke(new Action(() =>
                {
                    //XtraMessageBox.Show("The file can't be loaded.\nVui lòng kiểm tra phần mềm hỗ trợ", caption);
                    ThreadSafeFileWriter.WriteFile("nen_ocr_dpi_log_exception", linkThuMucKetQua.Text, "The file can't be loaded.\nVui lòng kiểm tra phần mềm hỗ trợ");
                }));
            }
            oGdPicturePDF.Dispose();
            return path_scale;
        }

        private void xoaDanhSach(List<string> lst)
        {
            foreach (var item in lst)
            {
                if (File.Exists(item))
                {
                    File.Delete(item);
                }
            }
        }

        private string giucautructhumuc(string filePath)
        {
            string MyPath = System.IO.Path.GetDirectoryName(filePath);
            string MyPathWithoutDriveOrNetworkShare = MyPath.Substring(Path.GetPathRoot(MyPath).Length);
            return MyPathWithoutDriveOrNetworkShare;
        }


        /// <span class="code-SummaryComment"><summary></span>
        /// Executes a shell command synchronously.
        /// <span class="code-SummaryComment"></summary></span>
        /// <span class="code-SummaryComment"><param name="command">string command</param></span>
        /// <span class="code-SummaryComment"><returns>string, as output of the command.</returns></span>
        public void ExecuteCommandSync(string program, object command)
        {
            try
            {
                // create the ProcessStartInfo using "cmd" as the program to be run,
                // and "/c " as the parameters.
                // Incidentally, /c tells cmd that we want it to execute the command that follows,
                // and then exit.
                System.Diagnostics.ProcessStartInfo procStartInfo =
                    new System.Diagnostics.ProcessStartInfo(program, "  " + command);

                // The following commands are needed to redirect the standard output.
                // This means that it will be redirected to the Process.StandardOutput StreamReader.
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                // Do not create the black window.
                procStartInfo.CreateNoWindow = true;
                // Now we create a process, assign its ProcessStartInfo and start it
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                // Get the output into a string
                string result = proc.StandardOutput.ReadToEnd();

                proc.WaitForExit();

                // Display the command output.
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                //File.AppendAllText("log_dpi.txt", DateTime.Now + ": " + ex.Message + "-" + ex.InnerException + "-" + ex.StackTrace);
                // Log the exception
                ThreadSafeFileWriter.WriteFile("nen_ocr_dpi_log_exception", linkThuMucKetQua.Text, command + " => " + ex.Message + ", " + ex.InnerException + ", " + ex.StackTrace);
            }
        }

        private void ResetSizeValues()
        {
            this.Invoke(new Action(() =>
            {
                nWidth.Value = 1;
                nHeight.Value = 1;
                nDocumentWidth.Value = 1;
                nDocumentHeight.Value = 1;
                nHorizontalResolution.Value = 1;
                nVerticalResolution.Value = 1;
                nScalePercent.Value = nScalePercentSet.Value;
                chkKeepAspectRatio.Checked = true;
                cbResampling.SelectedIndex = 6;
                //rbScalePercent.Checked = true;
                if (_currentImage != 0)
                {
                    nWidth.Value = _gdPictureImaging.GetWidth(_currentImage);
                    nHeight.Value = _gdPictureImaging.GetHeight(_currentImage);
                    //khogiayA4 = false;
                    //if (nHeight.Value <= 3808 && nWidth.Value <= 2780)
                    //{
                    //    khogiayA4 = true;
                    //}
                    nDocumentWidth.Value = Convert.ToDecimal(_gdPictureImaging.GetWidthInches(_currentImage));
                    nDocumentHeight.Value = Convert.ToDecimal(_gdPictureImaging.GetHeightInches(_currentImage));
                    nHorizontalResolution.Value = Convert.ToDecimal(_gdPictureImaging.GetHorizontalResolution(_currentImage));
                    nVerticalResolution.Value = Convert.ToDecimal(_gdPictureImaging.GetVerticalResolution(_currentImage));
                }
            }));
            UpdateScalePercentValue();
        }
        private void UpdateScalePercentValue()
        {
            this.Invoke(new Action(() =>
            {
                if (_currentImage == 0) return;
                int originalWidth = _gdPictureImaging.GetWidth(_currentImage);
                int originalHeight = _gdPictureImaging.GetHeight(_currentImage);
                nWidth.Value = Math.Max(nWidth.Minimum, originalWidth * (nScalePercent.Value / 100));
                nHeight.Value = Math.Max(nHeight.Minimum, originalHeight * (nScalePercent.Value / 100));
                nDocumentWidth.Value = Math.Max(nDocumentWidth.Minimum, nWidth.Value / nHorizontalResolution.Value);
                nDocumentHeight.Value = Math.Max(nDocumentHeight.Minimum, nHeight.Value / nVerticalResolution.Value);
            }));
        }
        private void UpdateWidthValue()
        {
            this.Invoke(new Action(() =>
            {
                if (_currentImage == 0 || !chkKeepAspectRatio.Checked || !rbResize.Checked) return;
                int originalWidth = _gdPictureImaging.GetWidth(_currentImage);
                int originalHeight = _gdPictureImaging.GetHeight(_currentImage);
                nHeight.Value = Math.Max(nHeight.Minimum, originalHeight * (nWidth.Value / originalWidth));
                nDocumentWidth.Value = Math.Max(nDocumentWidth.Minimum, nWidth.Value / nHorizontalResolution.Value);
            }));
        }
        private void UpdateHeightValue()
        {
            this.Invoke(new Action(() =>
            {
                if (_currentImage == 0 || !chkKeepAspectRatio.Checked || !rbResize.Checked) return;
                int originalWidth = _gdPictureImaging.GetWidth(_currentImage);
                int originalHeight = _gdPictureImaging.GetHeight(_currentImage);
                nWidth.Value = Math.Max(nWidth.Minimum, originalWidth * (nHeight.Value / originalHeight));
                nDocumentHeight.Value = Math.Max(nDocumentHeight.Minimum, nHeight.Value / nVerticalResolution.Value);
            }));
        }
        private void UpdateDocumentWidthValue()
        {
            this.Invoke(new Action(() =>
            {
                if (rbResize.Checked)
                {
                    nWidth.Value = Math.Max(nWidth.Minimum, nHorizontalResolution.Value * nDocumentWidth.Value);
                }
            }));
        }
        private void UpdateDocumentHeightValue()
        {
            this.Invoke(new Action(() =>
            {
                if (rbResize.Checked)
                {
                    nHeight.Value = Math.Max(nHeight.Minimum, nVerticalResolution.Value * nDocumentHeight.Value);
                }
            }));
        }
        private void UpdateHorizontalValue()
        {
            this.Invoke(new Action(() =>
            {
                if (rbResize.Checked)
                {
                    nDocumentWidth.Value = Math.Max(nDocumentWidth.Minimum, nWidth.Value / nHorizontalResolution.Value);
                }
            }));
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            xuly();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                proTongSoTepXL.Text = "";
                proTongSoTrangXL1Tep.Text = "";
                proTienTrinhOCR.Text = "";
                proTyLeNen.Text = "";
                proTyLeNen.Value2 = 0;
                progressStack.Text = "";
                progressStack.Value1 = 0;
                lblLoaiKhoGiay.Text = "";
                lblDungLuongDaXuLy.Text = "";
                lblTrangThai2.Text = "---/---";
                lblTrangThai3.Text = "---/---";
                barStaticItem2.Caption = "";
                progressPanel1.Visible = false;
            }));
            GC.Collect();
            if (tudongClose)
            {
                Close();
            }
        }

        private void linkThuMucNguon_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (linkThuMucNguon.Text != "...")
            {
                Process.Start("Explorer.exe", @"/select,""" + linkThuMucNguon.Text + "\"");
            }
        }

        private void btnThongSo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (panel1.Visible)
            {
                panel1.Visible = false;
            }
            else
            {
                panel1.Visible = true;
            }
        }

        private void btnHinhAnh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CN_NenTepPDF_DPI_IMAGE stim = new CN_NenTepPDF_DPI_IMAGE();
            stim.ShowDialog();
            isChangeContrast = stim.isChangeContrast;
            isChangeColor = stim.isChangeColor;
            _Brightness = stim._Brightness;
            _Contrast = stim._Contrast;
            _Saturation = stim._Saturation;
            _Gamma = stim._Gamma;
            _redColor = stim._redColor;
            _greenColor = stim._greenColor;
            _blueColor = stim._blueColor;
        }

        private void lblStatusXemDanhSachERROR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CN_DanhSachTepERROR dse = new CN_DanhSachTepERROR(_danhSachXuLyERROR);
            dse.ShowDialog();
        }
    }
}
