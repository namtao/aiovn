x = 644 # khối lượng
y = 9490 # giá

result = (73596780 + x*y + (x*y)*0.01)/(7356+x)

print("{:,}".format(x*y + (x*y)*0.01))
print("{:,}".format(round(result/1000, 2)))
print("{:,}".format(round(int(result))))
print("{:,}".format(result))