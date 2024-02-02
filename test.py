so_dien = 500

lst_muc = [0, 50,    100,  200,  300,  400,]
lst_gia = [1484, 1533, 1786, 2242, 2503, 2587]

count = 0
for v in lst_muc:
  if(so_dien <= v):
    break
  else:
    count+=1
    
print(count)

if(count >= len(lst_muc)):
    count = len(lst_muc) - 1

so_dien_le = abs(lst_muc[count] - so_dien)

kq = 0
for i in range(count):
    # sum += lst_muc[i+1] - lst_muc[i]
    kq += lst_gia[i] * (lst_muc[i+1] - lst_muc[i])
    print(f'{lst_gia[i]} - {lst_muc[i+1] - lst_muc[i]}')
    
kq += so_dien_le * lst_gia[count]
print(kq)
