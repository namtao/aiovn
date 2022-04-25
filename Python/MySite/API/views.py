from django.shortcuts import render
from rest_framework.decorators import api_view
from rest_framework.response import Response
from .models import *
from .serializers import NguoidungSerilizer
from django.http import HttpResponse, HttpResponseRedirect, JsonResponse
# Create your views here.


@api_view(['GET'])
def get_all_user(request):
    if request.method == 'GET':
        nguoi_dung = Nguoidung.objects.all()
        serializer = NguoidungSerilizer(nguoi_dung, many=True)
        return JsonResponse(serializer.data, safe=False, json_dumps_params={'ensure_ascii': False})
    return Response({'details':'Method Not Allowed'}, safe=False, status=405)
