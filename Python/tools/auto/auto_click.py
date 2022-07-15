import pyautogui
import time


# print ('di chuyển chuột đến vị trí cần click')
# time.sleep(5)

# x, y = pyautogui.position()

# i, j = pyautogui.position()

# for _ in range(10):
#     pyautogui.click(x, y)
#     time.sleep(1)

# pyautogui.press('a')

for _ in range(40):
    # Point(x=1809, y=131): tải xuống   
    # Point(x=1594, y=635): save 
    time.sleep(1)
    pyautogui.click(1809, 131)
    time.sleep(1)
    pyautogui.click(1594, 635)
    pyautogui.hotkey('ctrl', 'w')
    # print (pyautogui.position())
    
# pyautogui.hotkey('ctrl', 'c')