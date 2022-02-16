from django.shortcuts import render

from django.http import HttpResponse

from django.template import loader

import datetime


def index(request):
    return render(request, 'index.html')


def hello(request):
    text = """<h1>welcome to my app !</h1>"""
    return HttpResponse(text)


def viewArticle(request, articleId):
    text = "Displaying article Number : %s" % articleId
    return HttpResponse(text)


def hello(request):
    today = datetime.datetime.now().date()
    daysOfWeek = ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun']
    return render(request, "hello.html", {"today": today, "days_of_week" : daysOfWeek})
