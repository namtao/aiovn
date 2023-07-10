import os
import re
import shutil
from pathlib import Path


# 000.01.37.H08.01.01.40.1999.377.1.pdf
# mã định danh. phông số. mục lục số. hộp số. năm hình thành. hồ sơ số. STT.pdf
def copy_file_struct(input_path, output_path):
    for root, dirs, files in os.walk(input_path):
        for file in files:
            # $ regex kết thúc là ký tự trc $
            pattern = re.compile(".*pdf$")
            if pattern.match(file):
                head, tail = os.path.split(Path(os.path.join(root, file)))
                sothutu = tail.split(".")[-2]
                hososo = tail.split(".")[-3]
                nam = tail.split(".")[-4]
                hopso = tail.split(".")[-5]
                muclucso = tail.split(".")[-6]
                madinhdanh = tail[:13]

                if len(sothutu) == 1:
                    sothutu = "0" + sothutu

                if len(hopso) == 1:
                    hopso = "0" + hopso

                if len(hososo) == 1:
                    hososo = "0" + hososo

                if len(muclucso) == 1:
                    muclucso = "0" + muclucso

                folderName = ".".join([madinhdanh, nam, hososo])
                fileName = ".".join([madinhdanh, nam, hososo, sothutu, "pdf"])

                newPath = os.path.join(output_path, folderName)
                Path(newPath).mkdir(parents=True, exist_ok=True)

                # os.makedirs(newPath, exist_ok=True)

                if not os.path.exists(os.path.join(output_path, folderName, fileName)):
                    print(os.path.join(output_path, folderName, fileName))
                    shutil.copy(
                        os.path.join(root, file),
                        os.path.join(output_path, folderName, fileName),
                    )


copy_file_struct(
    r"D:\BINHDINH\ADDJ_THICONG\Files\000.00.37.H08", r"C:\BinhDinh\AppData\Document"
)
