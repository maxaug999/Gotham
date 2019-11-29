FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build

WORKDIR /app
COPY ./ ./
RUN cd ./Gotham
RUN dotnet publish Gotham -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS runtime

WORKDIR /app
COPY --from=build /app/out ./
EXPOSE 6002
ENTRYPOINT ["dotnet", "Gotham.dll"]