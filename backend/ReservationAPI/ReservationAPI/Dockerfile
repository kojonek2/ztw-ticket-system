FROM mcr.microsoft.com/dotnet/aspnet:3.1

ENV RESERVATION_APP_CONNECTION_STRING="Data Source=tcp:host.docker.internal,1434;Initial Catalog=TrainReservationDb;User Id=admin;Password=admin;MultipleActiveResultSets=True"

COPY bin/Release/netcoreapp3.1/publish App/
WORKDIR /App

EXPOSE 80
ENTRYPOINT ["dotnet", "ReservationAPI.dll"]