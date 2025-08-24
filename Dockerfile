ARG CONFIGURATION="Release"
ARG NUGET_PACKAGE_VERSION="1.0.0"
ARG COMPANIES_HOUSE_API_KEY
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS restore

ARG CONFIGURATION

COPY ./*.props .
COPY ./*.targets .
COPY ./*.sln .
COPY ./*.jpg .
COPY ./README.md .
COPY ./LICENSE .

COPY ./src/CompaniesHouse/*.csproj ./src/CompaniesHouse/
COPY ./src/CompaniesHouse.Extensions.Microsoft.DependencyInjection/*.csproj ./src/CompaniesHouse.Extensions.Microsoft.DependencyInjection/
COPY ./tests/CompaniesHouse.Extensions.Microsoft.DependencyInjection.Tests/*.csproj ./tests/CompaniesHouse.Extensions.Microsoft.DependencyInjection.Tests/
COPY ./tests/CompaniesHouse.IntegrationTests/*.csproj ./tests/CompaniesHouse.IntegrationTests/
COPY ./tests/CompaniesHouse.ScenarioTests/*.csproj ./tests/CompaniesHouse.ScenarioTests/
COPY ./tests/CompaniesHouse.Tests/*.csproj ./tests/CompaniesHouse.Tests/
COPY ./samples/SampleProject/*.csproj ./samples/SampleProject/
RUN dotnet restore

FROM restore AS build
ARG CONFIGURATION
ARG NUGET_PACKAGE_VERSION

COPY ./src/ ./src/
COPY ./tests/ ./tests/
COPY ./samples/ ./samples/
RUN dotnet build --configuration $CONFIGURATION --no-restore

FROM build AS test
ARG COMPANIES_HOUSE_API_KEY
RUN dotnet test --logger trx --configuration $CONFIGURATION --no-build; exit 0

FROM build AS pack
RUN mkdir -p artifacts
RUN dotnet pack --configuration Release -p:Version=${NUGET_PACKAGE_VERSION} --no-build --output ./artifacts

FROM scratch
COPY --from=pack /artifacts/*.nupkg /artifacts/
COPY --from=pack /artifacts/*.snupkg /artifacts/
COPY --from=test /tests/CompaniesHouse.Extensions.Microsoft.DependencyInjection.Tests/TestResults/*.trx /TestResults/CompaniesHouse.Extensions.Microsoft.DependencyInjection.Tests/
COPY --from=test /tests/CompaniesHouse.IntegrationTests/TestResults/*.trx /TestResults/CompaniesHouse.IntegrationTests/
COPY --from=test /tests/CompaniesHouse.ScenarioTests/TestResults/*.trx /TestResults/CompaniesHouse.ScenarioTests/
COPY --from=test /tests/CompaniesHouse.Tests/TestResults/*.trx /TestResults/CompaniesHouse.Tests/
