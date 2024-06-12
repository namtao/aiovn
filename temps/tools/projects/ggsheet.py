import re
import gspread
from oauth2client.service_account import ServiceAccountCredentials
import gdown
import os
import datetime

scopes = [
    "https://www.googleapis.com/auth/spreadsheets",
    "https://www.googleapis.com/auth/drive",
]


def download_ggsheet(url, output):

    if str(url).strip() and str(output).strip() and "drive.google" in url:
        gdown.download_folder(url=url, output=output, use_cookies=False)


def crawl_ggsheet():

    creds = ServiceAccountCredentials.from_json_keyfile_name(
        r"C:\Projects\artificial-brains\temps\tools\projects\crawl-gg-sheet-6b8a3bc1720e.json"
    )

    file = gspread.authorize(creds)
    workbook = file.open("LOG 2024")
    sheet = workbook.sheet1

    for row_index in range(100):
        row_value = sheet.row_values(row_index + 24)

        while len(row_value) != 4:
            row_value.append("")

        date_str = row_value[0].strip()
        if len(date_str.split("/")[0].strip()) > 0:
            try:
                # Extract and convert the date
                ngay, thang, nam = map(int, date_str.split("/"))
                ngay_thang_nam = datetime.datetime(nam, thang, ngay).strftime(
                    "%Y-%m-%d"
                )

                # Extract and sanitize the name
                ten = " ".join(re.findall(r"[^\W_]+", row_value[2]))

                # Extract the link
                link = row_value[3]

                # Construct the output path
                output = os.path.join(
                    r"C:\Users\vanna\OneDrive\AI VIET NAM\03. Module 01",
                    ngay_thang_nam,
                    ten,
                )

                # Print and download the file
                print(f"Date: {ngay_thang_nam}, Name: {ten}, Link: {link}")
                download_ggsheet(url=link, output=output)
            except ValueError as e:
                print(f"Error processing date '{date_str}' in row: {e}")
            except Exception as e:
                print(f"Unexpected error processing row: {e}")


crawl_ggsheet()
