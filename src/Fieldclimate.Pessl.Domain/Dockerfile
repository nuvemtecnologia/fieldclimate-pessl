ARG DOT_NET_CORE_SDK_VERSION="3.1"
FROM mcr.microsoft.com/dotnet/core/sdk:$DOT_NET_CORE_SDK_VERSION as base

#--------------------------------------Instalando ferramentas----------------------#
ARG OPENJDK_VERSION="default-jre"
RUN apt-get update -q && \
    apt-get install -y -q $OPENJDK_VERSION libxml2-utils bc

ARG SONAR_SCANNER_NUGET_VERSION="4.9.0"
ARG SONAR_SCANNER_BIN_VERSION="4.3.0.2102"
ARG SONAR_SCANNER_NETCORE_VERSION="netcoreapp3.0"
ARG REPORTGENERATOR_NUGET_VERSION="4.6.1"
ARG COVERLET_CONSOLE_NUGET_VERSION="1.7.2"

RUN dotnet tool install --global dotnet-sonarscanner --version ${SONAR_SCANNER_NUGET_VERSION} && \
    dotnet tool install --global dotnet-reportgenerator-globaltool --version ${REPORTGENERATOR_NUGET_VERSION} && \
    dotnet tool install --global coverlet.console --version ${COVERLET_CONSOLE_NUGET_VERSION}

ENV PATH "$PATH:/root/.dotnet/tools/"
RUN chmod +x /root/.dotnet/tools/.store/dotnet-sonarscanner/${SONAR_SCANNER_NUGET_VERSION}/dotnet-sonarscanner/${SONAR_SCANNER_NUGET_VERSION}/tools/${SONAR_SCANNER_NETCORE_VERSION}/any/sonar-scanner-${SONAR_SCANNER_BIN_VERSION}/bin/sonar-scanner
#----------------------------------------------------------------------------------------------#

ARG CONFIGURATION="Release"
ARG SOLUTION_NAME="Fieldclimate.Pessl.sln"

ENV CONFIGURATION=$CONFIGURATION
ENV SOLUTION_NAME=$SOLUTION_NAME
ENV RESULT_PATH="/TestResults/result/vsTest/"
ENV COVERAGE_PATH="/TestResults/codecoverage/"
ENV COVERAGE_REPORT_PATH="/TestResults/codecoverage/Report/"
#----------------------------------------------------------------------------------------------#

FROM base as restore

COPY ./*.sln ./

COPY src/*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p src/${file%.*}/ && mv $file src/${file%.*}/; done

COPY test/*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p test/${file%.*}/ && mv $file test/${file%.*}/; done

RUN dotnet restore ${SOLUTION_NAME} -v q

COPY . .

FROM restore as tests
RUN chmod +x ./entrypoint-tests.sh
ENTRYPOINT ./entrypoint-tests.sh