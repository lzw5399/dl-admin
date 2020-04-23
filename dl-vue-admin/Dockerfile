FROM node:slim

RUN mkdir /app

COPY ./build/index.js /app/index.js

COPY ./dist /app/dist

WORKDIR /app

RUN npm install express --save

RUN npm install connect-history-api-fallback --save

RUN npm install helmet --save

EXPOSE 80

ENTRYPOINT ["node", "index.js"]
