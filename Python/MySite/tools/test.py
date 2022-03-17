import sys
 
# stop Python from making .pyc files
sys.dont_write_bytecode = True

x = 4200
y = 36000

result = (0 + x*y + (x*y)/90)/(0+x)
print(result)
print(x*y)

