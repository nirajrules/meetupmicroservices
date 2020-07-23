curl -L https://istio.io/downloadIstio | sh -
cd istio-1.6.4
cp bin/istioctl /usr/local/bin
istioctl install --set profile=demo
kubectl label namespace default istio-injection=enabled