# nhập xuất trong python
x = int(input("nhap: \n"))
X = int(input())
print (x/2)
print (X/2)
print(list(range(1, 10)))

# python phân biệt chữ hoa chữ thường
if x==3:
    print ("là số 3")

# xóa tham chiếu đến x
del x

# list trong python có  thể chưa nhiều kiểu dữ liệu
list = [ 'abcd', 786 , 2.23, 'john', 70.2 ]

# tuple gần giống như list nhưng không thể cập nhật
tuple = ( 'abcd', 786 , 2.23, 'john', 70.2  )

# dictionary chưa các giá trị key-value
dict = {'name': 'john','code':6734, 'dept': 'sales'}
print (dict.keys())
print (dict.values()) 

# iter() and next() được sử dụng để truy cập lần lượt giá trị của 1 danh sách
# sys.exit(): thoát chương trình
# try: except: finally
# yield: trả vể 1 generator
# raise: tạo ra 1 exception
# Traceback: trace exception
# underscore được sử dụng để ignoring specific values nếu specific values đó không được sử dụng
# __ thể hiện modifier trong python. _ClassName__method_name
# if __name__ == "__main__": kiểm tra xem module đó được nhập trực tiếp hay import
# hàm range() là [)
# ** tương đương pow