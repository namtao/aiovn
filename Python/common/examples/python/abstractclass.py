from abc import ABC, abstractmethod

# câu này bắt buộc phải có
class abstractClassName(ABC):
    @abstractmethod
    def methodName(self):
        pass

# tạo class thứ 2 implement từ abstractClassName
class normalClass(abstractClassName):
    # khai báo cho class ở đây
    pass

print(dict(ABC))
