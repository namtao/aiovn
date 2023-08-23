import datetime
import glob
import io
import os
import pathlib
import tkinter
from sys import stdout as terminal
from tkinter import filedialog

import pandas as pd
import pikepdf
import PyPDF2
from halo import Halo
from PyPDF2 import PdfMerger, PdfReader, PdfWriter
from textual import on
from textual.app import App, ComposeResult
from textual.containers import VerticalScroll
from textual.widgets import Footer, Header, Input, Select, RichLog

from modules.convert import jpg_to_pdf, pdf_to_jpg
from modules.decor import get_files
from modules.explorer import analysis_in_folder

output = ""
historyPath = "/"


options = {
    0: "Phân tích thư mục",
    1: "Trang PDF theo hồ sơ",
    2: "PDF => JPG (300 DPI)",
    3: "JPG => PDF (300 DPI)",
    4: "Kiểm tra file 0KB và thumbs",
    # 5: "Thao tác với database"
}


def init():
    global output
    output = ""


# check file modified
@get_files
def check_file_modified(root, file):
    # global countModifier
    # countModifier = 0
    date_modifier = os.path.getmtime(os.path.join(root, file))
    date_create = os.path.getctime(os.path.join(root, file))
    getDate = datetime.datetime.now().strftime("%d/%m/%Y")
    # if ('2023' in datetime.date.fromtimestamp(max(date_modifier, date_create)).strftime("%d/%m/%Y")):
    # print(os.path.join(root, file))

    print(
        os.path.join(root, file)
        + " "
        + datetime.datetime.fromtimestamp(date_modifier).strftime("%d/%m/%Y %H:%M:%S")
    )


def brower_folder(name_windows="Chọn đường dẫn"):
    global historyPath

    root = tkinter.Tk()
    root.withdraw()  # use to hide tkinter window
    currdir = os.getcwd()
    tempdir = filedialog.askdirectory(
        parent=root, initialdir=historyPath, title=name_windows
    )
    if len(tempdir) > 0:
        historyPath = tempdir
        return tempdir
    root.quit()


@Halo()
def count_pdf(folderPath: str):
    global output
    """Thống kê trang pdf theo hồ sơ

    Args:
        folderPath (str): _description_
        text_log (TextLog): _description_

    Returns:
        _type_: _description_
    """

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
            if i in dict1:
                dict1[i] = dict1[i] + dict2[i]
            else:
                dict1[i] = dict2[i]
        return dict1

    for root, dirs, files in os.walk(folderPath):
        for file in files:
            try:
                if file.endswith(".pdf"):
                    # head, tail = (os.path.split(Path(os.path.join(root, file))))
                    madinhdanh = file[:13]
                    stt = file.split(".")[-2]
                    hososo = file.split(".")[-3]
                    nam = file.split(".")[-4]
                    hopso = file.split(".")[-5]
                    muclucso = file.split(".")[-6]
                    phong = file.split(".")[-7]

                    readpdf = PyPDF2.PdfReader(
                        open(os.path.join(root, file), "rb"), strict=False
                    )

                    key = f"{madinhdanh}.{phong}.{muclucso}.{hopso}.{nam}.{hososo}"
                    value = len(readpdf.pages)

                    new_dic = {key: [1, value]}

                    # a = dic[key][1]
                    if key in dict.keys():
                        dict[key] = [dict[key][0] + 1, dict[key][1] + value]
                    else:
                        dict[key] = new_dic[key]

                    # dict = merge_dict(dict, {key:value})
            except Exception as e:
                # print(file)
                output += file

    for key, value in dict.items():
        output += f"\n{key:<35} :\t{value[0]:>5} file \t{value[1]:>5} trang"


# edit metadata pdf file
def edit_metadata_pdf(root, file):
    try:
        pdf = pikepdf.open(os.path.join(root, file))
        with pdf.open_metadata() as meta:
            # meta['dc:title'] = ""
            print(meta["dc:title"])
    except Exception as e:
        print(str(e))


