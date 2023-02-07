import os

import inquirer
import numpy as np

from projects.analysis_in_folder import analysis_in_folder
from projects.check_modifier_file import check_modifier_file
from projects.decor import loading
from projects.hotich import create_struct
from projects.pdfx import edit_metadata_pdf
from projects.x2x import jpg2pdf, pdf2jpg

chucnang = {"Phân tích thư mục": "Y",
            "Phân tích file txt": "N",
            "Tìm kiếm tệp tin": "N",
            "Kiểm tra trùng tên": "N",
            "Thời gian tệp tin thay đổi": "N",
            "Tạo cấu trúc theo tên tệp tin": "Y",
            "Sửa đổi metadate pdf": "N",
            "JPG => PDF": "Y",
            "PDF => JPG": "Y",

            "Cấu hình": "Y"}

countModifier = 0


def config():
    global chucnang

    questions = [
        inquirer.Checkbox(
            "config",
            message="Chọn các chức năng?",
            choices={k: v for (k, v) in chucnang.items()}.keys(),
            default={k: v for (k, v) in chucnang.items() if 'Y' in v}.keys(),
        ),
    ]

    # class WorkplaceFriendlyTheme(Default):
    #     """Custom theme replacing X with Y and o with N"""

    # def __init__(self):
    #     super().__init__()
    #     self.Checkbox.selected_icon = "Y"
    #     self.Checkbox.unselected_icon = "N"

    # answers = inquirer.prompt(questions, theme=WorkplaceFriendlyTheme())
    answers = inquirer.prompt(questions)

    keychucnang = chucnang.keys()
    for item in keychucnang:
        if (item in answers['config']):
            chucnang[item] = 'Y'
        else:
            chucnang[item] = 'N'

    chucnang['Cấu hình'] = 'Y'

    # with open(config_file, mode='w', encoding="utf8") as f:
    #     f.write(str(chucnang))


if __name__ == '__main__':

    # if not (
    #         os.path.exists(config_file)):
    #     with open(config_file, mode='a', encoding="utf8") as f:
    #         f.write(str(chucnang))

    # else:
    #     if os.path.getsize(config_file) == 0:
    #         os.remove(config_file)

    #         with open(config_file, mode='w', encoding="utf8") as f:
    #             f.write(str(chucnang))
    #     else:
    #         with open(config_file, mode='r', encoding="utf8") as f:
    #             chucnang = json.loads(f.readlines()[0].replace('\'', '\"'))

    while True:
        print("-----Công cụ làm việc với Files-----")
        print()
        arr = np.array([])

        try:
            questions = [
                inquirer.List(
                    "choise", message="Chức năng cần sử dụng?",
                    # lọc những chức năng cho phép
                    choices={k: v for (k, v) in chucnang.items() if 'Y' in v}.keys())]

            answers = inquirer.prompt(questions)

            match answers['choise']:
                case 'Phân tích thư mục':
                    folderPath1 = input('Nhập đường dẫn cần phân tích: ')

                    analysis_in_folder()

                case 'Thời gian tệp tin thay đổi':
                    check_modifier_file(input('Nhập đường dẫn cần kiểm tra'))
                    print(countModifier)

                case 'Tạo cấu trúc theo tên tệp tin':
                    pathTarget = input('Nhập thư mục đầu ra: ')
                    create_struct(input('Nhập thư mục đầu vào: '))

                case 'Sửa đổi metadate pdf':
                    edit_metadata_pdf(input('Nhập đường dẫn cần sửa dổi: '))

                case 'JPG => PDF':
                    dir_img = input('Nhập đường dẫn thư mục jpg: ')
                    dir_pdf = input('Nhập đường dẫn thư mục pdf: ')

                    for root, dirs, files in os.walk(dir_img):
                        for file in files:
                            try:
                                jpg2pdf(os.path.join(root, file),
                                        os.path.join(dir_pdf, os.path.splitext(file)[0] + '.pdf'))
                            except Exception as e:
                                pass

                case 'PDF => JPG':
                    pdfPath = input('Nhập đường dẫn thư mục pdf: ')
                    jpgPath = input('Nhập đường dẫn thư mục jpg: ')

                    @loading
                    def run():
                        pdf2jpg(pdfPath, jpgPath)

                    run()

                case 'Cấu hình':
                    config()

                case _:
                    pass

        except Exception as e:
            print(str(e))
            input()
        finally:
            yn = str(input('\rBạn có muốn tiếp tục? (Y/N?): ')).upper()
            if (yn == 'Y'):
                os.system('cls')
                continue
            else:
                print("Hẹn gặp lại!!!\n")
                break

# split_pdf(r'E:\tay ninh\ubnd 2014 chua nen', r'E:\tay ninh\ubnd 2014 chua nen')

# split_merge_pdf_ocr(r'E:\tay ninh\da ocr\tay ninh\ubnd 2014 chua nen\tach')
