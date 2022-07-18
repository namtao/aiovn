# giống nạp chồng
# Với class method thì cả class sẽ được truyền thành tham số thứ nhất (cls) của phương thức này

from datetime import date

# random Nhanvien
class Nhanvien:
    def __init__(self, ten, tuoi):
        self.ten = ten
        self.tuoi = tuoi

    @classmethod
    def fromBirthYear(cls, ten, birthYear):
        return cls(ten, date.today().year - birthYear)

    def ketqua(self):
        print("Tuổi của " + self.ten + " là: " + str(self.tuoi))

nhanvien = Nhanvien('Alice', 23)
nhanvien.ketqua()

nhanvien1 = Nhanvien.fromBirthYear('Simon', 1990)
nhanvien1.ketqua()