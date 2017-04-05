#!/usr/bin/env bash

/var/lib/jenkins/docker run hub.docker.intel.com/iml/centos7_3 ${PWD}/:/device-scanner false "cd /device-scanner; rm -rf node_modules; rm -rf obj; rm -rf bin; yarn install; yarn run restore; RUNNER=CI yarn run test"
mv device-scanner*.xml ../results
