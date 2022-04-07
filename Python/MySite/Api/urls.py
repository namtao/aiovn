from django.urls import re_path
from django.urls import path, include, re_path


from django.urls import path, include
from django.contrib.auth.models import User
from rest_framework import routers, serializers, viewsets

from . import views


urlpatterns = [
    re_path(r'^users$', views.get_all_user, name='api'),
]