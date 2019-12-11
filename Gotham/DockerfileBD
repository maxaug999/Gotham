# building our new image from the microsft SQL 2017 image
FROM mcr.microsoft.com/mssql/server:latest

#Les crédentials du serveur MSSQL
ENV sa_password=1Secure*Password1				
ENV ACCEPT_EULA=Y

#TODO :

CMD ["sh","/script/run.sh"]

COPY run.sh /script/run.sh
#RUN chmod +x /script/run.sh

#script local to container 
COPY script.sql /src/script.sql

WORKDIR /src

EXPOSE 1433

#WORKDIR /app
#RUN chmod +x run.sh
#COPY run.sh ./
#COPY script.sql ./
#CMD["sh", "/app/run.sh"]
#WORKDIR /src
#EXPOSE 1433
