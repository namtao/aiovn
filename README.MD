# Tài liệu

- [Tài liệu](#tài-liệu)
  - [Python](#python)
    - [\*args](#args)
    - [\*\*kwargs](#kwargs)
    - [nonlocal](#nonlocal)
    - [global](#global)
    - [yield](#yield)
    - [list\[\]](#list)
    - [tuple()](#tuple)
    - [set{}](#set)
    - [dictionary {key:value}](#dictionary-keyvalue)
    - [enumerate](#enumerate)
    - [zip](#zip)
    - [Packing and Unpacking Arguments](#packing-and-unpacking-arguments)
    - [Type conversion](#type-conversion)
    - [Closure python](#closure-python)
    - [Decorator](#decorator)
    - [Class object](#class-object)
    - [Property](#property)
  - [Markdown](#markdown)
  - [Command](#command)
  - [PEP-8](#pep-8)
  - [Note](#note)
  - [Sql Server](#sql-server)
  - [MongoDB](#mongodb)
  - [Numpy](#numpy)
  - [Pandas](#pandas)
    - [Lý thuyết cơ bản](#lý-thuyết-cơ-bản)
    - [df.describe()](#dfdescribe)
    - [iloc\[hàng, cột\]](#ilochàng-cột)
    - [loc(hàng, cột)](#lochàng-cột)
    - [ix](#ix)
    - [reduce](#reduce)
    - [map](#map)
    - [flatten](#flatten)
    - [deepdiff](#deepdiff)
  - [XlsxWriter](#xlsxwriter)
    - [overlap](#overlap)
  - [PyautoGui](#pyautogui)
  - [Sources](#sources)
  - [How to?](#how-to)

## Python

### *args

Thay thế nhiều tham số trong hàm\
args là một tuple chứ không phải list\
*args sẽ phải đặt ở cuối cùng nếu không sẽ gặp lỗi ngay

### **kwargs

**kwargs cũng tương tự như như *args, tuy nhiên, nó không dùng cho các tham số thông thường truyền vào lần lượt, mà nó được sử dụng cho các tham số\
**kwargs trong hàm sẽ nhận giá trị là một dict với key là các tham số được truyền kèm giá trị tương ứng của chúng

### nonlocal

Được sử dụng trong nested functions, được khai báo trong hàm cha, khi gọi đến ở hàm con thì thêm từ khóa nonlocal

### global

Muốn thay đổi biến toàn cục trong hàm thì ta phải thêm từ khóa global vào biến\
Thay đổi phần tử hoặc giá trị của biến thì mới cần sử dụng global

### yield

Sẽ đình chỉ việc thực thi của hàm và trả về một giá trị cho caller nhưng vẫn giữ lại đầy đủ trạng thái của hàm để ngay sau khi thực thi xong câu lệnh yield, hàm vẫn có thể quay lại thực thi tiếp được tại câu lệnh tiếp theo nằm ngay sau câu lệnh yield vừa chạy xong. Điều này cho phép một hàm có thể trả về một loạt các giá trị theo thời gian, thay vì phải tính toán cùng một lúc ra nhiều outputs rồi đưa tất cả chúng vào trong một list (danh sách) và trả về duy nhất list đó.

### list[]

append: list append list =list 2 chiều (datatframe)\
extend: list extend list =list (nối 2 list thành 1 list)\
count: cho biết số lượng của phần tử trong list

### tuple()

tốc độ nhanh hơn list nhưng các đối tượng không thay đổi đc\
truy cập vào phần tử giống như chuỗi và list

### set{}

set có thể thay đổi nhưng các phần tử không được trùng nhau\
set không được sắp xếp nên không thể truy cập bằng chỉ mục

### dictionary {key:value}

### enumerate

Được sử dụng để lặp qua các danh sách và bao gồm chỉ mục (key, value)\
Có thể điều chỉnh số bắt đầu của index\
Nhanh hơn so với lặp thông thường

### zip

Kết hợp 2 danh sách và in các giá trị theo thứ tự của n, vòng lặp kết thúc khi 1 vòng lặp lặp qua 1 danh sách

### Packing and Unpacking Arguments

Ta có thể gán các giá trị của list hay tuple vào tham số của hàm bằng cách sử dụng * đối với list hay tuple hay ** đối với dictionary trước tham số của hàm

- Lưu ý độ dài của list hay tuple phải có cùng số lượng với số tham số của hàm.

```:
def fun(a, b, c, d):
  print(a, b, c, d)

my_list = [1, 2, 3, 4]

fun(*my_list)
```

### Type conversion

ord() : chuyển đổi ký tự thành số nguyên.\
hex() : chuyển đổi số nguyên thành chuỗi thập phân.\
oct() : chuyển đổi số nguyên thành chuỗi bát phân.\
tuple(): chuyển đổi thành tuple.\
set(): chuyển đổi thành set.\
list(): chuyển đổi thành list.\
dict() : chuyển đổi thành dictionary.\
str() : chuyển đổi thành string.\
complex(real,imag) : chuyển đổi thành số phức.\
chr(number): chuyển đổi số thành ký tự ASCII tương ứng.

```:
s = '4'

# printing character converting to integer
c = ord(s)
print ("After converting character to integer : ",end="")
print (c)

# printing integer converting to hexadecimal string
c = hex(56)
print ("After converting 56 to hexadecimal string : ",end="")
print (c)

# printing integer converting to octal string
c = oct(56)
print ("After converting 56 to octal string : ",end="")
print (c)


# Convert ASCII value to characters
a = chr(76)
b = chr(77)
  
print(a)
print(b)
```

```:
After converting character to integer : 52
After converting 56 to hexadecimal string : 0x38
After converting 56 to octal string : 0o70

L
M
```

### Closure python

[Lý thuyết](https://quantrimang.com/hoc/cach-su-dung-closure-trong-python-165316)

Là phương pháp ràng buộc dữ liệu với 1 hàm mà không cần thực sự truyền chúng làm tham số cho hàm\
Closure là một đối tượng hàm\
Closure được tạo hàm lồng nhau\
Sử dụng lớp lồng để không cần sử dụng biến toàn cục\
Giúp che giấu thông tin của hàm

Trong trường hợp có ít phương thức thì ta có thể dùng closure nhưng nếu nhiều thì nên sử dụng lập trình hướng đối tượng OOP

Ví dụ:

```:
def make_multiplier_of(n):
    def multiplier(x):
        return x * n
    return multiplier

# He so 3
times3 = make_multiplier_of(3)

# He so 5
times5 = make_multiplier_of(5)

# Output: 27
print(times3(9))

# Output: 15
print(times5(3))

# Output: 30
print(times5(times3(2)))
```

### Decorator

[Lý thuyết](https://quantrimang.com/hoc/decorator-trong-python-165379)\
[Tìm hiểu thêm](https://viblo.asia/p/cung-tim-hieu-python-decorators-bJzKmzJEZ9N)

Hàm có thể được truyền như tham số trong hàm khác\
Decorator là công cụ rất mạnh mẽ và hữu ích trong Python vì nó cho phép các lập trình viên sửa đổi hành vi của hàm hoặc lớp. Decorator cho phép chúng ta nhận tham số đầu vào là một hàm khác và mở rộng tính năng cho hàm đó mà không thay đổi nội dung của nó.\
Decorator là những functions thay đổi tính năng của một function, method hay class một cách dynamic, mà không phải sử dụng subclass\
Decorator là một hàm có thể nhận các hàm khác, cho phép bạn chạy một số đoạn code trước hoặc sau hàm chính mà không thay đổi kết quả.\
Tham số của hàm sẽ được truyền vào hàm decorator\
Tham số hàm decorator luôn là 1 hàm

```:
def smart_divide(func):
   def inner(a,b):
      print("I am going to divide",a,"and",b)
      if b == 0:
         print("Whoops! cannot divide")
         return

      return func(a,b)
   return inner

@smart_divide
def divide(a,b):
    return a/b
```

```:
>>> divide(2,5)
I am going to divide 2 and 5
0.4
>>> divide(2,0)
I am going to divide 2 and 0
Whoops! cannot divide
```

### Class object

[Lý thuyết](https://viblo.asia/p/class-va-object-trong-python-4P856dvLZY3)

Khi gọi phương thức có 1 tham số thì ta không cần gán tham số đầu tiên, bởi vì, bất cứ khi nào, object gọi các phương thức, object sẽ tự pass qua parameter đầu tiên

### Property

[Lý thuyết](https://quantrimang.com/hoc/property-trong-python-165430)

Được sử dụng trong getter setter trong class

## Markdown

Sử dụng > để viết trích dẫn\
Sử dụng ``` để tạo khối văn bản nhiều dòng\
Sử dụng \\ để xuống dòng văn bản

## Command

Xóa file cache dùng trong git

```:
find . -name "*.pyc" -exec rm -f {} \;
```

Các lệnh Python

```:
pip install --upgrade pip setuptools wheel
py -m ensurepip --upgrade
pip install --upgrade pip
auto-py-to-exe
```

Môi trường ảo trong Python

```:
pip install virtualenv
virtualenv --version
virtualenv my_project_env
python -m venv .venv
env\Scripts\activate

python -m pip freeze --all requirements.txt
python -m pip install -r requirements.txt
```

Django

```:
python manage.py inspectdb \models.py
django-admin startproject mysite
python manage.py startapp <Tên APPpython manage.py runserver
python manage.py makemigrations
python manage.py migrate
python manage.py createsuperuser
python manage.py syncdb
python manage.py collectstatic
```

Khác

```:
pipreqs --force --encoding utf-8 "./"
jupyter notebook
isort .
```

## PEP-8

1. Đặt tên cho các module/package: viết thường tất cả các ký tự, nếu có nhiều từ trong tên, dùng ký tự _ để nối giữa các từ
2. Đặt tên cho các biến dữ liệu (variable/name), function: viết thường tất cả các ký tự, nếu có nhiều từ trong tên, dùng ký tự _ để nối giữa các từ
3. Đặt tên cho class và attribute/function trong class: theo định dạng CapitalizedWord (hoặc CamelCase)
4. Quy ước đặt tên với attribute/function trong class: Mặc định, các attribute/function của một lớp được khai báo là public, quy tắc đặt tên như đặt tên biến (lower_case_with_underscore), Nếu khai báo protected , đặt 01 ký tự underscore ở đầu tiên, Nếu khai báo private, 2 dấu underscore liên tiếp ở đầu tiên

## Note

1. Dùng đệ quy để cải thiên tốc độ
2. Sử dụng np.array thay cho list

## Sql Server

1. Trigger

## MongoDB

- Tương quan giữa mongodb với sqlserver

| Operation | In SQL | In MongoDB |
| --------- | :----: | ---------: |
| Create    | Insert |     Insert |
| Read      | Select |       Find |
| Update    | Update |     Update |
| Delete    | Delete |     Remove |
| Table     | Table  | Collection |
| Row       |  Row   |   Document |

- Đặc điểm

  - Tốc độ nhanh
  - JSON object

## Numpy

[Lý thuyết](https://www.geeksforgeeks.org/numpy-tutorial/)

Numpy so với List

- Tốn ít bộ nhớ hơn
- Nhanh hơn
- Tiện lợi hơn (thuận tiện trong việc thực hiện các phép toán đối với danh sách)

Numpy có thể được tạo thành từ list, tuple, set, dict

## Pandas

[Lý thuyết](https://viblo.asia/p/pandas-python-tutorial-XL6lAxaDZek)

### Lý thuyết cơ bản

Series giống như mảng, list; dataframe được tạo từ nhiều series

### df.describe()

Hiển thị thống kê nhanh về dữ liệu (nhỏ nhất, lớn nhất, trung bình,...)

### iloc[hàng, cột]

Lựa chọn dữ liệu theo số thứ tự của hàng và cột, chỉ số hàng

### loc(hàng, cột)

Giống iloc nhưng có thể truyền tham số là nhãn nhưng k nhận chỉ số hàng làm tham số, có thể truyền vào 1 boolean =lọc dữ liệu

### ix

Là sự kết hợp giữa iloc và loc

### reduce

### map

### flatten

### deepdiff

## XlsxWriter

### overlap

Các định dạng không ghi đè lên nhau, phải Lý thuyết riêng

## PyautoGui

[Lý thuyết](https://pywinauto.readthedocs.io/en/latest/)

## Sources

[Deep learning](https://phamdinhkhanh.github.io/deepai-book/intro.html)\
[Data Science](https://phamdinhkhanh.github.io/2019/01/07/Ky_thuat_feature_engineering.html)

## How to?

<https://stackoverflow.com/questions/11621768/how-can-i-make-git-accept-a-self-signed-certificate>\
[Download FB video](https://snapsave.app/vn)
