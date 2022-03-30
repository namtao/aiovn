import sys
 
# stop Python from making .pyc files
sys.dont_write_bytecode = True

x = 2000
y = 36450

result = (18819000 + x*y + (x*y)*0.01)/(500+x)
print(result)
print(x*y)

