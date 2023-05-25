# sửa đổi metadata file pdf
import glob
import os
import pathlib
import re

import img2pdf
import pikepdf
import PyPDF2
from decor import get_files
from PIL import Image
from PyPDF2 import PdfFileMerger, PdfFileReader, PdfFileWriter

# from projects.decor import get_files

A4_SIZE = 8699840
# sửa metadata file pdf
# @get_files


def edit_metadata_pdf(root, file):
    try:
        pdf = pikepdf.open(os.path.join(root, file))
        with pdf.open_metadata() as meta:
            # meta['dc:title'] = ""
            print(meta['dc:title'])
    except Exception as e:
        print(str(e))

count = 0
index = 0

@get_files
def count_pdf_page(root, file):
    global count, index
    count += PyPDF2.PdfFileReader(open(os.path.join(root, file), 'rb'), strict=False).numPages
    index+=1
    print(f'{file} - {index} - {count}')

# print(count_pdf_page(r'Y:\SO HOA\DAK LAK 2023\ANH DA OCR'))


def split_pdf(pathPdfInput, pathPdfOutput):
    for root, dirs, files in os.walk(pathPdfInput):
        for file in files:
            pattern = re.compile(".*pdf$")

            if pattern.match(file):
                inputpdf = PdfFileReader(os.path.join(root, file), strict=False)
                fileName = pathlib.Path(file).stem
                parentPath = pathlib.Path(file).parent.absolute()

                pdfs = []

                for i in range(inputpdf.numPages):
                    output = PdfFileWriter()
                    output.addPage(inputpdf.getPage(i))
                    with open("%s#%s.pdf" % (os.path.join(pathPdfOutput, fileName), str(i).zfill(5)), "wb") as outputStream:
                        output.write(outputStream)
                        pdfs.append("%s#%s.pdf" % (os.path.join(pathPdfOutput, fileName), i))
                        outputStream.close()


def merge_pdf(lstFilesInput, fileNameOutput):
    merger = PdfFileMerger(strict=False)
    for file in lstFilesInput:
        merger.append(file)
    merger.write(fileNameOutput)


def merge_jpg_to_pdf():
    images = [
        # Image.open("/Users/apple/Desktop/" + f)
        Image.open(f)
        for f in [r"C:\Users\Nam\Downloads\hss 104\image00001.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00002.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00003.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00004.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00005.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00006.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00007.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00008.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00009.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00010.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00011.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00012.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00013.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00014.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00015.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00016.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00017.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00018.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00019.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00020.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00021.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00022.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00023.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00024.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00025.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00026.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00027.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00028.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00029.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00030.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00031.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00032.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00033.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00034.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00035.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00036.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00037.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00038.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00039.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00040.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00041.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00042.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00043.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00044.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00045.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00046.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00047.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00048.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00049.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00050.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00051.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00052.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00053.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00054.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00055.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00056.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00057.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00058.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00059.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00060.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00061.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00062.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00063.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00064.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00065.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00066.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00067.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00068.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00069.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00070.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00071.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00072.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00073.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00074.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00075.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00076.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00077.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00078.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00079.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00080.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00081.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00082.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00083.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00084.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00085.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00086.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00087.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00088.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00089.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00090.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00091.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00092.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00093.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00094.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00095.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00096.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00097.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00098.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image00099.jpg", r"C:\Users\Nam\Downloads\hss 104\image000100.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000101.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000102.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000103.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000104.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000105.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000106.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000107.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000108.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000109.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000110.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000111.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000112.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000113.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000114.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000115.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000116.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000117.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000118.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000119.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000120.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000121.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000122.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000123.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000124.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000125.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000126.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000127.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000128.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000129.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000130.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000131.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000132.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000133.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000134.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000135.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000136.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000137.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000138.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000139.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000140.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000141.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000142.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000143.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000144.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000145.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000146.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000147.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000148.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000149.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000150.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000151.jpg",
                  r"C:\Users\Nam\Downloads\hss 104\image000152.jpg"]

    ]

    pdf_path = r"C:\Users\Nam\Downloads\hss 104\bbd1.pdf"

    images[0].save(
        pdf_path, "PDF", resolution=100.0, save_all=True, append_images=images[1:]
    )


