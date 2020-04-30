namespace Doublelives.Service.Tasks
{
    public interface ITaskService
    {
        void WarmupDatabase();

        void ExportCurrentDbDataAsJsonFile();

        void ImportDataFromJsonFile();

        void FlushallCache();

        /// <summary>
        /// 填充缓存数据
        /// </summary>
        void FillCache();
    }
}
