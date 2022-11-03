import re
from PyPDF2 import PdfFileReader, PdfFileWriter, PdfFileMerger
import glob
import os
import pathlib
from PIL import Image
import time


def get_files(path, extensionFile):
    lst = []
    for root, dirs, files in os.walk(path):
        for file in files:
            if file.endswith(extensionFile):
                lst.append(os.path.join(root, file))
    return lst


def split_pdf(pathPdfInput):
    for root, dirs, files in os.walk(r'E:\OCR NEN\Chua nen\2006-2015 - Copy'):
        for file in files:
            pattern = re.compile(".*"+'pdf'+"$")

            if pattern.match(file):
                inputpdf = PdfFileReader(os.path.join(root, file), strict=False)
                fileName = pathlib.Path(file).stem
                parentPath = pathlib.Path(file).parent.absolute()

                pdfs = []

                for i in range(inputpdf.numPages):
                    output = PdfFileWriter()
                    output.addPage(inputpdf.getPage(i))
                    with open("%s-%s.pdf" % (os.path.join(r'E:\OCR NEN\Chua nen\2006-2015 - Copy', fileName), i), "wb") as outputStream:
                        output.write(outputStream)
                        pdfs.append("%s-%s.pdf" % (os.path.join(r'E:\OCR NEN\Chua nen\2006-2015 - Copy', fileName), i))
                        outputStream.close()


def merge_pdf(pdfs):
    pdfs = [r'C:\Users\Nam\Downloads\New folder\ghep\DJI_Avata_User_Manual-EN.1.pdf',
            r'C:\Users\Nam\Downloads\New folder\ghep\DJI_Avata_User_Manual-EN.2.pdf',
            r'C:\Users\Nam\Downloads\New folder\ghep\DJI_Avata_User_Manual-EN.3.pdf',
            r'C:\Users\Nam\Downloads\New folder\ghep\DJI_Avata_User_Manual-EN.4.pdf',
            r'C:\Users\Nam\Downloads\New folder\ghep\DJI_Avata_User_Manual-EN.5.pdf',
            r'C:\Users\Nam\Downloads\New folder\ghep\DJI_Avata_User_Manual-EN.6.pdf',
            r'C:\Users\Nam\Downloads\New folder\ghep\DJI_Avata_User_Manual-EN.7.pdf',
            r'C:\Users\Nam\Downloads\New folder\ghep\DJI_Avata_User_Manual-EN.8.pdf',
            r'C:\Users\Nam\Downloads\New folder\ghep\DJI_Avata_User_Manual-EN.9.pdf']
    merger = PdfFileMerger()
    index = 0
    for page in pdfs:
        merger.append(page)
    merger.write('merge.pdf')
    
# pdfs = []
# merge_pdf(pdfs)


def spit_and_merge_pdf(pathPdfInput, bytes=10485760):
    if(os.path.getsize(pathPdfInput) >= 10485760):
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
            if(sum < bytes):
                merger.append(page)

            else:
                if(page == pdfs[-1]):
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


def detect_size():

    # Disable PIL DecompositionBomb threshold for reading large images.
    pil_max_px = Image.MAX_IMAGE_PIXELS
    Image.MAX_IMAGE_PIXELS = None
    im = Image.open(
        r'C:\Projects\Python\Tools\page_1.jpg')
    Image.MAX_IMAGE_PIXELS = pil_max_px

    # pages = convert_from_path(r'\\192.168.100.10\Binh Phuoc\2. KHO LON A0 CHUA OCR\VP UBND TINH (TTLT)\HOP D65.114\15.pdf',
    #                           500, poppler_path=r'C:\Projects\Python\Library\poppler\bin')

    # Counter to store images of each page of PDF to image
    # image_counter = 1

    # # Iterate through all the pages stored above
    # for page in pages:
    #     filename = "page_" + str(image_counter)+".jpg"
    #     page.save(filename, 'JPEG')
    #     image_counter = image_counter + 1

    print(im.size)

    print(round(2.665))


import os
from PIL import Image

