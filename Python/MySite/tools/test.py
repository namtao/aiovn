import sys
 
# stop Python from making .pyc files
# sys.dont_write_bytecode = True

x = 2000
y = 35000

result = (37019000 + x*y + (x*y)*0.01)/(1000+x)
print(result)
print(x*y)

