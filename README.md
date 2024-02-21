# HeJing:基于 ASP\.NET Core+Vue 的基础框架 - 后端部分

## 系统介绍

HeJing 是一个基础架构，用于创建基于 ASP\.NET Core+Vue 平台的软件解决方案。

该项目为前后端分离项目的后端部分，前端项目地址：[传送门](https://github.com/zcqiand/HeJing-UI)。

## 更新日志

- [更新日志](./CHANGELOG.md)

## 待办任务

### 业务模块：

- [x] 统一集成 IdentityServer4 认证
- [ ] 统一集成 微信 认证
- [ ] 实现 RBAC 权限控制
- [ ] 实现多租户

### 组件模块：

- [x] 使用 AutoMapper 处理对象映射
- [x] 使用 Swagger 做 api 文档
- [x] 使用 Serilog 日志框架，集成原生 ILogger 接口做日志记录
- [ ] 新增 EventBus 事件总线
- [ ] 新增 RabbitMQ 消息队列
- [ ] 新增 Kafka 消息队列
- [ ] 支持 数据库`读写分离`和多库操作

## 功能清单

1. **权限管理**，在该模块中，需要实现以下功能：

   - 应用管理：管理员应该能够创建、编辑和删除组织中的应用。
   - 资源管理：管理员应该能够创建、编辑和删除组织中的部门。通过建立部门层次结构，可以更好地组织和管理组织内的用户。
   - 功能管理：管理员应该能够添加、删除和管理组织中的员工，并分配适当的角色和权限。通过员工管理，可以灵活地管理组织内的用户。
   - 用户注册和认证：用户应该能够注册一个账户并进行身份验证，以获取访问权限。
   - 用户角色分配：每个用户可以被分配一个或多个角色，每个角色代表一组权限。用户的角色将决定其可以访问的功能和资源。
   - 角色管理：管理员应该能够创建、编辑和删除角色，并为每个角色分配相应的权限。这样，可以更好地组织和管理大量用户的权限。
   - 资源访问控制：系统应该根据用户的角色或权限定义，限制用户对特定资源（如文件、数据库、API 等）的访问。这样，只有经过授权的用户才能访问受保护的资源。
   - 功能访问控制：系统应该根据用户的角色或权限定义，限制用户对特定功能或操作（如创建、编辑、删除等）的访问。这样，我们可以确保只有具备相应权限的用户才能执行敏感操作。
   - 数据行级别的访问控制：在某些情况下，我们需要对数据库中的特定数据行进行访问控制。系统应该能够基于用户角色或权限定义，限制用户对特定数据行的访问，以确保用户只能访问其所需的数据。

2. **组织机构**，在该模块中，需要实现以下功能：

   - 机构管理：管理员应该能够创建、编辑和删除组织中的机构。
   - 部门管理：管理员应该能够创建、编辑和删除组织中的部门。通过建立部门层次结构，可以更好地组织和管理组织内的用户。
   - 员工管理：管理员应该能够添加、删除和管理组织中的员工，并分配适当的角色和权限。通过员工管理，可以灵活地管理组织内的用户。

3. **日志管理**，在该模块中，需要实现以下功能：
   - 操作日志：系统应该能够记录用户的操作日志，包括登录、权限变更和资源访问记录等。操作日志可以帮助我们追踪用户的活动，并进行故障排查和审计。
   - 审计日志：系统应该能够生成详细的审计日志，记录用户的权限变更、资源访问和敏感操作等。审计日志可以用于安全审计和分析，帮助我们发现潜在的安全威胁或违规行为。

## 相关子系统

| 子系统              | 端口  | 域名                    |
| ------------------- | ----- | ----------------------- |
| 安全令牌服务（STS） | 44310 | sts.skoruba.local       |
| 身份验证管理 API    | 44302 | admin-api.skoruba.local |
| 身份验证管理 UI     | 44303 | admin.skoruba.local     |
| 权限管理 API        | 7238  | -                       |
| 权限管理 UI         | 3305  | -                       |
| -                   | -     | -                       |

## 技术选型

| 技术                  | 说明               | 官网                                                                                                 |
| --------------------- | ------------------ | ---------------------------------------------------------------------------------------------------- |
| ASP.NETCore           | Web 应用           | [https://learn.microsoft.com/zh-cn/dotnet/](https://learn.microsoft.com/zh-cn/dotnet/)               |
| EFCore                | ORM                | [https://learn.microsoft.com/zh-cn/dotnet/](https://learn.microsoft.com/zh-cn/dotnet/)               |
| IdentityServer4.Admin | 认证和授权         | [https://github.com/skoruba/IdentityServer4.Admin](https://github.com/skoruba/IdentityServer4.Admin) |
| Elasticsearch         | 搜索引擎           | [https://github.com/elastic/elasticsearch](https://github.com/elastic/elasticsearch)                 |
| RabbitMQ              | 消息队列           | [https://www.rabbitmq.com/](https://www.rabbitmq.com/)                                               |
| Redis                 | 内存数据存储       | [https://redis.io/](https://redis.io/)                                                               |
| MongoDB               | NoSql 数据库       | [https://www.mongodb.com](https://www.mongodb.com)                                                   |
| Serilog               | 日志框架           | [https://github.com/serilog/serilog](https://github.com/serilog/serilog)                             |
| LogStash              | 日志收集工具       | [https://github.com/elastic/logstash](https://github.com/elastic/logstash)                           |
| Kibana                | 日志可视化查看工具 | [https://github.com/elastic/kibana](https://github.com/elastic/kibana)                               |
| Nginx                 | Web 服务器         | [https://www.nginx.com/](https://www.nginx.com/)                                                     |
| Docker                | 应用容器引擎       | [https://www.docker.com](https://www.docker.com)                                                     |
| Swagger-UI            | API 文档生成工具   | [https://github.com/swagger-api/swagger-ui](https://github.com/swagger-api/swagger-ui)               |

## 联系我

- 微信公众号：南荣相如
- 邮箱：1282301776@qq.com
- 主页：https://home.nanrong.store/
- Github: https://github.com/zcqiand

## 微信公众号

如果大家想要实时关注我更新的文章以及分享的干货的话，可以关注我的公众号。

![](https://home.nanrong.store/assets/weixin.jpg)

## 捐赠支持

如果觉得我们的内容对于你有所帮助，请作者喝杯咖啡吧！ 后续会继续完善更新！一起加油！

![](https://home.nanrong.store/assets/zhifu.png)
