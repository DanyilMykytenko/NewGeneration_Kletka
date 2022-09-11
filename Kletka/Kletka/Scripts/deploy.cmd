@echo off
set tag=%1
if not defined tag exit

echo "Using tag: %tag%"

dotnet publish -c Release
docker build -t dmykytenko/hermes_danyilmykytenko:%tag% .
docker push dmykytenko/hermes_danyilmykytenko:%tag%