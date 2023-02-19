from config.config import db_connect
from models.bienmuc import Config
from models.hotich import *
from sqlalchemy.orm import Session
from sqlmodel import Session, select


def get_data_by_id(localName, id):
    with Session(db_connect(localName)) as session:
        statement = select(Config).where(Config.id == id)
        # print(session.exec(statement).first())
        

def update_bienmuc():
    with Session(db_connect('hn')) as session:
        statement = select(Config).where(Config.id == 85)
        # results = session.exec(statement)
        # row = results.one()
        # row.thongtin = "a"
        # session.commit()
        print('ok')
