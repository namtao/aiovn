import os


def get_files(folderPath, fileFormat):
    lst = []
    for root, dirs, files in os.walk(folderPath):
        for file in files:
            if file.endswith("." + fileFormat):
                # lst.append(os.path.join(root, file))
                print(os.path.join(root, file))

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
    # renames all subforders of dir, not including dir itself
    # dir = os.path.dirname(os.path.abspath(__file__))

    index = 0

    def rename_all(root, items):
        for name in items:
            try:
                global index
                index += 1
                os.rename(os.path.join(root, name),
                          os.path.join(root, strA + str(index) + str(os.path.splitext(os.path.join(root, name))[1].lower())))
            except OSError:
                pass  # can't rename it, so what
    for root, dirs, files in os.walk(dir, topdown=False):
        # rename_all(root, dirs)
        rename_all(root, files)


# lst = []
# index = 0
# for root, dirs, files in os.walk(r'\\192.168.31.127\New folder (2)\new\so ldtbxh-000.00.38.H41\G07-LD11(vl)', 'pdf'):
#     for file in files:
#         if file.endswith("." + 'pdf'):
#             # lst.append(os.path.join(root, file))
#             # print(os.path.join(root, file))
#             index+=1
#             print(str(index))
#             shutil.copyfile(os.path.join(root, file), os.path.join(r'\\192.168.31.127\New folder (2)\new\new', '000.00.38.H41.G07-LD11.' + str(index) + '.pdf'))

rename(r'\\192.168.31.127\New folder (2)\new\so vhtt 000.00.46.H41\G16-VH14',
       '000.00.46.H41.' + 'G16-VH14.')
