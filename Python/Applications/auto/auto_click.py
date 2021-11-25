import pyautogui
import time


print ('di chuyển chuột đến vị trí cần click')
time.sleep(5)

x, y = pyautogui.position()

# for _ in range(10):
#     pyautogui.click(x, y)
#     time.sleep(1)

pyautogui.press('a')