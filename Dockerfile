FROM microsoft/dotnet:2.2-sdk AS build-env


# Unsure if Expose and ENV are needed
EXPOSE 8080
ENV ASPNETCORE_URLS=http://*:8080
WORKDIR /app


RUN curl -sL https://deb.nodesource.com/setup_10.x |  bash -
RUN apt-get install -y nodejs
# Copy csproj and restore as distinct layers
COPY WebApi/*.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/out .

# Entry point doesnt seem to work well with heroku
# ENTRYPOINT ["dotnet", "Lee.dll"]

# this alone will not work working answer is last CMD
# CMD dotnet Lee.dll

CMD ASPNETCORE_URLS=http://*:$PORT dotnet WebApi.dll
