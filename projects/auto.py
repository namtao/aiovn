import random
import time

import pyautogui
import pyperclip


def spam():
    print("Tool Spam 1.0")
    msg = input("Nhập nội dung cần spam: ").split(" || ")
    n = int(input("Nhập số lần Spam: "))
    m = float(input("Nhập thời gian delay: "))

    print("Chuẩn bị")
    # Đếm ngược 5 giây
    for i in range(5, 0, -1):
        print(i, end="...", flush="True")
        time.sleep(1)
    print("Bắt đầu")

    # SPAM
    for i in range(n):
        pyperclip.copy(random.choice(msg))
        pyautogui.hotkey("ctrl", "v")
        pyautogui.press("enter")
        time.sleep(m)  # Delay


def auto_write():
    # while True:
    # sohieu = input('Số hiệu: ')
    # name = input('Tên: ')
    # date = input('Ngày: ')

    # # 432,250
    # # 83, 730

    # # điền số hiệu
    # pyperclip.copy(sohieu + ' /STP-LLTP')
    # pyautogui.click(432,250)
    # pyautogui.hotkey("ctrl", "v")

    # # điền trích yếu
    # pyperclip.copy('PHIẾU LÝ LỊCH TƯ PHÁP CỦA ' + name)
    # pyautogui.press('tab')
    # pyautogui.hotkey("ctrl", "v")

    # # điền ngày tháng có hiệu lực
    # pyperclip.copy(date)
    # pyautogui.press('tab')
    # pyautogui.hotkey("ctrl", "v")

    # # điền ngày tháng ban hành
    # pyperclip.copy(date)
    # pyautogui.press('tab')
    # pyautogui.press('tab')
    # pyautogui.hotkey("ctrl", "v")

    # # điền tên tổ chức
    # pyperclip.copy(name)
    # pyautogui.press('tab')
    # pyautogui.press('tab')
    # pyautogui.hotkey("ctrl", "v")

    # pyautogui.click(83, 730)
    # pyautogui.hotkey("alt", "tab")
    # print('------------------------------')

    # crawl data website => chuyển thành mp3

    # pyautogui.moveTo(83, 730)

    pyautogui.hotkey("alt", "tab")
    for i in range(318):
        pyautogui.press("F2")
        pyautogui.press("right")
        pyautogui.write("(1)")
        pyautogui.press("tab")


def auto_click():
    # print ('di chuyển chuột đến vị trí cần click')
    # time.sleep(5)

    # x, y = pyautogui.position()

    # i, j = pyautogui.position()

    # for _ in range(10):
    #     pyautogui.click(x, y)
    #     time.sleep(1)

    # pyautogui.press('a')

    for _ in range(10000000):
        # Point(x=1809, y=131): tải xuống
        # Point(x=1594, y=635): save
        # time.sleep(1)
        pyautogui.click(1291, 595)
        # time.sleep(1)
        # pyautogui.click(1594, 635)
        # pyautogui.hotkey('ctrl', 'w')

        # pyautogui.hotkey('ctrl', 'c')
        print(pyautogui.position())
