在当前项目的解决方案文件夹下：

打开 cmd 窗口执行如下命令即可得到 Grpc 协议代码
packages\Grpc.Tools.1.19.0\tools\windows_x64\protoc.exe -I Rpc.GenerProtocol Rpc.GenerProtocol\CallRpcMethod.proto --csharp_out Rpc.GenerProtocol --grpc_out Rpc.GenerProtocol --plugin=protoc-gen-grpc=packages\Grpc.Tools.1.19.0\tools\windows_x64\grpc_csharp_plugin.exe