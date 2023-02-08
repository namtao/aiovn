from collections import Counter

with open(r'other\lst1.txt', 'r') as fr:
    lst1 = fr.read().splitlines()
    
print({item for item, count in Counter(lst1).items() if count > 1})
