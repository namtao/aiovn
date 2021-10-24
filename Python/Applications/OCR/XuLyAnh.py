import cv2 
import pytesseract
import numpy as np
import os
import argparse
from matplotlib import pyplot as plt
import pdf2image
from PIL import Image
from pdf2image import convert_from_path, convert_from_bytes
import re
from pytesseract.pytesseract import Output

class OCR:
	#set path tesseract
	pytesseract.pytesseract.tesseract_cmd = r"C:\Program Files\Tesseract-OCR\tesseract.exe"

	#hinh nguyen ban
	img = cv2.imread('tv.jpg')

	# get grayscale image
	def get_grayscale(image):
		#
		return cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)

	# noise removal
	def remove_noise(image):
		#
	    return cv2.medianBlur(image,5)
	 
	#thresholding
	def thresholding(image):
		#
	    return cv2.threshold(image, 0, 255, cv2.THRESH_BINARY + cv2.THRESH_OTSU)[1]

	#dilation
	def dilate(image):
	    kernel = np.ones((5,5),np.uint8)
	    return cv2.dilate(image, kernel, iterations = 1)
	    
	#erosion
	def erode(image):
	    kernel = np.ones((5,5),np.uint8)
	    return cv2.erode(image, kernel, iterations = 1)

	#opening - erosion followed by dilation
	def opening(image):
	    kernel = np.ones((5,5),np.uint8)
	    return cv2.morphologyEx(image, cv2.MORPH_OPEN, kernel)

	#canny edge detection
	def canny(image):

	    return cv2.Canny(image, 100, 200)

	#skew correction
	def deskew(image):
	    coords = np.column_stack(np.where(image > 0))
	    angle = cv2.minAreaRect(coords)[-1]
	    if angle < -45:
	        angle = -(90 + angle)
	    else:
	        angle = -angle
	    (h, w) = image.shape[:2]
	    center = (w // 2, h // 2)
	    M = cv2.getRotationMatrix2D(center, angle, 1.0)
	    rotated = cv2.warpAffine(image, M, (w, h), flags=cv2.INTER_CUBIC, borderMode=cv2.BORDER_REPLICATE)
	    return rotated

	#template matching
	def match_template(image, template):

	    return cv2.matchTemplate(image, template, cv2.TM_CCOEFF_NORMED) 

	def basicocr(image):
		#OCR
		custom_config = r'-l vni --oem 3 --psm 6'
		custom_config = r'-l eng --psm 6'
		#thay the img = cac che do nhu tren
		print (pytesseract.image_to_string(image, config=custom_config))

	#Getting boxes around text
	def getting_boxes(image):
		h, w, c = image.shape
		boxes = pytesseract.image_to_boxes(image) 
		for b in boxes.splitlines():
		    b = b.split(' ')
		    image = cv2.rectangle(image, (int(b[1]), h - int(b[2])), (int(b[3]), h - int(b[4])), (0, 255, 0), 2)

	#Text template matching
	def text_date_matching(image):
		d = pytesseract.image_to_data(image, output_type=Output.DICT)
		keys = list(d.keys())

		date_pattern = '^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/(19|20)\d\d$'

		n_boxes = len(d['text'])
		for i in range(n_boxes):
		    if int(d['conf'][i]) > 60:
		    	if re.match(date_pattern, d['text'][i]):
			        (x, y, w, h) = (d['left'][i], d['top'][i], d['width'][i], d['height'][i])
			        image = cv2.rectangle(image, (x, y), (x + w, y + h), (0, 255, 0), 2)

	#ocr tv
	def orc_tv(image):
		# Đọc file ảnh và chuyển về ảnh xám
		gray = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)
		filename = "tv.pdf".format(os.getpid())
		# Load ảnh và apply nhận dạng bằng Tesseract OCR
		#text = pytesseract.image_to_string(Image.open(filename),lang='vie')
		text = pytesseract.image_to_string(image,config='--psm 4',lang='vie')

		# In dòng chữ nhận dạng được
		print(text)
		 
		# Hiển thị các ảnh chúng ta đã xử lý.
		cv2.imshow("Image", image)

	#crop and show image
	refPt = []
	cropping = False
	def crop(image):
		def click_and_crop(event, x, y, flags, param):
			# grab references to the global variables
			global refPt, cropping
			# if the left mouse button was clicked, record the starting
			# (x, y) coordinates and indicate that cropping is being
			# performed
			if event == cv2.EVENT_LBUTTONDOWN:
				refPt = [(x, y)]
				cropping = True
			# check to see if the left mouse button was released
			elif event == cv2.EVENT_LBUTTONUP:
				# record the ending (x, y) coordinates and indicate that
				# the cropping operation is finished
				OCR.refPt.append((x, y))
				cropping = False
				# draw a rectangle around the region of interest
				cv2.rectangle(image, OCR.refPt[0], OCR.refPt[1], (0, 255, 0), 2)
				cv2.imshow("image", image)

		# construct the argument parser and parse the arguments
		#ap = argparse.ArgumentParser()
		#ap.add_argument("-i", "--image", required=True, help="Path to the image")
		#args = vars(ap.parse_args())
		# load the image, clone it, and setup the mouse callback function
		clone = image.copy()
		cv2.namedWindow("image")
		cv2.setMouseCallback("image", click_and_crop)
		# keep looping until the 'q' key is pressed
		while True:
			# display the image and wait for a keypress 
			#cv2.resizeWindow('image', 600,600)
			cv2.imshow("image", image)
			ims = cv2.resize(image, (960, 540))
			key = cv2.waitKey(0) & 0xFF
			# if the 'r' key is pressed, reset the cropping region

			if key == ord("r"):
				image = clone.copy()
			# if the 'c' key is pressed, break from the loop
			elif key == ord("c"):
				if len(refPt) == 2:
					roi = clone[refPt[0][1]:refPt[1][1], refPt[0][0]:refPt[1][0]]
					cv2.imshow("Crop", roi)
					#cv2.waitKey(0)
			elif key == ord("e"):
				break
		# if there are two reference points, then crop the region of interest
		# from teh image and display it
		#if len(refPt) == 2:
		#	roi = clone[refPt[0][1]:refPt[1][1], refPt[0][0]:refPt[1][0]]
		#	cv2.imshow("Crop", roi)
		#	cv2.waitKey(0)
		# close all open windows
		#cv2.destroyAllWindows()

	#convert pdf to jpg
	def pdf_convert(inpath, image_path):
		print("convert......")
		OUTPUT_FOLDER = None
		FIRST_PAGE = None
		LAST_PAGE = None
		FORMAT = 'jpg'
		USERPWD = None
		USE_CROPBOX = False
		STRICT = False
		POPPLER_PATH = r"C:/Project/Python/poppler-21.03.0/Library/bin"

		pil_images = pdf2image.convert_from_path(inpath, output_folder = OUTPUT_FOLDER, first_page = FIRST_PAGE, last_page = LAST_PAGE, fmt = FORMAT, userpw = USERPWD, use_cropbox = USE_CROPBOX, strict = STRICT, poppler_path= POPPLER_PATH)

		#for image in pil_images:
		pil_images[0].save(image_path + 'image_convert.jpg')

	#convert to pdf searchable
	def image_convert():
		TESSDATA_PREFIX = r'C:\Program Files\Tesseract-OCR'
		tessdata_dir_config = '--tessdata-dir "C://Program Files//Tesseract-OCR//tessdata"'

		#input_dir = "‪a.tiff"

		#img = cv2.imread(input_dir, 1)

		pdf = pytesseract.image_to_pdf_or_hocr('a.tiff', lang = 'vie', extension='pdf')
		with open('test.pdf', 'w+b') as f:
		    f.write(pdf) # pdf type is bytes by default

		##result = pytesseract.image_to_pdf_or_hocr(img, lang="en", config = tessdata_dir_config)
		#f = open("searchable.pdf", "w+b")
		#f.write(bytearray(result))
		#f.close()

