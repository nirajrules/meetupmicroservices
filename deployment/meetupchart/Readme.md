# 1. Deployment Components

## 1.1. Helm Chart

This Helm Chart ('meetupchart') has been created to deploy MeetupExtensions application. Environment specific values are extracted and kept in values.yaml file. Here are some of the reference commands that you can use to work with this helm chart.

```bash
helm template ./meetupchart # Check the template rendering for the meetupchart with values being replaced from values.yaml file
helm install meetup ./meetupchart # Install the helm Chart; Recommended practice is not do a manual deployment but use a CD tool like ArgoCD
helm delete meetup # Delete the helm release
helm inspect values kiwigrid/fluentd-elasticsearch > values.yml # Inspect values for a given helm chart
helm install --set elasticsearch.hosts=elasticsearch-master:9200 -n logging fluentd kiwigrid/fluentd-elasticsearch # set individual values and namespace for helm install
helm install -f myvalues.yaml -f override.yaml  myredis ./redis # priority will be given to the last (right-most) file specified
```

## 1.2. Istio L7 Ingress Gateway traffic flow

A client makes a request on a specific port.
The Load Balancer listens on this port and forwards the request to one of the workers in the cluster (on the same or a new port).
Inside the cluster the request is routed to the Istio IngressGateway Service which is listening on the port the load balancer forwards to.
The Service forwards the request (on the same or a new port) to an Istio IngressGateway Pod (managed by a Deployment).
The IngressGateway Pod is configured by a Gateway (!) and a VirtualService.
The Gateway configures the ports, protocol, and certificates.
The VirtualService configures routing information to find the correct Service
The Istio IngressGateway Pod routes the request to the application Service.
And finally, the application Service routes the request to an application Pod (managed by a deployment)

Note: It's recommended to create Gateway and VirtualService in the same namespace as the destination K8s service
