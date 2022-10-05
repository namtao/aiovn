# Python documentation

## *args

thay thế nhiều tham số trong hàm
args là một tuple chứ không phải list
*args sẽ phải đặt ở cuối cùng nếu không sẽ gặp lỗi ngay

## **kwargs

**kwargs cũng tương tự như như *args, tuy nhiên, nó không dùng cho các tham số thông thường truyền vào lần lượt, mà nó được sử dụng cho các tham số
kwargs trong hàm sẽ nhận giá trị là một dict với key là các tham số được truyền kèm giá trị tương ứng của chúng

## nonlocal

được sử dụng trong nested functions, được khai báo trong hàm cha, khi gọi đến ở hàm con thì thêm từ khóa nonlocal
