# -*- coding: utf-8 -*-

################################################################################
## Form generated from reading UI file 'Home.ui'
##
## Created by: Qt User Interface Compiler version 6.4.0
##
## WARNING! All changes made in this file will be lost when recompiling UI file!
################################################################################

from PySide6.QtCore import (QCoreApplication, QDate, QDateTime, QLocale,
    QMetaObject, QObject, QPoint, QRect,
    QSize, QTime, QUrl, Qt)
from PySide6.QtGui import (QAction, QBrush, QColor, QConicalGradient,
    QCursor, QFont, QFontDatabase, QGradient,
    QIcon, QImage, QKeySequence, QLinearGradient,
    QPainter, QPalette, QPixmap, QRadialGradient,
    QTransform)
from PySide6.QtWidgets import (QApplication, QHeaderView, QLabel, QLineEdit,
    QMainWindow, QMenu, QMenuBar, QPushButton,
    QSizePolicy, QStatusBar, QTreeView, QWidget)

class Ui_MainWindow(object):
    def setupUi(self, MainWindow):
        if not MainWindow.objectName():
            MainWindow.setObjectName(u"MainWindow")
        MainWindow.resize(796, 552)
        self.btnXoaRac = QAction(MainWindow)
        self.btnXoaRac.setObjectName(u"btnXoaRac")
        self.centralwidget = QWidget(MainWindow)
        self.centralwidget.setObjectName(u"centralwidget")
        self.label = QLabel(self.centralwidget)
        self.label.setObjectName(u"label")
        self.label.setGeometry(QRect(40, 30, 81, 31))
        self.txtPath = QLineEdit(self.centralwidget)
        self.txtPath.setObjectName(u"txtPath")
        self.txtPath.setGeometry(QRect(110, 29, 271, 31))
        self.btnExe = QPushButton(self.centralwidget)
        self.btnExe.setObjectName(u"btnExe")
        self.btnExe.setGeometry(QRect(424, 32, 131, 31))
        self.tree = QTreeView(self.centralwidget)
        self.tree.setObjectName(u"tree")
        self.tree.setGeometry(QRect(40, 80, 721, 431))
        self.btnCheck = QPushButton(self.centralwidget)
        self.btnCheck.setObjectName(u"btnCheck")
        self.btnCheck.setGeometry(QRect(580, 30, 131, 31))
        MainWindow.setCentralWidget(self.centralwidget)
        self.menubar = QMenuBar(MainWindow)
        self.menubar.setObjectName(u"menubar")
        self.menubar.setGeometry(QRect(0, 0, 796, 21))
        self.menuFile = QMenu(self.menubar)
        self.menuFile.setObjectName(u"menuFile")
        self.menuTools = QMenu(self.menubar)
        self.menuTools.setObjectName(u"menuTools")
        self.menuChuy_n_i = QMenu(self.menubar)
        self.menuChuy_n_i.setObjectName(u"menuChuy_n_i")
        self.menuTi_n_ch = QMenu(self.menubar)
        self.menuTi_n_ch.setObjectName(u"menuTi_n_ch")
        self.menuC_u_h_nh = QMenu(self.menubar)
        self.menuC_u_h_nh.setObjectName(u"menuC_u_h_nh")
        self.menuTr_gi_p = QMenu(self.menubar)
        self.menuTr_gi_p.setObjectName(u"menuTr_gi_p")
        MainWindow.setMenuBar(self.menubar)
        self.statusbar = QStatusBar(MainWindow)
        self.statusbar.setObjectName(u"statusbar")
        MainWindow.setStatusBar(self.statusbar)

        self.menubar.addAction(self.menuFile.menuAction())
        self.menubar.addAction(self.menuTools.menuAction())
        self.menubar.addAction(self.menuChuy_n_i.menuAction())
        self.menubar.addAction(self.menuTi_n_ch.menuAction())
        self.menubar.addAction(self.menuC_u_h_nh.menuAction())
        self.menubar.addAction(self.menuTr_gi_p.menuAction())
        self.menuTools.addAction(self.btnXoaRac)

        self.retranslateUi(MainWindow)

        QMetaObject.connectSlotsByName(MainWindow)
    # setupUi

    def retranslateUi(self, MainWindow):
        MainWindow.setWindowTitle(QCoreApplication.translate("MainWindow", u"Home", None))
        self.btnXoaRac.setText(QCoreApplication.translate("MainWindow", u"X\u00f3a r\u00e1c", None))
        self.label.setText(QCoreApplication.translate("MainWindow", u"\u0110\u01b0\u1eddng d\u1eabn", None))
        self.btnExe.setText(QCoreApplication.translate("MainWindow", u"Th\u1ef1c hi\u1ec7n", None))
        self.btnCheck.setText(QCoreApplication.translate("MainWindow", u"Ki\u1ec3m tra", None))
        self.menuFile.setTitle(QCoreApplication.translate("MainWindow", u"File", None))
        self.menuTools.setTitle(QCoreApplication.translate("MainWindow", u"C\u00f4ng c\u1ee5", None))
        self.menuChuy_n_i.setTitle(QCoreApplication.translate("MainWindow", u"Chuy\u1ec3n \u0111\u1ed5i", None))
        self.menuTi_n_ch.setTitle(QCoreApplication.translate("MainWindow", u"Ti\u1ec7n \u00edch", None))
        self.menuC_u_h_nh.setTitle(QCoreApplication.translate("MainWindow", u"C\u1ea5u h\u00ecnh", None))
        self.menuTr_gi_p.setTitle(QCoreApplication.translate("MainWindow", u"Tr\u1ee3 gi\u00fap", None))
    # retranslateUi

