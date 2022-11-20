from functools import reduce


def A(x):
    return lambda y: x+y


t = A(6)
print(t(1))

mylist = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]

# lambda with filter
newlist = list(filter(lambda x: (x % 2 == 1), mylist))
print(newlist) #[1, 3, 5, 7, 9]

# lambda with map
newlist = list(map(lambda x: (x % 2 == 1), mylist))
print(newlist) #[True, False, True, False, True, False, True, False, True, False]

# lambda with reduce
newlist = reduce(lambda x, y: x*y, mylist)
print(newlist) #3628800
