# thiết lập file lấy thư viện

python -m pip freeze > C:\Projects\Python\Applications\requirements.txt
python -m pip install -r requirements.txt
pyuic5 -x gui/demo.ui -o gui/demo.py
django-admin startproject mysite
python manage.py startapp <Tên APP>
python manage.py migrate
python manage.py runserver
