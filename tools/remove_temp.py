import os
import re
import shutil
from pathlib import Path

lstMaPhuong = [
    '31471', '31472', '31473', '31474', '31475', '31477', '31478', '31480', '31481', '93711', '93712', '93713', '93714',
    '93715', '93716', '93717', '93718', '93719', '93720', '93721', '93722', '93723', '93724', '93725', '93726', '93727',
    '93728', '93729', '93730', '93731', '93732', '93733', '93734', '93735', '93736', '93737', '93738', '93739', '93740',
    '93741', '93742', '93743', '93744', '93745', '93746', '93748', '93749', '93750', '93751', '93752', '93753', '93754',
    '93755', '93756', '93757', '93758', '93759', '93760', '93761', '93762', '93763']

# xóa file rác và thư mục trống


def remove_temp(path):
    for root, dirs, files in os.walk(path):
        # [shutil.rmtree(os.path.join(root, dir)) for dir in dirs if (len(dir) > 10 or ('Temp' in dir))]

        # [os.remove(os.path.join(root, file)) for file in files if (
        #     ('_' in file) or os.path.getsize(os.path.join(root, file)) == 0 or ('jpg' in file))]

        for dir in dirs:
            if (('Temp' in dir)):
                print(os.path.join(root, dir))
                shutil.rmtree(os.path.join(root, dir))

    for root, dirs, files in os.walk(path):
        for file in files:
            # if (('_' in file) or os.path.getsize(os.path.join(root, file)) == 0 or ('jpg' in file)):
            if (('_' in file) or ('jpg' in file)):
                print(os.path.join(root, file))
                os.remove(os.path.join(root, file))

    def removeEmptyFolders(path, removeRoot=True):
        if not os.path.isdir(path):
            return

        # remove empty subfolders
        files = os.listdir(path)
        if len(files):
            for f in files:
                fullpath = os.path.join(path, f)
                if os.path.isdir(fullpath):
                    removeEmptyFolders(fullpath)

        # if folder empty, delete it
        files = os.listdir(path)
        if len(files) == 0 and removeRoot:
            print("Removing empty folder:", path)
            # os.rmdir(path)

    # removeEmptyFolders(path)


# kiểm tra file chưa nén và file nén xem đã đầy đủ chưa
def copy_nen(dir1, dir2, pathTarget):
    def get_files(folderPath, fileFormat):
        lst = []
        for root, dirs, files in os.walk(folderPath):
            for file in files:
                pattern = re.compile(".*"+fileFormat+"$")

                if pattern.match(file):
                    # lst.append(os.path.join(root, file))
                    lst.append(os.path.join(file))
                    # lst.append(os.path.splitext(file)[0])
        return lst

    lstPdf1 = get_files(dir1, 'pdf')
    lstPdf2 = get_files(dir2, 'pdf')

    # lstDaCopy = get_files(r'E:\OCR NEN', 'pdf')
    # lstPdf3 = get_files(dir3, 'pdf')

    # lstDuplicate = list(set(lstPdf1) & set(lstPdf2))
    lstNotDuplicate = list(set(lstPdf1) - set(lstPdf2))

    print(len(lstNotDuplicate))

    # count = 0
    for root, dirs, files in os.walk(dir1):
        for file in files:
            if (file in lstNotDuplicate):

                head, tail = (os.path.split(
                    Path(os.path.join(root, file))))

                # if (tail.split('.')[2] not in lstMaPhuong):

                print(os.path.join(root, file))
                newPath = os.path.join(pathTarget, tail.split('.')[0], tail.split('.')[
                    1], tail.split('.')[2], tail.split('.')[3])

                # Path(newPath).mkdir(parents=True, exist_ok=True)
                # shutil.copy(os.path.join(root, file),
                #             os.path.join(newPath, file))
                


def remove_nen(dir1, dir2):
    def get_files(folderPath, fileFormat):
        lst = []
        for root, dirs, files in os.walk(folderPath):
            for file in files:
                pattern = re.compile(".*"+fileFormat+"$")

                if pattern.match(file):
                    # lst.append(os.path.join(root, file))
                    lst.append(os.path.join(file))
                    # lst.append(os.path.splitext(file)[0])
        return lst

    # dir3 = r'E:\Chua nen'

    lstPdf1 = get_files(dir1, 'pdf')
    lstPdf2 = get_files(dir2, 'pdf')
    # lstPdf3 = get_files(dir3, 'pdf')

    lstDuplicate = list(set(lstPdf1) & set(lstPdf2))
    # lstNotDuplicate = list(set(lstPdf1) - set(lstPdf2) - set(lstPdf3))

    # print(len(lstDuplicate))

    for root, dirs, files in os.walk(dir1):
        for file in files:
            if (file in lstDuplicate):
                print(os.path.join(root, file))
                os.remove(os.path.join(root, file))


def create_struct(pathRoot, pathTarget):
    count = 0
    for root, dirs, files in os.walk(pathRoot):
        for fileName in files:
            try:
                head, tail = (os.path.split(
                    Path(os.path.join(root, fileName))))
                if (len(tail.split('.')) > 6):
                    newPath = os.path.join(pathTarget, tail.split('.')[0], tail.split('.')[
                                           1], tail.split('.')[2], tail.split('.')[3])
                    Path(newPath).mkdir(parents=True, exist_ok=True)
                    # os.path.splitext(tail)[0]
                    # os.path.splitext(tail)[1]
                    if not os.path.exists(os.path.join(newPath, tail.replace(' ', ''))):
                        shutil.move(os.path.join(root, fileName), os.path.join(
                            newPath, tail.replace(' ', '')))
                        count += 1
                    else:
                        pass
                        # print(os.path.join(root, fileName))
                        # with open('error.txt', 'a', encoding='utf8') as f:
                        # print(os.path.join(root, fileName))
                        # f.write(os.path.join(root, fileName) + '\n')
            except:
                # with open('error.txt', 'a', encoding='utf8') as f:
                # print(os.path.join(root, fileName))
                # f.write(os.path.join(root, fileName) + '\n')
                pass
    print(count)

def check_duplicate(dir1, dir2):
    def get_files(folderPath, fileFormat):
        lst = []
        for root, dirs, files in os.walk(folderPath):
            for file in files:
                pattern = re.compile(".*"+fileFormat+"$")

                if pattern.match(file):
                    # lst.append(os.path.join(root, file))
                    lst.append(os.path.join(file))
                    # lst.append(os.path.splitext(file)[0])
        return lst

    lstPdf1 = get_files(dir1, 'pdf')
    lstPdf2 = get_files(dir2, 'pdf')

    # lstDaCopy = get_files(r'E:\OCR NEN', 'pdf')
    # lstPdf3 = get_files(dir3, 'pdf')

    # lstDuplicate = list(set(lstPdf1) & set(lstPdf2))
    lstNotDuplicate = list(set(lstPdf1) - set(lstPdf2))

    print(len(lstNotDuplicate))
    
check_duplicate(r'')
