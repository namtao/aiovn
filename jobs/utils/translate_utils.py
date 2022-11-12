import os

from googletrans import Translator


def trans():
    text1 = '''Python is an easy to learn, powerful programming language'''
    translator = Translator()
    # print(translator.detect(text1))
    print(translator.translate(text1, src='en', dest='vi').text)  # type: ignore
