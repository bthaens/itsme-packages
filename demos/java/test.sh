#!/bin/bash
set -e


rm -f libs/itsme.jar
pushd ../../java
gradle build --stacktrace
cp build/libs/itsme.jar ../demos/java/libs/itsme.jar
popd

gradle build --stacktrace
java -jar build/libs/javatest.jar