# split pdf file by size
def spit_and_merge_pdf(pathPdfInput, bytes=10485760):
    if os.path.getsize(pathPdfInput) >= 10485760:
        inputpdf = PdfReader(pathPdfInput, "rb")
        fileName = pathlib.Path(pathPdfInput).stem
        parentPath = pathlib.Path(pathPdfInput).parent.absolute()

        sum = 0
        pdfs = []

        for i in range(len(inputpdf.pages)):
            output = PdfWriter()
            output.addPage(inputpdf.getPage(i))
            with open("%s.%s.pdf" % (fileName, i), "wb") as outputStream:
                output.write(outputStream)
                pdfs.append("%s.%s.pdf" % (fileName, i))
                outputStream.close()

        merger = PdfMerger()
        index = 0
        for page in pdfs:
            # get size file
            sum += os.path.getsize(page)
            # nếu dung lượng các trang chưa quá 10MB thì vẫn thêm vào sau
            if sum < bytes:
                merger.append(page)

            else:
                if page == pdfs[-1]:
                    merger.append(page)
                merger.write(r"%s\%s.%s.pdf" % (parentPath, fileName, index + 1))
                with open(r"split.txt", "a", encoding="utf-8") as fp:
                    fp.write(r"%s\%s.%s.pdf" % (parentPath, fileName, index + 1) + "\n")
                merger = PdfMerger()
                merger.append(page)
                index += 1
                sum = os.path.getsize(page)

        try:
            listPdf = glob.glob("*pdf")
            for page in listPdf:
                os.remove(page)
                # page.unlink()
        except:
            pass


@Halo()
def check_file_error(folder_path):
    result = ""
    for root, dirs, files in os.walk(folder_path):
        for file in files:
            if os.path.getsize(os.path.join(root, file)) == 0 or "Thumbs.db" in file:
                result += f"{os.path.join(root, file)}\n"

    return result


