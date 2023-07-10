from collections import Counter

lst1 = []
lst2 = []


with open(r"other\lst1.txt", "r") as fr:
    lst1 = fr.read().splitlines()

with open(r"other\lst2.txt", "r") as fr:
    lst2 = fr.read().splitlines()

lstDuplicate = list(set(lst1) & set(lst2))
# lstNotDuplicate = list(set(lst1) - set(lst2))
# lstNotDuplicate = list(set(lst2) - set(lst1))

with open(r"other\ketqua.txt", "w+") as fw:
    # check duplicate
    # dup = {item for item, count in Counter(lst1).items() if count > 1}
    try:
        for i in lstDuplicate:
            # for i in lstNotDuplicate:
            # for i in dup:
            # for i in lstDuplicate:

            fw.write(i + "\n")

    except Exception as e:
        print(e)
