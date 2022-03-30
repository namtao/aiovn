# Các câu lệnh quan trọng

find . -name "*.pyc" -exec rm -f {} \;

python -m venv Website-Django
Website-Django\Scripts\activate
pip install --upgrade pip setuptools wheel

python -m pip freeze > requirements.txt
python -m pip install -r requirements.txt
pyuic5 -x gui/demo.ui -o gui/demo.py
django-admin startproject mysite
python manage.py startapp <Tên APP>
python manage.py migrate
python manage.py runserver
python manage.py makemigrations
python manage.py migrate
python manage.py createsuperuser
python manage.py syncdb
python manage.py collectstatic
