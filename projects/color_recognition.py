import glob

import cv2
import numpy as np
from matplotlib import pyplot as plt


def detect_color():
    # load images
    bright = cv2.imread('OpenCV/cube01.png')
    dark = cv2.imread('OpenCV/cube02.png')

    # Không gian màu LAB
    brightLAB = cv2.cvtColor(bright, cv2.COLOR_BGR2LAB)
    darkLAB = cv2.cvtColor(dark, cv2.COLOR_BGR2LAB)

    # Không gian màu YCrCb
    brightYCB = cv2.cvtColor(bright, cv2.COLOR_BGR2YCrCb)
    darkYCB = cv2.cvtColor(dark, cv2.COLOR_BGR2YCrCb)

    # Không gian màu HSV
    brightHSV = cv2.cvtColor(bright, cv2.COLOR_BGR2HSV)
    darkHSV = cv2.cvtColor(dark, cv2.COLOR_BGR2HSV)

    # show results
    bgr = [40, 158, 16]
    thresh = 40

    minBGR = np.array([bgr[0] - thresh, bgr[1] - thresh, bgr[2] - thresh])
    maxBGR = np.array([bgr[0] + thresh, bgr[1] + thresh, bgr[2] + thresh])

    maskBGR = cv2.inRange(bright, minBGR, maxBGR)
    resultBGR = cv2.bitwise_and(bright, bright, mask=maskBGR)

    # convert 1D array to 3D, then convert it to HSV and take the first element
    # this will be same as shown in the above figure [65, 229, 158]
    hsv = cv2.cvtColor(np.uint8([[bgr]]), cv2.COLOR_BGR2HSV)[0][0]

    minHSV = np.array([hsv[0] - thresh, hsv[1] - thresh, hsv[2] - thresh])
    maxHSV = np.array([hsv[0] + thresh, hsv[1] + thresh, hsv[2] + thresh])

    maskHSV = cv2.inRange(brightHSV, minHSV, maxHSV)
    resultHSV = cv2.bitwise_and(brightHSV, brightHSV, mask=maskHSV)

    # convert 1D array to 3D, then convert it to YCrCb and take the first element
    ycb = cv2.cvtColor(np.uint8([[bgr]]), cv2.COLOR_BGR2YCrCb)[0][0]

    minYCB = np.array([ycb[0] - thresh, ycb[1] - thresh, ycb[2] - thresh])
    maxYCB = np.array([ycb[0] + thresh, ycb[1] + thresh, ycb[2] + thresh])

    maskYCB = cv2.inRange(brightYCB, minYCB, maxYCB)
    resultYCB = cv2.bitwise_and(brightYCB, brightYCB, mask=maskYCB)

    # convert 1D array to 3D, then convert it to LAB and take the first element
    lab = cv2.cvtColor(np.uint8([[bgr]]), cv2.COLOR_BGR2LAB)[0][0]

    minLAB = np.array([lab[0] - thresh, lab[1] - thresh, lab[2] - thresh])
    maxLAB = np.array([lab[0] + thresh, lab[1] + thresh, lab[2] + thresh])

    maskLAB = cv2.inRange(brightLAB, minLAB, maxLAB)
    resultLAB = cv2.bitwise_and(brightLAB, brightLAB, mask=maskLAB)

    cv2.imshow("Result BGR", resultBGR)
    cv2.imshow("Result HSV", resultHSV)
    cv2.imshow("Result YCB", resultYCB)
    cv2.imshow("Output LAB", resultLAB)

    cv2.waitKey(0)
    cv2.destroyAllWindows()


