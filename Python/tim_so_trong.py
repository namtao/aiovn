
kyhieu = input('Nhập ký hiệu: ') # NELCAI
so = input('Nhập số max: ') # 6200

lst = []
with open('timso.txt', 'r') as fr:   
    with open('ketqua.txt', 'w+') as fw:   
        # thêm số vào lst
        for s_line in fr:
            lst.append(int(s_line.strip()[(len(kyhieu)+2):]))
            
        # kiểm tra số không có
        for s in range(1, int(so) + 1):
            if(int(s) not in lst): 
                fw.write(kyhieu + '-T' + f'{s:05}' + '\n')