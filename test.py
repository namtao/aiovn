from sqlalchemy import create_engine

engine = create_engine("mssql+pyodbc://sa:Addj%40123@./hotichdata?driver=ODBC Driver 17 for SQL Server")
