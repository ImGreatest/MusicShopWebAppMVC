using Microsoft.AspNetCore.Mvc;
using MusicShopWebAppMVC.Models;

namespace MusicShopWebAppMVC.Controllers;

public class PerformerController : Controller
{
    // Вывод существующих записей
    public IActionResult ShowPerformers()
    {
        using ContextDB db = new ContextDB();
        var performerList = db.Performer.ToList();

        return View(performerList);
    }
    
        
    // Добавление новой записи
    [HttpPost]
    public IActionResult Adding(int newPerformerID, string newPerformer)
    {
        var entity = new Performer()
        {
            Id = newPerformerID,
            Name = newPerformer
        };

        using ContextDB db = new ContextDB();
        if (entity != null)
        {
            db.Add(entity);
            db.SaveChanges();
        }

        return RedirectToAction(nameof(ShowPerformers));
    }
    
    // Удаление записи
    [HttpPost]
    public IActionResult Delete(int deletePerformer)
    {
        using ContextDB db = new ContextDB();
        Performer data = db.Performer.Find(deletePerformer)!;

        if (data != null)
        {
            db.Performer.Remove(data);
            db.SaveChanges();
        }
        
        //перезагрузка страницы
        return RedirectToAction(nameof(ShowPerformers));
    }
    
    [HttpPost]
    public IActionResult Update(int? updatingPerformer, string newPerformer)
    {
        using ContextDB db = new ContextDB();
        Performer data = db.Performer.Find(updatingPerformer)!;

        data.Name = newPerformer;
        db.SaveChanges();

        return RedirectToAction(nameof(ShowPerformers));
    }
}