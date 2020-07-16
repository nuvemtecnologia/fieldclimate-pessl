#!/bin/bash

clear
echo "---------------Iniciando run-ci.sh---------------"
echo ""

export MINIMUM_CODE_COVERAGE=${MINIMUM_CODE_COVERAGE:-70}
export ARTIFACT_STAGING_DIRECTORY=${ARTIFACT_STAGING_DIRECTORY:-.}
export ARTIFACT_STAGING_DIRECTORY_TEST_RESULT="${ARTIFACT_STAGING_DIRECTORY}/TestResults"
rm -rf ${ARTIFACT_STAGING_DIRECTORY_TEST_RESULT}
mkdir ${ARTIFACT_STAGING_DIRECTORY_TEST_RESULT}

export GIT_SHORT_SHA=$(git rev-parse --short=10 $(git log -n1 --format=format:"%H" ))
export GIT_BRANCH=$(echo ${BRANCH:-$(git branch | sed -n -e 's/^\* \(.*\)/\1/p')} | sed 's/refs\/heads\///g' | sed 's/refs\/tags\///g' | sed 's/\//-/g' | sed 's/\./-/g')
export GIT_REPO_NAME=$(echo $(basename -s .git `git config --get remote.origin.url`))

export DOCKER_REGISTRY=${DOCKER_REGISTRY:-containerregistry.local}
export VERSION=${VERSION:-$(date '+%Y%m%d%H%M%S')}
export RUN_SONARQUBE=${RUN_SONARQUBE:-true}
export SONARQUBE_URL=${SONARQUBE_URL:-http://172.17.0.1:9000}
export SONARQUBE_ORGANIZATION${SONARQUBE_ORGANIZATION:-}
export SONARQUBE_TOKEN=${SONARQUBE_TOKEN}
export SONARQUBE_PROJECT=${GIT_REPO_NAME}
export SONARQUBE_PROJECT_VERSION=${VERSION}
export CONTAINER_NAME="ci-tests-artifacts-${VERSION}"
export TAG="$GIT_BRANCH-$GIT_SHORT_SHA"

if [[ $RUN_SONARQUBE -eq true && -z ${SONARQUBE_TOKEN}  ]]; then
    echo "RUN_SONARQUBE está true e não foi informado SONARQUBE_TOKEN. Use o comando export SONARQUBE_TOKEN=XXX para configurar. Acesse https://github.com/nuvemtecnologia/sonarqube-server para mais detalhes"
    exit 1
fi

echo '-----Iniciando docker-compose build'
docker-compose -f docker-compose.yml -f docker-compose.ci.yml up --build --force-recreate --abort-on-container-exit --exit-code-from agrosig-fieldclimate
EXIT_CODE=$?

echo '-----Extraindo artefatos dos testes'
docker cp ${CONTAINER_NAME}:/TestResults ${ARTIFACT_STAGING_DIRECTORY}

echo '-----Removendo container temporário'
docker rm ${CONTAINER_NAME}


echo "SUCESS..."

echo "EXIT_CODE: $EXIT_CODE"
exit $EXIT_CODE