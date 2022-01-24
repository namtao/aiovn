import sys
import pypdfocr 

x = 300
y = 30000

# result = (44144000 + x*y + (x*y)/1000)/(1000+x)
result = (54506400 + x*y + (x*y)/1300)/(1300+x)
print(result)
print(x*y)