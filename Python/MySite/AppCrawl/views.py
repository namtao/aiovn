from django.shortcuts import render

# Create your views here.
def index(request):
    return render(request, 'crawl.html')


def crawl(request):
    return render(request, 'crawl.html')
