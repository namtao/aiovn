
import operator
# This code explains how can we  
# use 'any' function on list  
list1 = [] 
list2 = [] 
  
# Index ranges from 1 to 10 to multiply 
for i in range(1,11): 
    list1.append(4*i)  
  
# Index to access the list2 is from 0 to 9 
for i in range(0,10): 
    list2.append(list1[i]%5==0) 
  
print('See whether at least one number is divisible by 5 in list 1=>') 
print(list1)
print(list2)
print(any(list1[i]%5==0)) 