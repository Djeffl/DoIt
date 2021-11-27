#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["test2/test2.csproj", "test2/"]
RUN dotnet restore "test2/test2.csproj"
COPY . .
WORKDIR "/src/test2"
RUN dotnet build "test2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "test2.csproj" -c Release -o /app/publish

#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "test2.dll"]