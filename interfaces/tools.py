import csv
import itertools
import os
import re
import tkinter
from functools import wraps
from pathlib import Path
from sys import stdout as terminal
from threading import Thread
from time import sleep
from tkinter import filedialog

import img2pdf
import openpyxl
import PyPDF2
from pdf2image import convert_from_path
from PIL import Image
from textual.app import App, ComposeResult
from textual.containers import VerticalScroll
from textual.widgets import (Footer, Header, Input, RadioButton, RadioSet,
                             TextLog)

index = 0
dictEx = {}
totalPdfPages = 0
output = ''
historyPath = 'C:/'


options = {
            0:'Phân tích thư mục',
            1:'Trang PDF theo hồ sơ',
            2:'PDF => JPG (300 DPI)',
            3:'JPG => PDF (300 DPI)',
            4:'Kiểm tra file 0KB'
          }

def brower_folder(name_windows = 'Chọn đường dẫn'):
    global historyPath
    
    root = tkinter.Tk()
    root.withdraw() #use to hide tkinter window
    currdir = os.getcwd()
    tempdir = filedialog.askdirectory(parent=root, initialdir=historyPath, title=name_windows)
    if len(tempdir) > 0:
        historyPath = tempdir
        return tempdir
    root.quit()


def txt_to_excel(input_file, output_file):
    wb = openpyxl.Workbook()
    ws = wb.worksheets[0]

    with open(input_file, 'r', encoding='utf-8') as data:
        reader = csv.reader(data, delimiter='\t')
        for row in reader:
            row = list(map(lambda x: x.replace(',', '.').replace(':', ''), row))
            ws.append(row)

    wb.save(output_file)
    # wb.close()


# loading process
def loading(function):
    @wraps(function)
    def wrapper(*args, **kwargs):
        done = False

        def clear():
            return os.system('cls')

        def animate():
            # for c in itertools.cycle(['⠷', '⠯', '⠟', '⠻', '⠽', '⠾']):
            for c in itertools.cycle(['.', '..', '...', '....', '.....']):
                if done:
                    break
                terminal.write('\rĐợi chờ là hạnh phúc ' + c + ' ')
                terminal.flush()
                sleep(0.1)
            terminal.write('Đã hoàn thành!                        ')
            terminal.flush()

        t = Thread(target=animate)
        t.start()

        # Chay lenh tai day
        function(*args, **kwargs)

        # clear()
        done = True

    return wrapper


# decor get_files
def get_files(function):
    @wraps(function)
    def wrapper(folderPath, fileFormat='', *args, **kwargs):
        for root, dirs, files in os.walk(folderPath):
            for file in files:
                # $ regex kết thúc là ký tự trc $
                pattern = re.compile(".*"+fileFormat+"$")
                if pattern.match(file):
                    function(root, file, *args, **kwargs)
    return wrapper


def init():
    global index
    global dictEx
    global totalPdfPages
    global output
    
    # index = 0
    dictEx = {}
    output = ''
    totalPdfPages = 0


@loading
def count_pdf(folderPath: str):
    global output
    '''Thống kê trang pdf theo hồ sơ

    Args:
        folderPath (str): _description_
        text_log (TextLog): _description_

    Returns:
        _type_: _description_
    '''
    
    totalPdfPages = 0
    index = 0
    # folderPath = r'D:\0.OCR,Nen 100KB\Trung tâm lưu trữ lịch sử tỉnh Tây Ninh\1 Đoàn Đại biểu Quốc hội tỉnh Tây Ninh\01 - da kt ok\Hop 1'
    # 0003.01.18.108.1

    # [Mã định danh].[Phông số].[Mục lục số].[Hộp số].[Năm hình thành].[Hồ sơ số].[STT]
    # 000.01.37.H08.01.01.01.1976.01.1
    dict = {}

    # print()

    def merge_dict(dict1, dict2):
        for i in dict2.keys():
            if (i in dict1):
                dict1[i] = dict1[i] + dict2[i]
            else:
                dict1[i] = dict2[i]
        return dict1

    for root, dirs, files in os.walk(folderPath):
        for file in files:
            try:
                if file.endswith('.pdf'):
                    # head, tail = (os.path.split(Path(os.path.join(root, file))))
                    madinhdanh = file[:13]
                    stt = file.split('.')[-2]
                    hososo = file.split('.')[-3]
                    nam = file.split('.')[-4]
                    hopso = file.split('.')[-5]
                    muclucso = file.split('.')[-6]
                    phong = file.split('.')[-7]

                    readpdf = PyPDF2.PdfFileReader(
                        open(os.path.join(root, file), 'rb'), strict=False)

                    key = f'{madinhdanh}.{phong}.{muclucso}.{hopso}.{nam}.{hososo}'
                    value = readpdf.numPages

                    new_dic = {key: [1, value]}

                    # a = dic[key][1]
                    if (key in dict.keys()):
                        dict[key] = [dict[key][0] + 1, dict[key][1] + value]
                    else:
                        dict[key] = new_dic[key]

                    # dict = merge_dict(dict, {key:value})
            except Exception as e:
                # print(file)
                output += file

    for key, value in dict.items():
        output += (f'\n{key:<35} : {value[0]:>5} file, {value[1]:>5} trang')


