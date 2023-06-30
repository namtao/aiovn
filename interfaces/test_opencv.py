import cv2

# path 
path = r'C:\Users\ADDJ\Downloads\New folder\a.jpg'
   
# Reading an image in default mode
image = cv2.imread(path)
   
# Window name in which image is displayed
window_name = 'Image'
  
# Start coordinate, here (5, 5)
# represents the top left corner of rectangle
start_point = (1320, 190) # (x, y) góc trên cùng bên trái
  
# Ending coordinate, here (220, 220)
# represents the bottom right corner of rectangle
end_point = (1524, 196)
  
# Blue color in BGR
color = (0, 0, 255)
  
# Line thickness of 2 px
thickness = 2
  
# Using cv2.rectangle() method
# Draw a rectangle with blue line borders of thickness of 2 px
image = cv2.rectangle(image, start_point, end_point, color, thickness)
  
# Displaying the image 
cv2.imshow(window_name, cv2.resize(image, (610, 780))) 
cv2.waitKey(0)
