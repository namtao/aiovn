from django.contrib import admin
from django.apps import apps
from django.contrib.auth.models import *

# register all models
admin.site.unregister(User)
admin.site.unregister(Group)

models = apps.get_models()

for model in models:
    admin.site.register(model)
