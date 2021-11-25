import socket

HOST = 'localhost' # Thiết lập địa chỉ address
PORT = 8888 # Thiết lập post lắng nghe
s = socket.socket(socket.AF_INET, socket.SOCK_STREAM) # cấu hình kết nối
s.bind((HOST, PORT)) # lắng nghe
s.listen(1) # thiết lập tối đa 1 kết nối đồng thời
conn, addr = s.accept() # chấp nhận kết nối và trả về thông số
with conn:
    try:
        # in ra thông địa chỉ của client
        print('Connected by', addr)
        while True:
            # Đọc nội dung client gửi đến
            data = conn.recv(1024)
            # In ra Nội dung 
            print(data)
            # Và gửi nội dung về máy khách
            conn.sendall(b'Hello client')
            if not data: # nếu không còn data thì dừng đọc
                break
    finally:
        s.close() # đóng socket