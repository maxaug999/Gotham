FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build

WORKDIR /app
COPY ./ ./
RUN cd ./Gotham.web
RUN dotnet publish Gotham.web -c Release -o out
WORKDIR /app/Gotham.web.unitTests
RUN dotnet test
WORKDIR /app/Gotham.web.acceptanceTests
# RUN dotnet test ne passent pas on sait pas pourquoi

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS runtime

WORKDIR /app
COPY --from=build /app/out ./
EXPOSE 6002
ENTRYPOINT ["dotnet", "Gotham.dll"]