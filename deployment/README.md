# Deployment Approaches

## Docker-Compose

docker-compose can be considered a wrapper around the docker CLI (in fact it is another implementation in python as said in the comments) in order to gain time and avoid 500 characters-long lines (and also start multiple containers at the same time). It uses a file called docker-compose.yml in order to retrieve parameters. docker-compose build and up commands let us manage and deploy a bunch of containers together - it can be seen as a ALM tool.

