# Artifical Brains

## Git

```:
find . -name "*.pyc" -exec rm -f {} \;
```

## Python

***Basic***

```:
pip install --upgrade pip setuptools wheel
py -m ensurepip --upgrade
pip install --upgrade pip
auto-py-to-exe
jupyter-book create artificial-brains/
jupyter-book build .
jupytext --to ipynb <your_file.md>
jupyter nbconvert --execute <my_notebook.ipynb>
```

***Virtual environment***

```:
<!-- update pip -->
python -m pip install --upgrade --force-reinstall pip
pip install textual --upgrade

<!-- export env.yml file -->
conda env export > env.yml

<!-- install update env -->
conda env update -n .env --file env.yml --prune

<!-- return list env and find string -->
pip list | findstr opencv
```
