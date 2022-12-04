import cv2
from matplotlib import pyplot as plt

# https://stackoverflow.com/questions/63933790/robust-algorithm-to-detect-uneven-illumination-in-images-detection-only-needed

def get_image_stats(img_path, lbl):
    img = cv2.imread(img_path)
    gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
    blurred = cv2.GaussianBlur(gray, (25, 25), 0)
    no_text = gray * ((gray/blurred)>0.99)                     # select background only
    no_text[no_text<10] = no_text[no_text>20].mean()           # convert black pixels to mean value
    no_bright = no_text.copy()
    no_bright[no_bright>220] = no_bright[no_bright<220].mean() # disregard bright pixels

    print(lbl)
    std = no_bright.std()
    print('STD:', std)
    bright = (no_text>220).sum()
    print('Brigth pixels:', bright)
    plt.figure()
    plt.hist(no_text.reshape(-1,1), 25)
    plt.title(lbl)

    if std>25:
        print("!!! Detected uneven illumination")
    if no_text.mean()<200 and bright>8000:
        print("!!! Detected glare")
        
get_image_stats('a.jpg', 'a')