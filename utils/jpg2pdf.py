import img2pdf
from PIL import Image
import os
import cv2

# set dpi keep size
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
    pdf_bytes = img2pdf.convert(image.filename, layout_fun = layout_fun)
    
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

# magick "C:\Users\Nam\Downloads\New folder\test.jpg" -strip -interlace Plane -gaussian-blur 0.05 -quality 85% "C:\Users\Nam\Downloads\New folder\result.jpg"

# magick mogrify -set density 300 "C:\Users\Nam\Downloads\New folder\result.jpg"
# convert  "C:\Users\Nam\Downloads\New folder\result.jpg" -density 300 -units PixelsPerInch  "C:\Users\Nam\Downloads\New folder\result.jpg"

from PIL import Image
image = cv2.imread(r'C:\Users\Nam\Downloads\New folder\result.jpg')
RGBimage = cv2.cvtColor(image, cv2.COLOR_BGR2RGB)
PILimage = Image.fromarray(RGBimage)
PILimage.save(r"C:\Users\Nam\Downloads\New folder\result2.jpg", dpi=(300,300))




from PIL import Image

image = Image.open(r"C:\Users\Nam\Downloads\New folder\result.pdf")
print(f"Original size : {image.size}") # 5464x3640

sunset_resized = image.resize((7680, 4320))
sunset_resized.save(r"C:\Users\Nam\Downloads\New folder\result_resize.pdf")