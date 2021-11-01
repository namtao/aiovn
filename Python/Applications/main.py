from CrawData.Craw import *
from Database.ReadDbDsg import *
from Utils.TtsUtils import *
import m3u8

if __name__ == "__main__":
    # crawlAudioBookZaloAPi("https://nhasachmienphi.com/doi-ngan-dung-ngu-dai.html")
    # getDB()

    crawlAudioBookZaloAI("https://nhasachmienphi.com/doi-ngan-dung-ngu-dai.html")

    # googleTTS('\n' + ' ', r'C:\Audio\Đời Ngắn Đừng Ngủ Dài.mp3')