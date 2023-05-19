from pypdf import PdfReader, PdfWriter

reader = PdfReader(r"C:\Users\Nam\Downloads\hss 104\a.pdf")

writer = PdfWriter()
writer.append_pages_from_reader(reader)
writer.encrypt("password")

with open(r"C:\Users\Nam\Downloads\hss 104\b.pdf", "wb") as out_file:
    writer.write(out_file)