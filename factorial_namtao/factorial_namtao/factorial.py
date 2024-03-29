def fact(n):
    if n < 0:
        raise ValueError('Factorial is not defined for negative numvers')
    elif n ==0 or n == 1:
        return 1
    else:
        return n * fact(n-1)    