def gui_color_detect():
    def show_pixel_value(event, x, y, flags, param):
        global img, combinedResult, placeholder

        if event == cv2.EVENT_MOUSEMOVE:
            # get the value of pixel from the location of mouse in (x,y)
            bgr = img[y, x]

            # Convert the BGR pixel into other colro formats
            ycb = cv2.cvtColor(np.uint8([[bgr]]), cv2.COLOR_BGR2YCrCb)[0][0]
            lab = cv2.cvtColor(np.uint8([[bgr]]), cv2.COLOR_BGR2Lab)[0][0]
            hsv = cv2.cvtColor(np.uint8([[bgr]]), cv2.COLOR_BGR2HSV)[0][0]

            # Create an empty placeholder for displaying the values
            placeholder = np.zeros((img.shape[0], 400, 3), dtype=np.uint8)

            # fill the placeholder with the values of color spaces
            cv2.putText(placeholder, "BGR {}".format(bgr), (20, 70),
                        cv2.FONT_HERSHEY_COMPLEX, .9, (255, 255, 255), 1, cv2.LINE_AA)
            cv2.putText(placeholder, "HSV {}".format(hsv), (20, 140),
                        cv2.FONT_HERSHEY_COMPLEX, .9, (255, 255, 255), 1, cv2.LINE_AA)
            cv2.putText(placeholder, "YCrCb {}".format(ycb), (20, 210),
                        cv2.FONT_HERSHEY_COMPLEX, .9, (255, 255, 255), 1, cv2.LINE_AA)
            cv2.putText(placeholder, "LAB {}".format(lab), (20, 280),
                        cv2.FONT_HERSHEY_COMPLEX, .9, (255, 255, 255), 1, cv2.LINE_AA)

            # Combine the two results to show side by side in a single image
            combinedResult = np.hstack([img, placeholder])

            cv2.imshow('PRESS P for Previous, N for Next Image', combinedResult)

    if __name__ == '__main__':

        # load the image and setup the mouse callback function
        global img
        files = glob.glob('OpenCV/image*.jpg')
        files.sort()
        img = cv2.imread(files[0])
        img = cv2.resize(img, (400, 400))
        cv2.imshow('PRESS P for Previous, N for Next Image', img)

        # Create an empty window
        cv2.namedWindow('PRESS P for Previous, N for Next Image')
        # Create a callback function for any event on the mouse
        cv2.setMouseCallback(
            'PRESS P for Previous, N for Next Image', show_pixel_value)
        i = 0
        while (1):
            k = cv2.waitKey(1) & 0xFF
            # check next image in the folder
            if k == ord('n'):
                i += 1
                img = cv2.imread(files[i % len(files)])
                img = cv2.resize(img, (400, 400))
                cv2.imshow('PRESS P for Previous, N for Next Image', img)

            # check previous image in folder
            elif k == ord('p'):
                i -= 1
                img = cv2.imread(files[i % len(files)])
                img = cv2.resize(img, (400, 400))
                cv2.imshow('PRESS P for Previous, N for Next Image', img)

            elif k == 27:
                cv2.destroyAllWindows()
                break


