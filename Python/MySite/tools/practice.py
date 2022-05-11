import cv2

img = cv2.imread(r'C:\Users\Administrator\Downloads\0001.jpg')

# Bilateral Blur
bilateral = cv2.bilateralFilter(img, 9, 75, 75)
cv2.imwrite('Bilateral.jpg', bilateral)
cv2.waitKey(0)
cv2.destroyAllWindows()