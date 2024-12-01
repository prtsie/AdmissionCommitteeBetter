namespace AdmissionCommittee.DB
{
    public interface IDataStorage : IDisposable
    {
        List<T> GetList<T>() where T : class, IDatabaseEntity;

        void Add<T>(T entity) where T : class, IDatabaseEntity;

        void Update<T>(T entity) where T : class, IDatabaseEntity;

        void Remove<T>(T entity) where T : class, IDatabaseEntity;

        void Save();
    }
}
