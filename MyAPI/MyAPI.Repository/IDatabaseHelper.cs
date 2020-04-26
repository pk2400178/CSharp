using System.Data;

namespace MyAPI.Repository
{
    public interface IDatabaseHelper
    {
        IDbConnection GetConnection();
    }
}