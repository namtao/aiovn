# Documents

- [Documents](#documents)
  - [Python](#python)
  - [Switch case](#switch-case)
  - [Union Operator](#union-operator)
  - [Markdown](#markdown)
  - [Command](#command)
  - [PEP-8](#pep-8)
  - [Note](#note)
  - [Sql Server](#sql-server)
  - [MongoDB](#mongodb)
  - [Numpy](#numpy)
  - [Pandas](#pandas)
  - [Dask](#dask)
  - [XlsxWriter](#xlsxwriter)
  - [PyAutoGui](#pyautogui)
  - [SQLAlchemy](#sqlalchemy)
  - [Rest API](#rest-api)
  - [JWT](#jwt)
  - [Mediapipe](#mediapipe)
  - [Docker](#docker)
  - [OCR](#ocr)
  - [TextToSpeech](#texttospeech)
  - [Nodejs](#nodejs)
  - [Dataset](#dataset)
  - [Machine Learning](#machine-learning)
  - [Data Science](#data-science)
  - [Sources](#sources)
  - [Knowledge](#knowledge)
  - [How to?](#how-to)
  - [Tricks](#tricks)

## Python

[Lý thuyết](https://www.geeksforgeeks.org/python-programming-language/?ref=ghm)

***\_\_all__*** dùng để định nghĩa các function public( có thể truy cập thì bên ngoài module) và ngược lại

***Protocol*** khi các đối tượng có cùng thuộc tính và cách tính của phương thức giống nhau ta có thể dùng Protocol

***async await*** là một chức năng thông thường với khả năng tạm dừng thực thi khi gặp một thao tác có thể mất một lúc để hoàn thành

Nhanh nhất so với multithread và process

****args***

Thay thế nhiều tham số trong hàm

args là một tuple chứ không phải list

*args sẽ phải đặt ở cuối cùng nếu không sẽ gặp lỗi ngay

*****kwargs***

**kwargs cũng tương tự như như *args, tuy nhiên, nó không dùng cho các tham số thông thường truyền vào lần lượt, mà nó được sử dụng cho các tham số

**kwargs trong hàm sẽ nhận giá trị là một dict với key là các tham số được truyền kèm giá trị tương ứng của chúng

***nonlocal***

Được sử dụng trong nested functions, được khai báo trong hàm cha, khi gọi đến ở hàm con thì thêm từ khóa nonlocal

***global***

Muốn thay đổi biến toàn cục trong hàm thì ta phải thêm từ khóa global vào biến

Thay đổi phần tử hoặc giá trị của biến thì mới cần sử dụng global

***yield***

Sẽ đình chỉ việc thực thi của hàm và trả về một giá trị cho caller nhưng vẫn giữ lại đầy đủ trạng thái của hàm để ngay sau khi thực thi xong câu lệnh yield, hàm vẫn có thể quay lại thực thi tiếp được tại câu lệnh tiếp theo nằm ngay sau câu lệnh yield vừa chạy xong. Điều này cho phép một hàm có thể trả về một loạt các giá trị theo thời gian, thay vì phải tính toán cùng một lúc ra nhiều outputs rồi đưa tất cả chúng vào trong một list (danh sách) và trả về duy nhất list đó.

***list[]***

append: list append list =list 2 chiều (datatframe)

extend: list extend list =list (nối 2 list thành 1 list)

count: cho biết số lượng của phần tử trong list

***tuple()***

tốc độ nhanh hơn list nhưng các đối tượng không thay đổi đc

truy cập vào phần tử giống như chuỗi và list

***set{}***

set có thể thay đổi nhưng các phần tử không được trùng nhau

set không được sắp xếp nên không thể truy cập bằng chỉ mục

***dictionary {key:value}***

Dùng hàm get(key, default) để truy cập đến phẩn tử trong dict, get() sẽ trả về giá trị của key, trả về None hoặc default(nếu có) nếu không có giá trị phù hợp với key

***enumerate***

Được sử dụng để lặp qua các danh sách và bao gồm chỉ mục (key, value)

Có thể điều chỉnh số bắt đầu của index

Nhanh hơn so với lặp thông thường

```:
names = ['Bob', 'Alice', 'Guido']
for index, value in enumerate(names):
    print(f'{index}: {value}')

```

```:
0: Bob
1: Alice
2: Guido

```

***zip***

Kết hợp 2 danh sách và in các giá trị theo thứ tự của n, vòng lặp kết thúc khi 1 vòng lặp lặp qua 1 danh sách

***Packing and Unpacking Arguments***

Ta có thể gán các giá trị của list hay tuple vào tham số của hàm bằng cách sử dụng * đối với list hay tuple hay ** đối với dictionary trước tham số của hàm

- Lưu ý độ dài của list hay tuple phải có cùng số lượng với số tham số của hàm.

```:
def fun(a, b, c, d):
  print(a, b, c, d)

my_list = [1, 2, 3, 4]

fun(*my_list)
```

***Type conversion***

ord() : chuyển đổi ký tự thành số nguyên.

hex() : chuyển đổi số nguyên thành chuỗi thập phân.

oct() : chuyển đổi số nguyên thành chuỗi bát phân.

tuple(): chuyển đổi thành tuple.

set(): chuyển đổi thành set.

list(): chuyển đổi thành list.

dict() : chuyển đổi thành dictionary.

str() : chuyển đổi thành string.

complex(real,imag) : chuyển đổi thành số phức.

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

***Closure python***

[Lý thuyết](https://quantrimang.com/hoc/cach-su-dung-closure-trong-python-165316)

Là phương pháp ràng buộc dữ liệu với 1 hàm mà không cần thực sự truyền chúng làm tham số cho hàm

Closure là một đối tượng hàm

Closure được tạo hàm lồng nhau

Sử dụng lớp lồng để không cần sử dụng biến toàn cục

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

***Decorator***

[Lý thuyết](https://quantrimang.com/hoc/decorator-trong-python-165379)\
[Tìm hiểu thêm](https://viblo.asia/p/cung-tim-hieu-python-decorators-bJzKmzJEZ9N)

Hàm có thể được truyền như tham số trong hàm khác

Decorator là công cụ rất mạnh mẽ và hữu ích trong Python vì nó cho phép các lập trình viên sửa đổi hành vi của hàm hoặc lớp. Decorator cho phép chúng ta nhận tham số đầu vào là một hàm khác và mở rộng tính năng cho hàm đó mà không thay đổi nội dung của nó.

Decorator là những functions thay đổi tính năng của một function, method hay class một cách dynamic, mà không phải sử dụng subclass

Decorator là một hàm có thể nhận các hàm khác, cho phép bạn chạy một số đoạn code trước hoặc sau hàm chính mà không thay đổi kết quả.

Tham số của hàm sẽ được truyền vào hàm decorator

Tham số hàm decorator luôn là 1 hàm

Tham số khi gọi hàm decorator là tham số được gán vào hàm inner. Sau khi return func về thì tham số trong func return sẽ gán vào hàm decorator

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

***Class object***

[Lý thuyết](https://viblo.asia/p/class-va-object-trong-python-4P856dvLZY3)

Khi gọi phương thức có 1 tham số thì ta không cần gán tham số đầu tiên, bởi vì, bất cứ khi nào, object gọi các phương thức, object sẽ tự pass qua parameter đầu tiên

***Property***

[Lý thuyết](https://quantrimang.com/hoc/property-trong-python-165430)

Được sử dụng trong getter setter trong class

***subprocess***

subprocess.run() đã được thêm vào Python 3.5 để đơn giản hóa subprocess.Popenkhi bạn chỉ muốn thực thi một lệnh và đợi cho đến khi lệnh kết thúc, nhưng bạn không muốn làm bất cứ điều gì khác trong thời gian đó. Đối với các trường hợp khác, bạn vẫn cần sử dụng subprocess.Popen.

Sự khác biệt chính là subprocess.run()thực thi một lệnh và đợi nó kết thúc, trong khi với subprocess.Popenbạn, bạn có thể tiếp tục thực hiện công việc của mình trong khi quá trình kết thúc và sau đó chỉ cần liên tục gọi Popen.communicate()cho chính mình để chuyển và nhận dữ liệu cho quy trình của bạn. Thứ hai, subprocess.run()trả về subprocess.CompletedProcess.

subprocess.run()chỉ cần kết thúc Popenvà Popen.communicate()do đó bạn không cần tạo một vòng lặp để truyền/nhận dữ liệu hoặc đợi quá trình kết thúc.

***Regex***

[Lý thuyết](https://viblo.asia/p/python-regex-Qbq5QMeE5D8)

| Ký tự | Ví dụ | Mô tả | Chuỗi phù hợp|
| --------- | :----: | :---------: |:-----:|
| []    | Một tập hợp các ký tự |     "[a-e]" |"adbc"|
| \      | Tín hiệu thể hiện một chuỗi đặc biệt (hoặc sử dụng để thoát các ký tự đặc biệt) |       "\d" |"123"|
| .    | Bất kỳ ký tự nào (ngoại trừ ký tự dòng mới) |     "he..o" |"henno"|
| ^    | Bắt đầu chuỗi |     "^hello" |"hello gua"|
| $     | Kết thúc chuỗi  | "world$" |"helo world"|
| *       |  Không hoặc nhiều lần xuất hiện   |   "aix*" |"ai"|
| +       |  Xuất hiện ít nhất một lần   |   "aix+" |"aixxxx"|
| {}       |   Chính xác số lần xuất hiện   |   "aix{2}" |"aixx"|
| \|      |  Hoặc   |   "a\|b" |"a"|
| ()       |  Nhóm ký tự   |   "(hello)" |"hello"|
|-|-|-|-|
| \A       |  Bắt đầu chuỗi bằng ký tự chỉ định   |   "\AThe" |"The world"|
| \b       |  Bắt đầu hoặc kết thúc của một từ bằng ký tự chỉ định   |r"\bSpa"  r"ain\b" |"The rain in Spain"  "He is Bi Rain"|
| \B       |  Khớp với các ký tự chỉ định nhưng không nằm ở đầu hoặc cuối từ   |   r"\BSpa"  r"ain\B" |"This is GSpan company"  "No words are rains"|
| \d       |  Chuỗi chứa ký tự là chữ số   |   "\d" |"he1lo"|
| \D       |  Chuỗi không chứa ký tự là số   |    "\D" |"Hello"|
| \s       |  Chuỗi chứa khoảng trắng   |   "\s" |"Hello world"|
| \S       |  Chuỗi không chứa khoảng trắng   |"\S" |"HelloWorld"|
| \w       |  Chuỗi chứa bất kỳ ký tự nào trong nhóm từ a tới Z, từ 0 tới 9 và dấu _ (underscore)   |"\w"|"This is global_variable"|
| \W       |  Ngược lại với \w   |   ""\W" |"*& ^ !"|
| \Z       |  Kết thúc chuỗi bằng các ký tự được chỉ định   |   "Spain\Z" |"The Spain"|
| -       |  -   |   - |-|
| [arg]       |  Chuỗi chứa một trong các ký tự a, r hoặc g|
| [a-n]       |  Chuỗi chứa một trong các ký tự nằm giữa a và n trong bảng chữ cái alphabet|
| [^arg]       |  Chuỗi không chứa bất kỳ ký tự a, r và g|
| [0124]       |  Chuỗi chứa bất kỳ chữ số nào trong nhóm 0, 1, 2 hoặc 4|
| [0-9]       |  Chuỗi chứa ký tự chữ số (tương đương sử dụng \d)|
| [0-5] [0-9]       |  Chuỗi chứa 2 ký tự số liên tiếp, số đầu tiên trong khoảng từ 0->5, số thứ 2 trong khoảng 0->9|
| [a-zA-Z]       |  Chuỗi chứa ký tự là chữ cái không phân biệt hoa và thường|
| [+]       |  Trong sets, các Special Sequences không mang ý nghĩa đặc biệt nữa, chúng chỉ là các ký tự thông thường. Biểu thức bên là chuỗi chứa ký tự +|

***re.compile()***: được sử dụng để biên dịch mẫu biểu thức chính quy được cung cấp dưới dạng chuỗi thành đối tượng mẫu biểu thức chính quy ( re.Pattern). Sau này, chúng ta có thể sử dụng đối tượng mẫu này để tìm kiếm sự trùng khớp bên trong các chuỗi mục tiêu khác nhau bằng cách sử dụng các phương thức biểu thức chính quy như a re.match() hoặc re.search().

***re.match()***: sẽ so khớp ở đầu chuỗi nếu không có biểu thức regex

***re.search()***: so khớp toàn bộ chuỗi

Match là đối tượng chứa thông tin về tìm kiếm phù hợp và kết quả của chúng. Nếu không có tìm kiếm nào phù hợp thì sẽ trả về None

***.string()*** trả về chuỗi được truyền vào hàm

***.span()*** trả về một tuple chứa điểm bắt đầu và kết thúc của vị trí phù hợp

***.group()*** trả về phần chuỗi phù hợp

```:
import re 
  str = "The rain in Spain" 
  x = re.search(r"\bS\w+", str) 
  print(x.span())    
--------------------------------------                
(12, 17)
```

```:
import re 
  str = "The rain in Spain" 
  x = re.search(r"\bS\w+", str) 
  print(x.string)
--------------------------------------                             
The rain in Spain
```

```:
import re 
  str = "The rain in Spain" 
  x = re.search(r"\bS\w+", str) 
  print(x.group())
---------------------------------------                    
Spain

```

***lambda*** được dùng khi chỉ thực hiện 1 việc cụ thể

Lambda là hàm, được coi như 1 biểu thức nên có thể gán cho 1 biến để gọi sau này

## Switch case

```:
match subject:
  case <patt1>:
      <act1>
  case <patt2>:
      <act2>
  case <patt3>:
      <act3>
  case _:
      <action_default>
```

## Union Operator

```:
def func(num: int | float) -> int | float:
    return num + 5


def func(num: Union[int, float]) -> Union[int, float]:
    return num + 5


def func(num: int) -> int:
    return num + 5
```

## Markdown

Sử dụng > để viết trích dẫn

Sử dụng ``` để tạo khối văn bản nhiều dòng

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


conda install pip

conda list -e > requirements.txt
conda create --name <env> --file requirements.txt

python -m pip freeze --all > reqs.txt
python -m pip install -r reqs.txt

pip list --format=freeze > requirements.txt


conda env export > env.yml
conda env update -n base --file env.yml --prune
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

Fast API

```:
uvicorn main:app --reload --host 127.0.0.1 --port 8000
```

Tabel to model

```:
sqlacodegen mssql+pyodbc://sa:Addj%40123@./hotichdata?driver=ODBC+Driver+17+for+SQL+Server --outfile model.py
omm db.sql -m pydantic
omm db.sql -m sqlalchemy
```

Khác

```:
pipreqs --force --encoding utf-8 "./"
jupyter notebook
isort .
pyarmor obfuscate pythonfile.py
```

Add Path windows

```:
setx -m PATH "%PATH%;F:\DATA\Setup"
setx PATH "%PATH%;F:\DATA\Setup"
```

## PEP-8

1. Đặt tên cho các module/package: viết thường tất cả các ký tự, nếu có nhiều từ trong tên, dùng ký tự _ để nối giữa các từ
2. Đặt tên cho các biến dữ liệu (variable/name), function: viết thường tất cả các ký tự, nếu có nhiều từ trong tên, dùng ký tự _ để nối giữa các từ
3. Đặt tên cho class và attribute/function trong class: theo định dạng CapitalizedWord (hoặc CamelCase)
4. Quy ước đặt tên với attribute/function trong class: Mặc định, các attribute/function của một lớp được khai báo là public, quy tắc đặt tên như đặt tên biến (lower_case_with_underscore), Nếu khai báo protected , đặt 01 ký tự underscore ở đầu tiên, Nếu khai báo private, 2 dấu underscore liên tiếp ở đầu tiên

## Note

1. Dùng đệ quy để cải thiên tốc độ
2. Sử dụng np.array thay cho list
3. Sử dụng dictionary thay cho list nếu có thể
4. Chia nhỏ df để thực hiện truy vấn nhanh hơn
5. Sử dụng enum
6. Sử dụng polar thay cho pandas
7. Sử dụng async/await

## Sql Server

1. Trigger

## MongoDB

[Lý thuyết](https://viblo.asia/p/tim-hieu-ve-mongodb-4P856ajGlY3)

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

Quy tắc truy cập và cắt trong numpy array: ```[start:end:step]```

Truy cập mảng nhiều chiều: ```arr[x, y, z]```

Ta có thể thực hiện các phép toán số học vào numpy array, điều mà list không làm được

Các thao tác làm việc với data nên sử dụng numpy

***Tìm kiếm***

| Function                      | Mô tả                                                                                             |
| ----------------------------- | :------------------------------------------------------------------------------------------------ |
|numpy.nanargmin()              |Trả về chỉ số của các giá trị tối thiểu trong trục đã chỉ định bỏ qua NaN.                         |
|numpy.argwhere()               |Tìm các chỉ số của các phần tử mảng khác không, được nhóm theo phần tử.                            |
|numpy.nonzero()                |Trả về các chỉ số của các phần tử khác không.                                                      |
|numpy.flatnonzero()            |Trả về các chỉ số khác không trong phiên bản phẳng của                                             |
|numpy.where()                  |Trả về các phần tử được chọn từ x hoặc y tùy thuộc vào điều kiện.                                  |
|numpy.searchsorted()           |Tìm các chỉ mục nơi các phần tử nên được chèn vào để duy trì trật tự.                              |
|numpy.extract()                |Trả về các phần tử của một mảng thỏa mãn một số điều kiện.                                         |

***Sắp xếp***

| Function                      | Mô tả                                                                                             |
| ----------------------------- | :------------------------------------------------------------------------------------------------ |
|numpy.ndarray.sort()           |Sắp xếp một mảng, tại chỗ.                                                                         |
|numpy.msort()                  |Trả về một bản sao của một mảng được sắp xếp dọc theo trục đầu tiên.                               |
|numpy.sort_complex()           |Sắp xếp một mảng phức tạp bằng cách sử dụng phần thực trước, sau đó là phần ảo.                    |
|numpy.partition()              |Trả về một bản sao được phân vùng của một mảng.                                                    |
|numpy.argpartition()           |Thực hiện phân vùng gián tiếp dọc theo trục đã cho bằng thuật toán được chỉ định bởi từ khóa loại. |

***Đếm số lần xuất hiện***

- np.count_nonzero()
- collections.Counter()

## Pandas

[Lý thuyết](https://viblo.asia/p/pandas-python-tutorial-XL6lAxaDZek)\
[Hướng dẫn](https://pandas.pydata.org/docs/user_guide/10min.html)\
[Group by](https://viblo.asia/p/pandas-groupby-13-chuc-nang-de-tong-hop-du-lieu-eW65G6gJlDO)\
[Tăng tốc select](https://pythonspeed.com/articles/pandas-sql-chunking/)\
[Tăng tốc insert](https://github.com/yehoshuadimarsky/bcpandas)

***Lý thuyết cơ bản***

Pandas được xây dựng dựa trên thư viện numpy

Series giống như mảng, list, cột trong excel; dataframe được tạo từ nhiều series

Dataframe giống với dictionary 1 key nhiều value

Hàng: axis = 0

Cột: axis = 1

\
***df.describe()***: Hiển thị thống kê nhanh về dữ liệu (nhỏ nhất, lớn nhất, trung bình,...)

***loc[hàng, cột]***: Lựa chọn dữ liệu theo tên của hàng và cột đó, chỉ mục có thể là kiểu boolean (chỉ mục của df được định nghĩa thông qua tham số index_col khi khởi tạo df), nếu không định nghĩa mặc định là STT bắt đầu bằng 0, vì vậy khi dùng loc, tham số đầu tiên có thể là số

***iloc[hàng, cột]***: Lựa chọn dữ liệu theo chỉ mục của hàng và cột

***reduce***

***map***

***flatten***

***deepdiff***

***isnull()***: kiểm tra df chứa NaN hay None không, kết quả trả về dạng df nhưng chưa các biểu giá trị là boolean (rỗng thì vẫn là True)

***notnull()***: ngược lại so với isnull()

***count()***: đếm số giá trị khác NaN trong df

***inplace*** nếu là True n sẽ thay thế df cũ, nếu không thì cần phải gán nếu muốn nhận df mới

***read_sql_table()***: lấy tất cả thông tin của bảng, đầu vào chỉ cần tên bảng (tương đương select *)

***read_sql_query()***: thực hiên câu lệnh sql (select)

***read_sql***: bao gồm cả read_sql_table() và read_sql_query()

- Thay thế rỗng thành NaN: ```df.replace(r'^\s*$', np.nan, regex=True)```

- Sử dụng df.itertuples() để lặp qua df và lấy chỉ mục

## Dask

<https://www.coiled.io/blog/speed-up-pandas-query-10x-with-dask>

<https://docs.dask.org/en/stable/>

## XlsxWriter

***overlap***

Các định dạng không ghi đè lên nhau, phải lý thuyết riêng

## PyAutoGui

[Lý thuyết](https://pywinauto.readthedocs.io/en/latest/)

## SQLAlchemy

[Lý thuyết](https://docs.sqlalchemy.org/en/20/core/engines.html)

<https://itsjoshcampos.codes/fast-api-sql-server-connection#heading-introduction>

## Rest API

<https://fastapi.tiangolo.com/tutorial/dependencies/>

<https://fastapi.tiangolo.com/advanced/templates/>

<https://restfulapi.net/resource-naming/>

<https://realpython.com/api-integration-in-python/>

## JWT

<https://viblo.asia/p/tich-hop-fastapi-voi-authentication-bang-jwt-XL6lA6rR5ek>

<https://www.vultr.com/docs/how-to-create-a-restful-api-using-python-and-fastapi-3398/>

<https://huongdanlaptrinh.net/fastapi-tao-api-chuan-va-cuc-nhanh-trong-python/>

<https://sqlmodel.tiangolo.com/tutorial/fastapi/session-with-dependency/>

<https://pyjwt.readthedocs.io/en/stable/>

<https://docs.pydantic.dev/>

<https://dev.to/anuradha9712/four-ways-to-make-an-api-calls-in-javascript-ilc>

<https://indominusbyte.github.io/fastapi-jwt-auth/usage/jwt-in-cookies/>

<https://fastapi.tiangolo.com/tutorial/security/simple-oauth2/>

<https://blog.ropnop.com/storing-tokens-in-browser/>

<https://github.com/tiangolo/fastapi/issues/754>

## Mediapipe

[Lý thuyết](https://viblo.asia/p/mediapipe-live-ml-solutions-va-ung-dung-ve-bang-hands-gestures-gAm5ymOV5db)

## Docker

[Lý thuyết](https://viblo.asia/p/huong-dan-cho-nguoi-moi-bat-dau-su-dung-docker-build-run-push-va-pull-naQZRp8X5vx)

Dùng để đóng gói project để triển khai

Giống như máy ảo nhưng nhanh hơn

Chứa các container chạy ứng dụng khác nhau

Images có thể tạo ra nhiều container

Builf docker: ```docker build -t <imageName> .```

Run docker: ```docker run <imageName>:<version>```

Thông tin: ```docker info```

Lưu config docker: ```docker save -o <path for generated tar file> <image name>```

Load config docker: ```docker load -i <path to image tar file>```

Copy file vào docker: ```docker cp . 4584b29c4197:/```

Xóa file trong docker: ```docker exec --user root lucid_hermann rm -rf bienmuc.bak```

## OCR

- <https://github.com/open-mmlab/mmocr?fbclid=IwAR37knpiJg8PkIYI4dl6Caugg4NkSMmQUMh7RlKYRXtKMgax9XOD01k9Zkc>
- <https://hypjudy.github.io/2017/03/28/cvpr-A4-paper-sheet-detection-and-cropping/>

## TextToSpeech

- <https://github.com/mozilla/TTS>  
- <https://github.com/as-ideas/TransformerTTS>
- <https://viblo.asia/p/text-to-speech-with-tacotron-2-L4x5x6DOZBM>
- <https://www.ncbi.nlm.nih.gov/pmc/articles/PMC7287261/>
- <https://itzone.com.vn/vi/article/text-to-speech-with-tacotron-2/>
- <https://github.com/TensorSpeech/TensorFlowTTS>
- <https://github.com/as-ideas/TransformerTTS#pre-trained-ljspeech-api>
- <https://github.com/buriburisuri/speech-to-text-wavenet>
- <https://github.com/duykhuongnguyen/Text-to-speech-for-Vietnamese>
- <https://github.com/open-mmlab/mmocr?fbclid=IwAR0E5m4w1ClcohJQf5CSjWmOYjvOGj9ITjHJbowNisjdNfkx3Hdso-4rQjA>

## Nodejs

[Hướng dẫn](https://viblo.asia/p/lam-quen-voi-nodejs-xay-dung-web-server-don-gian-YWOZrEe7KQ0)

## Dataset

[Dataset Kaggle](https://www.kaggle.com/datasets)\
[Dataset UCI](https://archive.ics.uci.edu/ml/datasets.php)\
[Dataset Google](https://datasetsearch.research.google.com/)\
[Dataset Github](https://github.com/namtao/awesome-public-datasets)

## Machine Learning

[Deep learning](https://phamdinhkhanh.github.io/deepai-book/intro.html)\
[Machine Learning](https://paperswithcode.com)\
[Parallelization](https://ray-project.github.io/2017/05/20/announcing-ray.html)

## Data Science

[Data Science](https://phamdinhkhanh.github.io/2019/01/07/Ky_thuat_feature_engineering.html)\
[Dark](https://dask.pydata.org/en/latest/)\
[Distarray](https://docs.enthought.com/distarray/)

## Sources

[SS64](https://ss64.com/)

## Knowledge

<https://www.howstuffworks.com/>

<https://bigthink.com/>

## How to?

- How to Determine the Orientation of an Object?
  - <https://automaticaddison.com/how-to-determine-the-orientation-of-an-object-using-opencv/>
  - <https://stackoverflow.com/questions/46731947/detect-angle-and-rotate-an-image-in-python/46732132>
  - <https://stackoverflow.com/questions/61609845/detect-angle-and-rotate-image-using-houghline-transform>
  - <https://www.fatalerrors.org/a/ocr-text-correction-after-text-detection.html>
  - <https://stackoverflow.com/questions/55654142/detect-if-an-ocr-text-image-is-upside-down>
  - <https://developpaper.com/python-opencv-implementation-of-rotating-text-correction/>
  - <https://gist.github.com/scionoftech/43b4dbe9e822411787e08d59d30f5368>
  - <https://gist.github.com/smeschke/aa989df78551a9050a78e0d7a8c50495>
  - <https://pyimagesearch.com/2017/02/20/text-skew-correction-opencv-python/>
  - <https://pyimagesearch.com/2014/08/25/4-point-opencv-getperspective-transform-example/>

- How can i make git accept a self signed certificate in iis?
  - <https://stackoverflow.com/questions/11621768/how-can-i-make-git-accept-a-self-signed-certificate>

- Remove duplicates from numpy array in python
  - <https://thispointer.com/remove-duplicates-from-numpy-array-in-python/>

- Cannot use Vietnamese keyboard in *.md file
  - <https://github.com/yzhang-gh/vscode-markdown/issues/617#issuecomment-585629661>

- How to Compress PDF Files in Python?
  - <https://www.thepythoncode.com/article/compress-pdf-files-in-python>
  - <https://stackoverflow.com/questions/2693820/extract-images-from-pdf-without-resampling-in-python>
  - <https://pymupdf.readthedocs.io/en/latest/recipes-images.html>
  - <https://filegi.com/file-info/jp2-2091/>
  - <https://www.geeksforgeeks.org/how-to-compress-images-using-python-and-pil/>
  - <https://askubuntu.com/questions/113544/how-can-i-reduce-the-file-size-of-a-scanned-pdf-file>
  - <https://sourceforge.net/projects/jpegoptim/>

  - <https://pyimagesearch.com/2014/07/07/color-quantization-opencv-using-k-means-clustering/>
  - <https://realpython.com/python-opencv-color-spaces/>
  - <https://github.com/iamaaditya/image-compression-cnn>
  - <https://github.com/Justin-Tan/high-fidelity-generative-compression>

- Lỗi PyInstaller
  - <https://chowdera.com/2022/179/202206282001331430.html>

## Tricks

[Download FB video](https://snapsave.app/vn)\
[Hidden Folder](https://quantrimang.com/cong-nghe/tao-mat-khau-bao-ve-thu-muc-trong-windows-7-73499)
