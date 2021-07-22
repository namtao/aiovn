from gtts import gTTS
import playsound

tts = gTTS('TN/CN: 15.35 /                                  15.50', lang='vi')
a =  r'C:\Projects\Python\hello.mp3'
tts.save(a)
playsound.playsound(a)

