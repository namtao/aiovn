import sys
 
# stop Python from making .pyc files
sys.dont_write_bytecode = True

x = 2600
y = 38800

result = (0 + x*y + (x*y)*0.01)/(0+x)
print(result)
print(x*y)

