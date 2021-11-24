def format_str(strA):
    specialcharacters = ['\\', '/', ':', '*', '?', '"', ',', '<', '>', '|']
    for i in strA:
        if(i in specialcharacters):
            strA = strA.replace(i, "")

    return str(strA)
