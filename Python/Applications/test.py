import os


for root, dirs, files in os.walk(r'C:\Projects\Python'):
    for file in files:
        if file.endswith(".pyc"):
            os.remove(root)
            # print(root)