using Microsoft.AspNetCore.Mvc;
using MusicShopWebAppMVC.Models;

namespace MusicShopWebAppMVC.Controllers;

public class LabelController : Controller
{
    // Вывод существующих записей
    public IActionResult ShowLabels()
    {
        using ContextDB db = new ContextDB();
        var labelsList = db.Label.ToList();
        
        return View(labelsList);
    }
    
    // Добавление новой записи
    [HttpPost]
    public IActionResult Adding(string newLabel)
    {
        var entity = new Label()
        {
            NameLabel = newLabel
        };

        using ContextDB db = new ContextDB();
        if (entity != null)
        {
            db.Add(entity);
            db.SaveChanges();
        }

        //перезагрузка страницы
        return RedirectToAction(nameof(ShowLabels));
    }

    // Удаление записи
    [HttpPost]
    public IActionResult Delete(string deleteLabel)
    {
        using ContextDB db = new ContextDB();
        Label data = db.Label.Find(deleteLabel)!;

        if (data != null)
        {
            db.Label.Remove(data);
            db.SaveChanges();
        }
        
        //перезагрузка страницы
        return RedirectToAction(nameof(ShowLabels));
    }

    [HttpPost]
    public IActionResult Update(string? updatingLabel, string newLabel)
    {
        using ContextDB db = new ContextDB();
        Label data = db.Label.Find(updatingLabel)!;

        var entity = new Label()
        {
            NameLabel = newLabel
        };
        
        db.Label.Remove(data);
        db.Add(entity);
        db.SaveChanges();
        

        return RedirectToAction(nameof(ShowLabels));
    }
}