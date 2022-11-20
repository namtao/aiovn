# Documents

## Important Commands

<!-- xóa file cache -->
find . -name "*.pyc" -exec rm -f {} \;

pip install --upgrade pip setuptools wheel
py -m ensurepip --upgrade
pip install --upgrade pip

<!-- py to exe -->
auto-py-to-exe

<!-- tạo môi trường ảo -->
pip install virtualenv
virtualenv --version
virtualenv my_project_env

<!-- tạo môi trường ảo pypy -->
virtualenv -p C:\Projects\Python\library\pypy3.9-v7.3.9-win64\pypy.exe pypy

python -m venv env
env\Scripts\activate

<!-- cài đặt thư viện -->
python -m pip freeze --all > requirements.txt
python -m pip install -r requirements.txt

pipreqs --force --encoding utf-8 "./"

jupyter notebook

<!-- sắp xếp lại thư viên import -->
isort .

<!-- Django -->
python manage.py inspectdb > models.py
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

## Note

1. Dùng đệ quy để cải thiên tốc độ

## Sql Server

1. Trigger
