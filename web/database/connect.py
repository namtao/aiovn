
from typing import Optional

from config.config import db_connect
from models.hotich import *
from sqlalchemy.orm import Session
from sqlmodel import Field, Session, SQLModel, select

from web.models.bienmuc import Config


class Config(SQLModel, table=True):
    id: Optional[int] = Field(default=None, primary_key=True)
    loaihoso: str
    mota: str
    truongthongtin: str
       

with Session(db_connect('hn')) as session:
    statement = select(Config).where(Config.id == "1")
    hero = session.exec(statement).first()
    print(hero)
