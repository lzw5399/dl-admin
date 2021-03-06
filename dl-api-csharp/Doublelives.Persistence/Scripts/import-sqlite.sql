/*
 Navicat Premium Data Transfer

 Source Server         : dl-admin
 Source Server Type    : SQLite
 Source Server Version : 3021000
 Source Schema         : main

 Target Server Type    : SQLite
 Target Server Version : 3021000
 File Encoding         : 65001

 Date: 22/04/2020 18:11:44
*/


-- ----------------------------
-- Records of cms_article
-- ----------------------------
INSERT INTO "cms_article" VALUES (1, '2019-03-09 16:24:58', 1, '2019-05-10 13:22:49', 1, 'enilu', '<div id="articleContent" class="content">
<div class="ad-wrap">
<p style="margin: 0 0 10px 0;">一般我们都有这样的需求：我需要知道库中的数据是由谁创建，什么时候创建，最后一次修改时间是什么时候，最后一次修改人是谁。web-flash最新代码已经实现该需求，具体实现方式网上有很多资料，这里做会搬运工，将web-flash的实现步骤罗列如下：%%</p>
</div>
<p>在Spring jpa中可以通过在实体bean的属性或者方法上添加以下注解来实现上述需求@CreatedDate、@CreatedBy、@LastModifiedDate、@LastModifiedBy。</p>
<ul class=" list-paddingleft-2">
<li>
<p>@CreatedDate 表示该字段为创建时间时间字段，在这个实体被insert的时候，会设置值</p>
</li>
<li>
<p>@CreatedBy 表示该字段为创建人，在这个实体被insert的时候，会设置值</p>
</li>
<li>
<p>@LastModifiedDate 最后修改时间 实体被update的时候会设置</p>
</li>
<li>
<p>@LastModifiedBy 最后修改人 实体被update的时候会设置</p>
</li>
</ul>
<h2>使用方式</h2>
<h3>实体类添加注解</h3>
<ul class=" list-paddingleft-2">
<li>
<p>首先在实体中对应的字段加上上述4个注解</p>
</li>
<li>
<p>在web-flash中我们提取了一个基础实体类BaseEntity，并将对应的字段添加上述4个注解,所有需要记录维护信息的表对应的实体都集成该类</p>
</li>
</ul>
<pre>import&nbsp;org.springframework.data.annotation.CreatedBy;
import&nbsp;org.springframework.data.annotation.CreatedDate;
import&nbsp;org.springframework.data.annotation.LastModifiedBy;
import&nbsp;org.springframework.data.annotation.LastModifiedDate;
import&nbsp;javax.persistence.Column;
import&nbsp;javax.persistence.GeneratedValue;
import&nbsp;javax.persistence.Id;
import&nbsp;javax.persistence.MappedSuperclass;
import&nbsp;java.io.Serializable;
import&nbsp;java.util.Date;
@MappedSuperclass
@Data
public&nbsp;abstract&nbsp;class&nbsp;BaseEntity&nbsp;implements&nbsp;Serializable&nbsp;{
&nbsp;&nbsp;&nbsp;&nbsp;@Id
&nbsp;&nbsp;&nbsp;&nbsp;@GeneratedValue
&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;Long&nbsp;id;
&nbsp;&nbsp;&nbsp;&nbsp;@CreatedDate
&nbsp;&nbsp;&nbsp;&nbsp;@Column(name&nbsp;=&nbsp;"create_time",columnDefinition="DATETIME&nbsp;COMMENT&nbsp;''创建时间/注册时间''")
&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;Date&nbsp;createTime;
&nbsp;&nbsp;&nbsp;&nbsp;@Column(name&nbsp;=&nbsp;"create_by",columnDefinition="bigint&nbsp;COMMENT&nbsp;''创建人''")
&nbsp;&nbsp;&nbsp;&nbsp;@CreatedBy
&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;Long&nbsp;createBy;
&nbsp;&nbsp;&nbsp;&nbsp;@LastModifiedDate
&nbsp;&nbsp;&nbsp;&nbsp;@Column(name&nbsp;=&nbsp;"modify_time",columnDefinition="DATETIME&nbsp;COMMENT&nbsp;''最后更新时间''")
&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;Date&nbsp;modifyTime;
&nbsp;&nbsp;&nbsp;&nbsp;@LastModifiedBy
&nbsp;&nbsp;&nbsp;&nbsp;@Column(name&nbsp;=&nbsp;"modify_by",columnDefinition="bigint&nbsp;COMMENT&nbsp;''最后更新人''")
&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;Long&nbsp;modifyBy;
}</pre>
<h3>实现AuditorAware接口返回操作人员的id</h3>
<p>配置完上述4个注解后，在jpa.save方法被调用的时候，时间字段会自动设置并插入数据库，但是CreatedBy和LastModifiedBy并没有赋值 这两个信息需要实现AuditorAware接口来返回操作人员的id</p>
<ul class=" list-paddingleft-2">
<li>
<p>首先需要在项目启动类添加@EnableJpaAuditing 注解来启用审计功能</p>
</li>
</ul>
<pre>@SpringBootApplication
@EnableJpaAuditing
public&nbsp;class&nbsp;AdminApplication&nbsp;extends&nbsp;WebMvcConfigurerAdapter&nbsp;{
&nbsp;//省略
}</pre>
<ul class=" list-paddingleft-2">
<li>
<p>然后实现AuditorAware接口返回操作人员的id</p>
</li>
</ul>
<pre>@Configuration
public&nbsp;class&nbsp;UserIDAuditorConfig&nbsp;implements&nbsp;AuditorAware&lt;Long&gt;&nbsp;{
&nbsp;&nbsp;&nbsp;&nbsp;@Override
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;Long&nbsp;getCurrentAuditor()&nbsp;{
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShiroUser&nbsp;shiroUser&nbsp;=&nbsp;ShiroKit.getUser();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;if(shiroUser!=null){
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return&nbsp;shiroUser.getId();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return&nbsp;null;
&nbsp;&nbsp;&nbsp;&nbsp;}
}</pre>
</div>', 1, 1, 'web-flash 将所有表增加维护人员和维护时间信息');
INSERT INTO "cms_article" VALUES (2, '2019-03-09 16:24:58', 1, '2019-03-23 23:12:16', 1, 'enilu.cn', '<div id="articleContent" class="content">
<div class="ad-wrap">
<p style="margin: 0 0 10px 0;"><a style="color: #a00; font-weight: bold;" href="https://my.oschina.net/u/3985214/blog/3018099?tdsourcetag=s_pcqq_aiomsg" target="_blank" rel="noopener" data-traceid="news_detail_above_texlink_1" data-tracepid="news_detail_above_texlink">开发十年，就只剩下这套架构体系了！ &gt;&gt;&gt;</a>&nbsp;&nbsp;<img style="max-height: 32px; max-width: 32px;" src="https://www.oschina.net/img/hot3.png" align="" /></p>
</div>
<h3>国际化</h3>
<ul class=" list-paddingleft-2">
<li>
<p>web-flash实现国际化了.</p>
</li>
<li>
<p>不了解上面两个的区别的同学可以再回顾下这个<a href="http://www.enilu.cn/web-flash/base/web-flash.html">文档</a></p>
</li>
<li>
<p>web-flash实现国际化的方式参考vue-element-admin的&nbsp;<a href="https://panjiachen.github.io/vue-element-admin-site/zh/guide/advanced/i18n.html" target="_blank" rel="noopener">官方文档</a>,这里不再赘述,强烈建议你先把文档读了之后再看下面的内容。</p>
</li>
</ul>
<h3>默认约定</h3>
<p>针对网站资源进行国际园涉及到的国际化资源的管理维护，这里给出一些web-flash的资源分类建议，当然，你也可以根据你的实际情况进行调整。</p>
<ul class=" list-paddingleft-2">
<li>
<p>src/lang/为国际化资源目录,目前提供了英文（en.js）和中文(zh.js)的两种语言实现。</p>
</li>
<li>
<p>目前资源语言资源文件中是json配置主要有以下几个节点：</p>
</li>
<ul class=" list-paddingleft-2" style="list-style-type: square;">
<li>
<p>route 左侧菜单资源</p>
</li>
<li>
<p>navbar 顶部导航栏资源</p>
</li>
<li>
<p>button 公共的按钮资源，比如：添加、删除、修改、确定、取消之类等等</p>
</li>
<li>
<p>common 其他公共的资源，比如一些弹出框标题、提示信息、label等等</p>
</li>
<li>
<p>login 登录页面资源</p>
</li>
<li>
<p>config 参数管理界面资源</p>
</li>
</ul>
<li>
<p>目前针对具体的页面资源只做了登录和参数管理两个页面，其他具体业务界面仅针对公共的按钮做了国际化，你可以参考config页面资源进行配置进行进一步配置：/src/views/cfg/</p>
</li>
<li>
<p>如果你有其他资源在上面对应的节点添加即可，针对每个页面特有的资源以页面名称作为几点进行维护，这样方便记忆和维护，不容易出错。</p>
</li>
</ul>
<h3>添加新的语言支持</h3>
<p>如果英文和中文两种语言不够，那么你可以通过下面步骤添加语言支持</p>
<ul class=" list-paddingleft-2">
<li>
<p>在src/lang/目录下新增对应的资源文件</p>
</li>
<li>
<p>在src/lang/index.js中import对应的资源文件</p>
</li>
<li>
<p>在src/lang/index.js中的messages变量中加入新的语言声明</p>
</li>
<li>
<p>在src/components/LangSelect/index.vue的语言下拉框中增加新的语言选项</p>
</li>
</ul>
<h3>演示地址</h3>
<ul class=" list-paddingleft-2">
<li>
<p>vue版本后台管理&nbsp;<a href="http://106.75.35.53:8082/vue/#/login" target="_blank" rel="noopener">http://106.75.35.53:8082/vue/#/login</a></p>
</li>
<li>CMS内容管理系统的h5前端demo:<a href="http://106.75.35.53:8082/mobile/#/index" target="_blank" rel="noopener">http://106.75.35.53:8082/mobile/#/index</a></li>
</ul>
</div>', 1, 2, 'web-flash1.0.1 发布，增加国际化和定时任务管理功能');
INSERT INTO "cms_article" VALUES (3, '2019-03-09 16:24:58', 1, '2019-04-28 17:39:52', 1, 'enilu.cn', '<div class="content" id="articleContent">
                        <div class="ad-wrap">
                                                    <p style="margin:0 0 10px 0;"><a data-traceid="news_detail_above_texlink_1" data-tracepid="news_detail_above_texlink" style="color:#A00;font-weight:bold;" href="https://my.oschina.net/u/3985214/blog/3018099?tdsourcetag=s_pcqq_aiomsg" target="_blank">开发十年，就只剩下这套架构体系了！ &gt;&gt;&gt;</a>&nbsp;&nbsp;<img src="https://www.oschina.net/img/hot3.png" align="" style="max-height: 32px; max-width: 32px;"></p>
                                    </div>
                        <p>web-flash使用的Spring Boot从1.5.1升级到2.1.1</p><p>下面为升级过程</p><ul class=" list-paddingleft-2"><li><p>版本升级</p><pre>&lt;spring.boot.version&gt;2.1.1.RELEASE&lt;/spring.boot.version&gt;
&lt;springframework.version&gt;5.1.3.RELEASE&lt;springframework.version&gt;</pre></li><li><p>配置增加</p><pre>spring.main.allow-bean-definition-overriding=true
spring.jpa.hibernate.use-new-id-generator-mappings=false</pre></li></ul><ul class=" list-paddingleft-2"><li><p>审计功能调整，调整后代码:</p><pre>@Configuration
public&nbsp;class&nbsp;UserIDAuditorConfig&nbsp;implements&nbsp;AuditorAware&lt;Long&gt;&nbsp;{
&nbsp;&nbsp;&nbsp;&nbsp;@Override
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;Optional&lt;Long&gt;&nbsp;getCurrentAuditor()&nbsp;{
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShiroUser&nbsp;shiroUser&nbsp;=&nbsp;ShiroKit.getUser();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;if(shiroUser!=null){
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return&nbsp;Optional.of(shiroUser.getId());
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return&nbsp;null;
&nbsp;&nbsp;&nbsp;&nbsp;}
}</pre></li><li><p>repository调整</p></li><ul class=" list-paddingleft-2" style="list-style-type: square;"><li><p>之前的 delete(Long id)方法没有了，替换为：deleteById(Long id)</p></li><li><p>之前的 T findOne(Long id)方法没有了，替换为：		</p><pre>Optional&lt;T&gt;&nbsp;optional&nbsp;=&nbsp;***Repository.findById(id);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;if&nbsp;(optional.isPresent())&nbsp;{
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return&nbsp;optional.get();
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return&nbsp;null;</pre></li></ul><li><p>随着这次Spring Boot的升级也顺便做了一些其他内容的调整和重构</p></li><ul class=" list-paddingleft-2" style="list-style-type: square;"><li><p>springframework也从4.3.5.RELEASE升级到5.1.3.RELEASE</p></li><li><p>为减小复杂度service去掉接口和实现类的结构，基础功能的service直接使用实现类；当然具体业务中如果有需求你也可以这没用</p></li><li><p>去掉了一些暂时用不到的maven依赖</p></li><li><p>完善了基础功能的审计功能(之前有介绍审计功能的实现翻番，后续会专门发一篇文档来说明审计功能在系统总的具体用法，当然聪明的你看代码就知道了)</p></li></ul></ul>
                    </div>', 1, 1, 'web-flash 升级 Spring Boot 到 2.1.1 版本');
INSERT INTO "cms_article" VALUES (4, '2019-03-09 16:24:58', 1, '2019-04-28 00:34:21', 1, 'enilu.cn', 'H5通用官网系统', 2, 17, 'H5通用官网系统');
INSERT INTO "cms_article" VALUES (5, '2019-03-09 16:24:58', 1, '2019-04-28 00:34:36', 1, 'enilu.cn', 'H5通用论坛系统', 2, 18, 'H5通用论坛系统');
INSERT INTO "cms_article" VALUES (6, '2019-03-09 16:24:58', 1, '2019-04-28 00:38:33', 1, 'enilu.cn', '官网建设方案', 3, 19, '官网建设方案');
INSERT INTO "cms_article" VALUES (7, '2019-03-09 16:24:58', 1, '2019-04-28 00:39:48', 1, 'enilu.cn', '论坛建设方案', 3, 22, '论坛建设方案');
INSERT INTO "cms_article" VALUES (8, '2019-03-09 16:24:58', 1, '2019-04-28 17:39:52', 1, 'enilu.cn', '案例1', 4, 3, '案例1');
INSERT INTO "cms_article" VALUES (9, '2019-03-09 16:24:58', 1, '2019-04-28 00:39:11', 1, 'enilu.cn', '案例2', 4, 20, '案例2');
INSERT INTO "cms_article" VALUES (14, '2019-03-09 16:24:58', 1, '2019-04-28 00:39:25', 1, 'test5', '<p>aaaaa<img class="wscnph" src="http://127.0.0.1:8082/file/download?idFile=12" /></p>', 4, 21, 'IDEA的代码生成插件发布啦');
INSERT INTO "cms_article" VALUES (15, '2019-04-28 17:39:52', 1, '2019-05-05 15:36:57', 1, 'enilu', '<p><img class="wscnph" src="http://127.0.0.1:8082/file/download?idFile=24" /></p>', 1, 25, '程序员头冷');



-- ----------------------------
-- Records of cms_banner
-- ----------------------------
INSERT INTO "cms_banner" VALUES (1, '2019-03-09 16:29:03', 1, NULL, NULL, 1, '不打开链接', 'index', 'javascript:');
INSERT INTO "cms_banner" VALUES (2, '2019-03-09 16:29:03', 1, NULL, NULL, 2, '打打开站内链接', 'index', '/contact');
INSERT INTO "cms_banner" VALUES (3, '2019-03-09 16:29:03', 1, NULL, NULL, 6, '打开外部链接', 'index', 'http://www.baidu.com');
INSERT INTO "cms_banner" VALUES (4, '2019-03-09 16:29:03', 1, NULL, NULL, 1, '不打开链接', 'product', 'javascript:');
INSERT INTO "cms_banner" VALUES (5, '2019-03-09 16:29:03', 1, NULL, NULL, 2, '打打开站内链接', 'product', '/contact');
INSERT INTO "cms_banner" VALUES (6, '2019-03-09 16:29:03', 1, NULL, NULL, 6, '打开外部链接', 'product', 'http://www.baidu.com');
INSERT INTO "cms_banner" VALUES (7, '2019-03-09 16:29:03', 1, NULL, NULL, 1, '不打开链接', 'solution', 'javascript:');
INSERT INTO "cms_banner" VALUES (8, '2019-03-09 16:29:03', 1, NULL, NULL, 2, '打打开站内链接', 'solution', '/contact');
INSERT INTO "cms_banner" VALUES (9, '2019-03-09 16:29:03', 1, NULL, NULL, 6, '打开外部链接', 'solution', 'http://www.baidu.com');
INSERT INTO "cms_banner" VALUES (10, '2019-03-09 16:29:03', 1, NULL, NULL, 1, '不打开链接', 'case', 'javascript:');
INSERT INTO "cms_banner" VALUES (11, '2019-03-09 16:29:03', 1, NULL, NULL, 2, '打打开站内链接', 'case', '/contact');
INSERT INTO "cms_banner" VALUES (12, '2019-03-09 16:29:03', 1, NULL, NULL, 6, '打开外部链接', 'case', 'http://www.baidu.com');
INSERT INTO "cms_banner" VALUES (14, '2019-03-09 16:29:03', 1, NULL, NULL, 1, '不打开链接', 'news', 'javascript:');
INSERT INTO "cms_banner" VALUES (15, '2019-03-09 16:29:03', 1, NULL, NULL, 2, '打打开站内链接', 'news', '/contact');
INSERT INTO "cms_banner" VALUES (16, '2019-03-09 16:29:03', 1, NULL, NULL, 6, '打开外部链接', 'news', 'http://www.baidu.com');



-- ----------------------------
-- Records of cms_channel
-- ----------------------------
INSERT INTO "cms_channel" VALUES (1, NULL, NULL, '2019-03-13 22:52:46', 1, 'news', '动态资讯');
INSERT INTO "cms_channel" VALUES (2, NULL, NULL, '2019-03-13 22:53:11', 1, 'product', '产品服务');
INSERT INTO "cms_channel" VALUES (3, NULL, NULL, '2019-03-13 22:53:37', 1, 'solution', '解决方案');
INSERT INTO "cms_channel" VALUES (4, NULL, NULL, '2019-03-13 22:53:41', 1, 'case', '精选案例');


-- ----------------------------
-- Records of cms_contacts
-- ----------------------------
INSERT INTO "cms_contacts" VALUES (1, '2019-07-31 17:44:27', NULL, '2019-07-31 17:44:27', NULL, 'test@qq.com', 15011111111, '测试联系，哈哈哈', '张三');



-- ----------------------------
-- Records of message
-- ----------------------------
INSERT INTO "message" VALUES (1, '2019-06-10 21:20:16', NULL, NULL, NULL, '【腾讯云】校验码1032，请于5分钟内完成验证，如非本人操作请忽略本短信。', 15021592814, 2, 'REGISTER_CODE', 0);


-- ----------------------------
-- Records of message_sender
-- ----------------------------
INSERT INTO "message_sender" VALUES (1, NULL, NULL, NULL, NULL, 'tencentSmsSender', ' 腾讯短信服务', NULL);
INSERT INTO "message_sender" VALUES (2, NULL, NULL, NULL, NULL, 'defaultEmailSender', '默认邮件发送器', NULL);



-- ----------------------------
-- Records of message_template
-- ----------------------------
INSERT INTO "message_template" VALUES (1, NULL, NULL, NULL, NULL, 'REGISTER_CODE', '注册页面，点击获取验证码', '【腾讯云】校验码{1}，请于5分钟内完成验证，如非本人操作请忽略本短信。', 1, '注册验证码', 0);
INSERT INTO "message_template" VALUES (2, NULL, NULL, NULL, NULL, 'EMAIL_TEST', '测试发送', '你好:{1},欢迎使用{2}', 2, '测试邮件', 1);
INSERT INTO "message_template" VALUES (3, NULL, NULL, NULL, NULL, 'EMAIL_HTML_TEMPLATE_TEST', '测试发送模板邮件', '你好<strong>${userName}</strong>欢迎使用<font color="red">${appName}</font>,这是html模板邮件', 2, '测试发送模板邮件', 1);



-- ----------------------------
-- Records of sys_cfg
-- ----------------------------
INSERT INTO "sys_cfg" VALUES (1, NULL, NULL, '2019-04-15 21:36:07', 1, '应用名称update by 2019-03-27 11:47:04', 'system.app.name', 'web-flash');
INSERT INTO "sys_cfg" VALUES (2, NULL, NULL, '2019-04-15 21:36:17', 1, '系统默认上传文件路径', 'system.file.upload.path', '/data/web-flash/runtime/upload');
INSERT INTO "sys_cfg" VALUES (3, NULL, NULL, '2019-04-15 21:36:17', 1, '腾讯sms接口appid', 'api.tencent.sms.appid', 1400219425);
INSERT INTO "sys_cfg" VALUES (4, NULL, NULL, '2019-04-15 21:36:17', 1, '腾讯sms接口appkey', 'api.tencent.sms.appkey', '5f71ed5325f3b292946530a1773e997a');
INSERT INTO "sys_cfg" VALUES (5, NULL, NULL, '2019-04-15 21:36:17', 1, '腾讯sms接口签名参数', 'api.tencent.sms.sign', '需要去申请咯');


-- ----------------------------
-- Records of sys_dept
-- ----------------------------
INSERT INTO "sys_dept" VALUES (24, NULL, NULL, NULL, NULL, '总公司', 1, 0, '[0],', '总公司', '', NULL);
INSERT INTO "sys_dept" VALUES (25, NULL, NULL, NULL, NULL, '开发部', 2, 24, '[0],[24],', '开发部', '', NULL);
INSERT INTO "sys_dept" VALUES (26, NULL, NULL, NULL, NULL, '运营部', 3, 24, '[0],[24],', '运营部', '', NULL);
INSERT INTO "sys_dept" VALUES (27, NULL, NULL, NULL, NULL, '战略部', 4, 24, '[0],[24],', '战略部', '', NULL);


-- ----------------------------
-- Records of sys_dict
-- ----------------------------
INSERT INTO "sys_dict" VALUES (16, NULL, NULL, NULL, NULL, '状态', 0, 0, NULL);
INSERT INTO "sys_dict" VALUES (17, NULL, NULL, NULL, NULL, '启用', 1, 16, NULL);
INSERT INTO "sys_dict" VALUES (18, NULL, NULL, NULL, NULL, '禁用', 2, 16, NULL);
INSERT INTO "sys_dict" VALUES (29, NULL, NULL, NULL, NULL, '性别', 0, 0, NULL);
INSERT INTO "sys_dict" VALUES (30, NULL, NULL, NULL, NULL, '男', 1, 29, NULL);
INSERT INTO "sys_dict" VALUES (31, NULL, NULL, NULL, NULL, '女', 2, 29, NULL);
INSERT INTO "sys_dict" VALUES (35, NULL, NULL, NULL, NULL, '账号状态', 0, 0, NULL);
INSERT INTO "sys_dict" VALUES (36, NULL, NULL, NULL, NULL, '启用', 1, 35, NULL);
INSERT INTO "sys_dict" VALUES (37, NULL, NULL, NULL, NULL, '冻结', 2, 35, NULL);
INSERT INTO "sys_dict" VALUES (38, NULL, NULL, NULL, NULL, '已删除', 3, 35, NULL);
INSERT INTO "sys_dict" VALUES (53, NULL, NULL, NULL, NULL, '证件类型', 0, 0, NULL);
INSERT INTO "sys_dict" VALUES (54, NULL, NULL, NULL, NULL, '身份证', 1, 53, NULL);
INSERT INTO "sys_dict" VALUES (55, NULL, NULL, NULL, NULL, '护照', 2, 53, NULL);
INSERT INTO "sys_dict" VALUES (68, '2019-01-13 14:18:21', 1, '2019-01-13 14:18:21', 1, '是否', 0, 0, NULL);
INSERT INTO "sys_dict" VALUES (69, '2019-01-13 14:18:21', 1, '2019-01-13 14:18:21', 1, '是', 1, 68, NULL);
INSERT INTO "sys_dict" VALUES (70, '2019-01-13 14:18:21', 1, '2019-01-13 14:18:21', 1, '否', 0, 68, NULL);


-- ----------------------------
-- Records of sys_file_info
-- ----------------------------
INSERT INTO "sys_file_info" VALUES (1, '2019-03-18 10:34:34', 1, '2019-03-18 10:34:34', 1, 'banner1.png', '7e9ebc08-b194-4f85-8997-d97ccb0d2c2d.png');
INSERT INTO "sys_file_info" VALUES (2, '2019-03-18 10:54:04', 1, '2019-03-18 10:54:04', 1, 'banner2.png', '756b9ca8-562f-4bf5-a577-190dcdd25c29.png');
INSERT INTO "sys_file_info" VALUES (3, '2019-03-18 20:09:59', 1, '2019-03-18 20:09:59', 1, 'offcial_site.png', 'b0304e2b-0ee3-4966-ac9f-a075b13d4af6.png');
INSERT INTO "sys_file_info" VALUES (4, '2019-03-18 20:10:18', 1, '2019-03-18 20:10:18', 1, 'bbs.png', '67486aa5-500c-4993-87ad-7e1fbc90ac1a.png');
INSERT INTO "sys_file_info" VALUES (5, '2019-03-18 20:20:14', 1, '2019-03-18 20:20:14', 1, 'product.png', '1f2b05e0-403a-41e0-94a2-465f0c986b78.png');
INSERT INTO "sys_file_info" VALUES (6, '2019-03-18 20:22:09', 1, '2019-03-18 20:22:09', 1, 'profile.jpg', '40ead888-14d1-4e9f-abb3-5bfb056a966a.jpg');
INSERT INTO "sys_file_info" VALUES (7, '2019-03-20 09:05:54', 1, '2019-03-20 09:05:54', 1, '2303938_1453211.png', '87b037da-b517-4007-a66e-ba7cc8cfd6ea.png');
INSERT INTO "sys_file_info" VALUES (8, NULL, NULL, NULL, NULL, 'login.png', '26835cc4-059e-4900-aff5-a41f2ea6a61d.png');
INSERT INTO "sys_file_info" VALUES (9, NULL, NULL, NULL, NULL, 'login.png', '7ec7553b-7c9e-44d9-b9c2-3d89b11cf842.png');
INSERT INTO "sys_file_info" VALUES (10, NULL, NULL, NULL, NULL, 'login.png', '357c4aad-19fd-4600-9fb6-e62aafa3df25.png');
INSERT INTO "sys_file_info" VALUES (11, NULL, NULL, NULL, NULL, 'index.png', '55dd582b-033e-440d-8e8d-c8d39d01f1bb.png');
INSERT INTO "sys_file_info" VALUES (12, NULL, NULL, NULL, NULL, 'login.png', '70507c07-e8bc-492f-9f0a-00bf1c23e329.png');
INSERT INTO "sys_file_info" VALUES (13, NULL, NULL, NULL, NULL, 'index.png', 'cd539518-d15a-4cda-a19f-251169f5d1a4.png');
INSERT INTO "sys_file_info" VALUES (14, NULL, NULL, NULL, NULL, 'login.png', '194c8a38-be94-483c-8875-3c62a857ead7.png');
INSERT INTO "sys_file_info" VALUES (15, NULL, NULL, NULL, NULL, 'index.png', '6a6cb215-d0a7-4574-a45e-5fa04dcfdf90.png');
INSERT INTO "sys_file_info" VALUES (16, '2019-03-21 19:37:50', 1, NULL, NULL, '测试文档.doc', 'd9d77815-496f-475b-a0f8-1d6dcb86e6ab.doc');
INSERT INTO "sys_file_info" VALUES (17, '2019-04-28 00:34:09', 1, NULL, NULL, '首页.png', 'd5aba978-f8af-45c5-b079-673decfbdf26.png');
INSERT INTO "sys_file_info" VALUES (18, '2019-04-28 00:34:34', 1, NULL, NULL, '资讯.png', '7e07520d-5b73-4712-800b-16f88d133db2.png');
INSERT INTO "sys_file_info" VALUES (19, '2019-04-28 00:38:32', 1, NULL, NULL, '产品服务.png', '99214651-8cb8-4488-b572-12c6aa21f30a.png');
INSERT INTO "sys_file_info" VALUES (20, '2019-04-28 00:39:09', 1, NULL, NULL, '67486aa5-500c-4993-87ad-7e1fbc90ac1a.png', '31fdc83e-7688-41f5-b153-b6816d5dfb06.png');
INSERT INTO "sys_file_info" VALUES (21, '2019-04-28 00:39:22', 1, NULL, NULL, '67486aa5-500c-4993-87ad-7e1fbc90ac1a.png', 'ffaf0563-3115-477b-b31d-47a4e80a75eb.png');
INSERT INTO "sys_file_info" VALUES (22, '2019-04-28 00:39:47', 1, NULL, NULL, '7e07520d-5b73-4712-800b-16f88d133db2.png', '8928e5d4-933a-4953-9507-f60b78e3ccee.png');
INSERT INTO "sys_file_info" VALUES (23, '2019-04-28 17:34:31', NULL, NULL, NULL, '756b9ca8-562f-4bf5-a577-190dcdd25c29.png', '7d64ba36-adc4-4982-9ec2-8c68db68861b.png');
INSERT INTO "sys_file_info" VALUES (24, '2019-04-28 17:39:43', NULL, NULL, NULL, 'timg.jpg', '6483eb26-775c-4fe2-81bf-8dd49ac9b6b1.jpg');
INSERT INTO "sys_file_info" VALUES (25, '2019-05-05 15:36:54', 1, NULL, NULL, 'timg.jpg', '7fe918a2-c59a-4d17-ad77-f65dd4e163bf.jpg');


-- ----------------------------
-- Records of sys_login_log
-- ----------------------------
INSERT INTO "sys_login_log" VALUES (71, '2019-05-10 13:17:43', '127.0.0.1', '登录日志', NULL, '成功', 1);
INSERT INTO "sys_login_log" VALUES (72, '2019-05-12 13:36:56', '127.0.0.1', '登录日志', NULL, '成功', 1);


-- ----------------------------
-- Records of sys_menu
-- ----------------------------
INSERT INTO "sys_menu" VALUES (1, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'system', 'layout', 0, 'system', 1, 1, 1, '系统管理', 1, 0, '[0],', 1, NULL, '/system');
INSERT INTO "sys_menu" VALUES (2, '2019-07-31 22:04:30', 1, '2019-03-11 22:25:38', 1, 'cms', 'layout', 0, 'documentation', 1, NULL, 1, 'CMS管理', 3, 0, '[0],', 1, NULL, '/cms');
INSERT INTO "sys_menu" VALUES (3, '2019-07-31 22:04:30', 1, '2019-06-02 10:09:09', 1, 'operationMgr', 'layout', 0, 'operation', 1, NULL, 1, '运维管理', 2, 0, '[0],', 1, NULL, '/optionMgr');
INSERT INTO "sys_menu" VALUES (4, '2019-07-31 22:04:30', 1, '2019-04-16 18:59:15', 1, 'mgr', 'views/system/user/index', 0, 'user', 1, NULL, 2, '用户管理', 1, 'system', '[0],[system],', 1, NULL, '/mgr');
INSERT INTO "sys_menu" VALUES (5, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'mgrAdd', NULL, 0, NULL, 0, NULL, 3, '添加用户', 1, 'mgr', '[0],[system],[mgr],', 1, NULL, '/mgr/add');
INSERT INTO "sys_menu" VALUES (6, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'mgrEdit', NULL, 0, NULL, 0, NULL, 3, '修改用户', 2, 'mgr', '[0],[system],[mgr],', 1, NULL, '/mgr/edit');
INSERT INTO "sys_menu" VALUES (7, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'mgrDelete', NULL, 0, NULL, 0, 0, 3, '删除用户', 3, 'mgr', '[0],[system],[mgr],', 1, NULL, '/mgr/delete');
INSERT INTO "sys_menu" VALUES (8, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'mgrReset', NULL, 0, NULL, 0, 0, 3, '重置密码', 4, 'mgr', '[0],[system],[mgr],', 1, NULL, '/mgr/reset');
INSERT INTO "sys_menu" VALUES (9, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'mgrFreeze', NULL, 0, NULL, 0, 0, 3, '冻结用户', 5, 'mgr', '[0],[system],[mgr],', 1, NULL, '/mgr/freeze');
INSERT INTO "sys_menu" VALUES (10, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'mgrUnfreeze', NULL, 0, NULL, 0, 0, 3, '解除冻结用户', 6, 'mgr', '[0],[system],[mgr],', 1, NULL, '/mgr/unfreeze');
INSERT INTO "sys_menu" VALUES (11, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'mgrSetRole', NULL, 0, NULL, 0, 0, 3, '分配角色', 7, 'mgr', '[0],[system],[mgr],', 1, NULL, '/mgr/setRole');
INSERT INTO "sys_menu" VALUES (12, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'role', 'views/system/role/index', 0, 'peoples', 1, 0, 2, '角色管理', 2, 'system', '[0],[system],', 1, NULL, '/role');
INSERT INTO "sys_menu" VALUES (13, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'roleAdd', NULL, 0, NULL, 0, 0, 3, '添加角色', 1, 'role', '[0],[system],[role],', 1, NULL, '/role/add');
INSERT INTO "sys_menu" VALUES (14, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'roleEdit', NULL, 0, NULL, 0, 0, 3, '修改角色', 2, 'role', '[0],[system],[role],', 1, NULL, '/role/edit');
INSERT INTO "sys_menu" VALUES (15, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'roleDelete', NULL, 0, NULL, 0, 0, 3, '删除角色', 3, 'role', '[0],[system],[role],', 1, NULL, '/role/remove');
INSERT INTO "sys_menu" VALUES (16, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'roleSetAuthority', NULL, 0, NULL, 0, 0, 3, '配置权限', 4, 'role', '[0],[system],[role],', 1, NULL, '/role/setAuthority');
INSERT INTO "sys_menu" VALUES (17, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'menu', 'views/system/menu/index', 0, 'menu', 1, 0, 2, '菜单管理', 4, 'system', '[0],[system],', 1, NULL, '/menu');
INSERT INTO "sys_menu" VALUES (18, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'menuAdd', NULL, 0, NULL, 0, 0, 3, '添加菜单', 1, 'menu', '[0],[system],[menu],', 1, NULL, '/menu/add');
INSERT INTO "sys_menu" VALUES (19, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'menuEdit', NULL, 0, NULL, 0, 0, 3, '修改菜单', 2, 'menu', '[0],[system],[menu],', 1, NULL, '/menu/edit');
INSERT INTO "sys_menu" VALUES (20, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'menuDelete', NULL, 0, NULL, 0, 0, 3, '删除菜单', 3, 'menu', '[0],[system],[menu],', 1, NULL, '/menu/remove');
INSERT INTO "sys_menu" VALUES (21, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'dept', 'views/system/dept/index', 0, 'dept', 1, NULL, 2, '部门管理', 3, 'system', '[0],[system],', 1, NULL, '/dept');
INSERT INTO "sys_menu" VALUES (22, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'dict', 'views/system/dict/index', 0, 'dict', 1, NULL, 2, '字典管理', 4, 'system', '[0],[system],', 1, NULL, '/dict');
INSERT INTO "sys_menu" VALUES (23, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'deptEdit', NULL, 0, NULL, 0, NULL, 3, '修改部门', 1, 'dept', '[0],[system],[dept],', 1, NULL, '/dept/update');
INSERT INTO "sys_menu" VALUES (24, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'deptDelete', NULL, 0, NULL, 0, NULL, 3, '删除部门', 1, 'dept', '[0],[system],[dept],', 1, NULL, '/dept/delete');
INSERT INTO "sys_menu" VALUES (25, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'dictAdd', NULL, 0, NULL, 0, NULL, 3, '添加字典', 1, 'dict', '[0],[system],[dict],', 1, NULL, '/dict/add');
INSERT INTO "sys_menu" VALUES (26, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'dictEdit', NULL, 0, NULL, 0, NULL, 3, '修改字典', 1, 'dict', '[0],[system],[dict],', 1, NULL, '/dict/update');
INSERT INTO "sys_menu" VALUES (27, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'dictDelete', NULL, 0, NULL, 0, NULL, 3, '删除字典', 1, 'dict', '[0],[system],[dict],', 1, NULL, '/dict/delete');
INSERT INTO "sys_menu" VALUES (28, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'deptList', NULL, 0, NULL, 0, NULL, 3, '部门列表', 5, 'dept', '[0],[system],[dept],', 1, NULL, '/dept/list');
INSERT INTO "sys_menu" VALUES (29, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'deptDetail', NULL, 0, NULL, 0, NULL, 3, '部门详情', 6, 'dept', '[0],[system],[dept],', 1, NULL, '/dept/detail');
INSERT INTO "sys_menu" VALUES (30, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'dictList', NULL, 0, NULL, 0, NULL, 3, '字典列表', 5, 'dict', '[0],[system],[dict],', 1, NULL, '/dict/list');
INSERT INTO "sys_menu" VALUES (31, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'dictDetail', NULL, 0, NULL, 0, NULL, 3, '字典详情', 6, 'dict', '[0],[system],[dict],', 1, NULL, '/dict/detail');
INSERT INTO "sys_menu" VALUES (32, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'deptAdd', NULL, 0, NULL, 0, NULL, 3, '添加部门', 1, 'dept', '[0],[system],[dept],', 1, NULL, '/dept/add');
INSERT INTO "sys_menu" VALUES (33, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'cfg', 'views/system/cfg/index', 0, 'cfg', 1, NULL, 2, '参数管理', 10, 'system', '[0],[system],', 1, NULL, '/cfg');
INSERT INTO "sys_menu" VALUES (34, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'cfgAdd', NULL, 0, NULL, 0, NULL, 3, '添加系统参数', 1, 'cfg', '[0],[system],[cfg],', 1, NULL, '/cfg/add');
INSERT INTO "sys_menu" VALUES (35, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'cfgEdit', NULL, 0, NULL, 0, NULL, 3, '修改系统参数', 2, 'cfg', '[0],[system],[cfg],', 1, NULL, '/cfg/update');
INSERT INTO "sys_menu" VALUES (36, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'cfgDelete', NULL, 0, NULL, 0, NULL, 3, '删除系统参数', 3, 'cfg', '[0],[system],[cfg],', 1, NULL, '/cfg/delete');
INSERT INTO "sys_menu" VALUES (37, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'task', 'views/system/task/index', 0, 'task', 1, NULL, 2, '任务管理', 11, 'system', '[0],[system],', 1, NULL, '/task');
INSERT INTO "sys_menu" VALUES (38, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'taskAdd', NULL, 0, NULL, 0, NULL, 3, '添加任务', 1, 'task', '[0],[system],[task],', 1, NULL, '/task/add');
INSERT INTO "sys_menu" VALUES (39, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'taskEdit', NULL, 0, NULL, 0, NULL, 3, '修改任务', 2, 'task', '[0],[system],[task],', 1, NULL, '/task/update');
INSERT INTO "sys_menu" VALUES (40, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'taskDelete', NULL, 0, NULL, 0, NULL, 3, '删除任务', 3, 'task', '[0],[system],[task],', 1, NULL, '/task/delete');
INSERT INTO "sys_menu" VALUES (41, '2019-03-11 22:29:54', 1, '2019-03-11 22:29:54', 1, 'channel', 'views/cms/channel/index', 0, 'channel', 1, NULL, 2, '栏目管理', 1, 'cms', '[0],[cms],', 1, NULL, '/channel');
INSERT INTO "sys_menu" VALUES (42, '2019-03-11 22:30:17', 1, '2019-03-11 22:30:17', 1, 'article', 'views/cms/article/index', 0, 'documentation', 1, NULL, 2, '文章管理', 2, 'cms', '[0],[cms],', 1, NULL, '/article');
INSERT INTO "sys_menu" VALUES (43, '2019-03-11 22:30:52', 1, '2019-03-11 22:30:52', 1, 'banner', 'views/cms/banner/index', 0, 'banner', 1, NULL, 2, 'banner管理', 3, 'cms', '[0],[cms],', 1, NULL, '/banner');
INSERT INTO "sys_menu" VALUES (44, '2019-03-18 19:45:37', 1, '2019-03-18 19:45:37', 1, 'contacts', 'views/cms/contacts/index', 0, 'contacts', 1, NULL, 2, '邀约管理', 4, 'cms', '[0],[cms],', 1, NULL, '/contacts');
INSERT INTO "sys_menu" VALUES (45, '2019-03-19 10:25:05', 1, '2019-03-19 10:25:05', 1, 'file', 'views/cms/file/index', 0, 'file', 1, NULL, 2, '文件管理', 5, 'cms', '[0],[cms],', 1, NULL, '/fileMgr');
INSERT INTO "sys_menu" VALUES (46, '2019-03-11 22:30:17', 1, '2019-03-11 22:30:17', 1, 'editArticle', 'views/cms/article/edit.vue', 0, 'articleEdit', 1, NULL, 2, '新建文章', 1, 'cms', '[0],[cms],', 1, NULL, '/cms/articleEdit');
INSERT INTO "sys_menu" VALUES (47, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'taskLog', 'views/system/taskLog/index', 1, 'task', 1, NULL, 2, '任务日志', 4, 'system', '[0],[system],', 1, NULL, '/taskLog');
INSERT INTO "sys_menu" VALUES (48, '2019-07-31 22:04:30', 1, '2019-06-02 10:25:31', 1, 'log', 'views/operation/log/index', 0, 'log', 1, NULL, 2, '业务日志', 6, 'operationMgr', '[0],[operationMgr],', 1, NULL, '/log');
INSERT INTO "sys_menu" VALUES (49, '2019-07-31 22:04:30', 1, '2019-06-02 10:25:36', 1, 'loginLog', 'views/operation/loginLog/index', 0, 'logininfor', 1, NULL, 2, '登录日志', 6, 'operationMgr', '[0],[operationMgr],', 1, NULL, '/loginLog');
INSERT INTO "sys_menu" VALUES (50, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'logClear', NULL, 0, NULL, 0, NULL, 3, '清空日志', 3, 'log', '[0],[system],[log],', 1, NULL, '/log/delLog');
INSERT INTO "sys_menu" VALUES (51, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'logDetail', NULL, 0, NULL, 0, NULL, 3, '日志详情', 3, 'log', '[0],[system],[log],', 1, NULL, '/log/detail');
INSERT INTO "sys_menu" VALUES (52, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'loginLogClear', NULL, 0, NULL, 0, NULL, 3, '清空登录日志', 1, 'loginLog', '[0],[system],[loginLog],', 1, NULL, '/loginLog/delLoginLog');
INSERT INTO "sys_menu" VALUES (53, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'loginLogList', NULL, 0, NULL, 0, NULL, 3, '登录日志列表', 2, 'loginLog', '[0],[system],[loginLog],', 1, NULL, '/loginLog/list');
INSERT INTO "sys_menu" VALUES (54, '2019-06-02 10:10:20', 1, '2019-06-02 10:10:20', 1, 'druid', 'views/operation/druid/index', 0, 'monitor', 1, NULL, 2, '数据库管理', 1, 'operationMgr', '[0],[operationMgr],', 1, NULL, '/druid');
INSERT INTO "sys_menu" VALUES (55, '2019-06-02 10:10:20', 1, '2019-06-02 10:10:20', 1, 'swagger', 'views/operation/api/index', 0, 'swagger', 1, NULL, 2, '接口文档', 2, 'operationMgr', '[0],[operationMgr],', 1, NULL, '/swagger');
INSERT INTO "sys_menu" VALUES (56, '2019-06-10 21:26:52', 1, '2019-06-10 21:26:52', 1, 'messageMgr', 'layout', 0, 'message', 1, NULL, 1, '消息管理', 4, 0, '[0],', 1, NULL, '/message');
INSERT INTO "sys_menu" VALUES (57, '2019-06-10 21:27:34', 1, '2019-06-10 21:27:34', 1, 'msg', 'views/message/message/index', 0, 'message', 1, NULL, 2, '历史消息', 1, 'messageMgr', '[0],[messageMgr],', 1, NULL, '/history');
INSERT INTO "sys_menu" VALUES (58, '2019-06-10 21:27:56', 1, '2019-06-10 21:27:56', 1, 'msgTpl', 'views/message/template/index', 0, 'template', 1, NULL, 2, '消息模板', 2, 'messageMgr', '[0],[messageMgr],', 1, NULL, '/template');
INSERT INTO "sys_menu" VALUES (59, '2019-06-10 21:28:21', 1, '2019-06-10 21:28:21', 1, 'msgSender', 'views/message/sender/index', 0, 'sender', 1, NULL, 2, '消息发送者', 3, 'messageMgr', '[0],[messageMgr],', 1, NULL, '/sender');
INSERT INTO "sys_menu" VALUES (60, '2019-06-10 21:28:21', 1, '2019-06-10 21:28:21', 1, 'msgClear', NULL, 0, NULL, 1, NULL, 2, '清空历史消息', 3, 'messageMgr', '[0],[messageMgr],', 0, NULL, NULL);
INSERT INTO "sys_menu" VALUES (61, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'msgTplEdit', NULL, 0, NULL, 0, NULL, 3, '编辑消息模板', 1, 'msgTpl', '[0],[messageMgr],[msgTpl]', 1, NULL, NULL);
INSERT INTO "sys_menu" VALUES (62, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'msgTplDelete', NULL, 0, NULL, 0, NULL, 3, '删除消息模板', 2, 'msgTpl', '[0],[messageMgr],[msgTpl]', 1, NULL, NULL);
INSERT INTO "sys_menu" VALUES (63, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'msgSenderEdit', NULL, 0, NULL, 0, NULL, 3, '编辑消息发送器', 1, 'msgSender', '[0],[messageMgr],[msgSender]', 1, NULL, NULL);
INSERT INTO "sys_menu" VALUES (64, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'msgSenderDelete', NULL, 0, NULL, 0, NULL, 3, '删除消息发送器', 2, 'msgSender', '[0],[messageMgr],[msgSender]', 1, NULL, NULL);
INSERT INTO "sys_menu" VALUES (65, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'fileUpload', NULL, 0, NULL, 0, NULL, 3, '上传文件', 1, 'file', '[0],[cms],[file],', 1, NULL, NULL);
INSERT INTO "sys_menu" VALUES (66, '2019-07-31 21:51:33', 1, '2019-07-31 21:51:33', 1, 'bannerEdit', NULL, 0, NULL, 0, NULL, 3, '编辑banner', 1, 'banner', '[0],[cms],[banner],', 1, NULL, NULL);
INSERT INTO "sys_menu" VALUES (67, '2019-07-31 21:51:33', 1, '2019-07-31 21:51:33', 1, 'bannerDelete', NULL, 0, NULL, 0, NULL, 3, '删除banner', 2, 'banner', '[0],[cms],[banner],', 1, NULL, NULL);
INSERT INTO "sys_menu" VALUES (68, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'channelEdit', NULL, 0, NULL, 0, NULL, 3, '编辑栏目', 1, 'channel', '[0],[cms],[channel],', 1, NULL, NULL);
INSERT INTO "sys_menu" VALUES (69, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'channelDelete', NULL, 0, NULL, 0, NULL, 3, '删除栏目', 2, 'channel', '[0],[cms],[channel],', 1, NULL, NULL);
INSERT INTO "sys_menu" VALUES (70, '2019-07-31 22:04:30', 1, '2019-07-31 22:04:30', 1, 'deleteArticle', NULL, 0, NULL, 0, NULL, 3, '删除文章', 2, 'article', '[0],[cms],[article]', 1, NULL, NULL);


-- ----------------------------
-- Records of sys_notice
-- ----------------------------
INSERT INTO "sys_notice" VALUES (1, '2017-01-11 08:53:20', 1, '2019-01-08 23:30:58', 1, '欢迎使用web-flash后台管理系统', '欢迎光临', 10);


-- ----------------------------
-- Records of sys_operation_log
-- ----------------------------
INSERT INTO "sys_operation_log" VALUES (1, 'cn.enilu.flash.api.controller.cms.ArticleMgrController', '2019-05-10 13:22:49', '添加参数', '业务日志', '参数名称=system.app.name', 'upload', '成功', 1);
INSERT INTO "sys_operation_log" VALUES (2, 'cn.enilu.flash.api.controller.cms.ArticleMgrController', '2019-06-10 13:31:09', '修改参数', '业务日志', '参数名称=system.app.name', 'upload', '成功', 1);
INSERT INTO "sys_operation_log" VALUES (3, 'cn.enilu.flash.api.controller.cms.ArticleMgrController', '2019-07-10 13:22:49', '编辑文章', '业务日志', '参数名称=system.app.name', 'upload', '成功', 1);
INSERT INTO "sys_operation_log" VALUES (4, 'cn.enilu.flash.api.controller.cms.ArticleMgrController', '2019-08-10 13:31:09', '编辑栏目', '业务日志', '参数名称=system.app.name', 'upload', '成功', 1);

-- ----------------------------
-- Records of sys_relation
-- ----------------------------
INSERT INTO "sys_relation" VALUES (1, 42, 1);
INSERT INTO "sys_relation" VALUES (2, 70, 1);
INSERT INTO "sys_relation" VALUES (3, 46, 1);
INSERT INTO "sys_relation" VALUES (4, 43, 1);
INSERT INTO "sys_relation" VALUES (5, 67, 1);
INSERT INTO "sys_relation" VALUES (6, 66, 1);
INSERT INTO "sys_relation" VALUES (7, 33, 1);
INSERT INTO "sys_relation" VALUES (8, 34, 1);
INSERT INTO "sys_relation" VALUES (9, 36, 1);
INSERT INTO "sys_relation" VALUES (10, 35, 1);
INSERT INTO "sys_relation" VALUES (11, 41, 1);
INSERT INTO "sys_relation" VALUES (12, 69, 1);
INSERT INTO "sys_relation" VALUES (13, 68, 1);
INSERT INTO "sys_relation" VALUES (14, 2, 1);
INSERT INTO "sys_relation" VALUES (15, 44, 1);
INSERT INTO "sys_relation" VALUES (16, 21, 1);
INSERT INTO "sys_relation" VALUES (17, 32, 1);
INSERT INTO "sys_relation" VALUES (18, 24, 1);
INSERT INTO "sys_relation" VALUES (19, 29, 1);
INSERT INTO "sys_relation" VALUES (20, 23, 1);
INSERT INTO "sys_relation" VALUES (21, 28, 1);
INSERT INTO "sys_relation" VALUES (22, 22, 1);
INSERT INTO "sys_relation" VALUES (23, 25, 1);
INSERT INTO "sys_relation" VALUES (24, 27, 1);
INSERT INTO "sys_relation" VALUES (25, 31, 1);
INSERT INTO "sys_relation" VALUES (26, 26, 1);
INSERT INTO "sys_relation" VALUES (27, 30, 1);
INSERT INTO "sys_relation" VALUES (28, 54, 1);
INSERT INTO "sys_relation" VALUES (29, 45, 1);
INSERT INTO "sys_relation" VALUES (30, 65, 1);
INSERT INTO "sys_relation" VALUES (31, 48, 1);
INSERT INTO "sys_relation" VALUES (32, 50, 1);
INSERT INTO "sys_relation" VALUES (33, 51, 1);
INSERT INTO "sys_relation" VALUES (34, 49, 1);
INSERT INTO "sys_relation" VALUES (35, 52, 1);
INSERT INTO "sys_relation" VALUES (36, 53, 1);
INSERT INTO "sys_relation" VALUES (37, 17, 1);
INSERT INTO "sys_relation" VALUES (38, 18, 1);
INSERT INTO "sys_relation" VALUES (39, 20, 1);
INSERT INTO "sys_relation" VALUES (40, 19, 1);
INSERT INTO "sys_relation" VALUES (41, 56, 1);
INSERT INTO "sys_relation" VALUES (42, 4, 1);
INSERT INTO "sys_relation" VALUES (43, 5, 1);
INSERT INTO "sys_relation" VALUES (44, 7, 1);
INSERT INTO "sys_relation" VALUES (45, 6, 1);
INSERT INTO "sys_relation" VALUES (46, 9, 1);
INSERT INTO "sys_relation" VALUES (47, 8, 1);
INSERT INTO "sys_relation" VALUES (48, 11, 1);
INSERT INTO "sys_relation" VALUES (49, 10, 1);
INSERT INTO "sys_relation" VALUES (50, 57, 1);
INSERT INTO "sys_relation" VALUES (51, 60, 1);
INSERT INTO "sys_relation" VALUES (52, 59, 1);
INSERT INTO "sys_relation" VALUES (53, 64, 1);
INSERT INTO "sys_relation" VALUES (54, 63, 1);
INSERT INTO "sys_relation" VALUES (55, 58, 1);
INSERT INTO "sys_relation" VALUES (56, 62, 1);
INSERT INTO "sys_relation" VALUES (57, 61, 1);
INSERT INTO "sys_relation" VALUES (58, 3, 1);
INSERT INTO "sys_relation" VALUES (59, 12, 1);
INSERT INTO "sys_relation" VALUES (60, 13, 1);
INSERT INTO "sys_relation" VALUES (61, 15, 1);
INSERT INTO "sys_relation" VALUES (62, 14, 1);
INSERT INTO "sys_relation" VALUES (63, 16, 1);
INSERT INTO "sys_relation" VALUES (64, 55, 1);
INSERT INTO "sys_relation" VALUES (65, 1, 1);
INSERT INTO "sys_relation" VALUES (66, 37, 1);
INSERT INTO "sys_relation" VALUES (67, 38, 1);
INSERT INTO "sys_relation" VALUES (68, 40, 1);
INSERT INTO "sys_relation" VALUES (69, 39, 1);
INSERT INTO "sys_relation" VALUES (70, 47, 1);
INSERT INTO "sys_relation" VALUES (128, 41, 2);
INSERT INTO "sys_relation" VALUES (129, 42, 2);
INSERT INTO "sys_relation" VALUES (130, 43, 2);
INSERT INTO "sys_relation" VALUES (131, 44, 2);
INSERT INTO "sys_relation" VALUES (132, 45, 2);
INSERT INTO "sys_relation" VALUES (133, 46, 2);
INSERT INTO "sys_relation" VALUES (134, 65, 2);
INSERT INTO "sys_relation" VALUES (135, 66, 2);
INSERT INTO "sys_relation" VALUES (136, 67, 2);
INSERT INTO "sys_relation" VALUES (137, 68, 2);
INSERT INTO "sys_relation" VALUES (138, 69, 2);
INSERT INTO "sys_relation" VALUES (139, 70, 2);
INSERT INTO "sys_relation" VALUES (143, 2, 2);

-- ----------------------------
-- Records of sys_role
-- ----------------------------
INSERT INTO "sys_role" VALUES (1, NULL, NULL, NULL, NULL, 24, '超级管理员', 1, 0, 'administrator', 1);
INSERT INTO "sys_role" VALUES (2, NULL, NULL, NULL, NULL, 25, '网站管理员', 1, 1, 'developer', NULL);


-- ----------------------------
-- Records of sys_task
-- ----------------------------
INSERT INTO "sys_task" VALUES (1, '2018-12-28 09:54:00', 1, '2019-03-27 11:47:11', -1, 0, '0 0/30 * * * ?', '{
"appname": "web-flash",
"version":1
}
            
            
            
            
            
            
            
            
            
            
            
            ', 0, '2019-03-27 11:47:00', '执行成功', 'cn.enilu.flash.service.task.job.HelloJob', 'default', '测试任务', '测试任务,每30分钟执行一次');


-- ----------------------------
-- Records of sys_user
-- ----------------------------
INSERT INTO "sys_user" VALUES (-1, '2016-01-29 08:49:53', NULL, '2019-03-20 23:45:24', 1, 'system', NULL, NULL, NULL, NULL, '应用系统', NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO "sys_user" VALUES (1, '2016-01-29 08:49:53', NULL, '2019-03-20 23:45:24', 1, 'admin', NULL, '2017-05-05 00:00:00', 27, 'eniluzt@qq.com', '管理员', 'b5a51391f271f062867e5984e2fcffee', 15021222222, 1, '8pgby', 2, 1, 25);
INSERT INTO "sys_user" VALUES (2, '2018-09-13 17:21:02', NULL, '2019-01-09 23:05:51', 1, 'developer', NULL, '2017-12-31 00:00:00', 25, 'eniluzt@qq.com', '网站管理员', 'fac36d5616fe9ebd460691264b28ee27', 15022222222, '2,', 'vscp9', 1, 1, NULL);
