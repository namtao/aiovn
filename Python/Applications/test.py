import os
import pandas as pd


# for root, dirs, files in os.walk(r'C:\Projects\Python'):
#     for file in files:
#         if file.endswith(".pyc"):
#             # os.remove(root)
#             print(root)
            
ind = pd.Index([1, 2, 4, 7, 10, 12, 15])
print("Array slicing: ", ind[::2])