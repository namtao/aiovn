
from api import auth, db
from fastapi import FastAPI, Request
from fastapi.responses import HTMLResponse
from fastapi.staticfiles import StaticFiles
from fastapi.templating import Jinja2Templates
from pydantic import BaseModel

app = FastAPI()

app.mount("/static", StaticFiles(directory=r"static"), name="static")
app.include_router(auth.router)
app.include_router(db.router)


templates = Jinja2Templates(directory="templates")


class LoginRequest(BaseModel):
    username: str
    password: str


@app.get("/details", response_class=HTMLResponse)
async def details(request: Request):
    return templates.TemplateResponse("details.html", {"request": request})
