from django.shortcuts import render

from django.http import HttpResponse

from django.template import loader

import datetime


def index(request):
    return render(request, 'batch.html')
