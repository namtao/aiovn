import time
from datetime import datetime

presentDate = datetime.now()
# expire = datetime.now() + datetime.timedelta(
#     seconds=1
# )
print(int(datetime.timestamp(presentDate)))
# print(int(datetime.timestamp(expire)))


# 1671981773
# 1671956587

ts = 1671981773

# if you encounter a "year is out of range" error the timestamp
# may be in milliseconds, try `ts /= 1000` in that case
print(datetime.utcfromtimestamp(ts).strftime('%Y-%m-%d %H:%M:%S'))
