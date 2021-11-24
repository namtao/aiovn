import cv2

# 0: read camera in laptop
# 1: read in webcam
cap = cv2.VideoCapture(0)
# width
cap.set(3, 640)
# height
cap.set(4, 480)
# Brightness
cap.set(10, 100)

while True:
    success, img = cap.read()
    cv2.imshow("Video", img)
    if cv2.waitKey(1) & 0xFF == ord('q'):
        break