@loading
def analysis_in_folder(folderPath: str):

    # countFile = len(next(os.walk(folderPath))[1])
    # countFolder = len(next(os.walk(folderPath))[2])
    # output += (f'\rTổng: {countFile:,} tệp và {countFolder:,} thư mục\n')
    global output

    @get_files
    def inner(root, file):

        global totalPdfPages
        global dictEx
        # os.system( 'cls' )
        # terminal.write(f'\r{os.path.join(root, file)}')
        # terminal.flush()
        

        # thống kê số file của từng loại file
        if (os.path.splitext(file)[1] in dictEx.keys()):
            dictEx[os.path.splitext(file)[1]] += 1
        else:
            dictEx[os.path.splitext(file)[1]] = 1

        # đếm trang pdf
        if ('.pdf' in os.path.splitext(file)[1]):
            readpdf = PyPDF2.PdfFileReader(open(os.path.join(root, file), 'rb'), strict=False)
            totalPdfPages += readpdf.numPages

    # không cần gán tham số fileFomat vào wapper bởi đã có giá trị mặc định
    inner(folderPath)

    for key, value in dictEx.items():
        output += (f'Số file {key: <8}:\t{value: >8,}\n')

    output += (f'\nSố trang PDF:\t{totalPdfPages: >12,}')
    
    # return output


@loading
def pdf_to_jpg(pdf_folder_path, jpg_folder_path):
    # pytesseract.pytesseract.tesseract_cmd = r"C:\Program Files\Tesseract-OCR\tesseract.exe"
    Image.MAX_IMAGE_PIXELS = 1000000000000

    for root, dirs, files in os.walk(pdf_folder_path):
        for file in files:

            pattern = re.compile(".*pdf$")
            if pattern.match(file):
                pages = convert_from_path(
                    os.path.join(root, file), 300, poppler_path=r'poppler\Library\bin')
                image_counter = 1
                for page in pages:
                    filename = os.path.splitext(file)[0] + '#' + str(image_counter).zfill(5)+".jpg"
                    
                    output_path = os.path.join(jpg_folder_path, filename)
                    if(not os.path.exists(output_path)):
                        page.save(output_path, 'JPEG')
                    image_counter = image_counter + 1

               
# @loading                 
# def jpg_to_pdf(img_path, pdf_path):

#     # opening image
#     image = Image.open(img_path)

#     # converting into chunks using img2pdf
#     pdf_bytes = img2pdf.convert(image.filename)

#     # opening or creating pdf file
#     file = open(pdf_path, "wb")

#     # writing pdf files with chunks
#     file.write(pdf_bytes)

#     # closing image file
#     image.close()

#     # closing pdf file
#     file.close()

@loading
def jpg_to_pdf(jpg_folder_path, pdf_folder_path):

    def merge_jpg_to_pdf(lstImage, pdfPath):
        images = [
            Image.open(f)
            for f in lstImage

        ]

        images[0].save(
            pdfPath, "PDF", resolution=300.0, save_all=True, append_images=images[1:]
        )
 
 
    for root, dirs, files in os.walk(jpg_folder_path):
        lstJpg = []
        if(len(files) > 0):
            # lstJpg = [os.path.join(root, file) for file in files if(re.compile("*jpg$").match(file))]
            for file in files:
                # $ regex kết thúc là ký tự trc $
                if re.compile(".*jpg$").match(file):
                    lstJpg.append(os.path.join(root, file))
            # parent = root.split('\\')[-1]
            # folderPath = os.path.join(pdf_folder_path)
            folderPath = os.path.join(pdf_folder_path, root.split('/')[-2], root.split('/')[-1])
            if(not os.path.exists(folderPath)):
                Path(folderPath).mkdir(parents=True, exist_ok=True)    
            pdfPath = os.path.join(pdf_folder_path, folderPath,  'ghep.pdf')
                
            if (len(lstJpg)>0):
                merge_jpg_to_pdf(lstJpg, pdfPath)

@loading        
def check_file_0KB(folder_path):
    global output
    for root, dirs, files in os.walk(folder_path):
        for file in files:
            if (os.path.getsize(os.path.join(root, file)) == 0):
                output += f'{os.path.join(root, file)}\n'
                
