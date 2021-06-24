from django import urls
from django.contrib import admin
from django.urls import path, include

urlpatterns = [
    path('', include('MyApp.urls')), # cấu hình multi-level path
    path('admin/', admin.site.urls),
]
