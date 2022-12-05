import os
import sys

import cv2
import img2pdf
import wand.image
from matplotlib import pyplot as plt
from PIL import Image
from skimage.exposure import rescale_intensity
from skimage.filters import threshold_yen
from skimage.io import imread, imsave
from wand.display import display
from wand.version import QUANTUM_RANGE

# magick a.jpg -quality 10% o.jpg
# magick mogrify -quality 10 a.jpg
# jpegoptim --size=200k a.jpg
# https://manpages.ubuntu.com/manpages/bionic/man1/jpegoptim.1.html


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


# chuyển ảnh jpg sang pdf
def jpg2pdf(img_path, pdf_path):
    # opening image
    image = Image.open(img_path)

    # set dpi
    dpix = dpiy = 300
    layout_fun = img2pdf.get_fixed_dpi_layout_fun((dpix, dpiy))

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


# điều chỉnh tự động độ sáng và độ tương phản
def automatic_contrast_brightness():
    # https://stackoverflow.com/questions/56905592/automatic-contrast-and-brightness-adjustment-of-a-color-photo-of-a-sheet-of-pape
    img = imread('goc.jpg')

    yen_threshold = threshold_yen(img)
    bright = rescale_intensity(img, (0, yen_threshold), (0, 255))

    imsave('out.jpg', bright)


# GUI điều chỉnh độ sáng và độ tương phản
def gui_contrast_brightness():
    # https://www.geeksforgeeks.org/changing-the-contrast-and-brightness-of-an-image-using-python-opencv/
    # https://stackoverflow.com/questions/67120450/error-2unspecified-error-the-function-is-not-implemented-rebuild-the-libra
    def BrightnessContrast(brightness=0):

        # getTrackbarPos returns the current
        # position of the specified trackbar.
        brightness = cv2.getTrackbarPos('Brightness',
                                        'GEEK')

        contrast = cv2.getTrackbarPos('Contrast',
                                      'GEEK')

        effect = controller(img, brightness,
                            contrast)

        # The function imshow displays an image
        # in the specified window
        cv2.imshow('Effect', effect)

    def controller(img, brightness=255,
                   contrast=127):

        brightness = int((brightness - 0) * (255 - (-255)) / (510 - 0) + (-255))

        contrast = int((contrast - 0) * (127 - (-127)) / (254 - 0) + (-127))

        if brightness != 0:

            if brightness > 0:

                shadow = brightness

                max = 255

            else:

                shadow = 0
                max = 255 + brightness

            al_pha = (max - shadow) / 255
            ga_mma = shadow

            # The function addWeighted calculates
            # the weighted sum of two arrays
            cal = cv2.addWeighted(img, al_pha,
                                  img, 0, ga_mma)

        else:
            cal = img

        if contrast != 0:
            Alpha = float(131 * (contrast + 127)) / (127 * (131 - contrast))
            Gamma = 127 * (1 - Alpha)

            # The function addWeighted calculates
            # the weighted sum of two arrays
            cal = cv2.addWeighted(cal, Alpha,
                                  cal, 0, Gamma)

        # putText renders the specified text string in the image.
        cv2.putText(cal, 'B:{},C:{}'.format(brightness,
                                            contrast), (10, 30),
                    cv2.FONT_HERSHEY_SIMPLEX, 1, (0, 0, 255), 2)

        return cal

    if __name__ == '__main__':
        # The function imread loads an image
        # from the specified file and returns it.
        original = cv2.imread("a.jpg")

        # Making another copy of an image.
        img = original.copy()

        # The function namedWindow creates a
        # window that can be used as a placeholder
        # for images.
        cv2.namedWindow('GEEK')

        # The function imshow displays an
        # image in the specified window.
        cv2.imshow('GEEK', original)

        # createTrackbar(trackbarName,
        # windowName, value, count, onChange)
        # Brightness range -255 to 255
        cv2.createTrackbar('Brightness',
                           'GEEK', 255, 2 * 255,
                           BrightnessContrast)

        # Contrast range -127 to 127
        cv2.createTrackbar('Contrast', 'GEEK',
                           127, 2 * 127,
                           BrightnessContrast)

        BrightnessContrast(0)

    # The function waitKey waits for
    # a key event infinitely or for delay
    # milliseconds, when it is positive.
    cv2.waitKey(0)


# imagemagick python
def python_wand():
    # https://stackoverflow.com/questions/56905592/automatic-contrast-and-brightness-adjustment-of-a-color-photo-of-a-sheet-of-pape

    # magick image.jpg -colorspace HCL -channel 1 -separate +channel tmp1.png
    # magick tmp1.png -auto-threshold otsu tmp2.png
    # magick image.jpg -colorspace gray -negate -lat 20x20+10% -negate tmp3.png
    # magick tmp3.png ( image.jpg tmp2.png -alpha off -compose copy_opacity -composite ) -compose over -composite result.png

    with wand.image(filename='goc2.jpg') as img:
        with img.clone() as copied:
            with img.clone() as hcl:
                hcl.transform_colorspace('hcl')
                with hcl.channel_images['green'] as mask:
                    mask.auto_threshold(method='otsu')
                    copied.composite(mask, left=0, top=0, operator='copy_alpha')
                    # img.transform_colorspace('gray')
                    img.negate()
                    img.adaptive_threshold(width=20, height=20, offset=0.1*QUANTUM_RANGE)
                    img.negate()
                    img.composite(copied, left=0, top=0, operator='over')
                    img.save(filename='goc_process.jpg')


# làm mờ ảnh
def blur_image():
    img = cv2.imread('a.jpg')

    blur = cv2.blur(img, (5, 5))

    plt.subplot(121), plt.imshow(img), plt.title('Original')
    plt.xticks([]), plt.yticks([])
    plt.subplot(122), plt.imshow(blur), plt.title('Blurred')
    plt.xticks([]), plt.yticks([])
    plt.show()


# đồng đều màu sắc của ảnh
def detect_uneven_image():
    # https://stackoverflow.com/questions/63933790/robust-algorithm-to-detect-uneven-illumination-in-images-detection-only-needed

    def get_image_stats(img_path, lbl):
        img = cv2.imread(img_path)
        gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
        blurred = cv2.GaussianBlur(gray, (25, 25), 0)
        no_text = gray * ((gray/blurred) > 0.99)                     # select background only
        no_text[no_text < 10] = no_text[no_text > 20].mean()           # convert black pixels to mean value
        no_bright = no_text.copy()
        no_bright[no_bright > 220] = no_bright[no_bright < 220].mean()  # disregard bright pixels

        print(lbl)
        std = no_bright.std()
        print('STD:', std)
        bright = (no_text > 220).sum()
        print('Brigth pixels:', bright)
        plt.figure()
        plt.hist(no_text.reshape(-1, 1), 25)
        plt.title(lbl)

        if std > 25:
            print("!!! Detected uneven illumination")
        if no_text.mean() < 200 and bright > 8000:
            print("!!! Detected glare")

    get_image_stats('a.jpg', 'a')


# compressMe(r'KS.1996.93017.01.A3.01.jpg', False)
# jpg2pdf(r'D:\xD\build\a.jpg', r'D:\xD\build\a.pdf')
