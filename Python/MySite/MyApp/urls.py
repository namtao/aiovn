from django.contrib import admin
from django.urls import path
from . import views

urlpatterns = [
    path('', views.index, name="index"),
    #path('administrator', views.administrator, name="administrator"),
]
