from typing import Optional

from config.config import db_connect
from sqlmodel import Field, SQLModel


class Config2(SQLModel, table=True):
    id: Optional[int] = Field(default=None, primary_key=True)
    loaihoso: str
    mota: str
    truongthongtin: str