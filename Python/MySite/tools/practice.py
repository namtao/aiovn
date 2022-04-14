from skimage.filters import threshold_yen
from skimage.exposure import rescale_intensity
from skimage.io import imread, imsave
import cv2

img = imread(r'C:\Users\Administrator\Downloads\0001.jpg')

# Bilateral Blur
bilateral = cv2.bilateralFilter(img, 9, 75, 75)
cv2.imwrite('Bilateral.jpg', bilateral)
cv2.waitKey(0)
cv2.destroyAllWindows()