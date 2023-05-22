from config.config import db_connect
from models.bienmuc import *
from sqlmodel import SQLModel


# tạo khi chưa có và không update khi đã có
def create_table():
    SQLModel.metadata.create_all(db_connect('hn'))



