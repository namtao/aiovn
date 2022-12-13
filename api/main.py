import uvicorn
from fastapi import FastAPI

app = FastAPI()


@app.get("/")
async def root():
    return {"message": "Hello world"}

if __name__ == '__main__':
    uvicorn.run(app, port=5000, reload=True)
