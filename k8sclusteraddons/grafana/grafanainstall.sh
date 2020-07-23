#GitHub Helm Chart URL - https://github.com/helm/charts/tree/master/stable/grafana
#helm repo add stable https://kubernetes-charts.storage.googleapis.com/ => Add Stable Repo if not already installed

helm install --name grafana stable/grafana