import requests
from bs4 import BeautifulSoup
import json
import os
from Utils.TtsUtils import *
import m3u8
# import PyPDF2
from PyPDF2  import PdfFileReader
import numpy as np
import cv2
from scipy import ndimage
import pytesseract
import math
from scipy import ndimage
from pdf2image import convert_from_path


def rotatepng():
    image1 = cv2.imread(r'C:\Projects\Python\Applications\cheo.png')
    gray=cv2.cvtColor(image1,cv2.COLOR_BGR2GRAY)

    edges = cv2.Canny(gray,50,150,apertureSize = 3)

    canimg = cv2.Canny(gray, 50, 200)
    lines= cv2.HoughLines(canimg, 1, np.pi / 180.0, 250, np.array([]))
    #lines= cv2.HoughLines(edges, 1, np.pi/180, 80, np.array([]))
    for line in lines:
        rho, theta = line[0]
        a = np.cos(theta)
        b = np.sin(theta)
        x0 = a*rho
        y0 = b*rho
        x1 = int(x0 + 1000 * ( -b ))
        y1 = int(y0 + 1000 * ( a ))
        x2 = int(x0 - 1000 * ( -b ))
        y2 = int(y0 - 1000 * ( a ))

        cv2.line(image1, (x1,y1), (x2,y2), (0,0,255),2)
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
    
def detectLineHoughTransform():
    img = cv2.imread(r'C:\Projects\Python\Applications\cheo.png')
    
    # Convert the img to grayscale
    gray = cv2.cvtColor(img,cv2.COLOR_BGR2GRAY)
    
    # Apply edge detection method on the image
    edges = cv2.Canny(gray,50,150,apertureSize = 3)
    
    # This returns an array of r and theta values
    lines = cv2.HoughLines(edges,1,np.pi/180, 200)
    
    # The below for loop runs till r and theta values 
    # are in the range of the 2d array
    for r,theta in lines[0]:
        
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
        #drawn. In this case, it is red. 
        cv2.line(img,(x1,y1), (x2,y2), (0,0,255),2)
        
    # All the changes made in the input image are finally
    # written on a new image houghlines.jpg
    cv2.imshow('Image', img)
    cv2.waitKey(0)
    cv2.destroyAllWindows()

def rotate2Video():
    src = 255 - cv2.imread(r"C:\Projects\Python\Applications\nguoc.png", 0)
    scores = []

    h,w = src.shape
    small_dimention = min(h,w)
    src = src[:small_dimention, :small_dimention]

    out = cv2.VideoWriter(r'C:\Projects\Python\Applications\rotate.avi',
                        cv2.VideoWriter_fourcc('M','J','P','G'),
                        15, (320,320))


    def rotate(img, angle):
        rows,cols = img.shape
        M = cv2.getRotationMatrix2D((cols/2,rows/2),angle,1)
        dst = cv2.warpAffine(img,M,(cols,rows))
        return dst

    def sum_rows(img):
        # Create a list to store the row sums
        row_sums = []
        # Iterate through the rows
        for r in range(img.shape[0]-1):
            # Sum the row
            row_sum = sum(sum(img[r:r+1,:]))
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
        bg[:, left_side:] = roi[:,left_side:]   
        cv2.imshow('bg1', bg)
        k = cv2.waitKey(1)
        out.write(cv2.cvtColor(cv2.resize(bg, (320,320)), cv2.COLOR_GRAY2BGR))
        return k

    # Rotate the image around in a circle
    angle = 0
    while angle <= 360:
        # Rotate the source image
        img = rotate(src, angle)    
        # Crop the center 1/3rd of the image (roi is filled with text)
        h,w = img.shape
        buffer = min(h, w) - int(min(h,w)/1.5)
        #roi = img.copy()
        roi = img[int(h/2-buffer):int(h/2+buffer), int(w/2-buffer):int(w/2+buffer)]
        # Create background to draw transform on
        bg = np.zeros((buffer*2, buffer*2), np.uint8)
        # Threshold image
        _, roi = cv2.threshold(roi, 140, 255, cv2.THRESH_BINARY)
        # Compute the sums of the rows
        row_sums = sum_rows(roi)
        # High score --> Zebra stripes
        score = np.count_nonzero(row_sums)
        if sum(row_sums) < 100000: scores.append(angle)
        k = display_data(roi, row_sums, buffer)
        if k == 27: break
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
        cv2.line(display, (0,int(h/2)), (w,int(h/2)), 255, 1)
        display = rotate(display, -angle)
        # Rotate the bins image
        bins_image = rotate(bins_image, angle)
        # Draw a line on a temporary image
        temp = np.zeros_like(bins_image)
        cv2.line(temp, (0,int(h/2)), (w,int(h/2)), 50, 1)
        # 'Fill' up the bins
        bins_image += temp
        bins_image = rotate(bins_image, -angle)

    # Find the most filled bin
    for col in range(bins_image.shape[0]-1):
        column = bins_image[:, col:col+1]
        if np.amax(column) == np.amax(bins_image): x = col
    for col in range(bins_image.shape[0]-1):
        column = bins_image[:, col:col+1]
        if np.amax(column) == np.amax(bins_image): y = col
    # Draw circles showing the most filled bin
    cv2.circle(display, (x,y), 560, 255, 5)

    # Plot with Matplotlib
    import matplotlib.pyplot as plt
    import matplotlib.image as mpimg
    f, axarr = plt.subplots(1,3, sharex=True)
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

def rotate90():

    img_before = cv2.imread(r"C:\Projects\Python\Applications\nguoc2.png")

    cv2.imshow("Before", img_before)    
    key = cv2.waitKey(0)

    img_gray = cv2.cvtColor(img_before, cv2.COLOR_BGR2GRAY)
    img_edges = cv2.Canny(img_gray, 100, 100, apertureSize=3)
    lines = cv2.HoughLinesP(img_edges, 1, math.pi / 180.0, 100, minLineLength=100, maxLineGap=5)

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

rotate90()
