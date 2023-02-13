import os
import re
import shutil

lst = ['KS.1999.93617.02.A2.253.pdf',
       'KS.1999.93619.02.A2.253.pdf',
       'KS.1999.93619.02.A2.255.pdf',
       'KS.1999.93619.02.A2.196.pdf']

for root, dirs, files in os.walk(r'D:\HoTich\HOTICH_HG\soucre - hlongmy\FilesNen'):
    for file in files:
        pattern = re.compile(".*"+'pdf'+"$")

        if pattern.match(file) and file in lst:
            # shutil.copy(os.path.join(root, file),
            #             os.path.join(r'C:\Users\Administrator\Downloads\fix', file))
            print(os.path.join(root, file))
            os.remove(os.path.join(root, file))
