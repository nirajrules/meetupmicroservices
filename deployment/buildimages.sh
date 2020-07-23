# Build and Publish Images to Docker Registry

DOCKER_REGISTRY=docker.io/nirajdock

rm -rf ../src/MeetupAPIService/src/obj
rm -rf ../src/MeetupAPIService/src/bin
rm -rf ../src/MeetupUI/src/bin
rm -rf ../src/MeetupUI/src/obj

docker image build -t $DOCKER_REGISTRY/meetupui -f ../src/MeetupUI/Dockerfile ../src
docker image build -t $DOCKER_REGISTRY/meetupapiservice -f ../src/MeetupAPIService/Dockerfile ../src

docker image push $DOCKER_REGISTRY/meetupui
docker image push $DOCKER_REGISTRY/meetupapiservice