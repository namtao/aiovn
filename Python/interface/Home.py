import eel, os, random

eel.init(r'interface\web')

@eel.expose
def pick_file(folder):
    if os.path.isdir(folder):
        return random.choice(os.listdir(folder))
    else:
        return 'Not valid folder'

def close_callback(route, websockets):
    if not websockets:
        exit()


eel.start('error-404.html', size=(320, 120), close_callback=close_callback)