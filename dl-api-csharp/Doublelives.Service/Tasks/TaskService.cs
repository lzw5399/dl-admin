using Doublelives.Domain.Cms;
using Doublelives.Domain.Messages;
using Doublelives.Domain.Sys;
using Doublelives.Persistence;
using System;
using System.Diagnostics;
using System.Linq;

namespace Doublelives.Service.Tasks
{
    public class TaskService : ITaskService
    {
        private readonly DlAdminDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;

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
    }
}
