import logging
import os
import time
from pathlib import Path

import PyPDF2
from halo import Halo
from watchdog.events import LoggingEventHandler
from watchdog.observers import Observer

from modules.decor import get_files


@Halo()
def analysis_in_folder(folder_path: str):
    dict_extension = {}
    total_pdf_pages = 0
    output = ""

    @get_files
    def inner(root, file):
        # os.system( 'cls' )
        # terminal.write(f'\r{os.path.join(root, file)}')
        # terminal.flush()

        nonlocal total_pdf_pages

        # thống kê số file của từng loại file
        if os.path.splitext(file)[1] in dict_extension.keys():
            dict_extension[os.path.splitext(file)[1]] += 1
        else:
            dict_extension[os.path.splitext(file)[1]] = 1

        # đếm trang pdf
        if ".pdf" in os.path.splitext(file)[1]:
            readpdf = PyPDF2.PdfReader(
                open(os.path.join(root, file), "rb"), strict=False
            )
            total_pdf_pages += len(readpdf.pages)

    # không cần gán tham số fileFomat vào wapper bởi đã có giá trị mặc định
    inner(folder_path)

    number_of_files = sum(len(files) for _, _, files in os.walk(folder_path))
    number_of_folders = sum(len(dirs) for _, dirs, _ in os.walk(folder_path))

    output += f"{'Số thư mục':<20}\t{number_of_folders:>10,}\n"
    output += f"{'Số tệp':<20}\t{number_of_files:>10,}\n"

    for key, value in dict_extension.items():
        output += f"Số file {key: <12}\t{value: >10,}\n"

    output += f"\n\n{'Số trang PDF':<20}\t{total_pdf_pages: >10,}\n"
    output += f"{'Tổng số trang pdf':<20} \t{total_pdf_pages:>9,}"

    return output


def traces_of_changes(folder_path):
    logging.basicConfig(
        level=logging.INFO,
        format="%(asctime)s - %(message)s",
        datefmt="%Y-%m-%d %H:%M:%S",
    )
    event_handler = LoggingEventHandler()
    observer = Observer()
    observer.schedule(event_handler, folder_path, recursive=True)
    observer.start()
    try:
        while True:
            time.sleep(1)
    except KeyboardInterrupt:
        observer.stop()
    observer.join()


def check_file_name():
    while True:
        print("*** Công cụ kiểm tra đặt tên files ***")
        print("")
        folderJpgPath = input("Nhập đường dẫn thư mục cần kiểm tra: ")
        print("")

        # folderJpgPath = r'C:\Users\ADDJ\Downloads\test'

        # print('\nSai tên thư mục hoặc tên files: ')

        for root, dirs, files in os.walk(folderJpgPath):
            for file in files:
                head, tail = os.path.split(Path(os.path.join(root, file)))

                hss = tail.split(".")[-3]
                hs = tail.split(".")[-4]
                nam = tail.split(".")[-5]
                ma = tail[0:13]

                filePath = os.path.join(root, file)

                f_ma = root.split("\\")[-4]
                f_nam = root.split("\\")[-3]
                f_hs = root.split("\\")[-2]
                f_hss = root.split("\\")[-1]

                if f_ma != ma or f_nam != nam or f_hss != hss or f_hs != hs:
                    print(os.path.join(root, file))

        input("\nOK!Gẹt Gô!\n")
        os.system("cls")
