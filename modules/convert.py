import json
import os
import re
from pathlib import Path
import shutil

import pyttsx3
import requests
from bs4 import BeautifulSoup
from gtts import gTTS
from halo import Halo
from pdf2image import convert_from_path
from PIL import Image


@Halo()
def jpg_to_pdf(jpg_folder_path, pdf_folder_path):
    def merge_jpg_to_pdf(lstImage, pdfPath):
        images = [Image.open(f) for f in lstImage]

        images[0].save(
            pdfPath, "PDF", resolution=300.0, save_all=True, append_images=images[1:]
        )

    for root, dirs, files in os.walk(jpg_folder_path):
        lstJpg = []
        if len(files) > 0:
            # lstJpg = [os.path.join(root, file) for file in files if(re.compile("*jpg$").match(file))]
            for file in files:
                # $ regex kết thúc là ký tự trc $
                if re.compile(".*jpg$").match(file):
                    lstJpg.append(os.path.join(root, file))
            # parent = root.split('\\')[-1]
            # folderPath = os.path.join(pdf_folder_path)
            folderPath = os.path.join(
                pdf_folder_path, root.split("/")[-2], root.split("/")[-1]
            )
            if not os.path.exists(folderPath):
                Path(folderPath).mkdir(parents=True, exist_ok=True)
            pdfPath = os.path.join(pdf_folder_path, folderPath, "ghep.pdf")

            if len(lstJpg) > 0:
                merge_jpg_to_pdf(lstJpg, pdfPath)
                
            # jpf tp pdf one file
            # for file in files:
            #     # $ regex kết thúc là ký tự trc $
            #     if re.compile(".*jpg$").match(file) and len(file.split(".")) >= 6 and 'TEMP' not in str(root):                    
            #         newPath = os.path.join(pdf_folder_path, root[3:])
            #         Path(newPath).mkdir(parents=True, exist_ok=True)
            #         head, tail = os.path.splitext(file)

            #         images = Image.open(os.path.join(root, file))
            #         file_name_pdf = os.path.join(newPath, head + ".pdf")
            #         if(not os.path.exists(file_name_pdf)):
            #             images.save(
            #                 file_name_pdf, "PDF", resolution=300.0, save_all=True
            #             )
            #             count += 1
            #             print(count)
            #     elif re.compile(".*pdf$").match(file) and len(file.split(".")) >= 6 and 'TEMP' not in str(root):

            #         newPath = os.path.join(pdf_folder_path, root[3:])

            #         Path(newPath).mkdir(parents=True, exist_ok=True)
            #         head, tail = os.path.splitext(file)

            #         if(not os.path.exists(os.path.join(newPath, file))):
            #             shutil.copy(
            #                 os.path.join(root, file),
            #                 os.path.join(
            #                     newPath,
            #                     file,
            #                 ),
            #             )

            #             count += 1
            #             print(count)


@Halo()
def pdf_to_jpg(pdf_folder_path, jpg_folder_path):
    # pytesseract.pytesseract.tesseract_cmd = r"C:\Program Files\Tesseract-OCR\tesseract.exe"
    Image.MAX_IMAGE_PIXELS = 1000000000000

    for root, dirs, files in os.walk(pdf_folder_path):
        for file in files:
            pattern = re.compile(".*pdf$")
            if pattern.match(file):
                pages = convert_from_path(os.path.join(root, file), 300)
                image_counter = 1
                for page in pages:
                    filename = (
                        os.path.splitext(file)[0]
                        + "#"
                        + str(image_counter).zfill(5)
                        + ".jpg"
                    )

                    output_path = os.path.join(jpg_folder_path, filename)
                    if not os.path.exists(output_path):
                        page.save(output_path, "JPEG")
                    image_counter = image_counter + 1

