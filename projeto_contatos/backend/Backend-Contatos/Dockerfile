# --------------- STAGE 1: BUILD ---------------
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copia apenas o .csproj primeiro para aproveitar cache do Docker
COPY ["Backend-Contatos/Backend-Contatos.csproj", "Backend-Contatos/"]
RUN dotnet restore "Backend-Contatos/Backend-Contatos.csproj"

# Copia o restante do codigo e compila
COPY . .
WORKDIR "/src/Backend-Contatos"
RUN dotnet publish -c Release -o /app/publish

# --------------- STAGE 2: RUNTIME ---------------
FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine AS final
WORKDIR /app

# Copia apenas os artefatos de build - nao o SDK
COPY --from=build /app/publish .

EXPOSE 8081
ENTRYPOINT ["dotnet", "Backend-Contatos.dll"]