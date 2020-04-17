## 前言
- gl-admin是一个基于[ASP.NET Core 3.1](https://dotnet.microsoft.com/apps/aspnet)和[Vue.js](https://cn.vuejs.org)的后台管理系统, 其中前台的实现基于[vue-element-admin](https://github.com/PanJiaChen/vue-element-admin)搭建的
- 目标是具备后台管理类系统的通用的基础功能

## 目录说明
- dl-api-csharp 基于C#&.Net Core WebAPI实现的后台api服务
- dl-api-golang 基于Golang&Gin实现的后台api服务(计划中...)
- dl-vue-admin 基于vuejs的后台管理系统

## 技术选型
- 核心框架：ASP.NET Core 3.1
- 数据访问层：EntityFramework Core 3
- 数据库：MySQL
- 缓存：Redis
- 前端：基于vue-element-admin

## 路线图
- [ ] 部门管理
- [ ] 用户管理
- [ ] 角色管理
- [ ] 菜单管理：配置菜单功能
- [ ] 权限分配：为指定的角色配置特定的功能菜单
- [ ] 参数管理：维护系统参数，并缓存系统参数提供高效的读取
- [ ] 数据字典管理：配置维护数据字典
- [ ] 定时任务管理：编写、配置、执行定时任务
- [ ] 业务日志：通过注解的方式记录用户操作日志，并提供日志查询功能
- [ ] 登录日志：查看用户登录登出日志
- [ ] cms内容管理，配合dl-vue-h5提供了手机端内容展示系统
- [ ] 消息管理：配置消息模板，发送短信，邮件消息
