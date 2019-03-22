# NetCoreDemo

.NET Core 学习例子

# 服务注册方式

1. AddScoped 在请求开始到请求结束中，在此次请求中获取的对象都是同一个

2. AddTransient 每次从容器(IServiceProvider)中获取的都是一个新的实例，每次使用时都是一个新的实例

3. AddSingleton 每次从容器(IServiceProvider)中获取的都是同一个实例，项目启动-项目关闭,相当于单例 

# 管道请求顺序

1. 异常/错误处理

2. HTTP 严格传输安全协

3. HTTPS 重定向

4. 静态文件服务器

5. Cookie 策略实施

6. 身份验证

7. 会话

8. MVC

# swagger

 报 See config settings - "CustomSchemaIds" for a workaround 错误

 原因：有相同类名，但是命名空间又不相同

解决方案：设置 CustomSchemaIds(p => p.FullName)

# JWT

### JWT 构成

头部(header).载荷(payload).签名(signature)

#### header

由声明类型和声明加密的算法组成

```json
{
  'typ': 'JWT',
  'alg': 'HS256'
}
```

#### payload

**iss**: jwt签发者

**sub**: jwt所面向的用户

**aud**: 接收jwt的一方

**exp**: jwt的过期时间，这个过期时间必须要大于签发时间

**nbf**: 定义在什么时间之前，该jwt都是不可用的

**iat**: jwt的签发时间

**jti**: jwt的唯一身份标识，主要用来作为一次性token,从而回避重放攻击

#### signature

var encodeStr = base64(header) + "." + base64(payload);

var secret = "服务端自定的加密字符串密钥";

var signature = HmacSha256(encodeStr + "." + secret);

# 未完成功能

1. JWT 服务端自动过期 Token
2. 全局配置权限过滤特性(Authorize)
3. webapi 全局配置路由？