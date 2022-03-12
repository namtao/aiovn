import requests
from bs4 import BeautifulSoup
import json
import os
import m3u8
# import PyPDF2
from PyPDF2 import PdfFileReader,PdfFileWriter
import numpy as np
import cv2
from scipy import ndimage
import pytesseract
import math
from scipy import ndimage
from pdf2image import convert_from_path


def rotatepng():
    image1 = cv2.imread(
        r'C:\Projects\Python\Tools\DetectOrientationImage\cheo.png')
    gray = cv2.cvtColor(image1, cv2.COLOR_BGR2GRAY)

    edges = cv2.Canny(gray, 50, 150, apertureSize=3)

    canimg = cv2.Canny(gray, 50, 200)
    lines = cv2.HoughLines(canimg, 1, np.pi / 180.0, 250, np.array([]))
    #lines= cv2.HoughLines(edges, 1, np.pi/180, 80, np.array([]))
    for line in lines:
        rho, theta = line[0]
        a = np.cos(theta)
        b = np.sin(theta)
        x0 = a*rho
        y0 = b*rho
        x1 = int(x0 + 1000 * (-b))
        y1 = int(y0 + 1000 * (a))
        x2 = int(x0 - 1000 * (-b))
        y2 = int(y0 - 1000 * (a))

        cv2.line(image1, (x1, y1), (x2, y2), (0, 0, 255), 2)
    print(theta)
    print(rho)

    img_rotated = ndimage.rotate(image1, 180 * theta / 3.1415926 - 90)
    cv2.imshow("Image", img_rotated)

    # cv2.waitKey(0)
    # cv2.imshow("Image", image1)

    # cv2.waitKey(0)
    # cv2.imshow("Image", edges)

    cv2.waitKey(0)
    # close all open windows
    cv2.destroyAllWindows()


def detect_line_hough_transform():
    img = cv2.imread(
        r'C:\Projects\Python\Tools\DetectOrientationImage\cheo.png')

    # Convert the img to grayscale
    gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)

    # Apply edge detection method on the image
    edges = cv2.Canny(gray, 50, 150, apertureSize=3)

    # This returns an array of r and theta values
    lines = cv2.HoughLines(edges, 1, np.pi/180, 200)

    # The below for loop runs till r and theta values
    # are in the range of the 2d array
    for r, theta in lines[0]:

        # Stores the value of cos(theta) in a
        a = np.cos(theta)

        # Stores the value of sin(theta) in b
        b = np.sin(theta)

        # x0 stores the value rcos(theta)
        x0 = a*r

        # y0 stores the value rsin(theta)
        y0 = b*r

        # x1 stores the rounded off value of (rcos(theta)-1000sin(theta))
        x1 = int(x0 + 1000*(-b))

        # y1 stores the rounded off value of (rsin(theta)+1000cos(theta))
        y1 = int(y0 + 1000*(a))

        # x2 stores the rounded off value of (rcos(theta)+1000sin(theta))
        x2 = int(x0 - 1000*(-b))

        # y2 stores the rounded off value of (rsin(theta)-1000cos(theta))
        y2 = int(y0 - 1000*(a))

        # cv2.line draws a line in img from the point(x1,y1) to (x2,y2).
        # (0,0,255) denotes the colour of the line to be
        # drawn. In this case, it is red.
        cv2.line(img, (x1, y1), (x2, y2), (0, 0, 255), 2)

    # All the changes made in the input image are finally
    # written on a new image houghlines.jpg
    cv2.imshow('Image', img)
    cv2.waitKey(0)
    cv2.destroyAllWindows()