class MainApp(App[str]):
    CSS_PATH = 'styles.css'

    BINDINGS = [
        ('f1', 'dir1', 'Folder 1'),
        ('f2', 'dir2', 'Folder 2'),
        ('f3', 'dir3', 'Folder 3'),
        ('f5', 'execute', 'Execute'),
        # ('E', 'brower', 'Brower'),
        ("f10", "export", "Export"),
        ('del', 'clear', 'Clear'),
        ('q', 'quit', 'Quit'),
    ]

    def compose(self) -> ComposeResult:
        self.title = 'Công cụ tổng hợp'

        yield Header()
        with VerticalScroll(id='input-option'):
            yield Input(placeholder='Input (Nhấn F1 để chọn đường dẫn)', id='path_1', classes='box')
            yield Input(placeholder='Input (Nhấn F2 để chọn đường dẫn)', id='path_2', classes='box')
            yield Input(placeholder='Output (Nhấn F3 để chọn đường dẫn)', id='path_3', classes='box')

            with VerticalScroll():
                with VerticalScroll():
                    with RadioSet(id='focus_me'):
                        for key, value in options.items():
                            yield RadioButton(str(value), value=True)

                    yield TextLog(wrap=True, id='log')
        
        

        yield Footer()

    # def on_button_pressed(self, event: Button.Pressed) -> None:
    # self.exit(event.button.id)

    # self.query_one(Input).value = brower_folder()
    # pass
    # count_pdf(brower_folder())

    def on_mount(self) -> None:
        self.query_one('#focus_me').focus()
        self.query_one('#focus_me').border_title = 'Chức năng'
        self.query_one('#focus_me').border_subtitle = 'xD'
        self.query_one('#focus_me').styles.border_title_align = 'center'

        self.query_one('#path_2', Input).display = False
        self.query_one('#path_3', Input).display = False

    def on_radio_set_changed(self, event: RadioSet.Changed) -> None:
        # self.query_one('#pressed', Label).update(
        #     f'Pressed button label: {event.pressed.label}'
        # )
        # self.query_one('#index', Label).update(
        #     f'Pressed button index: {event.radio_set.pressed_index}'
        # )
        global index
        index = event.radio_set.pressed_index

        if (index != 0):
            # self.query_one('#path_2', Input).disabled = False
            self.query_one('#path_2', Input).display = False
            
        if(index == 2 or index ==3):
            self.query_one('#path_3', Input).display = True
            
        match index:
                
            case 2:
                self.query_one('#path_3', Input).display = True
                
            case 3:
                self.query_one('#path_3', Input).display = True


            case _:
                self.query_one('#path_3', Input).display = False
                self.query_one('#path_2', Input).display = False
                

    def on_ready(self) -> None:
        self.query_one(TextLog)

    def action_execute(self) -> None:
        if(self.query_one('#path_1').value == ''):
            self.query_one(TextLog).write("Chọn đường dẫn rồi thực hiện")
        else:
            init()
            self.query_one(TextLog).clear()
            
            match index:
                case 0:
                    # Phân tích thư mục
                    analysis_in_folder(self.query_one('#path_1').value)
                    
                case 1:
                    # Đếm trang PDF theo hồ sơ
                    count_pdf(self.query_one('#path_1').value)
                    
                case 2:
                    # PDF => JPG
                    pdf_to_jpg(self.query_one('#path_1').value, self.query_one('#path_3').value)
                    
                case 3:
                    # JPG => PDF (trong cùng 1 folder sẽ ghép thành 1 tệp pdf và giữ nguyên cấp độ thư mục)
                    jpg_to_pdf(self.query_one('#path_1').value, self.query_one('#path_3').value)
                    
                case 4:
                    check_file_0KB(self.query_one('#path_1').value)

                case _:
                    pass         
                                
            # os.system( 'cls' )
            # terminal.write("\n Click vào đây để tiếp tục!!!")
            
        self.query_one(TextLog).write(output.replace('\t', ''))            

    def action_clear(self) -> None:
        self.query_one('#path_1').value = ''
        self.query_one(TextLog).clear()

    def action_dir1(self) -> None:
        self.query_one('#path_1').value = brower_folder('Input 1')

    def action_dir2(self) -> None:
        if(self.query_one('#path_2', Input).display == True):
            self.query_one('#path_2').value = brower_folder('Input 2')
        
    def action_dir3(self) -> None:
        if(self.query_one('#path_3', Input).display == True):
            self.query_one('#path_3').value = brower_folder('Output')
            
    def action_export(self) -> None:
        with open('export.txt', 'w+', encoding='utf-8') as f:
            f.write(output)
            
        
        os.system("attrib +h export.txt")      
          
        txt_to_excel('export.txt', 'export.xlsx')
        os.system('export.xlsx')
        os.system("attrib +h export.xlsx")
        

    # def on_key(self, event: events.Key) -> None:
    #     if(event.name == 'enter'):
    #         self.query_one('#path_1').value = brower_folder('Input')
    #         self.query_one('#path_2').value = brower_folder('Output')
    

if __name__ == '__main__':
    try:
        MainApp().run()
    except Exception as e:
        print(e)
    finally:
        if(os.path.exists('export.xlsx')):
            os.remove('export.xlsx')
        if(os.path.exists('export.xlsx')):
            os.remove('export.txt')
