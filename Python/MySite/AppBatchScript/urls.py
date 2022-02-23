from django.urls import re_path
from django.urls import path, include, re_path

from . import views


urlpatterns = [
    re_path(r'$', views.index, name='batch'),
    re_path(r'^autocommit', views.autocommit, name='autocommit'),
]
