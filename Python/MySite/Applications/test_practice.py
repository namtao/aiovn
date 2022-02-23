import re

pattern = '^a...s$'
test_string = 'abyssa'
result = re.match(pattern, test_string)

if result:
  print("Tim kiem thanh cong.")
else:
  print("Tim kiem khong thanh cong.")