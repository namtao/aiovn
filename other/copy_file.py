import os
import re
import shutil

lst = ['KS.1999.93719.02.A2.259.pdf',
       'KS.1999.93719.02.A2.260.pdf',
       'KS.1999.93719.02.A2.261.pdf',
       'KS.1999.93719.02.A2.161.pdf',
       'KS.2002.93712.01.A2.145.pdf',
       'KS.2002.93712.01.A2.146.pdf',
       'KS.2002.93712.01.A2.147.pdf',
       'KS.2002.93712.01.A2.148.pdf',
       'KS.2004.31477.02.A2.237.pdf',
       'KS.2004.31477.02.A2.238.pdf',
       'KS.2004.31477.02.A2.239.pdf',
       'KS.2004.31477.02.A2.240.pdf',
       'KS.2004.93711.01.A2.133.pdf',
       'KS.2004.93711.01.A2.134.pdf',
       'KS.2004.93711.01.A2.135.pdf',
       'KS.2004.93711.01.A2.136.pdf',
       'KS.2005.31477.02.A2.200.pdf',
       'KS.2005.31477.02.A2.201.pdf',
       'KS.2005.31477.02.A2.202.pdf',
       'KS.2005.31477.02.A2.203.pdf',
       'KS.2005.31480.03.A2.409.pdf',
       'KS.2005.31480.03.A2.410.pdf',
       'KS.2005.31480.03.A2.411.pdf',
       'KS.2005.31480.03.A2.412.pdf',
       'KS.2005.93711.01.A2.29.pdf',
       'KS.2005.93711.01.A2.30.pdf',
       'KS.2005.93711.01.A2.31.pdf',
       'KS.2005.93711.01.A2.32.pdf',
       'KS.2005.93711.02.A2.288(1).pdf',
       'KS.2005.93711.02.A2.289(1).pdf',
       'KS.2005.93711.02.A2.290(1).pdf',
       'KS.2005.93711.02.A2.291(1).pdf',
       'KS.2006.93711.02.A4.241.pdf']

for root, dirs, files in os.walk(r'D:\HoTich\HOTICH_HG\source - haugiang\Files'):
    for file in files:
        pattern = re.compile(".*"+'pdf'+"$")

        if pattern.match(file) and file in lst:
            shutil.copy(os.path.join(root, file),
                        os.path.join(r'C:\Users\Administrator\Downloads\Sửa lỗi', file))
            print(os.path.join(root, file))
            # os.remove(os.path.join(root, file))
