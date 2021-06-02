import cv2 
import pytesseract
import numpy as np
import os
import argparse
from matplotlib import pyplot as plt
import pdf2image
from PIL import Image
from pdf2image import convert_from_path, convert_from_bytes
import XuLyAnh

img = cv2.imread('a.png', cv2.IMREAD_GRAYSCALE)
#img = np.full((100,80,3), 12, np.uint8)
imgGray = cv2.cvtColor(img, cv2.COLOR_BAYER_BG2GRAY)
imgBlur = cv2.GaussianBlur(imgGray, (7, 7), 0)
imgCanny = cv2.Canny(img, 100, 200)
#làm mờ
#cv2.imshow('Blur', XuLyAnh.ChinhSua.image_resize(imgBlur, height = 500))
#đen trắng
#cv2.imshow('Gray', XuLyAnh.ChinhSua.image_resize(imgGray, height = 500))
#canny: vẽ đường bao
#cv2.imshow('Canny', XuLyAnh.ChinhSua.image_resize(imgCanny, height = 500))


#man hinh cho
cv2.waitKey(0) 