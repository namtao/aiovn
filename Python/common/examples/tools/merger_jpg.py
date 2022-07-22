import cv2
from cv2 import imshow
import numpy as np
import imgstitch

img = imgstitch.stitch_images_and_save(r'common\examples\tools', [r"C:\Projects\Python\common\examples\tools\1.jpg", r"C:\Projects\Python\common\examples\tools\2.jpg", r"C:\Projects\Python\common\examples\tools\3.jpg"], 1, r'common\examples\tools')
