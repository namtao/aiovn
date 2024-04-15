def is_prime(n: int):
    if(n >= 0):
        if(n ==2 or n == 1): return True
        if(n<=0): return False
        count = 0
        for i in range(1, int(n/2)+1):
            if n % i ==0:
                count+=1
        if(count > 1):
            return False
        
        return True
    
    return False


print(is_prime(5))
print(is_prime('x'))