def text2speech():
    def save_mp3(text, path):
        # f = open(r"C:\Projects\Python\tts.txt", "r+", encoding="utf-8")
        # print(f.read())
        engine = pyttsx3.init("sapi5")
        rate = engine.getProperty("rate")
        # engine.setProperty('rate', 180)
        voices = engine.getProperty("voices")
        engine.setProperty("voice", voices[1].id)
        # engine.say(f.read())
        # engine.say(text)
        # engine.save_to_file(text, r'C:\Projects\Python\test.mp3')
        # engine.stop()
        # os.system('start test.mp3')
        engine.save_to_file(text, path)

        engine.runAndWait()

    # coding=utf-8
    def save_mp3_fpt(text, path):
        url = "https://api.fpt.ai/hmi/tts/v5"

        payload = text

        headers = {
            "api-key": "M4F4yIYGEiXa2U22V1AqWwhWQCVQMQLq",
            "speed": "",
            "voice": "banmai",
        }

        response = requests.request(
            "POST", url, data=payload.encode("utf-8"), headers=headers
        )

        # print(response.text)
        soup = BeautifulSoup(response.content, "html.parser")
        site_json = json.loads(soup.text)

        for key, value in site_json.items():
            # print (value)
            response = requests.get(value)

            file = open(path, "wb")
            file.write(response.content)
            file.close()

            break

    def mp3_to_mp4(pathmp3, chaper):
        cmd = (
            "ffmpeg -loop 1 -framerate 1 -i background.jpg -i "
            + '"'
            + chaper
            + '.mp3"'
            + " -map 0:v -map 1:a -r 10 -vf \"scale='iw-mod(iw,2)':'ih-mod(ih,2)',format=yuv420p\" -movflags +faststart -shortest -fflags +shortest -max_interleave_delta 100M "
            + '"'
            + chaper
            + '.mp4"'
        )
        os.chdir(pathmp3)
        os.system(cmd)

    def m3u8_to_mp3(linkm3u8, chaper):
        cmd = (
            "ffmpeg -allowed_extensions ALL -i "
            + linkm3u8
            + " -map 0:a -acodec libmp3lame "
            + '"'
            + chaper
            + '.mp3"'
        )
        os.system(cmd)

    def get_link_m3u8(text):
        url = "https://zalo.ai/api/demo/v1/tts/synthesize"

        # text.encode('utf-8')  # Totally fine.
        payload = (
            "input=" + text + "&speaker_id=" + "1" + "&speed=" + "1.0" + "&dict_id=0"
        )
        headers = {
            "content-type": "application/x-www-form-urlencoded; charset=utf-8",
            "origin": "https://zalo.ai",
            "referer": "https://zalo.ai/experiments/text-to-audio-converter",
            "cookie": "zpsid=eMKnVbo-PZEvNHqtDTKIOgHQ7p4nrWzalI47O4wZJssuT3bRV_irVuyWFcWShorgrNnyH1sN7H_cHL08DySx4jayN3Kgv2SblZf95sovCHgQRaSg; zai_did=8k9uAj3FNiTevcSSryzXoYYo64d0o6V3AB4PHJ8q; zpsidleg=eMKnVbo-PZEvNHqtDTKIOgHQ7p4nrWzalI47O4wZJssuT3bRV_irVuyWFcWShorgrNnyH1sN7H_cHL08DySx4jayN3Kgv2SblZf95sovCHgQRaSg; zai_sid=lf2zTzCfGqIZbxznrofUGhhifo2eNnvBlxcP6va7P5c8xPue-bDyJDAnt0JxQqmvuOZmID4xQZJUyVnrp1Xs0xdtwLUAHM0ydQFdQl1IIGRigkzd; __zi=3000.SSZzejyD0jydXQcYsa00d3xBfxgP71AM8Tdbg8yB7SWftQxdY0aRp2gIh-QFHXF2BvMWxp0mDW.1; fpsend=149569; _zlang=vn",
        }

        response = requests.request(
            "POST", url, data=payload.encode("utf-8"), headers=headers
        )
        # f = open(r'C:\Users\ADMIN\Downloads\out.txt', "w")

        return json.loads(response.text)["data"]["url"]

    def google_TTS(text, path):
        # tts = gTTS(text='Good morning', lang='en')

        tts = gTTS(text=text, lang="vi", slow=False)

        # tts = gTTS(text='안녕하세요', lang='ko')

        tts.save(path + ".mp3")


# jpg_to_pdf(r'/home/vannam/Downloads/a', r'/home/vannam/Downloads/a')
pdf_to_jpg(r'/home/vannam/Downloads/a', r'/home/vannam/Downloads/a')