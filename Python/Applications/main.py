from craw_data.craw import *
from database.read_db_dsg import *
import m3u8
from utils.excel_utils import *

if __name__ == "__main__":
    # crawl_audio_book_zalo_ai("https://nhasachmienphi.com/doi-ngan-dung-ngu-dai.html")

    write_to_excel(read_from_excel(
        r'C:\Users\ADMIN\Downloads\HS TAQB PM_cần đổi mã.xlsx'), r'C:\Users\ADMIN\Downloads\HS TAQB PM.xlsx')