def get_size_format(b, factor=1024, suffix="B"):
    """
    Scale bytes to its proper byte format
    e.g:
        1253656 => '1.20MB'
        1253656678 => '1.17GB'
    """
    for unit in ["", "K", "M", "G", "T", "P", "E", "Z"]:
        if b < factor:
            return f"{b:.2f}{unit}{suffix}"
        b /= factor
    return f"{b:.2f}Y{suffix}"



def compress_img(image_name, new_size_ratio=0.9, quality=90, width=None, height=None, to_jpg=True):
    # load the image to memory
    img = Image.open(image_name)
    # print the original image shape
    print("[*] Image shape:", img.size)
    a, b = img.size
    # get the original image size in bytes
    image_size = os.path.getsize(image_name)
    # print the size before compression/resizing
    print("[*] Size before compression:", get_size_format(image_size))
    if new_size_ratio < 1.0:
        # if resizing ratio is below 1.0, then multiply width & height with this ratio to reduce image size
        img = img.resize((int(img.size[0] * new_size_ratio), int(img.size[1] * new_size_ratio)), Image.ANTIALIAS)
        # print new image shape
        print("[+] New Image shape:", img.size)
    elif width and height:
        # if width and height are set, resize with them instead
        img = img.resize((width, height), Image.ANTIALIAS)
        # print new image shape
        print("[+] New Image shape:", img.size)
    # split the filename and extension
    filename, ext = os.path.splitext(image_name)
    # make new filename appending _compressed to the original file name
    if to_jpg:
        # change the extension to JPEG
        new_filename = f"{filename}.jpg"
    else:
        # retain the same extension of the original image
        new_filename = f"{filename}{ext}"
    try:
        # save the image with the corresponding quality and optimize set to True
        img.save(new_filename, quality=quality, optimize=True)
    except OSError:
        # convert the image to RGB mode first
        img = img.convert("RGB")
        # save the image with the corresponding quality and optimize set to True
        img.save(new_filename, quality=quality, optimize=True)
    print("[+] New file saved:", new_filename)
    # get the new image size in bytes
    new_image_size = os.path.getsize(new_filename)
    # print the new size in a good format
    print("[+] Size after compression:", get_size_format(new_image_size))
    # calculate the saving bytes
    saving_diff = new_image_size - image_size
    
    # print the saving percentage
    print(f"[+] Image size change: {saving_diff/image_size*100:.2f}% of the original image size.")
      
    
if __name__ == "__main__":
    # import argparse
    # parser = argparse.ArgumentParser(description="Simple Python script for compressing and resizing images")
    # parser.add_argument("image", help="Target image to compress and/or resize")
    # parser.add_argument("-j", "--to-jpg", action="store_true", help="Whether to convert the image to the JPEG format")
    # parser.add_argument("-q", "--quality", type=int, help="Quality ranging from a minimum of 0 (worst) to a maximum of 95 (best). Default is 90", default=90)
    # parser.add_argument("-r", "--resize-ratio", type=float, help="Resizing ratio from 0 to 1, setting to 0.5 will multiply width & height of the image by 0.5. Default is 1.0", default=1.0)
    # parser.add_argument("-w", "--width", type=int, help="The new width image, make sure to set it with the `height` parameter")
    # parser.add_argument("-hh", "--height", type=int, help="The new height for the image, make sure to set it with the `width` parameter")
    # args = parser.parse_args()
    # # print the passed arguments
    # print("="*50)
    # print("[*] Image:", args.image)
    # print("[*] To JPEG:", args.to_jpg)
    # print("[*] Quality:", args.quality)
    # print("[*] Resizing ratio:", args.resize_ratio)
    # if args.width and args.height:
    #     print("[*] Width:", args.width)
    #     print("[*] Height:", args.height)
    # print("="*50)
    # # compress the image
    
    # compress_img(args.image, args.resize_ratio, args.quality, args.width, args.height, args.to_jpg)
    compress_img(r'common\utils\image.jpg')
        
    while (os.path.getsize(r'common\utils\image.jpg') > 100000):
        compress_img(r'common\utils\image.jpg')
    
    
        # new_filename = Image.open(r'common\utils\image.jpg')
        # new_filename = new_filename.resize((7680, 4320), Image.Resampling.LANCZOS)
        # new_filename.save(r'common\utils\image.jpg')
        
    # python compress_image.py sample-satellite-images.png