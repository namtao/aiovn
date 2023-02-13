
from api import auth, db
from fastapi import FastAPI, Request
from fastapi.responses import HTMLResponse
from fastapi.staticfiles import StaticFiles
from fastapi.templating import Jinja2Templates
from pydantic import BaseModel
from views import admin, user

app = FastAPI()

app.mount("/static", StaticFiles(directory=r"static"), name="static")
app.mount("/resources", StaticFiles(directory=r"resources"), name="resources")
app.include_router(auth.router)
app.include_router(db.router)
app.include_router(user.router)
app.include_router(admin.router)



