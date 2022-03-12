from django import forms

class form_rename(forms.Form):
    file_type = forms.CharField(max_length=1000)
    root_path = forms.CharField(max_length=1000)
    target_path = forms.CharField(max_length=1000)