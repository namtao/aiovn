from django.urls import re_path
from django.urls import path, include, re_path
 
from . import views 
 
urlpatterns = [
     # re_path(r'^$', views.index, name='index'),
     re_path(r'^index', views.index, name='index'),
     re_path(r'^article/(\d+)/', views.viewArticle, name = 'article'), # Sending Parameters to Views
     re_path(r'^hello/', views.hello, name='hello'),
]