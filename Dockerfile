FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY EmployeeAPI/*.csproj ./EmployeeAPI/
RUN dotnet restore
#RUN dotnet restore -r linux-x64

# copy everything else and build app
COPY EmployeeAPI/. ./EmployeeAPI/
WORKDIR /source/EmployeeAPI
RUN dotnet publish -c release -o /app --no-restore
#RUN dotnet publish -c release -o /app -r linux-x64 --self-contained false --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
#FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal-amd64
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "EmployeeAPI.dll"]
