from config.config import db_connect
from models.bienmuc import Config
from models.hotich import *
from sqlalchemy.orm import Session
from sqlmodel import Session, select


def get_data_by_id(localName, tableName, id):
    with Session(db_connect(localName)) as session:
        statement = select(tableName).where(Config.id == id)
        return session.exec(statement).first()
        

def update_bienmuc(localName, tableName, id, thongtin):
    with Session(db_connect(localName)) as session:
        statement = select(tableName).where(Config.id == id)
        results = session.exec(statement)
        row = results.one()
        row.thongtin = thongtin
        session.commit()
