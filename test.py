class MyClass: 
     "Đây là class thứ 3 được khởi tạo" 
     a = 10 
     def func(self): 
        print('Xin chào')

ob = MyClass()

# Output: <function MyClass.func at 0x000000000335B0D0>
print(MyClass.func)

# Output: <bound method MyClass.func of <__main__.MyClass object at 0x000000000332DEF0>>
print(ob.func)

# Gọi hàm func()
# Output: Xin chào
ob.func()