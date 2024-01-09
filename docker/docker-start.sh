#!/bin/bash

# NB: Run from parent directory (solution root): ./docker/docker-start.sh

# Stop images
docker rm $(docker stop $(docker ps -a -q --filter ancestor=docker.io/philcoultard/coultard:coultard-tictactoe --format="{{.ID}}"))

# Build application
rm -Rf publish || true
dotnet restore
export REVISION=$((1 + $RANDOM % 100))
export BUILD_VERSION=1.0.0.$REVISION
echo BUILD_VERSION=$BUILD_VERSION
dotnet build "src/Coultard.TicTacToe/Coultard.TicTacToe.csproj" --no-restore --configuration Release /p:Version=$BUILD_VERSION
cat src/Coultard.TicTacToe/obj/Release/net8.0/Coultard.TicTacToe.AssemblyInfo.cs
dotnet publish "src/Coultard.TicTacToe/Coultard.TicTacToe.csproj" --configuration Release --no-restore --no-build --output ./publish
cd publish && rm -Rf cs de en es fr it ja ko pl pt-BR ru tr zh-Hans zh-Hant && cd ../
cd publish/runtimes && rm -Rf unix win win-arm64 win-x64 win-x86 && cd ../../
cd publish && find . -type f -name 'Coultard.TicTacToe*Tests*' -exec rm {} + && cd ../

# Build image
docker build --no-cache --tag coultard-tictactoe --progress=plain .

# Start
# NB: --platform linux/amd64 is to get around "WARNING: The requested image's platform (linux/amd64) does not match the detected host platform (linux/arm64/v8) and no specific platform was requested"
docker run -p 9091:9091 --name coultard-tictactoe --detach --env-file=docker/coultard-tictactoe-env.list coultard-tictactoe:latest

kubectl get pods -n coultard-tradobot -o=jsonpath='{range .items[*]}{"\n"}{.metadata.name}{":\t"}{range .spec.containers[*]}{.image}{", "}{end}{end}'