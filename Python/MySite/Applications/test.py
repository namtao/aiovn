import sys
 
# stop Python from making .pyc files
sys.dont_write_bytecode = True

x = 2500
y = 34500

# result = (44144000 + x*y + (x*y)/1000)/(1000+x)
# result = (54506400 + x*y + (x*y)/1300)/(1300+x)
result = (41933000 + x*y + (x*y)/1000)/(1000+x)
print(result)
print(x*y)