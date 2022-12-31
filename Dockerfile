# 
FROM python:3.10

# 
WORKDIR /app/
COPY /website/ /app/

# 
COPY requirements.txt /app/requirements.txt

# 
RUN pip install -r /app/requirements.txt

# 
# COPY ./app /code/app

# 
CMD ["uvicorn", "app.main:app", "--host", "0.0.0.0", "--port", "8000"]
# CMD [ "python", "test.py" ]
