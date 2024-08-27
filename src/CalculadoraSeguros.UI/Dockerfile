FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/CalculadoraSeguros.UI/CalculadoraSeguros.UI.csproj", "src/CalculadoraSeguros.UI/"]
COPY ["src/CalculadoraSeguros.API/CalculadoraSeguros.API.csproj", "src/CalculadoraSeguros.API/"]
COPY ["src/CalculadoraSeguros.Domain/CalculadoraSeguros.Domain.csproj", "src/CalculadoraSeguros.Domain/"]
COPY ["src/CalculadoraSeguros.Shared/CalculadoraSeguros.Shared.csproj", "src/CalculadoraSeguros.Shared/"]
COPY ["src/CalculadoraSeguros.Infra/CalculadoraSeguros.Infra.csproj", "src/CalculadoraSeguros.Infra/"]
RUN dotnet restore "./src/CalculadoraSeguros.UI/CalculadoraSeguros.UI.csproj"
COPY . .
WORKDIR "/src/src/CalculadoraSeguros.UI"
RUN dotnet build "./CalculadoraSeguros.UI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CalculadoraSeguros.UI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CalculadoraSeguros.UI.dll"]