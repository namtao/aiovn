# Các mặt nạ như vậy có thể được sử dụng để thực hiện các phép toán trên mỗi pixel của hình ảnh để đạt được hiệu ứng mong muốn (như làm mờ hoặc làm sắc nét hình ảnh). Lý do cần làm mờ ảnh:

# – Làm giảm một số loại nhiễu nhất định trong hình ảnh. Vì lý do này, làm mờ thường được gọi là làm mịn.

# – Để xóa phông nền như thực hiện chế độ chụp chân dung (Portrait) ở trên máy ảnh của thiết bị di động.

import cv2
import numpy as np


# Blur images
def blurKernel():
    image = cv2.imread('OpenCV/Filter_conv_1.jpg')

    # Print error message if image is null
    if image is None:
        print('Could not read image')

    # Apply identity kernel
    kernel1 = np.array([[0, 0, 0],
                        [0, 1, 0],
                        [0, 0, 0]])

    identity = cv2.filter2D(src=image, ddepth=-1, kernel=kernel1)

    cv2.imshow('Original', image)
    cv2.imshow('Identity', identity)
        
    cv2.waitKey()
    cv2.imwrite('identity.jpg', identity)
    cv2.destroyAllWindows()

    # Apply blurring kernel
    kernel2 = np.ones((5, 5), np.float32) / 25
    img = cv2.filter2D(src=image, ddepth=-1, kernel=kernel2)

    cv2.imshow('Original', image)
    cv2.imshow('Kernel Blur', img)
        
    cv2.waitKey()
    cv2.imwrite('blur_kernel.jpg', img)
    cv2.destroyAllWindows()
    

# tăng sắc nét cho ảnh  
def filter2DImage():
    image = cv2.imread('OpenCV/image.jpg')
    """
    Apply identity kernel
    """
    kernel1 = np.array([[0, 0, 0],
                        [0, 1, 0],
                        [0, 0, 0]])
    # filter2D() function can be used to apply kernel to an image.
    # Where ddepth is the desired depth of final image. ddepth is -1 if...
    # ... depth is same as original or source image.
    identity = cv2.filter2D(src=image, ddepth=-1, kernel=kernel1)

    # We should get the same image
    cv2.imshow('Original', image)
    cv2.imshow('Identity', identity)

    cv2.waitKey()
    cv2.imwrite('identity.jpg', identity)
    cv2.destroyAllWindows()
    