def rotate_video():
    src = 255 - \
        cv2.imread(
            r"C:\Projects\Python\Tools\DetectOrientationImage\nguoc.png", 0)
    scores = []

    h, w = src.shape
    small_dimention = min(h, w)
    src = src[:small_dimention, :small_dimention]

    out = cv2.VideoWriter(r'C:\Projects\Python\Tools\rotate.avi',
                          cv2.VideoWriter_fourcc('M', 'J', 'P', 'G'),
                          15, (320, 320))

    def rotate(img, angle):
        rows, cols = img.shape
        M = cv2.getRotationMatrix2D((cols/2, rows/2), angle, 1)
        dst = cv2.warpAffine(img, M, (cols, rows))
        return dst

    def sum_rows(img):
        # Create a list to store the row sums
        row_sums = []
        # Iterate through the rows
        for r in range(img.shape[0]-1):
            # Sum the row
            row_sum = sum(sum(img[r:r+1, :]))
            # Add the sum to the list
            row_sums.append(row_sum)
        # Normalize range to (0,255)
        row_sums = (row_sums/max(row_sums)) * 255
        # Return
        return row_sums

    def display_data(roi, row_sums, buffer):
        # Create background to draw transform on
        bg = np.zeros((buffer*2, buffer*2), np.uint8)
        # Iterate through the rows and draw on the background
        for row in range(roi.shape[0]-1):
            row_sum = row_sums[row]
            bg[row:row+1, :] = row_sum
        left_side = int(buffer/3)
        bg[:, left_side:] = roi[:, left_side:]
        cv2.imshow('bg1', bg)
        k = cv2.waitKey(1)
        out.write(cv2.cvtColor(cv2.resize(bg, (320, 320)), cv2.COLOR_GRAY2BGR))
        return k

    # Rotate the image around in a circle
    angle = 0
    while angle <= 360:
        # Rotate the source image
        img = rotate(src, angle)
        # Crop the center 1/3rd of the image (roi is filled with text)
        h, w = img.shape
        buffer = min(h, w) - int(min(h, w)/1.5)
        #roi = img.copy()
        roi = img[int(h/2-buffer):int(h/2+buffer),
                  int(w/2-buffer):int(w/2+buffer)]
        # Create background to draw transform on
        bg = np.zeros((buffer*2, buffer*2), np.uint8)
        # Threshold image
        _, roi = cv2.threshold(roi, 140, 255, cv2.THRESH_BINARY)
        # Compute the sums of the rows
        row_sums = sum_rows(roi)
        # High score --> Zebra stripes
        score = np.count_nonzero(row_sums)
        if sum(row_sums) < 100000:
            scores.append(angle)
        k = display_data(roi, row_sums, buffer)
        if k == 27:
            break
        # Increment angle and try again
        angle += .5
    cv2.destroyAllWindows()

    # Create images for display purposes
    display = src.copy()
    # Create an image that contains bins.
    bins_image = np.zeros_like(display)
    for angle in scores:
        # Rotate the image and draw a line on it
        display = rotate(display, angle)
        cv2.line(display, (0, int(h/2)), (w, int(h/2)), 255, 1)
        display = rotate(display, -angle)
        # Rotate the bins image
        bins_image = rotate(bins_image, angle)
        # Draw a line on a temporary image
        temp = np.zeros_like(bins_image)
        cv2.line(temp, (0, int(h/2)), (w, int(h/2)), 50, 1)
        # 'Fill' up the bins
        bins_image += temp
        bins_image = rotate(bins_image, -angle)

    # Find the most filled bin
    for col in range(bins_image.shape[0]-1):
        column = bins_image[:, col:col+1]
        if np.amax(column) == np.amax(bins_image):
            x = col
    for col in range(bins_image.shape[0]-1):
        column = bins_image[:, col:col+1]
        if np.amax(column) == np.amax(bins_image):
            y = col
    # Draw circles showing the most filled bin
    cv2.circle(display, (x, y), 560, 255, 5)

    # Plot with Matplotlib
    import matplotlib.pyplot as plt
    import matplotlib.image as mpimg
    f, axarr = plt.subplots(1, 3, sharex=True)
    axarr[0].imshow(src)
    axarr[1].imshow(display)
    axarr[2].imshow(bins_image)
    axarr[0].set_title('Source Image')
    axarr[1].set_title('Output')
    axarr[2].set_title('Bins Image')
    axarr[0].axis('off')
    axarr[1].axis('off')
    axarr[2].axis('off')
    plt.show()

    cv2.waitKey()
    cv2.destroyAllWindows()


