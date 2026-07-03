# syntax=docker/dockerfile:1
ARG CONFIGURATION="Release"
ARG NUGET_PACKAGE_VERSION="1.0.0"
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS restore

ARG CONFIGURATION

COPY ./*.props .
COPY ./*.targets .
COPY ./global.json .
COPY ./*.slnx .
COPY ./*.jpg .
COPY ./README.md .
COPY ./LICENSE .

COPY ./src/CompaniesHouse/*.csproj ./src/CompaniesHouse/
COPY ./src/CompaniesHouse.Extensions.Microsoft.DependencyInjection/*.csproj ./src/CompaniesHouse.Extensions.Microsoft.DependencyInjection/
COPY ./src/CompaniesHouse.SourceGenerator/*.csproj ./src/CompaniesHouse.SourceGenerator/
COPY ./tests/CompaniesHouse.Extensions.Microsoft.DependencyInjection.Tests/*.csproj ./tests/CompaniesHouse.Extensions.Microsoft.DependencyInjection.Tests/
COPY ./tests/CompaniesHouse.IntegrationTests/*.csproj ./tests/CompaniesHouse.IntegrationTests/
COPY ./tests/CompaniesHouse.ScenarioTests/*.csproj ./tests/CompaniesHouse.ScenarioTests/
COPY ./tests/CompaniesHouse.SourceGenerator.Tests/*.csproj ./tests/CompaniesHouse.SourceGenerator.Tests/
COPY ./tests/CompaniesHouse.Tests/*.csproj ./tests/CompaniesHouse.Tests/
COPY ./samples/SampleProject/*.csproj ./samples/SampleProject/
RUN dotnet restore

FROM restore AS build
ARG CONFIGURATION
ARG NUGET_PACKAGE_VERSION

COPY ./src/ ./src/
COPY ./tests/ ./tests/
COPY ./samples/ ./samples/
COPY ./external/ ./external/
COPY ./enumerations/ ./enumerations/
RUN dotnet build --configuration $CONFIGURATION --no-restore

FROM build AS test
RUN --mount=type=secret,id=companies_house_api_key,required=false \
    export COMPANIES_HOUSE_API_KEY="$(cat /run/secrets/companies_house_api_key 2>/dev/null || true)" && \
    dotnet test --logger trx --configuration $CONFIGURATION --no-build

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