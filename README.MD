# Tài liệu

- [Tài liệu](#tài-liệu)
  - [Python](#python)
  - [Command](#command)
  - [PEP-8](#pep-8)
  - [Note](#note)
  - [Sql Server](#sql-server)
  - [MongoDB](#mongodb)
  - [Pandas](#pandas)
  - [XlsxWriter](#xlsxwriter)

## Python

- *args

> Thay thế nhiều tham số trong hàm
>
> args là một tuple chứ không phải list
>
> *args sẽ phải đặt ở cuối cùng nếu không sẽ gặp lỗi ngay

- **kwargs

> **kwargs cũng tương tự như như *args, tuy nhiên, nó không dùng cho các tham số thông thường truyền vào lần lượt, mà nó được sử dụng cho các tham số
>
> **kwargs trong hàm sẽ nhận giá trị là một dict với key là các tham số được truyền kèm giá trị tương ứng của chúng

- nonlocal

> Được sử dụng trong nested functions, được khai báo trong hàm cha, khi gọi đến ở hàm con thì thêm từ khóa nonlocal\

- global

> Muốn thay đổi biến toàn cục trong hàm thì ta phải thêm từ khóa global vào biến
>
> Thay đổi phần tử hoặc giá trị của biến thì mới cần sử dụng global

- yield

> Sẽ đình chỉ việc thực thi của hàm và trả về một giá trị cho caller nhưng vẫn giữ lại đầy đủ trạng thái của hàm để ngay sau khi thực thi xong câu lệnh yield, hàm vẫn có thể quay lại thực thi tiếp được tại câu lệnh tiếp theo nằm ngay sau câu lệnh yield vừa chạy xong. Điều này cho phép một hàm có thể trả về một loạt các giá trị theo thời gian, thay vì phải tính toán cùng một lúc ra nhiều outputs rồi đưa tất cả chúng vào trong một list (danh sách) và trả về duy nhất list đó.

- Decorator

> Decorator là công cụ rất mạnh mẽ và hữu ích trong Python vì nó cho phép các lập trình viên sửa đổi hành vi của hàm hoặc lớp. Decorator cho phép chúng ta nhận tham số đầu vào là một hàm khác và mở rộng tính năng cho hàm đó mà không thay đổi nội dung của nó.
>
> Decorator là những functions thay đổi tính năng của một function, method hay class một cách dynamic, mà không phải sử dụng subclass

- list

> append: list append list => list 2 chiều (datatframe)
> extend: list extend list => list (nối 2 list thành 1 list)

- enumerate

> Được sử dụng để lặp qua các danh sách và bao gồm chỉ mục (key, value)

- zip

> Kết hợp 2 danh sách và in các giá trị theo thứ tự của n, vòng lặp kết thúc khi 1 vòng lặp lặp qua 1 danh sách

## Command

> find . -name "*.pyc" -exec rm -f {} \;
>
> pip install --upgrade pip setuptools wheel
>
> py -m ensurepip --upgrade
>
> pip install --upgrade pip
>
> auto-py-to-exe
>
> pip install virtualenv
>
>virtualenv --version
>
>virtualenv my_project_env
>
> virtualenv -p C:\Projects\Python\library\pypy3.9-v7.3.9-win64\pypy.exe pypy
>
> python -m venv env
> env\Scripts\activate
>
> python -m pip freeze --all > requirements.txt
> python -m pip install -r requirements.txt
>
> pipreqs --force --encoding utf-8 "./"
>
> jupyter notebook
>
> isort .
>
> python manage.py inspectdb \> models.py
>
> pyuic5 -x gui/demo.ui -o gui/demo.py
>
> django-admin startproject mysite
>
> python manage.py startapp <Tên APP>
>
> python manage.py runserver
>
> python manage.py makemigrations
>
> python manage.py migrate
>
> python manage.py createsuperuser
>
> python manage.py syncdb
>
> python manage.py collectstatic
>

## PEP-8

1. Đặt tên cho các module/package: viết thường tất cả các ký tự, nếu có nhiều từ trong tên, dùng ký tự _ để nối giữa các từ
2. Đặt tên cho các biến dữ liệu (variable/name), function: viết thường tất cả các ký tự, nếu có nhiều từ trong tên, dùng ký tự _ để nối giữa các từ
3. Đặt tên cho class và attribute/function trong class: theo định dạng CapitalizedWord (hoặc CamelCase)
4. Quy ước đặt tên với attribute/function trong class: Mặc định, các attribute/function của một lớp được khai báo là public, quy tắc đặt tên như đặt tên biến (lower_case_with_underscore), Nếu khai báo protected , đặt 01 ký tự underscore ở đầu tiên, Nếu khai báo private, 2 dấu underscore liên tiếp ở đầu tiên

## Note

1. Dùng đệ quy để cải thiên tốc độ

## Sql Server

1. Trigger

## MongoDB

- Tương quan giữa mongodb với sqlserver

| Operation | In SQL    | In MongoDB|
|-----------|:---------:|----------:|
|Create     |Insert     |Insert     |
|Read       |Select     |Find       |
|Update     |Update     |Update     |
|Delete     |Delete     |Remove     |
|Table      |Table      |Collection |
|Row        |Row        |Document   |

- Đặc điểm

  - Tốc độ nhanh
  - JSON object

## Pandas

- Lý thuyết cơ bản

>series giống như mảng, list; dataframe được tạo từ nhiều series

- df.describe()

> Hiển thị thống kê nhanh về dữ liệu (nhỏ nhất, lớn nhất, trung bình,...)

- iloc[hàng, cột]

> Lựa chọn dữ liệu theo số thứ tự của hàng và cột, chỉ số hàng

- loc(hàng, cột)

> Giống iloc nhưng có thể truyền tham số là nhãn nhưng k nhận chỉ số hàng làm tham số, có thể truyền vào 1 boolean => lọc dữ liệu

- ix

> Là sự kết hợp giữa iloc và loc

- reduce

- map

- flatten

- deepdiff

## XlsxWriter

- overlap

> Các định dạng không ghi đè lên nhau, phải định nghĩa riêng
