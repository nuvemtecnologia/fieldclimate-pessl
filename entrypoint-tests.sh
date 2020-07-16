#!/bin/bash

# Necessário instalar esses pacotes nos projetos de teste
#https://gunnarpeipman.com/aspnet/code-coverage/
# coverlet.msbuild
# Microsoft.CodeCoverage
# XunitXml.TestLogger

red='\e[1;31m'
green='\e[32m'
reset='\e[0m'
CoverletOutputFormat="cobertura,opencover"
REPORT_GENERATOR_REPORTS="${COVERAGE_PATH}coverage.cobertura.xml"
REPORT_GENERATOR_REPORT_TYPES="HTMLInline"

echo ""

echo "-------------------------------------------------------"
echo "Iniciando entrypoint - entrypoint-tests.sh"
echo ""
echo "dotnet properties"
echo "SOLUTION_NAME: $SOLUTION_NAME"
echo "CONFIGURATION: $CONFIGURATION"
echo "RESULT_PATH: $RESULT_PATH"
echo "COVERAGE_PATH: $COVERAGE_PATH"
echo "COVERLET_OUTPUT_FORMAT: $CoverletOutputFormat"
echo "COVERAGE_REPORT_PATH: $COVERAGE_REPORT_PATH"
echo ""
echo "Sonar properties"
echo "RUN_SONARQUBE: $RUN_SONARQUBE"
echo "SONARQUBE_URL: $SONARQUBE_URL"
echo "SONARQUBE_PROJECT: $SONARQUBE_PROJECT"
echo "SONARQUBE_PROJECT_VERSION: $SONARQUBE_PROJECT_VERSION"
echo "SONARQUBE_ORGANIZATION: $SONARQUBE_ORGANIZATION"
echo ""
echo "reportgenerator properties"
echo "REPORT_GENERATOR_REPORTS: $REPORT_GENERATOR_REPORTS"
echo "REPORT_GENERATOR_REPORT_TYPES: $REPORT_GENERATOR_REPORT_TYPES"
echo "-------------------------------------------------------"
echo ""

if [[ ${RUN_SONARQUBE} = "true" ]]; then
    dotnet sonarscanner begin \
        /k:"$SONARQUBE_PROJECT" \
        /v:"$SONARQUBE_PROJECT_VERSION" \
        /o:$SONARQUBE_ORGANIZATION \
        /d:sonar.verbose=false \
        /d:sonar.login=$SONARQUBE_TOKEN \
        /d:sonar.host.url=${SONARQUBE_URL} \
        /d:sonar.cs.vstest.reportsPaths="${RESULT_PATH}*.trx" \
        /d:sonar.cs.opencover.reportsPaths="${COVERAGE_PATH}**/coverage.opencover.xml" || true;
fi


dotnet build $SOLUTION_NAME -c $CONFIGURATION -v q --no-restore

if [ $? -ne 0 ]; then
    echo -e "${red}dotnet build Failed" 1>&2
    exit 1
fi

dotnet test $SOLUTION_NAME --no-build --no-restore -v n --logger "trx;LogFileName=TestResults.trx" --results-directory $RESULT_PATH /p:CollectCoverage=true /p:CoverletOutput=$COVERAGE_PATH /p:CoverletOutputFormat=\"$CoverletOutputFormat\"

if [ $? -ne 0 ]; then
    echo -e "${red}dotnet test Failed" 1>&2
    exit 1
fi

reportgenerator "-reports:${REPORT_GENERATOR_REPORTS}" "-targetdir:$COVERAGE_REPORT_PATH" -reporttypes:"${REPORT_GENERATOR_REPORT_TYPES}" -verbosity:Error || true;

if [[ ${RUN_SONARQUBE} = "true" ]]; then
    dotnet sonarscanner end /d:sonar.login=$SONARQUBE_TOKEN || true;
fi


echo "-----Checking Code Coverage"
CODE_COVERAGE=$(xmllint --xpath "string(//CoverageSession/Summary/@sequenceCoverage)" ${COVERAGE_PATH}/coverage.opencover.xml)

echo "MINIMUM_CODE_COVERAGE: $MINIMUM_CODE_COVERAGE"
echo "CODE_COVERAGE: $CODE_COVERAGE"

if (( $(echo "$CODE_COVERAGE < $MINIMUM_CODE_COVERAGE" |bc -l) )); then
    MESSAGE_ERROR="Algo deu errado. CODE_COVERAGE '$CODE_COVERAGE' is less then MINIMUM_CODE_COVERAGE: '${MINIMUM_CODE_COVERAGE}'"
    echo -e "${red} $MESSAGE_ERROR" 1>&2
    exit 1
fi

echo -e "${green}SUCESS..."
echo -e "${green}Parabéns. Seu código possui '$CODE_COVERAGE%' de cobertura"
exit 0