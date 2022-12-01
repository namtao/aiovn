import os
import re
import shutil
from pathlib import Path

# kiểm tra file chưa nén và file nén xem đã đầy đủ chưa

lstMaPhuong = ['31340', '31341', '31343', '31344', '31411', '31414', '93111', '93112', '93113', '93114', '93115', '93116', '93117', '93118', '93119', '93120', '93121', '93122', '93123', '93124', '93125', '93126', '93127', '93128', '93129', '93130', '93131', '93132', '93133', '93134', '93135', '93136', '93137' ]

for root, dirs, files in os.walk(r'E:\OCR NEN\CHUA NEN\a\VI THANH'):
    for file in files:
        pattern = re.compile(".*"+'pdf'+"$")

        if pattern.match(file):

            head, tail = (os.path.split(
                Path(os.path.join(root, file))))

            if (tail.split('.')[2] in lstMaPhuong):

                newPath = os.path.join(r'E:\OCR NEN\CHUA NEN\a\NGA BAY', tail.split('.')[
                                       0], tail.split('.')[1], tail.split('.')[2], tail.split('.')[3])

                Path(newPath).mkdir(parents=True, exist_ok=True)
                shutil.move(os.path.join(root, file),
                            os.path.join(newPath, file))
