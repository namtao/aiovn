from config.config import db_connect
from models.bienmuc import Config
from models.hotich import *
from sqlalchemy.orm import Session
from sqlmodel import Session, select


def get_data_by_id(localName, id):
    with Session(db_connect(localName)) as session:
        statement = select(Config).where(Config.id == id)
        print(session.exec(statement).first())