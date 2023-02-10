import os

for root, dirs, files in os.walk(r'D:\HoTich\HOTICH_HG\soucre - hlongmy\Files'):
    for file in files:
        if (os.path.getsize(os.path.join(root, file)) == 0):
            print(os.path.join(root, file))