# vms
# Docker commands
```
docker build -t vms-back .
```
```
docker run -d -p 53835:80 --name vms-back-app vms-back
```
```
http://192.168.99.100:53835/swagger/index.html
```
```
docker save -o prod-vms-back.tar vms-back
```
```
docker load -i prod-vms-back.tar
```

# Resource
https://docs.docker.com/engine/examples/dotnetcore/
