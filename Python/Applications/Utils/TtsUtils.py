import pyttsx3
import os

def savemp3(text, path):
    # f = open(r"C:\Projects\Python\tts.txt", "r+", encoding="utf-8")
    # print(f.read())
    engine = pyttsx3.init('sapi5')
    rate = engine.getProperty('rate')
    # engine.setProperty('rate', 180)
    voices = engine.getProperty('voices')
    engine.setProperty('voice', voices[1].id)
    # engine.say(f.read())
    # engine.say(text)
    # engine.save_to_file(text, r'C:\Projects\Python\test.mp3')
    # engine.stop()
    # os.system('start test.mp3')
    engine.save_to_file(text, path)

    engine.runAndWait()

def convert2mp4(pathmp3, chaper):
    cmd = 'ffmpeg -loop 1 -framerate 1 -i background.jpg -i '+'\"' + chaper + '.mp3\"' + \
        ' -map 0:v -map 1:a -r 10 -vf "scale=\'iw-mod(iw,2)\':\'ih-mod(ih,2)\',format=yuv420p" -movflags +faststart -shortest -fflags +shortest -max_interleave_delta 100M ' + \
        '\"' + chaper + '.mp4\"'
    os.chdir(pathmp3)
    os.system(cmd)