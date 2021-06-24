from django.contrib import admin
from django.urls import path
from . import views
from django.conf.urls import url

urlpatterns = [
    path('', views.home, name="home"),
    path('details', views.details, name="details"),
    path('truyenhay', views.truyenhay, name="truyenhay"),
    path('python', views.python, name="python"),
    path('book', views.book, name="book"),
    path('bookdetails', views.bookdetails, name="bookdetails"),
    path('read', views.read, name="read"),
    path('finance/personalfinance', views.personalfinance, name="personalfinance"),
    
]
