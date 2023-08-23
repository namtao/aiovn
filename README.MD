# Commands

- [Commands](#commands)
  - [Git](#git)
  - [Python](#python)
  - [Docker](#docker)
  - [Network](#network)
  - [Linux](#linux)

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
```

***Virtual environment***

```:
<!-- update pip -->
python -m pip install --upgrade --force-reinstall pip

<!-- export env.yml file -->
conda env export > env.yml

<!-- install update env -->
conda env update -n .env --file env.yml --prune

<!-- return list env and find string -->
pip list | findstr opencv
```

## Docker

| Command                                                     | Description |
| ----------------------------------------------------------- | ----------- |
| `docker build -t <imageName> .`                             | Build       |
| `docker run <imageName>:<version>`                          | Run         |
| `docker info`                                               | Information |
| `docker save -o <path for generated tar file> <image name>` | Save config |
| `docker load -i <path to image tar file>`                   | Load config |
| `docker cp . 4584b29c4197:/`                                | Copy file   |
| `docker exec --user root lucid_hermann rm -rf bienmuc.bak`  | Delete file |

## Network

| Command | Description |
| ------- | ----------- |
|         |             |

## Linux

| Command | Description |
| ------- | ----------- |
|         |             |