def setDpiImg2Pdf():
    # storing image path
    img_path = r"C:\Users\Nam\Downloads\New folder\result.jpg"

    # storing pdf path
    pdf_path = r"C:\Users\Nam\Downloads\New folder\result.pdf"

    dpix = dpiy = 300
    layout_fun = img2pdf.get_fixed_dpi_layout_fun((dpix, dpiy))

    # opening image
    image = Image.open(img_path)

    # converting into chunks using img2pdf
    pdf_bytes = img2pdf.convert(image.filename, layout_fun=layout_fun)

    # opening or creating pdf file
    file = open(pdf_path, "wb")

    # writing pdf files with chunks
    file.write(pdf_bytes)

    # closing image file
    image.close()

    # closing pdf file
    file.close()

    # output
    print("Successfully made pdf file")


def detect_size(img):
    # Disable PIL DecompositionBomb threshold for reading large images.
    pil_max_px = Image.MAX_IMAGE_PIXELS
    Image.MAX_IMAGE_PIXELS = None
    im = Image.open(img)
    Image.MAX_IMAGE_PIXELS = pil_max_px

    print('{}'.format(im.size))
    print((im.width*im.height)/A4_SIZE)


def spit_and_merge_pdf(pathPdfInput, bytes=10485760):
    if (os.path.getsize(pathPdfInput) >= 10485760):
        inputpdf = PdfFileReader(pathPdfInput, "rb")
        fileName = pathlib.Path(pathPdfInput).stem
        parentPath = pathlib.Path(pathPdfInput).parent.absolute()

        sum = 0
        pdfs = []

        for i in range(inputpdf.numPages):
            output = PdfFileWriter()
            output.addPage(inputpdf.getPage(i))
            with open("%s.%s.pdf" % (fileName, i), "wb") as outputStream:
                output.write(outputStream)
                pdfs.append("%s.%s.pdf" % (fileName, i))
                outputStream.close()

        merger = PdfFileMerger()
        index = 0
        for page in pdfs:
            # get size file
            sum += os.path.getsize(page)
            # nếu dung lượng các trang chưa quá 10MB thì vẫn thêm vào sau
            if (sum < bytes):
                merger.append(page)

            else:
                if (page == pdfs[-1]):
                    merger.append(page)
                merger.write(r"%s\%s.%s.pdf" %
                             (parentPath, fileName, index + 1))
                with open(r"split.txt", "a", encoding="utf-8") as fp:
                    fp.write(r"%s\%s.%s.pdf" %
                             (parentPath, fileName, index + 1) + '\n')
                merger = PdfFileMerger()
                merger.append(page)
                index += 1
                sum = os.path.getsize(page)

        try:
            listPdf = glob.glob("*pdf")
            for page in listPdf:
                os.remove(page)
                # page.unlink()
        except:
            pass


def split_merge_pdf_ocr(folderPath):
    # lấy danh sách tên file cần ghép
    for root, dirs, files in os.walk(folderPath):
        dict = {}
        for file in files:
            if ('#' in file):

                i = os.path.join(root, file.split('#')[0] + '.pdf')

                if (i not in dict.keys()):
                    dict[i] = []

                dict[i].append(os.path.join(root, file))

    # thực hiện ghép
    for k, v in dict.items():
        merge_pdf(v, k)

# sum = 0
# index = 0
# with open(r'projects\pdf.txt', 'r') as fr:
#     lst = fr.read().splitlines()
#     try:
#         for i in lst:
#             sum += count_pdf_page(i)
#             index += 1
#             print(f'{index} - {sum}')
#     except:
#         index += 1
#         pass
