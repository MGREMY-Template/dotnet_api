#!/bin/bash

# Help

Help()
{
  echo "Add migration in project for every DB Providers"
  echo
  echo "Syntax: add-migration.sh [-n]"
  echo "n     Name of the migration"
  echo "c     dotnet configuration (default: Development)"
  echo
}

############################################################
############################################################

############################################################
############################################################
# Main program                                             #
############################################################
############################################################
############################################################
# Process the input options. Add options as needed.        #
############################################################

MigrationName="";
Configuration="Debug"
DBProviders=("MariaDb" "MySql" "PostgresSql" "SqLite" "SqlServer");

while getopts ":h:n:c:" option; do
  case $option in
    h)
      Help
      exit;;
    n)
      MigrationName=$OPTARG;;
    c)
      Configuration=$OPTARG;;
    ?)
      Help
      exit;;
  esac
done

if [ "$MigrationName" = "" ];then
  Help
  exit;
fi

echo
echo "Building project with ${Configuration} configuration"
dotnet build --configuration "${Configuration}"

for i in "${DBProviders[@]}"
do
  echo
  echo "Creating migration ${MigrationName} for ${i}"
  dotnet ef migrations add "${MigrationName}" --no-build --configuration "${Configuration}" --project "${i}"Migrations/"${i}"Migrations.csproj --startup-project API/API.csproj -- Database:Type="${i}"
done
