from PyQt6 import QtWidgets, uic, QtGui
import sys

class Ui(QtWidgets.QMainWindow):
    def __init__(self):
        super(Ui, self).__init__()
        uic.loadUi(r'interface\design\Home.ui', self)
        self.show()
        self.btnExe.clicked.connect(self.btnXoa)
        self.setWindowIcon(QtGui.QIcon(r'interface\image\icon.ico'))
    
    def btnXoa(self):
        self.win2 = Ui2()
        self.win2.show()
    
        
        
class Ui2(QtWidgets.QMainWindow):
    def __init__(self):
        super(Ui2, self).__init__()
        uic.loadUi(r'interface\design\test2.ui', self)
        # self.show()

app = QtWidgets.QApplication(sys.argv)
window = Ui()
app.exec()