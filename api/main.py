import uvicorn
from fastapi import FastAPI

app = FastAPI()


@app.get("/")
async def root():
    return {"message": "Hello world"}


app = FastAPI()

fake_items_db = [{"item_name": "Foo"}, {"item_name": "Bar"}, {"item_name": "Baz"}]  # pair format: key-value


@app.get("/items/")
async def read_item(skip: int = 0, limit: int = 1):
    return fake_items_db[skip: skip + limit]  # trả về dữ liệu từ skip đến skip + limit

if __name__ == '__main__':
    uvicorn.run(app, port=5000, reload=True)
