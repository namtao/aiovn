from sqlalchemy import BigInteger, Column, Identity, MetaData, Table, Unicode
from sqlalchemy.orm import declarative_base

metadata = MetaData()


t_Files = Table(
    'Files', metadata,
    Column('ID', BigInteger, Identity(start=1, increment=1), nullable=False),
    Column('FileName', Unicode, nullable=False),
    Column('FilePath', Unicode, nullable=False),
    Column('Description', Unicode)
)
