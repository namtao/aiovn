import uvicorn
from fastapi import FastAPI, Response

app = FastAPI()


@app.get("/")
async def root():
    return {"message": "Hello world"}


app = FastAPI()

fake_items_db = [{"item_name": "Foo"}, {"item_name": "Bar"}, {"item_name": "Baz"}]  # pair format: key-value

@app.get("/test")
async def get_json():

    test = "[1592494390, 'test', -0.2761097089544078, -0.0852381808812182, -0.101153, nan]"
    # print(test)
    return Response(content=test, media_type="application/json")

@app.get("/items/")
async def read_item(skip: int = 0, limit: int = 1):
    return fake_items_db[skip: skip + limit]  # trả về dữ liệu từ skip đến skip + limit

if __name__ == '__main__':
    uvicorn.run(app, port=5000, reload=True)
