import sys
import os


os.system('cmd /c "cls"')

# stop Python from making .pyc files
# sys.dont_write_bytecode = True

x = 7500
y = 8000

result = (124461000 + x*y + (x*y)*0.01)/(4500+x)

print("{:,}".format(round(result/1000, 2)))
print("{:,}".format(round(int(result))))
print("{:,}".format(x*y + 0.01*x*y))