from functools import wraps


def function1(function):
    @wraps(function)
    # @wraps(function) nhận một function sẽ được decorate copy cả function name, doc string, list các tham số,... 
    # Nó cho phép truy cập những thuộc tính của function trước khi function được decorate
    def wrapper(*args, **kwargs):
        print('Bắt đầu')
        function(*args, **kwargs)
        print('Kết thúc')

    return wrapper


@function1
def function2(*args, **kwargs):
    print('hello world ' + str(args) + ' ' + str(kwargs))


function2('nam', 'abc', {'key': 'hello world'})
