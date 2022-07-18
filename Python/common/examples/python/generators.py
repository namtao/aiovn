def func(i):
    while i < 10:
        yield i
        i+=1
        
j = func(1)

print(next(j))


print(help(func(1)))