from django.shortcuts import render
from django.http import HttpResponse, HttpResponseRedirect
from django.template import loader
import datetime
import subprocess
from pathlib import Path
import os

BASE_DIR = Path(__file__).resolve().parent.parent

def index(request):
    return render(request, 'datatranfer.html')
    
