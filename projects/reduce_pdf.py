import os
import fitz  # PyMuPDF
from PIL import Image

def compress_image(image_path, target_size_kb):
    img = Image.open(image_path)
    
    # Chỉnh kích thước ảnh để đạt được kích thước mục tiêu
    while Image.Image.getsize(img)[0] * Image.Image.getsize(img)[1] > target_size_kb * 1024:
        img = img.resize((int(img.width * 0.9), int(img.height * 0.9)), Image.ANTIALIAS)

    # Lưu ảnh đã nén
    img.save(image_path, quality=85)  # quality có thể điều chỉnh tùy ý

def compress_pdf(input_pdf, output_pdf, target_size_kb):
    # Mở tệp PDF với PyMuPDF
    pdf_document = fitz.open(input_pdf)

    # Lặp qua từng trang PDF
    for page_number in range(pdf_document.page_count):
        page = pdf_document[page_number]

        # Lặp qua mỗi hình ảnh trên trang
        for img_index, img in enumerate(page.getImageList()):
            image_index = img[0]

            # Trích xuất hình ảnh từ trang
            base_image = pdf_document.extract_image(image_index)
            image_bytes = base_image["image"]

            # Lưu hình ảnh vào một tệp tạm thời
            temp_image_path = f"temp_image_{page_number}_{img_index}.png"
            with open(temp_image_path, "wb") as temp_image_file:
                temp_image_file.write(image_bytes)

            # Nén ảnh
            compress_image(temp_image_path, target_size_kb)

            # Chèn hình ảnh đã nén trở lại vào trang
            img_file = page.new_image(xref=image_index, base_image=temp_image_path)
            page.insert_image(img_file)

    # Lưu tệp PDF mới
    pdf_document.save(output_pdf)
    pdf_document.close()

    # Xóa các tệp ảnh tạm thời
    for page_number in range(pdf_document.page_count):
        for img_index in range(len(pdf_document[page_number].getImageList())):
            temp_image_path = f"temp_image_{page_number}_{img_index}.png"
            try:
                os.remove(temp_image_path)
            except FileNotFoundError:
                pass

if __name__ == "__main__":
    input_pdf_path = "input.pdf"  # Đặt tên tệp PDF đầu vào của bạn
    output_pdf_path = "output.pdf"  # Đặt tên tệp PDF đầu ra của bạn
    target_size_kb = 100  # Kích thước mục tiêu cho mỗi ảnh trong tệp PDF (KB)

    compress_pdf(input_pdf_path, output_pdf_path, target_size_kb)
