from config.config import db_connect
from models.bienmuc import *
from sqlmodel import SQLModel


def create_table():
    SQLModel.metadata.create_all(db_connect('hn'))
    # tạo khi chưa có và không update khi đã có



