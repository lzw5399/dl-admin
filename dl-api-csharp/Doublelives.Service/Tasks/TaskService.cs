using Doublelives.Domain.Cms;
using Doublelives.Domain.Infrastructure;
using Doublelives.Domain.Messages;
using Doublelives.Domain.Sys;
using Doublelives.Persistence;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Doublelives.Service.Tasks
{
    public class TaskService : ITaskService
    {
        private readonly DlAdminDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;
        private List<string> list;

        public TaskService(DlAdminDbContext dbContext, IUnitOfWork unitOfWork)
        {
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
        }

        public void WarmupDatabase()
        {
            var xx = _dbContext.Set<SysUser>().ToList();
            var sw = Stopwatch.StartNew();
            int count = 0;
            count += _dbContext.Set<CmsArticle>().ToList().Count();
            count += _dbContext.Set<CmsBanner>().ToList().Count();
            count += _dbContext.Set<CmsChannel>().ToList().Count();
            count += _dbContext.Set<CmsContacts>().ToList().Count();
            count += _dbContext.Set<Message>().ToList().Count();
            count += _dbContext.Set<MessageSender>().ToList().Count();
            count += _dbContext.Set<MessageTemplate>().ToList().Count();
            count += _dbContext.Set<SysCfg>().ToList().Count();
            count += _dbContext.Set<SysDept>().ToList().Count();
            count += _dbContext.Set<SysDict>().ToList().Count();
            count += _dbContext.Set<SysFileInfo>().ToList().Count();
            count += _dbContext.Set<SysLoginLog>().ToList().Count();
            count += _dbContext.Set<SysMenu>().ToList().Count();
            count += _dbContext.Set<SysNotice>().ToList().Count();
            count += _dbContext.Set<SysOperationLog>().ToList().Count();
            count += _dbContext.Set<SysRelation>().ToList().Count();
            count += _dbContext.Set<SysRole>().ToList().Count();
            count += _dbContext.Set<SysTask>().ToList().Count();
            count += _dbContext.Set<SysTaskLog>().ToList().Count();
            count += _dbContext.Set<SysUser>().ToList().Count();
            sw.Stop();
            _dbContext.Set<SysTaskLog>().Add(new SysTaskLog
            {
                ExecAt = DateTime.Now,
                ExecSuccess = true,
                Name = "刷新mysql",
                IdTask = 1,
                JobException = $"成功！执行时间:{sw.ElapsedMilliseconds}"
            });
        }

        /// <summary>
        /// 将当前数据导出成json文件，这样可以跨数据库导入导出数据
        /// </summary>
        public void ExportCurrentDbDataAsJsonFile()
        {
            var datas = new Dictionary<string, object>
            {
                { "CmsArticle", _dbContext.Set<CmsArticle>().ToList()} ,
                { "CmsBanner" ,_dbContext.Set<CmsBanner>().ToList()} ,
                { "CmsChannel" ,_dbContext.Set<CmsChannel>().ToList()} ,
                { "CmsContacts" ,_dbContext.Set<CmsContacts>().ToList()} ,
                { "Message" ,_dbContext.Set<Message>().ToList()} ,
                { "MessageSender" , _dbContext.Set<MessageSender>().ToList()} ,
                { "MessageTemplate" ,_dbContext.Set<MessageTemplate>().ToList()} ,
                { "SysCfg" ,_dbContext.Set<SysCfg>().ToList()} ,
                { "SysDept" ,_dbContext.Set<SysDept>().ToList()} ,
                { "SysDict" , _dbContext.Set<SysDict>().ToList()} ,
                { "SysFileInfo" ,_dbContext.Set<SysFileInfo>().ToList()} ,
                { "SysLoginLog" ,_dbContext.Set<SysLoginLog>().ToList()} ,
                { "SysMenu" ,_dbContext.Set<SysMenu>().ToList()} ,
                { "SysNotice" ,_dbContext.Set<SysNotice>().ToList()} ,
                { "SysOperationLog" ,_dbContext.Set<SysOperationLog>().ToList()} ,
                { "SysRelation" ,_dbContext.Set<SysRelation>().ToList()} ,
                { "SysRole" ,_dbContext.Set<SysRole>().ToList()} ,
                { "SysTask" ,_dbContext.Set<SysTask>().ToList()} ,
                { "SysTaskLog" , _dbContext.Set<SysTaskLog>().ToList()} ,
                { "SysUser" ,_dbContext.Set<SysUser>().ToList()}
            };
            foreach (var data in datas)
            {
                var json = JsonConvert.SerializeObject(data.Value, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                Write(data.Key, json);
            }
        }

        public void ImportDataFromJsonFile()
        {
            var arr = new string[]
            {
                "SysCfg",
                "SysDept",
                "SysDict",
                "SysFileInfo",
                "SysLoginLog",
                "SysMenu",
                "SysNotice",
                "SysOperationLog",
                "SysRelation",
                "SysRole",
                "SysTask",
                "SysTaskLog",
                "SysUser"
            };

            foreach (var item in arr)
            {
                var types = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(a => a.GetTypes().Where(t => (t != typeof(AuditableEntityBase) && typeof(AuditableEntityBase) == t.BaseType) || (t.BaseType == typeof(EntityBase) && t != typeof(AuditableEntityBase))))
                    .ToArray();

                var type = types.FirstOrDefault(it => it.Name == item);
                var mi = GetType().GetMethod("Read").MakeGenericMethod(type);
                mi.Invoke(this, new object[] { item });
            }
        }

        public void Read<T>(string fileName) where T: EntityBase
        {
            var jsonPath = new DirectoryInfo(@$"C:\Users\11301\Desktop\json\{fileName}.json").FullName;

            using (var sr = new StreamReader(jsonPath))
            {
                string json = sr.ReadToEnd();
                var range = JsonConvert.DeserializeObject<List<T>>(json);

                _dbContext.Set<T>().AddRange(range);
                _dbContext.SaveChanges();
            }
        }

        private void Write(string fileName, string json)
        {
            using (FileStream fs = new FileStream(@$"C:\Users\11301\Desktop\json\{fileName}.json", FileMode.Create))
            {
                //获得字节数组
                byte[] data = System.Text.Encoding.Default.GetBytes(json);
                //开始写入
                fs.Write(data, 0, data.Length);
                //清空缓冲区、关闭流
                fs.Flush();
                fs.Close();
            }
        }
    }
}
