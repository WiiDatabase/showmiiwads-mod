#!/bin/bash

    #####################################################################
    ##                 __            __ _ ___________                  ##
    ##                 \ \          / /| |____   ____|                 ##
    ##                  \ \        / / | |    | |                      ##
    ##                   \ \  /\  / /  | |    | |                      ##
    ##                    \ \/  \/ /   | |    | |                      ##
    ##                     \  /\  /    | |    | |                      ##
    ##                      \/  \/     |_|    |_|                      ##
    ##                                                                 ##
    ##                        Wiimms ISO Tools                         ##
    ##                      http://wit.wiimm.de/                       ##
    ##                                                                 ##
    #####################################################################
    ##                                                                 ##
    ##   This file is part of the WIT project.                         ##
    ##   Visit http://wit.wiimm.de/ for project details and sources.   ##
    ##                                                                 ##
    ##   Copyright (c) 2009-2011 by Dirk Clemens <wiimm@wiimm.de>      ##
    ##                                                                 ##
    #####################################################################
    ##                                                                 ##
    ##   This file installs the distribution on a windows system.      ##
    ##                                                                 ##
    #####################################################################


#------------------------------------------------------------------------------
# simple cygwin check

if [[ $1 != --cygwin ]]
then
    echo "Option --cygwin not set => exit" >&2
    exit 1
fi

#------------------------------------------------------------------------------
# pre definitions

BIN_FILES="wit wwt wdf wfuse"
WDF_LINKS="wdf-cat wdf-dump"
SHARE_FILES="titles.txt titles-de.txt titles-es.txt titles-fr.txt titles-it.txt titles-ja.txt titles-ko.txt titles-nl.txt titles-pt.txt titles-ru.txt titles-zhcn.txt titles-zhtw.txt system-menu.txt"
WIN_INSTALL_PATH="Wiimm/WIT"

#------------------------------------------------------------------------------
# setup

echo "* setup"

export PATH=".:$PATH"

WIN_PROG_PATH="$(regtool get /machine/SOFTWARE/Microsoft/Windows/CurrentVersion/ProgramFilesDir)"
CYGWIN_PROG_PATH="$( realpath "$WIN_PROG_PATH" )"

WDEST="$WIN_PROG_PATH\\${WIN_INSTALL_PATH//\//\\}"
CDEST="$CYGWIN_PROG_PATH/$WIN_INSTALL_PATH"

#------------------------------------------------------------------------------
# install files

if [[ $(stat -c%d-%i "$PWD") != "$(stat -c%d-%i "$CDEST")" ]]
then
    echo "* install files to $WDEST"

    mkdir -p "$CDEST"
    cp --preserve=time *.bat *.dll *.exe *.sh *.txt "$CDEST"
fi

#------------------------------------------------------------------------------
# define application pathes

for tool in $BIN_FILES $WDF_LINKS
do
    [[ -s "$CDEST/$tool.exe" ]] || continue
    echo "* define application path for '$tool.exe'"
    key="/machine/SOFTWARE/Microsoft/Windows/CurrentVersion/App Paths/$tool.exe"
    regtool add "$key"
    regtool set "$key/" "${WDEST}\\${tool}.exe"
    regtool set "$key/Path" "${WDEST}\\"
done

#------------------------------------------------------------------------------
# add WIT path to environment 'Path'

key="/machine/SYSTEM/CurrentControlSet/Control/Session Manager/Environment/Path"
winPath="$(regtool get "$key")"

if [[ winPath != "" ]] && ! echo ";$winPath;" | grep -qF ";$WDEST;"
then
    echo "* add WIT path to environment 'Path'"
    regtool set "$key" "$winPath;$WDEST"
fi

#------------------------------------------------------------------------------

