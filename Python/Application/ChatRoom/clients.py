import socket

HOST = 'localhost'    # Cấu hình address server
PORT = 8888             # Cấu hình Port sử dụng
s = socket.socket(socket.AF_INET, socket.SOCK_STREAM) # Cấu hình socket
s.connect((HOST, PORT)) # tiến hành kết nối đến server
s.sendall(b'Hello server!') # Gửi dữ liệu lên server 
data = s.recv(1024) # Đọc dữ liệu server trả về
print('Server Respone: ', repr(data))