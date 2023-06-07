import os
import tkinter
from tkinter import filedialog

from textual import events
from textual.app import App, ComposeResult
from textual.widgets import (Button, Checkbox, Footer, Header, Input, Label,
                             TextLog)


def brower_folder():
    root = tkinter.Tk()
    root.withdraw() #use to hide tkinter window
    currdir = os.getcwd()
    tempdir = filedialog.askdirectory(parent=root, initialdir=currdir, title='Please select a directory')
    if len(tempdir) > 0:
        return tempdir
    root.quit()
    
class MainApp(App[str]):
    CSS_PATH = "style.css"
    
    
    def compose(self) -> ComposeResult:
        # yield Header()
        # yield Label("Chương trình thống kê số trang pdf theo hồ sơ")
        # yield Label("Chương trình thống kê số trang pdf theo hồ sơ")
        # yield Button("No", id="no", variant="error")
        yield Input(placeholder="Nhập hoặc nhấn 'ENTER' để chọn đường dẫn", id='txtPath', disabled=False, classes="box") 
        # yield Button("Chọn đường dẫn", id="btnBrower", classes="box")
        yield Button("Thực hiện", id="btnExecute", classes="box")
        # yield Checkbox("A", id="chbA", classes="box")
        
        yield TextLog()
        
        
        # self.title = 'anc'
        # yield Footer()
        
    def on_button_pressed(self, event: Button.Pressed) -> None:
        # self.exit(event.button.id)
        
        # self.query_one(Input).value = brower_folder()
        pass
        # self.query_one(TextLog).write(event)
    
    def on_key(self, event: events.Key) -> None:
        # self.query_one(TextLog).write(event)
        if(event.name == 'enter'):
            # self.query_one(TextLog).write(event)    
            self.query_one(Input).value = brower_folder()
        


if __name__ == "__main__":
    app = MainApp()
    reply = app.run()
    # print(reply)

