import cv2
import numpy as np
from matplotlib import pyplot as plt


def image_holding():
    # Màu là 1, grayscale là 0, và không thay đổi là -1

    image = 'OpenCV/thresh.jpg'
    img = cv2.imread(image, 0)

    # 500 x 250

    # add image
    # add = cv2.add(img,img)
    # cv2.imshow('add',add)

    # thresholding image
    # retval, threshold = cv2.threshold(img, 12, 255, cv2.THRESH_BINARY)
    # cv2.imshow('Original',img)
    # cv2.imshow('Threshold',threshold)

    # Adaptive thresholding
    # th = cv2.adaptiveThreshold(img, 255, cv2.ADAPTIVE_THRESH_GAUSSIAN_C, cv2.THRESH_BINARY, 115, 1)
    # cv2.imshow('Original',img)
    # cv2.imshow('Adaptive threshold',th)

    # Otsu threshold
    # retval2,threshold2 = cv2.threshold(img, 125,255,cv2.THRESH_BINARY+cv2.THRESH_OTSU)
    # cv2.imshow('original',img)
    # cv2.imshow('Otsu threshold',threshold2)

    ########################################################################################
    cv2.waitKey(0)
    cv2.destroyAllWindows()


def detect_color_from_camera():
    cap = cv2.VideoCapture(0)

    while(1):
        _, frame = cap.read()
        hsv = cv2.cvtColor(frame, cv2.COLOR_BGR2HSV)

        # nhận biết màu đỏ
        lower_red = np.array([30, 150, 20])
        upper_red = np.array([255, 255, 255])

        mask = cv2.inRange(hsv, lower_red, upper_red)
        res = cv2.bitwise_and(frame, frame, mask=mask)

        cv2.imshow('frame', frame)
        cv2.imshow('mask', mask)
        cv2.imshow('res', res)

        k = cv2.waitKey(5) & 0xFF
        if k == 27:
            break

    cv2.destroyAllWindows()


def detect_hsv():
    cap = cv2.VideoCapture(0)

    def nothing(x):
        pass
    # Creating a window for later use
    cv2.namedWindow('result')

    # Starting with 100's to prevent error while masking
    h, s, v = 100, 100, 100

    # Creating track bar
    cv2.createTrackbar('h', 'result', 0, 179, nothing)
    cv2.createTrackbar('s', 'result', 0, 255, nothing)
    cv2.createTrackbar('v', 'result', 0, 255, nothing)

    while(1):

        _, frame = cap.read()

        # converting to HSV
        hsv = cv2.cvtColor(frame, cv2.COLOR_BGR2HSV)

        # get info from track bar and appy to result
        h = cv2.getTrackbarPos('h', 'result')
        s = cv2.getTrackbarPos('s', 'result')
        v = cv2.getTrackbarPos('v', 'result')

        # Normal masking algorithm
        lower_blue = np.array([h, s, v])
        upper_blue = np.array([180, 255, 255])

        mask = cv2.inRange(hsv, lower_blue, upper_blue)

        result = cv2.bitwise_and(frame, frame, mask=mask)

        cv2.imshow('result', result)

        k = cv2.waitKey(5) & 0xFF
        if k == 27:
            break

    cap.release()

    cv2.destroyAllWindows()
