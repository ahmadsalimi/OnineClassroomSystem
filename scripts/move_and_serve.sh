#!/bin/bash

source = $1
target = $2

echo "Stopping service."
sudo systemctl stop classroomApi.service
echo "Service stopped"
echo "Extracting..."
sudo rm $target -d
unzip $source $target
sudo rm $source
echo "Starting service."
sudo systemctl start classroomApi.service
echo "Service Started."
