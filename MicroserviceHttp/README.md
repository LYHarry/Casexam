# MicroserviceDemo

微服务 Demo


## 接口主程序
http://localhost:5000/api/Order/OrderInfo
http://localhost:5000/api/User/UserInfo

## UserService

dotnet MicroserviceDemo.UserServiceInstance.dll --ip="127.0.0.1"  --port=2028 --weight=1
dotnet MicroserviceDemo.UserServiceInstance.dll --ip="127.0.0.1"  --port=2029 --weight=5
dotnet MicroserviceDemo.UserServiceInstance.dll --ip="127.0.0.1"  --port=2030 --weight=10

## OrderService

dotnet MicroserviceDemo.OrderServiceInstance.dll --ip="127.0.0.1"  --port=4028 --weight=1
dotnet MicroserviceDemo.OrderServiceInstance.dll --ip="127.0.0.1"  --port=4029 --weight=5
dotnet MicroserviceDemo.OrderServiceInstance.dll --ip="127.0.0.1"  --port=4030 --weight=10

## Consul

consul：
consul.exe agent -dev
http://localhost:8500/