from PyPDF2 import PdfReader, PdfWriter

reader = PdfReader(r"D:\xD\build\a.pdf")
writer = PdfWriter()

for page in reader.pages:
    page.compress_content_streams()  # This is CPU intensive!
    writer.add_page(page)

with open("out.pdf", "wb") as f:
    writer.write(f)