FROM python:3.10.12-slim

ENV PIP_NO_CACHE_DIR=1
ENV PYTHONDONTWRITEBYTECODE=1
ENV PYTHONUNBUFFERED=1

RUN pip install --upgrade pip
RUN pip install "setuptools<81" wheel

# Descargamos la versión CPU de PyTorch (150MB) en vez de la versión GPU (3GB) para que Docker no explote.
RUN pip install torch==2.2.2+cpu --index-url https://download.pytorch.org/whl/cpu
RUN pip install "onnx==1.15.0"

RUN pip install mlagents==1.1.0

WORKDIR /workspace
