### ENVIRONMENT SETUP ###
# Install apache
FROM centos:latest

RUN yum -y install httpd
# expose port 80 and run apache
CMD ["/usr/sbin/httpd", "-D", "FOREGROUND"]
EXPOSE 80

### BACKEND SET UP ###
# build backend project
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-backend
WORKDIR /source/backend

# Copy csproj from all layers and restore distinct layers
COPY *.sln .
COPY PZCheesy.Api/*.csproj ./PZCheesy.Api/
COPY PZCheesy.Core/*.csproj ./PZCheesy.Core/
COPY PZCheesy.Data/*.csproj ./PZCheesy.Data/
COPY PZCheesy.Services/*.csproj ./PZCheesy.Services/
COPY PZCheesy.UnitTests/*.csproj ./PZCheesy.UnitTests/

RUN dotnet restore

# Copy everything else and build app
COPY PZCheesy.Api/. ./PZCheesy.Api/
COPY PZCheesy.Core/. ./PZCheesy.Core/
COPY PZCheesy.Data/. ./PZCheesy.Data/
COPY PZCheesy.Services/. ./PZCheesy.Services/
COPY PZCheesy.UnitTests/. ./PZCheesy.UnitTests/

WORKDIR /source/backend
# pubish project
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /source

COPY --from=build-backend /source/backend/out .
EXPOSE 80
EXPOSE 443
ENTRYPOINT ["dotnet", "PZCheesy.Api.dll"]