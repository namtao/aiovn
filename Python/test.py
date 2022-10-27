import multiprocessing
x = 0  # khối lượng
y = 8990  # giá

result = (79000000 + x*y + (x*y)*0.001)/(8000+x)

print("{:,}".format(round(result/1000, 2)))
print("{:,}".format(round(int(result))))
print("{:,}".format(result))
print("{:,}".format(x*y + (x*y)*0.001))

# print("Số lượng cpu : ", multiprocessing.cpu_count())
