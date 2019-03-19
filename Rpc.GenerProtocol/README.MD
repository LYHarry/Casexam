# 生成 gRPC 协议代码
在当前项目的解决方案文件夹下：

打开 cmd 窗口执行命令：
packages\Grpc.Tools.1.19.0\tools\windows_x64\protoc.exe -I Rpc.GenerProtocol Rpc.GenerProtocol\CallRpcMethod.proto --csharp_out Rpc.GenerProtocol --grpc_out Rpc.GenerProtocol --plugin=protoc-gen-grpc=packages\Grpc.Tools.1.19.0\tools\windows_x64\grpc_csharp_plugin.exe 

# 参数说明

-I  指定搜索目录

--csharp_out  c# 代码文件输出路径

--grpc_out  grpc 协议代码文件输出路径

# 参考资料

生成 grpc 协议代码：

https://www.cnblogs.com/linezero/p/grpc.html

protoc 参数说明：

https://www.cnblogs.com/ghj1976/p/5435565.html