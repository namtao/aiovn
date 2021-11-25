from openpyxl import Workbook


def write_to_excel(arr):

    filename = r"C:\Projects\Python\test.xlsx"

    workbook = Workbook()
    sheet = workbook.active
    sheet.title = 'data'
    for row in range(1, len(arr)+1):
        for col in range(1, len(arr[0])+1):
            sheet.cell(column=col, row=row,
                       value="{0}".format(arr[row-1][col-1]))

    # for row in range(1,101):
    #     for col in range(1,101):
    #         sheet.cell(column=col, row=row, value="{0}".format(get_column_letter(col)))

    workbook.save(filename=filename)
    workbook.close()
