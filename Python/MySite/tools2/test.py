import sys
 
# stop Python from making .pyc files
sys.dont_write_bytecode = True

x = 1000
y = 40000

# result = (44144000 + x*y + (x*y)/1000)/(1000+x)
# result = (54506400 + x*y + (x*y)/1300)/(1300+x)
# result = (41933000 + x*y + (x*y)/1000)/(1000+x)
# result = (50436100 + x*y + (x*y)/1300)/(1300+x)
result = (94876800 + x*y + (x*y)/2400)/(2400+x)
print(result)
print(x*y)

