from django.urls import re_path
from django.urls import path, include, re_path

from . import views


urlpatterns = [
    re_path(r'$', views.index, name='index'),
    re_path(r'^batch', views.batch_index, name='batch'),
    re_path(r'^autocommit', views.autocommit, name='autocommit'),
    re_path(r'^py2exe', views.py2exe, name='py2exe'),
    re_path(r'^crawl', views.crawl_index, name='crawl'),
    re_path(r'^crawl_data', views.crawl_data, name='crawl_data'),
    re_path(r'^datatranfer', views.datatranfer_index, name='datatranfer'),
    re_path(r'^python', views.python_index, name='python'),
    re_path(r'^rename', views.rename_index, name='rename'),
    re_path(r'^change_name', views.rename, name='change_name'),
    re_path(r'^hello', views.hello, name='hello'),
]