from io_utils import *

macu = '9039'
mamoi = '93018'


folderPath = r'D:\Share\JPG GOC\1. CHO GHEP - CHO DOI TEN\28.07\9039 da ghep+da nhan ban'

lst = get_files(folderPath, 'pdf')
for fileName in lst:
    head, tail = (os.path.split(Path(fileName)))
    vitri = tail.find(macu)
    if(vitri != -1):
        # newName = tail[:vitri] + '93020' + tail[(vitri + 4):]
        newName = os.path.join(Path(fileName).parent, tail.replace(macu, mamoi))
        os.rename(fileName, newName)


