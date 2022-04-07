from rest_framework import serializers

from .models import Nguoidung

class NguoidungSerilizer(serializers.ModelSerializer):
    class Meta:
        model = Nguoidung
        fields = ['id','tendangnhap','matkhau','trangthai','ngaytao','ngaycapnhat','tendaydu','quyen']