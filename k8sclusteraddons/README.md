istioctl manifest generate --set profile=demo | kubectl delete -f -

istioctl analyze -n logging

istioctl profile dump demo > istiodemoprofile.yml

PORT=$(kubectl get service -n istio-system istio-ingressgateway --output jsonpath='{.spec.ports[?(@.name=="status-port")].nodePort}')

kubectl label namespace default istio-injection=enabled

https://www.elastic.co/guide/en/elastic-stack-get-started/7.2/get-started-elastic-stack.html