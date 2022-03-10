import numpy as np


a = [1, 2, 3, 4, 5]

for i in np.nditer(np.array(a)):
    print(i)
