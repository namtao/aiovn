import os


def format_str(strA):
    specialcharacters = ['\\', '/', ':', '*', '?', '"', ',', '<', '>', '|']
    for i in strA:
        if (i in specialcharacters):
            strA = strA.replace(i, "")

    return str(strA)


def compound_unicode(unicode_str):
    """
    Chuyển đổi chuỗi Unicode Tổ Hợp sang Unicode Dựng Sẵn
    """
    dict_compound = {'\u0065\u0309': '\u1EBB', '\u0065\u0301': '\u00E9', '\u0065\u0300': '\u00E8',
                     '\u0065\u0323': '\u1EB9', '\u0065\u0303': '\u1EBD', '\u00EA\u0309': '\u1EC3',
                     '\u00EA\u0301': '\u1EBF', '\u00EA\u0300': '\u1EC1', '\u00EA\u0323': '\u1EC7',
                     '\u00EA\u0303': '\u1EC5', '\u0079\u0309': '\u1EF7', '\u0079\u0301': '\u00FD',
                     '\u0079\u0300': '\u1EF3', '\u0079\u0323': '\u1EF5', '\u0079\u0303': '\u1EF9',
                     '\u0075\u0309': '\u1EE7', '\u0075\u0301': '\u00FA', '\u0075\u0300': '\u00F9',
                     '\u0075\u0323': '\u1EE5', '\u0075\u0303': '\u0169', '\u01B0\u0309': '\u1EED',
                     '\u01B0\u0301': '\u1EE9', '\u01B0\u0300': '\u1EEB', '\u01B0\u0323': '\u1EF1',
                     '\u01B0\u0303': '\u1EEF', '\u0069\u0309': '\u1EC9', '\u0069\u0301': '\u00ED',
                     '\u0069\u0300': '\u00EC', '\u0069\u0323': '\u1ECB', '\u0069\u0303': '\u0129',
                     '\u006F\u0309': '\u1ECF', '\u006F\u0301': '\u00F3', '\u006F\u0300': '\u00F2',
                     '\u006F\u0323': '\u1ECD', '\u006F\u0303': '\u00F5', '\u01A1\u0309': '\u1EDF',
                     '\u01A1\u0301': '\u1EDB', '\u01A1\u0300': '\u1EDD', '\u01A1\u0323': '\u1EE3',
                     '\u01A1\u0303': '\u1EE1', '\u00F4\u0309': '\u1ED5', '\u00F4\u0301': '\u1ED1',
                     '\u00F4\u0300': '\u1ED3', '\u00F4\u0323': '\u1ED9', '\u00F4\u0303': '\u1ED7',
                     '\u0061\u0309': '\u1EA3', '\u0061\u0301': '\u00E1', '\u0061\u0300': '\u00E0',
                     '\u0061\u0323': '\u1EA1', '\u0061\u0303': '\u00E3', '\u0103\u0309': '\u1EB3',
                     '\u0103\u0301': '\u1EAF', '\u0103\u0300': '\u1EB1', '\u0103\u0323': '\u1EB7',
                     '\u0103\u0303': '\u1EB5', '\u00E2\u0309': '\u1EA9', '\u00E2\u0301': '\u1EA5',
                     '\u00E2\u0300': '\u1EA7', '\u00E2\u0323': '\u1EAD', '\u00E2\u0303': '\u1EAB',
                     '\u0045\u0309': '\u1EBA', '\u0045\u0301': '\u00C9', '\u0045\u0300': '\u00C8',
                     '\u0045\u0323': '\u1EB8', '\u0045\u0303': '\u1EBC', '\u00CA\u0309': '\u1EC2',
                     '\u00CA\u0301': '\u1EBE', '\u00CA\u0300': '\u1EC0', '\u00CA\u0323': '\u1EC6',
                     '\u00CA\u0303': '\u1EC4', '\u0059\u0309': '\u1EF6', '\u0059\u0301': '\u00DD',
                     '\u0059\u0300': '\u1EF2', '\u0059\u0323': '\u1EF4', '\u0059\u0303': '\u1EF8',
                     '\u0055\u0309': '\u1EE6', '\u0055\u0301': '\u00DA', '\u0055\u0300': '\u00D9',
                     '\u0055\u0323': '\u1EE4', '\u0055\u0303': '\u0168', '\u01AF\u0309': '\u1EEC',
                     '\u01AF\u0301': '\u1EE8', '\u01AF\u0300': '\u1EEA', '\u01AF\u0323': '\u1EF0',
                     '\u01AF\u0303': '\u1EEE', '\u0049\u0309': '\u1EC8', '\u0049\u0301': '\u00CD',
                     '\u0049\u0300': '\u00CC', '\u0049\u0323': '\u1ECA', '\u0049\u0303': '\u0128',
                     '\u004F\u0309': '\u1ECE', '\u004F\u0301': '\u00D3', '\u004F\u0300': '\u00D2',
                     '\u004F\u0323': '\u1ECC', '\u004F\u0303': '\u00D5', '\u01A0\u0309': '\u1EDE',
                     '\u01A0\u0301': '\u1EDA', '\u01A0\u0300': '\u1EDC', '\u01A0\u0323': '\u1EE2',
                     '\u01A0\u0303': '\u1EE0', '\u00D4\u0309': '\u1ED4', '\u00D4\u0301': '\u1ED0',
                     '\u00D4\u0300': '\u1ED2', '\u00D4\u0323': '\u1ED8', '\u00D4\u0303': '\u1ED6',
                     '\u0041\u0309': '\u1EA2', '\u0041\u0301': '\u00C1', '\u0041\u0300': '\u00C0',
                     '\u0041\u0323': '\u1EA0', '\u0041\u0303': '\u00C3', '\u0102\u0309': '\u1EB2',
                     '\u0102\u0301': '\u1EAE', '\u0102\u0300': '\u1EB0', '\u0102\u0323': '\u1EB6',
                     '\u0102\u0303': '\u1EB4', '\u00C2\u0309': '\u1EA8', '\u00C2\u0301': '\u1EA4',
                     '\u00C2\u0300': '\u1EA6', '\u00C2\u0323': '\u1EAC', '\u00C2\u0303': '\u1EAA'}

    for k, v in dict_compound:
        unicode_str = unicode_str.replace(k, v)
    return unicode_str


def string_search_from_multiple_files(path):
    text = input("input text : ")

    # path = input("path : ")
    f = 0
    os.chdir(path)
    files = os.listdir()
    # print(files)
    for file_name in files:
        abs_path = os.path.abspath(file_name)
        if os.path.isdir(abs_path):
            string_search_from_multiple_files(abs_path)
        if os.path.isfile(abs_path):
            f = open(file_name, "r")
            if text in f.read():
                f = 1
                print(text + " found in ")
                final_path = os.path.abspath(file_name)
                print(final_path)
                return True

    if f == 1:
        print(text + " not found! ")
        return False
    
    
def removeEscape(value):
    return ' '.join(str(value).splitlines()).strip()
