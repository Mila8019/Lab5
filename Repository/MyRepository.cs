using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Lab5.Database;
using Lab5.Models;

namespace Lab5.Repository;

public class MyRepository:IMyRepository
{
    private readonly MyContext _context;
    
    public MyRepository(MyContext context)
    {
        _context = context;
        _context.Database.EnsureCreated();
    }
    public void SaveToDb(ObservableCollection<WordModel> contacts)
    {
        _context.WordModels?.RemoveRange(_context.WordModels);
        _context.SaveChanges();

        // Добавление новых задач и сохранение изменений
        _context.WordModels?.AddRange(contacts);
        _context.SaveChanges();
    }

    public List<WordModel> LoadFromDb()
    {
        return _context.WordModels!.ToList();
    }
}