from django.contrib import admin
from django.urls import path
from . import views

urlpatterns = [
    path('', views.home, name="home"),
    #path('administrator', views.administrator, name="administrator"),
    path('details', views.details, name="details"),
]
