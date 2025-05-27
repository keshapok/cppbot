#!/bin/bash

echo "Установка зависимостей..."
sudo apt update
sudo apt install -y cmake g++ mingw-w64 libopencv-dev
dotnet --version || sudo apt install -y dotnet-sdk-8.0

cd cpp
mkdir -p build && cd build
cmake ..
make

cd ../../csharp
dotnet publish -r win-x64 -p:PublishSingleFile=true --self-contained
