class Person:
    def __init__(self, fname: str = '', lname: str = '', age: int = 18):
        self.__fname = fname
        self.__lname = lname
        self.__age = age

    @property
    def age(self):
        return self.__age

    @age.setter
    def age(self, age: int):
        if age > 0:
            self.__age = age

    @property
    def first_name(self):
        return self.__fname

    @first_name.setter
    def first_name(self, fname: str):
        if fname.isalpha():
            self.__fname = fname

    @property
    def last_name(self):
        return self.__lname

    @last_name.setter
    def last_name(self, lname: str):
        if lname.isalpha():
            self.__lname = lname

    @property
    def full_name(self):
        return f'{self.__fname} {self.__lname}'

    def print(self, format=True):
        if not format:
            print(self.name, self.age)
        else:
            print(f'{self.full_name}, {self.age} years old')


putin = Person()
putin.first_name = 'Putin'
putin.last_name = 'Vladimir'
putin.age = 66
print(putin.full_name, putin.age)
