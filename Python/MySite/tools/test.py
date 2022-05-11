import sys
import os


os.system('cmd /c "cls"')

# stop Python from making .pyc files
# sys.dont_write_bytecode = True

x = 20000
y = 5000

result = (123400800 + x*y + (x*y)*0.01)/(3600+x)

print("{:,}".format(round(result/1000, 2)))
print("{:,}".format(round(int(result))))
print("{:,}".format(x*y + 0.01*x*y))
# print("------------------------------")

# x = 0
# y = 15200

# result = (10682700 + x*y + (x*y)*0.01)/(700+x)

# print("{:,}".format(round(result/1000, 2)))
# print("{:,}".format(round(int(result))))
# print("{:,}".format(x*y))