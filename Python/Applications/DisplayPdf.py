
# Importing tkinter to make gui in python
from tkinter import *
from tkinter.filedialog import askopenfile
  
# Importing tkPDFViewer to place pdf file in gui.
# In tkPDFViewer library there is
# an tkPDFViewer module. That I have imported as pdf
from tkPDFViewer import tkPDFViewer as pdf
from PIL import ImageTk, Image
import cv2
from pdf2image import convert_from_path
import os

# Initializing tk
root = Tk('')
root.title ('PDF Viewer')
root.iconbitmap(r'C:\Projects\Python\Applications\icon.ico')
root.filename = askopenfile(parent=root, mode="rb", title="Choose a file",filetypes=[("PDF Files"," *.pdf"), ("All Files"," *.*")])
root.configure(background='gray')

def printcoords(event):
    #outputting x and y coords to console
    print (event.x,event.y)
    
# load images
def loadImages(path):
    # creating a object 
    # image = Image.open(root.filename.name)
    image = Image.open(path)
    MAX_SIZE = (500, 500)

    # creat thumbnail file
    image.thumbnail(MAX_SIZE)

    # load an image
    myimage = ImageTk.PhotoImage((image))
    label = Label(root, image = myimage)
    label2 = Label(root, image = myimage)
    label.grid(column=1, row=0)
    label2.grid(column=2, row=10)
    # label.pack()
    root.bind("click", printcoords)
    root.mainloop()

# load pdf
def loadPdf():
    # Set the width and height of our root window.
    root.geometry("960x540")
    # root.attributes('-fullscreen',True)
    
    # creating object of ShowPdf from tkPDFViewer.
    v1 = pdf.ShowPdf()
    
    # Adding pdf location and width and height.
    v2 = v1.pdf_view(root, pdf_location = root.filename)
    
    # Placing Pdf in my gui.
    v2.pack()
    root.mainloop()

if root.filename.name.__contains__('.pdf'):
    pages = convert_from_path(root.filename.name, 300, poppler_path=r'C:\Projects\Python\Library\poppler\bin')
    for page in pages:
        page.save('out.jpg', 'JPEG')
        loadImages('out.jpg')
        os.remove('out.jpg')
        