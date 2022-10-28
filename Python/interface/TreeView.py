from PySide6 import QtWidgets as qtw
from PySide6 import QtCore as qtc
from PySide6 import QtGui as qtg
import sys


class MainWindow(qtw.QWidget):
    def __init__(self, *args, **kwargs):
        super().__init__(*args, **kwargs)
        # Init UI
        self.width = 540
        self.height = 380
        self.setGeometry(
            qtw.QStyle.alignedRect(
                qtc.Qt.LeftToRight,
                qtc.Qt.AlignCenter,
                self.size(),
                qtg.QGuiApplication.primaryScreen().availableGeometry(),
            ),
        )
        self.tree = qtw.QTreeView()
        self.model = qtw.QFileSystemModel()

        # Items
        self.path_input = qtw.QLineEdit()
        path_label = qtw.QLabel("Enter a path to begin: ")
        check_btn = qtw.QPushButton("Check")  # To display the items
        clear_btn = qtw.QPushButton("Clear")  # To clear the TreeView
        self.start_btn = qtw.QPushButton("Start")  # To start the process
        self.start_btn.setEnabled(False)

        # Layouts
        top_h_layout = qtw.QHBoxLayout()
        top_h_layout.addWidget(path_label)
        top_h_layout.addWidget(self.path_input)
        top_h_layout.addWidget(check_btn)
        bot_h_layout = qtw.QHBoxLayout()
        bot_h_layout.addWidget(clear_btn)
        bot_h_layout.addWidget(self.start_btn)
        main_v_layout = qtw.QVBoxLayout()
        main_v_layout.addLayout(top_h_layout)
        main_v_layout.addWidget(self.tree)
        main_v_layout.addLayout(bot_h_layout)
        self.setLayout(main_v_layout)

        check_btn.clicked.connect(self.init_model)
        clear_btn.clicked.connect(self.clear_model)
        self.start_btn.clicked.connect(self.start)

        self.show()

    def init_model(self):
        self.model.setRootPath(self.path_input.text())
        self.tree.setModel(self.model)
        self.tree.setRootIndex(self.model.index(self.path_input.text()))
        self.tree.setColumnWidth(0, 205)
        self.tree.setAlternatingRowColors(True)
        self.path_input.clear()
        self.start_btn.setEnabled(True)

    def clear_model(self):
        self.tree.setModel(None)
        self.path_input.clear()

    def start(self):
        qtw.QMessageBox.information(self, "Done", "Process completed")


if __name__ == "__main__":
    app = qtw.QApplication(sys.argv)
    w = MainWindow()
    sys.exit(app.exec_())