import os
import sys
from PIL import Image
import img2pdf

# giảm chất lượng của ảnh bằng PIL
def compressMe(file, verbose=False):

    # Get the path of the file
    filepath = r'images\KS.1996.93017.01.A3.01.jpg'

    # open the image
    picture = Image.open(filepath)

    # Save the picture with desired quality
    # To change the quality of image,
    # set the quality variable at
    # your desired level, The more
    # the value of quality variable
    # and lesser the compression
    picture = picture.convert('RGB')
    picture.save("Compressed_"+file,
                 "JPEG",
                 optimize=True,
                 quality=10)
    
    return

def jpg2pdf(img_path, pdf_path):
    # opening image
    image = Image.open(img_path)

    # set dpi
    dpix = dpiy = 300
    layout_fun = img2pdf.get_fixed_dpi_layout_fun((dpix, dpiy))    
    
    # converting into chunks using img2pdf
    pdf_bytes = img2pdf.convert(image.filename, layout_fun = layout_fun)

    # opening or creating pdf file
    file = open(pdf_path, "wb")

    # writing pdf files with chunks
    file.write(pdf_bytes)

    # closing image file
    image.close()

    # closing pdf file
    file.close()

# magick a.jpg -quality 10% o.jpg
# magick mogrify -quality 10 a.jpg
# jpegoptim --size=200k a.jpg
# https://manpages.ubuntu.com/manpages/bionic/man1/jpegoptim.1.html

compressMe(r'KS.1996.93017.01.A3.01.jpg', False)
jpg2pdf(r'Compressed_KS.1996.93017.01.A3.01.jpg', 'Compressed_KS.1996.93017.01.A3.01.pdf')