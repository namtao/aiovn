kyhieu = "NE"
so = 700
hautoT = "T"
hautoS = "S"


with open(r"other\timso.txt", "r") as fr:
    with open(r"other\ketqua.txt", "w+") as fw:
        lst = fr.read().splitlines()

        for s in range(1, int(so) + 1):
            try:
                NotT = kyhieu + f"{s:05}"
                T = kyhieu + f"{s:05}" + hautoT
                S = kyhieu + f"{s:05}" + hautoS

                # if(NotT not in lst):
                #     fw.write(NotT + '\n')

                if S not in lst:
                    fw.write(S + "\n")

                if T not in lst:
                    fw.write(T + "\n")

            except Exception as e:
                print(e)
                print(lst[s - 1])
