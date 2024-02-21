import datetime
import os

def count_file_in_day(dir_path):
    count = 0
    for root, dirs, files in os.walk(dir_path):
        for file in files:
            date_modifier = os.path.getmtime(os.path.join(root, file))
            date_create = os.path.getctime(os.path.join(root, file))

            current_date = datetime.datetime.now().strftime("%d/%m/%Y")
            file_date = datetime.datetime.fromtimestamp(min(date_modifier, date_create)).strftime("%d/%m/%Y")

            if(file_date == current_date):
                count+=1

    return count

print(count_file_in_day(r'\\192.168.1.14\Users\Admin\Desktop\Thu vien Thai Nguyen'))
print(count_file_in_day(r'\\192.168.1.16\Users\Admin\Desktop\Thu vien Thai Nguyen'))