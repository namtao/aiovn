from django.shortcuts import render

from django.http import HttpResponse
 
def index(request):
    response = HttpResponse()
    response.write("<h1>Welcome</h1>")
    response.write("This is the polls app")
    return response
