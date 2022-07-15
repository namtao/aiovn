import os

index = 0


def get_files(folderPath, fileFormat):
    lst = []
    for root, dirs, files in os.walk(folderPath):
        for file in files:
            if file.endswith("." + fileFormat):
                lst.append(os.path.join(file))
                # print(os.path.join(root, file))

    return lst


def rename(dir, strA):
    # renames all subforders of dir, not including dir itself
    # dir = os.path.dirname(os.path.abspath(__file__))
    lst = get_files(r'C:\Users\ADMIN\Downloads\New folder (2)\New folder', 'pdf')

    def rename_all(root, items):
        for name in items:
            global index
            index += 1
            tenmoi = os.path.join(
                strA + str(index) + str(os.path.splitext(os.path.join(root, name))[1].lower()))
            # kierm tra trùng tên
            while (tenmoi in lst):
                index += 1
                tenmoi = os.path.join(
                    strA + str(index) + str(os.path.splitext(os.path.join(root, name))[1].lower()))

            # thực hiện đổi tên
            os.rename(os.path.join(root, name),
                      os.path.join(root, strA + str(index) + str(os.path.splitext(os.path.join(root, name))[1].lower())))

    # chạy thư mục để đổi tên
    for root, dirs, files in os.walk(dir, topdown=False):
        # rename_all(root, dirs)
        rename_all(root, files)


thumuccandoiten = r'C:\Users\ADMIN\Downloads\New folder (2)\New folder (2)'

madinhdanh = '000.00.38.H41.G07-LĐ07.'

rename(thumuccandoiten, madinhdanh)

