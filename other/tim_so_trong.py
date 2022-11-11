kyhieu = 'NEKT'
so = 6000
hauto = 'T'



with open(r'other\timso.txt', 'r') as fr:   
    with open(r'other\ketqua.txt', 'w+') as fw:   
        
        lst = fr.read().splitlines() 
        
             
        for s in range(1, int(so) + 1):
            try:
            
                NotT = kyhieu + f'{s:05}'
                T = kyhieu + f'{s:05}' + hauto
                
                if(NotT not in lst):
                    fw.write(NotT + '\n')
                    
                if(T not in lst):
                    fw.write(T + '\n')
                    
            except Exception as e:
                print(e)
                print(lst[s-1])
                
            
                