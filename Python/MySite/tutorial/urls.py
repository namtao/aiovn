<<<<<<< HEAD
from django.urls import re_path
=======
from django.urls import path, include, re_path
>>>>>>> 47f6bea784ba0950a30b3b4b4dfe25d69882ffbc
 
from . import views 
 
urlpatterns = [ 
     re_path(r'^$', views.index, name='index'),
]