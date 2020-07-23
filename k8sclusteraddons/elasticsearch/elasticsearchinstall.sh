#Helm Chart Github URL - https://github.com/elastic/helm-charts/tree/master/elasticsearch

helm repo add elastic https://helm.elastic.co
helm install --name elasticsearch elastic/elasticsearch