class ChinhSua:
    	#thay đổi gamma để thay đổi độ tương phản của hình ảnh: =1 bình thường, >1 tối, <1 sáng
	def adjust_image_gamma(image, gamma = 1.0):
		image = np.power(image, gamma)
		max_val = np.max(image.ravel())
		image = image/max_val * 255
		image = image.astype(np.uint8)
		return image

	#thay đổi gamma nhưng tốc độ nhanh hơn
	def adjust_image_gamma_lookuptable(image, gamma=1.0):
		# build a lookup table mapping the pixel values [0, 255] to
		# their adjusted gamma values
		table = np.array([((i / 255.0) ** gamma) * 255
			for i in np.arange(0, 256)]).astype("uint8")

		# apply gamma correction using the lookup table
		return cv2.LUT(image, table)

	#resize image
	def image_resize(image, width = None, height = None, inter = cv2.INTER_AREA):
		# initialize the dimensions of the image to be resized and
		# grab the image size
		dim = None
		(h, w) = image.shape[:2]

		# if both the width and height are None, then return the
		# original image
		if width is None and height is None:
			return image

		# check to see if the width is None
		if width is None:
			# calculate the ratio of the height and construct the
			# dimensions
			r = height / float(h)
			dim = (int(w * r), height)

		# otherwise, the height is None
		else:
			# calculate the ratio of the width and construct the
			# dimensions
			r = width / float(w)
			dim = (width, int(h * r))

		# resize the image
		resized = cv2.resize(image, dim, interpolation = inter)

		# return the resized image
		return resized

	#thay đổi tương phản và độ sáng hình ảnh
	def pixel_transform(image, alpha = 1.0, beta = 0):
		'''
		out[pixel] = alpha * image[pixel] + beta
		'''
		output = np.zeros(image.shape, image.dtype)
		h, w, ch = image.shape
		for y in range(h):
			for x in range(w):
				for c in range(ch):
					output[y,x,c] = np.clip(alpha*image[y,x,c] + beta, 0, 255)

		return output

################################################################################################################
def main():
	#getting_boxes(img)

	#ocr tieng viet
	#OCR.orc_tv(OCR.img)

	#crop(img)
	#inpath = "tv2.pdf"
	#image_path = "C:/Project/Python/"
	#pdf_convert(inpath, image_path)

	#OCR.image_convert()
		
	#cac che do cua hinh anh
	gray = OCR.get_grayscale(OCR.img)
	thresh = OCR.thresholding(gray)
	opening = OCR.opening(gray)
	canny = OCR.canny(gray)

	#show image on windows
	#cv2.imshow('Image OCR', ChinhSua.image_resize(opening, height = 1000))
	#OCR.crop(ChinhSua.image_resize(opening, height = 1000))
	#OCR.crop(OCR.img)

	#basicocr(img)

	#xử lý ảnh
	#low_adjusted = adjust_image_gamma_lookuptable(img, 0.9)
	#transformed_high = cv2.convertScaleAbs(img, 50, 1)# g(x)=αf(x)+β    α: độ tương phản, β: độ sáng    
	#cv2.imshow('test', image_resize(transformed_high, height = 800))
	
	#man hinh cho
	cv2.waitKey(0) 

if __name__ == '__main__':
	main()
	#print (__name__)