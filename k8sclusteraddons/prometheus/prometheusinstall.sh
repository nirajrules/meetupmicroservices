#Helm Chart Github URL - https://github.com/helm/charts/tree/master/stable/prometheus
#helm inspect values stable/prometheus > /tmp/prometheus.values
#helm install --name my-release stable/prometheus --values /tmp/prometheus.values
#default helm install creates 2 persistent volumes
#default helm install service type is clusterIP
#helm repo add stable https://kubernetes-charts.storage.googleapis.com/ => Add Stable Repo if not already installed

helm install --name prometheus stable/prometheus