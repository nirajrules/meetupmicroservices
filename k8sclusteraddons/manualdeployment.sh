#!/usr/bin/env bash

# ### Install Kubectl ###
curl -LO https://storage.googleapis.com/kubernetes-release/release/`curl -s https://storage.googleapis.com/kubernetes-release/release/stable.txt`/bin/linux/amd64/kubectl
chmod +x ./kubectl
sudo mv ./kubectl /usr/local/bin/kubectl

# ### Install Helm ###
brew install helm # If not on mac refer to - https://helm.sh/docs/intro/install/

# ### Install istioctl ###
curl -L https://istio.io/downloadIstio | sh -
cp istio-*/bin/istioctl /usr/local/bin
rm -rf istio-*

### Install Istio ###
istioctl install --set profile=demo # demo profile installs prometheus(monitoring), grafana (monitoring), jaeger (tracing), kiali (istio management console) 
kubectl label namespace default istio-injection=enabled

### Install Prometheus & Grafana ###
helm repo add stable https://kubernetes-charts.storage.googleapis.com/ 
helm install prometheus stable/prometheus
helm install grafana stable/grafana

### Install ElasticSearch & Kibana ###
helm repo add elastic https://helm.elastic.co
kubectl create namespace logging
helm install elasticsearch elastic/elasticsearch -n logging
helm install kibana elastic/kibana -n logging

### Install FluentD ###
kubectl apply -f ./fluentd/daemonset.yml 
# Helm Chart appears to be still in beta - https://github.com/fluent/helm-charts

### Install Argo ###
kubectl create namespace argocd
kubectl apply -n argocd -f ./argo/argorelease.yml

### Install Tekton ###
kubectl apply --filename ./tekton/tektonrelease.yml

### Install Let's Encrypt Certificates ###
CERT_DIR=/Users/nirajbhatt
EMAIL="nirajbhatt@outlook.com"
DOMAIN="*.niraj.dockerps.io"
docker run -it --rm \
  --name letsencrypt \
  -v "${CERT_DIR}/letsencrypt:/etc/letsencrypt" \
  -v "${CERT_DIR}/opt/letsencrypt:/var/log/letsencrypt" \
  -v "${CERT_DIR}/opt/letsencrypt:/var/lib/letsencrypt" \
  certbot/certbot:latest certonly \
  --server https://acme-v02.api.letsencrypt.org/directory \
  --manual --preferred-challenges dns \
  -m "${EMAIL}" -d "${DOMAIN}" --agree-tos

# # Examine certificate in ${CERT_DIR}/letsencrypt/live/<domainName> folder
# openssl x509 -in cert.pem -text -noout

# Check if certificate is issued by a given CA
# openssl verify -verbose -CAFile ca.pem cert.pem

# Run the below command to create K8s secret used for istio telemetry gateway

kubectl create -n istio-system secret tls telemetry-gw-cert --key=${CERT_DIR}/letsencrypt/live/niraj.dockerps.io/privkey.pem --cert=${CERT_DIR}/letsencrypt/live/niraj.dockerps.io

# Expose K8s Addons via Istio Ingress Gateway
kubectl apply -f exposeaddons.yml