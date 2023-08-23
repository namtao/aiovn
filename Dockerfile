# 
FROM python:3.10

# 
WORKDIR /app/
COPY /web/ /app/

# 
COPY requirements.txt /app/requirements.txt

# 
RUN pip install -r /app/requirements.txt

# 
# COPY ./app /code/app

# 
CMD ["uvicorn", "main:app", "--host", "127.0.0.1", "--port", "8000"]
# CMD [ "python", "test.py" ]
