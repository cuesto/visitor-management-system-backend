#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["VMS.Web/VMS.Web.csproj", "VMS.Web/"]
COPY ["VMS.DataModel/VMS.DataModel.csproj", "VMS.DataModel/"]
COPY ["VMS.Utils/VMS.Utils.csproj", "VMS.Utils/"]
RUN dotnet restore "VMS.Web/VMS.Web.csproj"
COPY . .
WORKDIR "/src/VMS.Web"
RUN dotnet build "VMS.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VMS.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VMS.Web.dll"]