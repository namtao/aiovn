
from database.create import create_table
from fastapi import APIRouter, Request
from fastapi.responses import HTMLResponse
from fastapi.security import APIKeyCookie
from fastapi.templating import Jinja2Templates

router = APIRouter()
cookie_sec = APIKeyCookie(name="session")
views = Jinja2Templates(directory='views')


@router.get("/custom-view", response_class=HTMLResponse)
async def view(request: Request):
    # create_table()
    return views.TemplateResponse('admin/custom-view.html', {"request": request})
