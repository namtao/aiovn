import glob
import os

import pandas as pd
import xlsxwriter

# use glob to get all the csv files
    # in the folder
path = r'C:\Users\ADMIN\Downloads\New folder (2)'
csv_files = glob.glob(os.path.join(path, "*.xlsx"))

# loop over the list of excel files
for f in csv_files:

    # read the excel file
    df = pd.read_excel(f)

    df_new = pd.read_excel(f)

    # set header
    df_new.columns = ['Số tt', 'Sổ KHVB', 'Ngày tháng VB',
                    'Trích yếu nội dung', 'Tác giả văn bản', 'Tờ số', 'ghi chú']

    df_new['Số tt'] = df['Số tt']
    df_new['Sổ KHVB'] = df['Sổ KHVB']
    df_new['Ngày tháng VB'] = df['Ngày tháng VB']
    df_new['Trích yếu nội dung'] = df['Trích yếu nội dung']
    df_new['Tác giả văn bản'] = df['Tác giả văn bản']
    df_new['Tờ số'] = df['Tờ số']
    df_new['ghi chú'] = df['ghi chú']

    os.remove(f)
    writer = pd.ExcelWriter(f, engine='xlsxwriter')

    # df_new.to_excel(f, index=False)

    df_new.to_excel(writer, sheet_name='Sheet1', index=False, header = True)

    workbook = writer.book
    worksheet = writer.sheets['Sheet1']

    border_fmt = workbook.add_format(
        {'bottom': 1, 'top': 1, 'left': 1, 'right': 1})
    worksheet.conditional_format(xlsxwriter.utility.xl_range(0, 0, len(df_new), len(
        df_new.columns) - 1), {'type': 'no_errors', 'format': border_fmt})

    header_format = workbook.add_format({
    'bold': True,
    'text_wrap': True,
    'valign': 'top',
    'fg_color': '#D7E4BC',
    'valign':'vcenter',
    'align':'center',
    'font_size':15,
    'border': 1})
    
    for col_num, value in enumerate(df.columns.values):
        worksheet.write(0, col_num, value, header_format)
        
    format_header = workbook.add_format()
    format_header.set_font_size(30)
    format_header.set_valign('vcenter')
    format_header.set_align('center')
    format_header.set_bold()
    format_header.set_text_wrap()

    format_data = workbook.add_format()
    format_data.set_valign('vcenter')
    format_data.set_align('center')
    format_data.set_text_wrap()

    worksheet.set_column('A:Z', 15, format_data)
    # worksheet.set_row(0, 30, format_header)
    
    writer.save()
