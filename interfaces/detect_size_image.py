import os
import re

import PyPDF2
from PIL import Image
from textual import events
from textual.app import App, ComposeResult
from textual.containers import Container
from textual.widgets import Button, Footer, Header, Input, TextLog
from utils import brower_folder

A4_SIZE_PX = 8699840 # 2480 x 3508 pixels
A4_SIZE_MM = 62370 # 210mm x 297mm


def detect_size_jpg(img):
    # Disable PIL DecompositionBomb threshold for reading large images.
    pil_max_px = Image.MAX_IMAGE_PIXELS
    Image.MAX_IMAGE_PIXELS = None
    im = Image.open(img)
    Image.MAX_IMAGE_PIXELS = pil_max_px

    # print('{}'.format(im.size))
    print(img, (im.width*im.height)/A4_SIZE_PX)
    
    
def detect_size_pdf(img):
    pdf = PyPDF2.PdfFileReader(img,"rb")
    p = pdf.getPage(0)

    w_in_user_space_units = p.mediaBox.getWidth()
    h_in_user_space_units = p.mediaBox.getHeight()

    # 1 user space unit is 1/72 inch
    # 1/72 inch ~ 0.352 millimeters

    w = float(w_in_user_space_units) * 0.352
    h = float(h_in_user_space_units) * 0.352

    print(img , (w * h) / A4_SIZE_MM)
    

def detect(path):
    for root, dirs, files in os.walk(path):
        for file in files:
            if re.compile(".*pdf$").match(file):
                detect_size_pdf(os.path.join(root, file))
            elif re.compile(".*jpg$").match(file):
                detect_size_jpg(os.path.join(root, file))
    
class MainApp(App[str]):
    CSS_PATH = "styles.css"
    
    
    def compose(self) -> ComposeResult:
        yield Header()
        with Container(id="app-grid"):
            yield Input(placeholder="Nhập hoặc nhấn 'ENTER' để chọn đường dẫn", id='txtPath', disabled=False, classes="box") 
            # yield Button("Thực hiện", id="btnExecute", classes="box")
            
            yield TextLog()
        
        
        self.title = 'anc'
        yield Footer()
    
    def on_ready(self) -> None:
        self.query_one(TextLog)
        
    def on_button_pressed(self, event: Button.Pressed) -> None:
        pass
    
    def on_key(self, event: events.Key) -> None:
        if(event.name == 'enter'):
            self.query_one(Input).value = brower_folder()
            
        if(event.name == 'f5'):
            self.action_execute()
        


if __name__ == "__main__":
    app = MainApp()
    reply = app.run()