class MainApp(App[str]):
    CSS_PATH = "tools.css"

    BINDINGS = [
        ("f1", "dir1", "Folder 1"),
        ("f2", "dir2", "Folder 2"),
        ("f3", "dir3", "Folder 3"),
        ("f5", "execute", "Execute"),
        # ('E', 'brower', 'Brower'),
        ("f10", "export", "Export"),
        ("del", "clear", "Clear"),
        ("q", "quit", "Quit"),
    ]

    def compose(self) -> ComposeResult:
        self.title = "Công cụ tổng hợp"

        LINES = """I must not fear.
            Fear is the mind-killer.
            Fear is the little-death that brings total obliteration.
            I will face my fear.
            I will permit it to pass over me and through me.""".splitlines()

        # LETO = """
        # # Duke Leto I Atreides

        # Head of House Atreides.
        # """

        # JESSICA = """
        # # Lady Jessica

        # Bene Gesserit and concubine of Leto, and mother of Paul and Alia.
        # """

        # PAUL = """
        # # Paul Atreides

        # Son of Let
        # o and Jessica.
        # """
        yield Header()

        # with TabbedContent(initial="jessica"):
        #     with TabPane("Leto", id="leto"):
        #         yield Markdown(LETO)
        #     with TabPane("Jessica", id="jessica"):
        #         yield Markdown(JESSICA)
        #     with TabPane("Paul", id="paul"):
        #         yield Markdown(PAUL)

        yield Select(
            ((str(value), str(key)) for key, value in options.items()),
            prompt="Chọn chức năng",
            id="focus_me",
        )

        with VerticalScroll(id="input-option"):
            yield Input(
                placeholder="Input (Nhấn F1 để chọn đường dẫn)",
                id="path_1",
                classes="box",
            )
            yield Input(
                placeholder="Input (Nhấn F2 để chọn đường dẫn)",
                id="path_2",
                classes="box",
            )
            yield Input(
                placeholder="Output (Nhấn F3 để chọn đường dẫn)",
                id="path_3",
                classes="box",
            )

            with VerticalScroll():
                with VerticalScroll():
                    # with RadioSet(id="focus_me"):
                    #     for key, value in options.items():
                    #         yield RadioButton(str(value), value=True)

                    yield RichLog(wrap=True, id="log")
        # yield LoadingIndicator()

        yield Footer()

    # def on_button_pressed(self, event: Button.Pressed) -> None:
    # self.exit(event.button.id)

    # self.query_one(Input).value = brower_folder()
    # pass
    # count_pdf(brower_folder())

    @on(Select.Changed, "#focus_me")
    def select_changed(self, event: Select.Changed) -> None:
        global index
        try:
            index = int(event.value)
        except:
            pass

        if index != 0:
            # self.query_one('#path_2', Input).disabled = False
            self.query_one("#path_2", Input).display = False

        if index == 2 or index == 3:
            self.query_one("#path_3", Input).display = True

        match index:
            case 2:
                self.query_one("#path_3", Input).display = True

            case 3:
                self.query_one("#path_3", Input).display = True

            case _:
                self.query_one("#path_3", Input).display = False
                self.query_one("#path_2", Input).display = False

    def on_mount(self) -> None:
        # self.query_one("#focus_me").focus()
        # self.query_one("#focus_me").border_title = "Chức năng"
        # self.query_one("#focus_me").border_subtitle = "xD"
        # self.query_one("#focus_me").styles.border_title_align = "center"

        # self.query_one("#path_1", Input).display = False
        self.query_one("#path_2", Input).display = False
        self.query_one("#path_3", Input).display = False
        # self.query_one(LoadingIndicator).display = False

    def on_ready(self) -> None:
        self.query_one(RichLog)

    def action_execute(self) -> None:
        if self.query_one("#path_1").value == "":
            self.query_one(RichLog).write("Chọn đường dẫn rồi thực hiện")
        else:
            init()

            self.query_one(RichLog).clear()

            global output

            match index:
                case 0:
                    # Phân tích thư mục
                    output = analysis_in_folder(self.query_one("#path_1").value)

                case 1:
                    # Đếm trang PDF theo hồ sơ
                    count_pdf(self.query_one("#path_1").value)

                case 2:
                    # PDF => JPG
                    pdf_to_jpg(
                        self.query_one("#path_1").value, self.query_one("#path_3").value
                    )

                case 3:
                    # JPG => PDF (trong cùng 1 folder sẽ ghép thành 1 tệp pdf và giữ nguyên cấp độ thư mục)
                    jpg_to_pdf(
                        self.query_one("#path_1").value, self.query_one("#path_3").value
                    )

                case 4:
                    output = check_file_error(self.query_one("#path_1").value)

                case _:
                    pass

            # os.system( 'cls' )
            terminal.write("\nHoàn thành!!!")

        self.query_one(RichLog).write(output.replace("\t", ""))
        # self.query_one(TextLog).write(output)

    def action_clear(self) -> None:
        self.query_one("#path_1").value = ""
        self.query_one(RichLog).clear()

    def action_dir1(self) -> None:
        self.query_one("#path_1").value = brower_folder("Input 1")

    def action_dir2(self) -> None:
        if self.query_one("#path_2", Input).display == True:
            self.query_one("#path_2").value = brower_folder("Input 2")

    def action_dir3(self) -> None:
        if self.query_one("#path_3", Input).display == True:
            self.query_one("#path_3").value = brower_folder("Output")

    def action_export(self) -> None:
        # with open('export.txt', 'w+', encoding='utf-8') as f:
        #     f.write(output)

        # os.system("attrib +h export.txt")

        # print to excel
        global output
        output = io.StringIO(output)
        df = pd.read_csv(output, sep="\t", header=None, index_col=0)
        df.to_excel("export.xlsx", header=None)

        os.system("export.xlsx")
        os.system("attrib +h export.xlsx")

    # def on_key(self, event: events.Key) -> None:
    #     if(event.name == 'enter'):
    #         self.query_one('#path_1').value = brower_folder('Input')
    #         self.query_one('#path_2').value = brower_folder('Output')


if __name__ == "__main__":
    try:
        if datetime.datetime.now().year == 2023:
            MainApp().run()
        else:
            input("Bye!!!\n")
    except Exception as e:
        print(e)
    finally:
        if os.path.exists("export.xlsx"):
            os.remove("export.xlsx")
        if os.path.exists("export.txt"):
            os.remove("export.txt")
