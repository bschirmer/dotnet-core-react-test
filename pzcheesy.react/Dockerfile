### FRONTEND SETUP ###
# build react project
FROM node:12.16.1 AS build-frontend

# make a folder for frontend files
WORKDIR /source

# expose node to path
ENV PATH /source/node_modules/.bin:$PATH
COPY package.json /source/package.json

# build react project
RUN npm install --silent
RUN npm install react-scripts -g --silent
COPY . /source

CMD [ "npm", "start" ]