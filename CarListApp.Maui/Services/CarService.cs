using System.Diagnostics;
using Bogus;
using CarListApp.Maui.Models;
using SQLite;

namespace CarListApp.Maui.Services;

public class CarService
{
    private SQLiteConnection _conn;
    private string _dbPath;
    public string StatusMessage { get; private set; }

    public CarService(string dbPath)
    {
        _dbPath = dbPath;
        StatusMessage = "";
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
            Debug.WriteLine(e.Message);
            StatusMessage = "Failed to retrieve data.";
        }

        return new List<Car>();
    }

    public void AddCar(Car car)
    {
        try
        {
            if (car == null)
            {
                throw new Exception("Invalid car record");
            }

            Init();

            var result = _conn.Insert(car);
            StatusMessage = result == 0 ? "Insert Failed" : "Insert Successful";
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            StatusMessage = "Failed to Insert data";
        }
    }

    public int DeleteCar(int id)
    {
        try
        {
            Init();
            return _conn.Table<Car>().Delete(q => q.Id.Equals(id));
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            StatusMessage = "Failed to Delete data";
        }

        return 0;
    }

    public Car GetCar(int id)
    {
        throw new NotImplementedException();
    }
}