using DataAccess.Entities;

namespace DataAccess.Interfaces
{
    public interface IDBReader
    {
        string ConnectionString { get;}

        bool CheckConnection();

        bool ReadAllData();

        List<DBTable> GetAllTables();
    }
}
