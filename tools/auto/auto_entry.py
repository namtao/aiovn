import pyautogui
import pyperclip
import time


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
    pyautogui.press('F2') 
    pyautogui.press('right') 
    pyautogui.write('(1)') 
    pyautogui.press('tab')