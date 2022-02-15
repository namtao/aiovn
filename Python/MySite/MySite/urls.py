"""MySite URL Configuration

The `urlpatterns` list routes URLs to views. For more information please see:
    https://docs.djangoproject.com/en/3.2/topics/http/urls/
Examples:
Function views
    1. Add an import:  from my_app import views
    2. Add a URL to urlpatterns:  path('', views.home, name='home')
Class-based views
    1. Add an import:  from other_app.views import Home
    2. Add a URL to urlpatterns:  path('', Home.as_view(), name='home')
Including another URLconf
    1. Import the include() function: from django.urls import include, path
    2. Add a URL to urlpatterns:  path('blog/', include('blog.urls'))
"""

"""
    khi bắt đầu chạy server, django sẽ đọc các url trong file <project>/urls.py,
"""

from django.contrib import admin
from django.urls import path, re_path
from django.urls import include
from django.urls import path, include, re_path

urlpatterns = [
    path('admin/', admin.site.urls),
    re_path(r'^admin/', admin.site.urls),
    re_path(r'^tutorial/', include('tutorial.urls')), # đường dẫn bao gồm tên webapp
    re_path(r'^$', include('tutorial.urls')), # đường dẫn trắng
]