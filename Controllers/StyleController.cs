using Microsoft.AspNetCore.Mvc;
using MusicShopWebAppMVC.Models;

namespace MusicShopWebAppMVC.Controllers;

public class StyleController : Controller
{
    // Вывод существующих записей
    public IActionResult ShowStyles()
    {
        using ContextDB db = new ContextDB();
        var stylesList = db.Style.ToList();

        return View(stylesList);
    }

    // Добавление новой записи
    [HttpPost]
    public IActionResult Adding(string newStyle)
    {
        var entity = new Style()
        {
            NameStyle = newStyle
        };

        using ContextDB db = new ContextDB();
        if (entity != null)
        {
            db.Add(entity);
            db.SaveChanges();
        }
        
        return RedirectToAction(nameof(ShowStyles));
    }


    [HttpPost]
    public IActionResult Delete(string deleteStyle)
    {
        using ContextDB db = new ContextDB();
        Style data = db.Style.Find(deleteStyle)!;

        if (data != null)
        {
            db.Style.Remove(data);
            db.SaveChanges();
        }
        
        return RedirectToAction(nameof(ShowStyles));
    }
    
    
    [HttpPost]
    public IActionResult Update(string? updatingStyle, string newStyle)
    {
        using ContextDB db = new ContextDB();
        Style data = db.Style.Find(updatingStyle)!;

        var entity = new Label()
        {
            NameLabel = newStyle
        };
        
        db.Style.Remove(data);
        db.Add(entity);
        db.SaveChanges();
        

        return RedirectToAction(nameof(ShowStyles));
    }
}