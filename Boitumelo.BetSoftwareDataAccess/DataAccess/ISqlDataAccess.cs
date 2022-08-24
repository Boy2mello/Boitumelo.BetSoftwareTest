namespace Boitumelo.BetSoftwareDataAccess.DataAccess;

public interface ISqlDataAccess
{
    Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionNameOrId = "Default");
    Task SaveData<T>(string storedProcedure, T parameters, string connectionNameOrId = "Default");
    Task<int> ExecuteCommand<T>(string commandStatement, string connectionId = "Default");
}