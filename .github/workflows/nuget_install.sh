#!/bin/bash

set -e

[ "${DEBUG:-false}" = "true" ] && set -x

help_message="\
Usage:

Runs 'dotnet package' and 'dotnet nuget push'.

VERSION_NUMBER: The version number for the nuget.
PROJECT_FILE: The project file for the nuget.
NUGET_KEY: The Key to the Nugets. It's in the name.
PUBLISH: Set to \"true\" if NuGet should be published"

if [[ -z "$VERSION_NUMBER" ]]; then
    echo "Missing or empty VERSION_NUMBER environment variable." >&2
    echo "$help_message"
    exit 1
fi

if [[ -z "$PROJECT_FILE" ]]; then
    echo "Missing or empty PROJECT_FILE environment variable." >&2
    echo "$help_message"
    exit 1
fi

sanitized_version_number=${VERSION_NUMBER//\+/.}

dotnet add "$PROJECT_FILE" package SwedbankPay.Sdk --version "$sanitized_version_number"
