namespace AutoApplication.DataLibrary.DataAccess
{
    public interface ISqlServerDataModification
    {
        int SaveData<T>(string sql, T data);
        int UpdateData<T>(string sql, T data);
    }
}