import os


def get_files(folderPath, fileFormat):
    lst = []
    for root, dirs, files in os.walk(folderPath):
        for file in files:
            if file.endswith("." + fileFormat):
                lst.append(os.path.join(root, file))
                # print(os.path.join(root, file))

    return lst


# rename file
def replace(folderPath, before, after):
    with open(r"error.txt", "a", encoding="utf-8") as f:
        for root, dirs, files in os.walk(folderPath):
            for file in files:
                if file.endswith(".pdf"):
                    try:
                        os.rename(os.path.join(root, file), os.path.join(
                            root, file.replace(before, after)))
                    except:
                        f.writelines(os.path.join(root, file) + '\n')


def case_rename(dir):
    # renames all subforders of dir, not including dir itself
    # dir = os.path.dirname(os.path.abspath(__file__))
    def rename_all(root, items):
        for name in items:
            try:
                os.rename(os.path.join(root, name),
                          os.path.join(root, name.lower()))
            except OSError:
                pass  # can't rename it, so what

    # starts from the bottom so paths further up remain valid after renaming
    for root, dirs, files in os.walk(dir, topdown=False):
        rename_all(root, dirs)
        rename_all(root, files)


def before_rename(dir, str):
    # renames all subforders of dir, not including dir itself
    # dir = os.path.dirname(os.path.abspath(__file__))
    def rename_all(root, items):
        for name in items:
            try:
                os.rename(os.path.join(root, name),
                          os.path.join(root, str + name.upper()))
            except OSError:
                pass  # can't rename it, so what

    # starts from the bottom so paths further up remain valid after renaming
    for root, dirs, files in os.walk(dir, topdown=False):
        # rename_all(root, dirs)
        rename_all(root, files)


def after_rename(dir, str):
    # renames all subforders of dir, not including dir itself
    # dir = os.path.dirname(os.path.abspath(__file__))
    def rename_all(root, items):
        for name in items:
            try:
                os.rename(os.path.join(root, name),
                          os.path.join(root, name.upper() + str))
            except OSError:
                pass  # can't rename it, so what

    # starts from the bottom so paths further up remain valid after renaming
    for root, dirs, files in os.walk(dir, topdown=False):
        # rename_all(root, dirs)
        rename_all(root, files)


def rename(dir, strA):
    def rename_all(root, items):
        lst = get_files(dir, 'JPG')
        index = 0
        for name in items:
            try:
                index += 1
                if(len(str(index)) == 1):
                    tenmoi = os.path.join(strA + '0' + str(index) + str(os.path.splitext(os.path.join(root, name))[1].lower()))
                else:
                    tenmoi = os.path.join(strA + str(index) + str(os.path.splitext(os.path.join(root, name))[1].lower()))
                # kierm tra trùng tên
                while (tenmoi in lst):
                    index += 1
                    
                    if(len(index) == 1):
                        tenmoi = os.path.join(strA + '0' + str(index) + str(os.path.splitext(os.path.join(root, name))[1].lower()))
                    else:
                        tenmoi = os.path.join(strA + str(index) + str(os.path.splitext(os.path.join(root, name))[1].lower()))
                    
                os.rename(os.path.join(root, name),
                          os.path.join(root, tenmoi))
            except OSError:
                pass  # can't rename it, so what
            
    for root, dirs, files in os.walk(dir, topdown=False):
        # rename_all(root, dirs)
        rename_all(root, files)


rename(r'\\192.168.1.110\Share\JPG GOC\KH\2014\31321\01\A4', 'KH.2014.31321.01.A4.')

