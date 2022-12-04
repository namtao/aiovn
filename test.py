import numpy as np

a = np.array([1, 2, 3, 4, 5, 6])
a = np.append(a, 1)

for index, value in enumerate(a, 1):
    print(f'{index} {value}')
