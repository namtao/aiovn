def function1(function):
    def wrapper(*args, **kwargs):
        print("hello world")
        function(*args, **kwargs)
        print("hello world 2")
    
    return wrapper

@function1
def function2(*args, **kwargs):
    print("hello world " + str(args) + " " + str(kwargs))
    

# function2 = function1(function2)

function2("nam", "hello world")