def gui_color_segment():
    # global variable to keep track of
    show = False

    def on_trackbar_activity(x):
        global show
        show = True
        pass

    if __name__ == '__main__':

        # Get the filename from the command line
        files = glob.glob('OpenCV/*.png')
        files.sort()
        # load the image
        original = cv2.imread(files[0])
        # Resize the image
        rsize = 250
        original = cv2.resize(original, (rsize, rsize))

        # position on the screen where the windows start
        initialX = 50
        initialY = 50

        # creating windows to display images
        cv2.namedWindow('P-> Previous, N-> Next', cv2.WINDOW_AUTOSIZE)
        cv2.namedWindow('SelectBGR', cv2.WINDOW_AUTOSIZE)
        cv2.namedWindow('SelectHSV', cv2.WINDOW_AUTOSIZE)
        cv2.namedWindow('SelectYCB', cv2.WINDOW_AUTOSIZE)
        cv2.namedWindow('SelectLAB', cv2.WINDOW_AUTOSIZE)

        # moving the windows to stack them horizontally
        cv2.moveWindow('P-> Previous, N-> Next', initialX, initialY)
        cv2.moveWindow('SelectBGR', initialX + (rsize + 5), initialY)
        cv2.moveWindow('SelectHSV', initialX + 2*(rsize + 5), initialY)
        cv2.moveWindow('SelectYCB', initialX + 3*(rsize + 5), initialY)
        cv2.moveWindow('SelectLAB', initialX + 4*(rsize + 5), initialY)

        # creating trackbars to get values for YCrCb
        cv2.createTrackbar('CrMin', 'SelectYCB', 0, 255, on_trackbar_activity)
        cv2.createTrackbar('CrMax', 'SelectYCB', 0, 255, on_trackbar_activity)
        cv2.createTrackbar('CbMin', 'SelectYCB', 0, 255, on_trackbar_activity)
        cv2.createTrackbar('CbMax', 'SelectYCB', 0, 255, on_trackbar_activity)
        cv2.createTrackbar('YMin', 'SelectYCB', 0, 255, on_trackbar_activity)
        cv2.createTrackbar('YMax', 'SelectYCB', 0, 255, on_trackbar_activity)

        # creating trackbars to get values for HSV
        cv2.createTrackbar('HMin', 'SelectHSV', 0, 180, on_trackbar_activity)
        cv2.createTrackbar('HMax', 'SelectHSV', 0, 180, on_trackbar_activity)
        cv2.createTrackbar('SMin', 'SelectHSV', 0, 255, on_trackbar_activity)
        cv2.createTrackbar('SMax', 'SelectHSV', 0, 255, on_trackbar_activity)
        cv2.createTrackbar('VMin', 'SelectHSV', 0, 255, on_trackbar_activity)
        cv2.createTrackbar('VMax', 'SelectHSV', 0, 255, on_trackbar_activity)

        # creating trackbars to get values for BGR
        cv2.createTrackbar('BGRBMin', 'SelectBGR', 0, 255, on_trackbar_activity)
        cv2.createTrackbar('BGRBMax', 'SelectBGR', 0, 255, on_trackbar_activity)
        cv2.createTrackbar('BGRGMin', 'SelectBGR', 0, 255, on_trackbar_activity)
        cv2.createTrackbar('BGRGMax', 'SelectBGR', 0, 255, on_trackbar_activity)
        cv2.createTrackbar('BGRRMin', 'SelectBGR', 0, 255, on_trackbar_activity)
        cv2.createTrackbar('BGRRMax', 'SelectBGR', 0, 255, on_trackbar_activity)

        # creating trackbars to get values for LAB
        cv2.createTrackbar('LABLMin', 'SelectLAB', 0, 255, on_trackbar_activity)
        cv2.createTrackbar('LABLMax', 'SelectLAB', 0, 255, on_trackbar_activity)
        cv2.createTrackbar('LABAMin', 'SelectLAB', 0, 255, on_trackbar_activity)
        cv2.createTrackbar('LABAMax', 'SelectLAB', 0, 255, on_trackbar_activity)
        cv2.createTrackbar('LABBMin', 'SelectLAB', 0, 255, on_trackbar_activity)
        cv2.createTrackbar('LABBMax', 'SelectLAB', 0, 255, on_trackbar_activity)

        # show all images initially
        cv2.imshow('SelectHSV', original)
        cv2.imshow('SelectYCB', original)
        cv2.imshow('SelectLAB', original)
        cv2.imshow('SelectBGR', original)
        i = 0
        while (1):

            cv2.imshow('P-> Previous, N-> Next', original)
            k = cv2.waitKey(1) & 0xFF

            # check next image in folder
            if k == ord('n'):
                i += 1
                original = cv2.imread(files[i % len(files)])
                original = cv2.resize(original, (rsize, rsize))
                show = True

            # check previous image in folder
            elif k == ord('p'):
                i -= 1
                original = cv2.imread(files[i % len(files)])
                original = cv2.resize(original, (rsize, rsize))
                show = True
            # Close all windows when 'esc' key is pressed
            elif k == 27:
                break

            if show:  # If there is any event on the trackbar
                show = False

                # Get values from the BGR trackbar
                BMin = cv2.getTrackbarPos('BGRBMin', 'SelectBGR')
                GMin = cv2.getTrackbarPos('BGRGMin', 'SelectBGR')
                RMin = cv2.getTrackbarPos('BGRRMin', 'SelectBGR')
                BMax = cv2.getTrackbarPos('BGRBMax', 'SelectBGR')
                GMax = cv2.getTrackbarPos('BGRGMax', 'SelectBGR')
                RMax = cv2.getTrackbarPos('BGRRMax', 'SelectBGR')
                minBGR = np.array([BMin, GMin, RMin])
                maxBGR = np.array([BMax, GMax, RMax])

                # Get values from the HSV trackbar
                HMin = cv2.getTrackbarPos('HMin', 'SelectHSV')
                SMin = cv2.getTrackbarPos('SMin', 'SelectHSV')
                VMin = cv2.getTrackbarPos('VMin', 'SelectHSV')
                HMax = cv2.getTrackbarPos('HMax', 'SelectHSV')
                SMax = cv2.getTrackbarPos('SMax', 'SelectHSV')
                VMax = cv2.getTrackbarPos('VMax', 'SelectHSV')
                minHSV = np.array([HMin, SMin, VMin])
                maxHSV = np.array([HMax, SMax, VMax])

                # Get values from the LAB trackbar
                LMin = cv2.getTrackbarPos('LABLMin', 'SelectLAB')
                AMin = cv2.getTrackbarPos('LABAMin', 'SelectLAB')
                BMin = cv2.getTrackbarPos('LABBMin', 'SelectLAB')
                LMax = cv2.getTrackbarPos('LABLMax', 'SelectLAB')
                AMax = cv2.getTrackbarPos('LABAMax', 'SelectLAB')
                BMax = cv2.getTrackbarPos('LABBMax', 'SelectLAB')
                minLAB = np.array([LMin, AMin, BMin])
                maxLAB = np.array([LMax, AMax, BMax])

                # Get values from the YCrCb trackbar
                YMin = cv2.getTrackbarPos('YMin', 'SelectYCB')
                CrMin = cv2.getTrackbarPos('CrMin', 'SelectYCB')
                CbMin = cv2.getTrackbarPos('CbMin', 'SelectYCB')
                YMax = cv2.getTrackbarPos('YMax', 'SelectYCB')
                CrMax = cv2.getTrackbarPos('CrMax', 'SelectYCB')
                CbMax = cv2.getTrackbarPos('CbMax', 'SelectYCB')
                minYCB = np.array([YMin, CrMin, CbMin])
                maxYCB = np.array([YMax, CrMax, CbMax])

                # Convert the BGR image to other color spaces
                imageBGR = np.copy(original)
                imageHSV = cv2.cvtColor(original, cv2.COLOR_BGR2HSV)
                imageYCB = cv2.cvtColor(original, cv2.COLOR_BGR2YCrCb)
                imageLAB = cv2.cvtColor(original, cv2.COLOR_BGR2LAB)

                # Create the mask using the min and max values obtained from trackbar and apply bitwise and operation to get the results
                maskBGR = cv2.inRange(imageBGR, minBGR, maxBGR)
                resultBGR = cv2.bitwise_and(original, original, mask=maskBGR)

                maskHSV = cv2.inRange(imageHSV, minHSV, maxHSV)
                resultHSV = cv2.bitwise_and(original, original, mask=maskHSV)

                maskYCB = cv2.inRange(imageYCB, minYCB, maxYCB)
                resultYCB = cv2.bitwise_and(original, original, mask=maskYCB)

                maskLAB = cv2.inRange(imageLAB, minLAB, maxLAB)
                resultLAB = cv2.bitwise_and(original, original, mask=maskLAB)

                # Show the results
                cv2.imshow('SelectBGR', resultBGR)
                cv2.imshow('SelectYCB', resultYCB)
                cv2.imshow('SelectLAB', resultLAB)
                cv2.imshow('SelectHSV', resultHSV)

        cv2.destroyAllWindows()
