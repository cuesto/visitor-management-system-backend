# vms
# Docker commands
```
docker build -t vms-back .
```
```
docker run -d -p 53835:80 --name vms-back-app vms-back
```
```
http://192.168.99.101:53835/swagger/index.html
```
