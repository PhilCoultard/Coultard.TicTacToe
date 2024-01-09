FROM mcr.microsoft.com/dotnet/aspnet:8.0-bookworm-slim
WORKDIR /app
COPY ./publish/ .
USER app
ENTRYPOINT ["dotnet", "Coultard.TicTacToe.dll"]