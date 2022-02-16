from django.shortcuts import render

from django.http import HttpResponse
	
from django.template import loader
 
def index(request):
    return render(request, 'index.html')

def hello(request):
    text = """<h1>welcome to my app !</h1>"""
    return HttpResponse(text)

def viewArticle(request, articleId):
    text = "Displaying article Number : %s"%articleId
    return HttpResponse(text)