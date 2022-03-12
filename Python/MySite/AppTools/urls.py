from django.urls import path, include, re_path

from . import views


urlpatterns = [
    path('', views.index, name='rename'),
    re_path(r'^change_name', views.rename, name='change_name'),
    re_path(r'^hello', views.hello, name='hello'),
]
