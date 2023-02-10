import os
import re
import shutil

lst = ['KH.1891.93656.01.A4.1940.17.pdf',
       'KH.1891.93656.01.A4.1955.13.pdf',
       'KH.1895.93639.01.A4.1919.06.pdf',
       'KH.1902.93642.01.A4.1921.15.pdf',
       'KH.1902.93642.01.A4.1935.13.pdf',
       'KH.1904.93631.01.A4.1923.21.pdf',
       'KH.1907.93652.01.A4.1957.01.pdf',
       'KH.1920.93639.01.A4.1927.05.pdf',
       'KH.1920.93639.01.A4.1928.06.pdf',
       'KH.1920.93639.01.A4.1929.11.pdf',
       'KH.1920.93639.01.A4.1935.35.pdf',
       'KH.1920.93641.01.A4.1930.20.pdf',
       'KH.1920.93645.01.A4.1933.16.pdf',
       'KH.1930.93631.01.A4.1930.23.pdf',
       'KH.1930.93631.01.A4.1936.13.pdf',
       'KH.1930.93631.01.A4.1939.25.pdf',
       'KH.1930.93631.01.A4.1943.17.pdf',
       'KH.1930.93648.01.A4.1955.10.pdf',
       'KH.1930.93655.01.A4.1930.19.pdf',
       'KH.2001.93620.01.A2.93.pdf',
       'KH.2003.93620.01.A2.56.pdf',
       'KH.2005.31483.01.A2.139.pdf',
       'KS.1887.93654.01.A4.1887.08.pdf',
       'KS.1909.93645.01.A4.1910.27.pdf',
       'KS.1909.93645.01.A4.1922.28.pdf',
       'KS.2001.3620.04.A2.764.pdf',
       'KS.2001.3620.05.A2.957.pdf',
       'KS.2002.3620.01.A2.105.pdf',
       'KS.2003.93620.01.A2.2004.120.pdf',
       'KS.2006.93629.02.A4.41.pdf',
       'KT.1900.93645.01.A4.1936.29.pdf',
       'KT.1901.93639.01.A4.1931.25.pdf',
       'KT.1906.93631.01.A4.1955.02.pdf',
       'KT.1930.93637.01.A4.1963.19.pdf',
       'KT.1930.93637.01.A4.1969.09.pdf',
       'KT.1940.93639.01.A4.1941.10.pdf']

for root, dirs, files in os.walk(r'E:\0.H Long My'):
    for file in files:
        pattern = re.compile(".*"+'pdf'+"$")

        if pattern.match(file) and file in lst:
            shutil.copy(os.path.join(root, file),
                        os.path.join(r'C:\Users\Administrator\Downloads\fix', file))
            print(os.path.join(root, file))
            # os.remove(os.path.join(root, file))
