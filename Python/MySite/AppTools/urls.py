from django.urls import path, include, re_path

from . import views


urlpatterns = [
    path('', views.index, name='rename'),
    re_path(r'^getfiles', views.getfiles, name='getfiles'),
]
