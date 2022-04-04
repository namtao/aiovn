from django.urls import re_path
from django.urls import path, include, re_path

from . import views

urlpatterns = [
    re_path('^api/', include('rest_framework.urls')),
    re_path(r'$', views.index, name='index'),
    re_path(r'^batch$', views.batch_index, name='batch'),
    re_path(r'^auto-commit$', views.autocommit, name='auto-commit'),
    re_path(r'^py2exe$', views.py2exe, name='py2exe'),
    re_path(r'^crawl$', views.crawl_index, name='crawl'),
    re_path(r'^beautiful-soup', views.beautiful_soup, name='beautiful-soup'),
    re_path(r'^data-tranfer$', views.datatranfer_index, name='data-tranfer'),
    re_path(r'^python$', views.python_index, name='python'),
    re_path(r'^rename$', views.rename_index, name='rename'),
    re_path(r'^change-name$', views.change_name, name='change-name'),
    re_path(r'^hello$', views.hello, name='hello'),
]