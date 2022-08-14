using Bogus;
using CarListApp.Maui.Models;
using SQLite;

namespace CarListApp.Maui.Services;

public class CarService
{
    private SQLiteConnection _conn;
    private string _dbPath;
    private string _statusMessage;

    public CarService(string dbPath)
    {
        _dbPath = dbPath;
        _statusMessage = "";
    }

    private void Init()
    {
        if (_conn != null)
        {
            return;
        }
        _conn = new SQLiteConnection(_dbPath);
        _conn.CreateTable<Car>();
    }

    public List<Car> GetCars()
    {
        
        try
        {
            Init();
            return _conn.Table<Car>().ToList();

        }
        catch (Exception e)
        {
            _statusMessage = "Failed to retrieve data.";
        }

        return new List<Car>();
    }
}