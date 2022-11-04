# Python documentation

## *args

thay thế nhiều tham số trong hàm
args là một tuple chứ không phải list
*args sẽ phải đặt ở cuối cùng nếu không sẽ gặp lỗi ngay

## **kwargs

**kwargs cũng tương tự như như *args, tuy nhiên, nó không dùng cho các tham số thông thường truyền vào lần lượt, mà nó được sử dụng cho các tham số
kwargs trong hàm sẽ nhận giá trị là một dict với key là các tham số được truyền kèm giá trị tương ứng của chúng

## nonlocal

được sử dụng trong nested functions, được khai báo trong hàm cha, khi gọi đến ở hàm con thì thêm từ khóa nonlocal\

## yield

sẽ đình chỉ việc thực thi của hàm và trả về một giá trị cho caller nhưng vẫn giữ lại đầy đủ trạng thái của hàm để ngay sau khi thực thi xong câu lệnh yield, hàm vẫn có thể quay lại thực thi tiếp được tại câu lệnh tiếp theo nằm ngay sau câu lệnh yield vừa chạy xong. Điều này cho phép một hàm có thể trả về một loạt các giá trị theo thời gian, thay vì phải tính toán cùng một lúc ra nhiều outputs rồi đưa tất cả chúng vào trong một list (danh sách) và trả về duy nhất list đó.

## global

muốn thay đổi biến toàn cục trong hàm thì ta phải thêm từ khóa global vào biến
thay đổi phần tử hoặc giá trị của biến thì mới cần sử dụng global

## Decorator

Decorator là công cụ rất mạnh mẽ và hữu ích trong Python vì nó cho phép các lập trình viên sửa đổi hành vi của hàm hoặc lớp. Decorator cho phép chúng ta nhận tham số đầu vào là một hàm khác và mở rộng tính năng cho hàm đó mà không thay đổi nội dung của nó.
Decorator là những functions thay đổi tính năng của một function, method hay class một cách dynamic, mà không phải sử dụng subclass
