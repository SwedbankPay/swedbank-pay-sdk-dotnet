#!/bin/bash

set -e

[ "${DEBUG:-false}" = "true" ] && set -x

help_message="\
Usage:

Runs 'dotnet package' and 'dotnet nuget push'.

VERSION_NUMBER: The version number for the nuget.
SLN_FILE: The project file for the nuget.
NUGET_KEY: The Key to the Nugets. It's in the name.
PUBLISH: Set to \"true\" if NuGet should be published"

if [[ -z "$VERSION_NUMBER" ]]; then
    echo "Missing or empty VERSION_NUMBER environment variable." >&2
    echo "$help_message"
    exit 1
fi

if [[ -z "$SLN_FILE" ]]; then
    echo "Missing or empty SLN_FILE environment variable." >&2
    echo "$help_message"
    exit 1
fi
if [[ -z "$NUGET_KEY" ]]; then
    echo "Missing or empty NUGET_KEY environment variable." >&2
    echo "$help_message"
    exit 1
fi

sanitized_version_number=${VERSION_NUMBER//\+/.}

dotnet pack "$SLN_FILE" \
    -p:Version="$sanitized_version_number" \
    --configuration Release \
    --output nugets/

if [[ "${PUBLISH:-false}" = "true" ]]
then
    dotnet nuget push nugets/*.nupkg -s https://api.nuget.org/v3/index.json -k "$NUGET_KEY" --skip-duplicate
fi
