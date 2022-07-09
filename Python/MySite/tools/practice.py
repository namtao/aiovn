def function1(function):
    def wrapper():
        print("hello world")
        function()
        print("hello world 2")
    
    return wrapper

@function1
def function2():
    print("hello world 3")
    

# function2 = function1(function2)

function2()