def top_bot_margin_ratio(image: np.ndarray) -> float:
    if len(image.shape) > 2 and image.shape[2] > 1:
        image = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)
    above = 0
    below = 0
    for x in range(image.shape[1]):
        col = np.argwhere(image[:, x] < 128)
        if col.shape[0] > 0:
            above += col[0, 0]
            below += image.shape[0] - 1 - col[-1, 0]
    return math.log(above / below)


def rotate_90():

    img_before = cv2.imread(
        r"C:\Projects\Python\Tools\DetectOrientationImage\nguoc2.png")

    cv2.imshow("Before", img_before)
    key = cv2.waitKey(0)

    img_gray = cv2.cvtColor(img_before, cv2.COLOR_BGR2GRAY)
    img_edges = cv2.Canny(img_gray, 100, 100, apertureSize=3)
    lines = cv2.HoughLinesP(img_edges, 1, math.pi / 180.0,
                            100, minLineLength=100, maxLineGap=5)

    angles = []

    for [[x1, y1, x2, y2]] in lines:
        cv2.line(img_before, (x1, y1), (x2, y2), (255, 0, 0), 3)
        angle = math.degrees(math.atan2(y2 - y1, x2 - x1))
        angles.append(angle)

    cv2.imshow("Detected lines", img_before)
    key = cv2.waitKey(0)

    median_angle = np.median(angles)
    img_rotated = ndimage.rotate(img_before, median_angle)

    print(f"Angle is {median_angle:.04f}")
    cv2.imshow('rotated.jpg', img_rotated)
    cv2.waitKey(0)
    cv2.destroyAllWindows()

def rotate():
        # import the necessary packages
    import numpy as np
    import argparse
    import cv2


    image = cv2.imread(r'Tools\files\images\cheo.png')

    # convert the image to grayscale and flip the foreground
    # and background to ensure foreground is now "white" and
    # the background is "black"
    gray = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)
    gray = cv2.bitwise_not(gray)
    # threshold the image, setting all foreground pixels to
    # 255 and all background pixels to 0
    thresh = cv2.threshold(gray, 0, 255,
        cv2.THRESH_BINARY | cv2.THRESH_OTSU)[1]

    # grab the (x, y) coordinates of all pixel values that
    # are greater than zero, then use these coordinates to
    # compute a rotated bounding box that contains all
    # coordinates
    coords = np.column_stack(np.where(thresh > 0))
    angle = cv2.minAreaRect(coords)[-1]
    # the `cv2.minAreaRect` function returns values in the
    # range [-90, 0); as the rectangle rotates clockwise the
    # returned angle trends to 0 -- in this special case we
    # need to add 90 degrees to the angle
    if angle < -45:
        angle = -(90 + angle)
    # otherwise, just take the inverse of the angle to make
    # it positive
    else:
        angle = -angle
    
    # rotate the image to deskew it
    (h, w) = image.shape[:2]
    center = (w // 2, h // 2)
    M = cv2.getRotationMatrix2D(center, angle, 1.0)
    rotated = cv2.warpAffine(image, M, (w, h),
        flags=cv2.INTER_CUBIC, borderMode=cv2.BORDER_REPLICATE)

    # draw the correction angle on the image so we can validate it
    cv2.putText(rotated, "Angle: {:.2f} degrees".format(angle),
        (10, 30), cv2.FONT_HERSHEY_SIMPLEX, 0.7, (0, 0, 255), 2)
    # show the output image
    print("[INFO] angle: {:.3f}".format(angle))
    cv2.imshow("Input", image)
    cv2.imshow("Rotated", rotated)
    cv2.waitKey(0)
    

import numpy as np
import cv2 as cv
# Create a black image
img = np.zeros((512,512,3), np.uint8)
# Draw a diagonal blue line with thickness of 5 px
# cv.line(img,(0,0),(511,511),(255,0,0),5)

cv2.imshow("Rotated", img)
cv2.waitKey(0)

