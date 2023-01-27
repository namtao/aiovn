lst1=[]
lst2=[]



with open(r'other\lst1.txt', 'r') as fr:
    with open(r'other\ketqua.txt', 'w+') as fw:

        lst1 = fr.read().splitlines()
        
with open(r'other\lst2.txt', 'r') as fr:
    with open(r'other\ketqua.txt', 'w+') as fw:

        lst2 = fr.read().splitlines()

# lstDuplicate = list(set(lst1) & set(lst2))
lstNotDuplicate = list(set(lst1) - set(lst2))

with open(r'other\ketqua.txt', 'w+') as fw:

        try:

            for i in lstNotDuplicate:
            # for i in lstDuplicate:

                fw.write(i + '\n')

        except Exception as e:
            print(e)
