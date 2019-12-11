#!/bin/bash
    ( /opt/mssql/bin/sqlservr --accept-eula & ) | grep -q "Service Broker manager has started" \
    && /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P '1Secure*Password1' -i script.sql     
/bin/bash