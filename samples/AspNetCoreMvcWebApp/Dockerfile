FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["samples/AspNetCoreMvcWebApp/AspNetCoreMvcWebApp.csproj", "samples/AspNetCoreMvcWebApp/"]
RUN dotnet restore "samples/AspNetCoreMvcWebApp/AspNetCoreMvcWebApp.csproj"
COPY . .
WORKDIR "/src/samples/AspNetCoreMvcWebApp"
RUN dotnet build "AspNetCoreMvcWebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AspNetCoreMvcWebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Devpro.Hubspot.Samples.AspNetCoreMvcWebApp.dll"]
