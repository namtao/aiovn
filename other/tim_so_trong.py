
kyhieu = 'NECB'
so = 6000

with open('timso.txt', 'r') as fr:   
    with open('ketqua.txt', 'w+') as fw:   
        
        lst = fr.read().splitlines() 
                
        for s in range(1, int(so) + 1):
            NotT = kyhieu + f'{s:05}'
            # T = kyhieu +'-T' + f'{s:05}'
            
            if(NotT not in lst):
                fw.write(kyhieu + f'{s:05}' + '\n')
                
            # if(T not in lst):
            #     fw.write(kyhieu +'-T' + f'{s:05}' + '\n')
                
            
                