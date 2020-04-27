namespace Doublelives.Service.Tasks
{
    public interface ITaskService
    {
        void WarmupDatabase();

        void ExportCurrentDbDataAsJsonFile();

        void ImportDataFromJsonFile();
    }
}
