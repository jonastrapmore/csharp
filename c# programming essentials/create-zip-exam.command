#!/bin/bash
cd "$(dirname "$0")" # This needs to be here for MACOS if the extension is ".command" clickable!
ARCH=$(uname -m)
if [ "$(uname)" == "Darwin" ]; then
    if [ "$ARCH" == "x86_64" ]; then
	chmod +x ./zip-logic/macosx/x86_64/create-zip-exam
        ./zip-logic/macosx/x86_64/create-zip-exam
    elif [ "$ARCH" == "arm64" ]; then
	chmod +x ./zip-logic/macosx/arm64/create-zip-exam
        ./zip-logic/macosx/arm64/create-zip-exam
    fi
else
    chmod +x ./zip-logic/linux/x86_64/create-zip-exam
    ./zip-logic/linux/x86_64/create-zip-exam
fi
