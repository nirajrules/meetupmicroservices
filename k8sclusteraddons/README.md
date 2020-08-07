# Cheat sheet for K8s cluster Addons

## Istio Commands

Istio is installed through demo profile along with - Prometheus, Grafana, Jaeger (Tracing), Kiali (Mesh Vizualizer). Here are few handy Istio commands using istioctl. Here's a good link to understand Istio basics - <https://docs.mirantis.com/docker-enterprise/v3.0/dockeree-products/ucp/deploy-apps-with-kubernetes/cluster-ingress.html> 

Delete all the istio components from the demo profile

```bash
istioctl manifest generate --set profile=demo | kubectl delete -f -
```

Analyze istio issues for a given namespace (logging in this case)

```bash
istioctl analyze -n logging
```

Get a list of components that are installed with istio demo profile

```bash
istioctl profile dump demo > istiodemoprofile.yml
```

Get the status port for istio and run the healthcheck on any of the manager / worker nodes

```bash
PORT=$(kubectl get service -n istio-system istio-ingressgateway --output jsonpath='{.spec.ports[?(@.name=="status-port")].nodePort}')
IPADDR=51.141.127.241 # Public IP Address of a Worker or Manager VM in the Cluster
curl -vvv http://$IPADDR:$PORT/healthz/ready
```

Enable Istio Sidecar injection for a given namespace. Note Sidecar Injection is not necessary for Istio Ingress (Gateway / VirtualService / DestinationRules).

```bash
kubectl label namespace default istio-injection=enabled
```

## EFK Stack

EFK Stack - ElasticSearch, FluentD & Kibana stack is used for logging. By default FluentD runs as a daemonset on all clsuter nodes and captures /var/log and /var/lib/docker/containers paths. This brings in all K8s & Docker logs to ElasticSearch which can be indexed and viewed through Kibana. Below URL is a quick start guide for Elastic Stack - <https://www.elastic.co/guide/en/elastic-stack-get-started/7.2/get-started-elastic-stack.html>

## Prometheus

Promethus is log scraping tool. It scrapes data periodically and stores it in time series database. Refer this link for a quick overview of prometheus architecture - <https://prometheus.io/docs/introduction/overview/#architecture>. Scraping is done via jobs defined in prometheus config. Job contains scrape interval at which the scraping is done. The configmap is created for you when you install prometheus via istio demo profile.

```bash
kubectl get configmaps prometheus -n istio-system -o yaml
```

A quick way to create scraping endpoint in K8s is to create a K8s service with annotation prometheus.io/scrape: 'true'. Prometheus configmap has default K8s scraping jobs which would pick up K8s services with that annotation. For more details refer to - <https://prometheus.io/docs/prometheus/latest/configuration/configuration/#kubernetes_sd_config>.

For example you can deploy the helm chart for this prometheus exporter (make sure you provide dtr_ca.pem, DTR URL, DTR Username & Password in values.yml) - <https://github.com/stevejr/dtr-prometheus-exporter>. Deploying the helm chart should pop up the metrics endpoint in targets as shown below.

![image info](./images/PromTargets.png)

