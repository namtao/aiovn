import easyocr

reader = easyocr.Reader(['vi', 'en'])
print(reader.readtext(r'C:\Users\Nam\Downloads\image00002.jpg', detail = 0, paragraph=True))