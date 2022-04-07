# Tài liệu

## Các câu lệnh quan trọng

find . -name "*.pyc" -exec rm -f {} \;

python -m venv Website-Django
Website-Django\Scripts\activate
pip install --upgrade pip setuptools wheel

python manage.py inspectdb > models.py

python -m pip freeze > requirements.txt
python -m pip install -r requirements.txt
pyuic5 -x gui/demo.ui -o gui/demo.py
django-admin startproject mysite
python manage.py startapp <Tên APP>
python manage.py runserver
python manage.py makemigrations
python manage.py migrate
python manage.py createsuperuser
python manage.py syncdb
python manage.py collectstatic

## PEP-8

1. Đặt tên cho các module/package: viết thường tất cả các ký tự, nếu có nhiều từ trong tên, dùng ký tự _ để nối giữa các từ
2. Đặt tên cho các biến dữ liệu (variable/name), function: viết thường tất cả các ký tự, nếu có nhiều từ trong tên, dùng ký tự _ để nối giữa các từ
3. Đặt tên cho class và attribute/function trong class: theo định dạng CapitalizedWord (hoặc CamelCase)
4. Quy ước đặt tên với attribute/function trong class: Mặc định, các attribute/function của một lớp được khai báo là public, quy tắc đặt tên như đặt tên biến (lower_case_with_underscore), Nếu khai báo protected , đặt 01 ký tự underscore ở đầu tiên, Nếu khai báo private, 2 dấu underscore liên tiếp ở đầu tiên
