using System;
using System.IO;
using System.Net;

namespace CopyPDF
{
    class Program
    {
        static void Main(string[] args)
        {
            //test thư mục share
            //NetworkCredential myCred = new NetworkCredential("ADMIN", "", @"\\192.168.1.219\Folder share\Nhân bản");

            //tìm kiếm đường dẫn của file text
            //string[] filePath = Directory.GetFiles(@"\\192.168.1.219\Folder share\Nhân bản", "*.txt", SearchOption.AllDirectories);
            //string[] filePath = Directory.GetFiles(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "insertPDF.txt", SearchOption.AllDirectories);
            Console.Write("NHAP DUONG DAN THU MUC CHUA FILE TXT: ");
            string[] fileTxtPath = Directory.GetFiles(Console.ReadLine(), "*.txt", SearchOption.AllDirectories);
            Console.Write("NHAP DUONG DAN CHUA FILE CAN NHAN BAN: ");
            string filePdfPath = Console.ReadLine();
            Console.Write("NHAP DUONG DAN THU MUC CHUA FILE PDF DA NHAN BAN: ");
            string target = Console.ReadLine();

            for (int j = 0; j < fileTxtPath.Length; j++)
            {
                try
                {
                    //tìm kiếm đường dẫn của file text
                    using (StreamReader sr = new StreamReader(fileTxtPath[j]))
                    {
                        string fileName;
                        while ((fileName = sr.ReadLine()) != null)
                        {
                            string[] str = fileName.ToUpper().Split('X');
                            fileName = str[0].Trim() + ".pdf";

                            //tìm kiếm đường dẫn của file pdf
                            //local
                            string[] filePaths = Directory.GetFiles(filePdfPath, fileName, SearchOption.AllDirectories);

                            //tìm kiếm file PDF
                            //string[] filePaths = Directory.GetFiles(@"\\192.168.1.219\Folder share\Nhân bản", fileName, SearchOption.AllDirectories);
                            /*string sourcePath = Path.GetDirectoryName(filePaths[0].Trim());
                            if (!System.IO.Directory.Exists(Path.Combine(sourcePath, "Clone")))
                                System.IO.Directory.CreateDirectory(Path.Combine(sourcePath, "Clone"));*/

                            string sourcePath = Path.GetDirectoryName(filePaths[0].Trim());
                            if (!System.IO.Directory.Exists(target))
                                System.IO.Directory.CreateDirectory(target);

                            //thư mục nhân bản
                            string targetPath = Path.Combine(target);
                            if (str.Length == 2)
                            {
                                for (int i = 0; i < Int32.Parse(str[1].Trim()); i++)
                                {
                                    //Combine file và đường dẫn
                                    string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
                                    string targetFile = System.IO.Path.Combine(targetPath, Path.GetFileNameWithoutExtension(fileName) + "(" + (i + 1) + ").pdf");
                                    //Copy file từ file nguồn đến file đích
                                    System.IO.File.Copy(sourceFile, targetFile, true);
                                }
                            }
                            else if (str.Length == 1)
                            {
                                //Combine file và đường dẫn
                                string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
                                string targetFile = System.IO.Path.Combine(targetPath, Path.GetFileNameWithoutExtension(fileName) + "(1).pdf");
                                //Copy file từ file nguồn đến file đích
                                System.IO.File.Copy(sourceFile, targetFile, true);
                            }
                            else Console.WriteLine("Sai định dạng rồi!!!");
                        }
                        Console.WriteLine("Copy done successfully!!!");
                        //sr.Close();
                        //File.Create(filePath[0]).Close();
                        //File.WriteAllText(filePath[j], String.Empty);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
            }
            Console.ReadLine();
        }
    }
}
