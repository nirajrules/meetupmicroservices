#Helm Chart Github URL - https://github.com/elastic/helm-charts/tree/master/kibana

helm repo add elastic https://helm.elastic.co
helm install --name kibana elastic/kibana