using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MusicShopWebAppMVC.Models;

namespace MusicShopWebAppMVC.Controllers;

public class ConditionController : Controller
{
    // Вывод существующих записей
    public IActionResult ShowConditions()
    {
        using ContextDB db = new ContextDB();
        var conditionList = db.Condition.ToList();
        
        return View(conditionList);
    }
    
    
    // Добавление новой записи
    [HttpPost]
    public IActionResult Adding(string newCondition)
    {
        var entity = new Condition()
        {
            Id = newCondition
        };

        using ContextDB db = new ContextDB();
        if (entity != null)
        {
            db.Add(entity);
            db.SaveChanges();
        }

        //перезагрузка страницы
        return RedirectToAction(nameof(ShowConditions));
    }

    // Удаление записи
    [HttpPost]
    public IActionResult Delete(string deleteCondition)
    {
        using ContextDB db = new ContextDB();
        Condition data = db.Condition.Find(deleteCondition)!;

        if (data != null)
        {
            db.Condition.Remove(data);
            db.SaveChanges();
        }
        
        //перезагрузка страницы
        return RedirectToAction(nameof(ShowConditions));
    }


    [HttpPost]
    public IActionResult Update(string? updatingCondition, string newCondition)
    {
        using ContextDB db = new ContextDB();
        Condition data = db.Condition.Find(updatingCondition)!;

        var entity = new Condition()
        {
            Id = newCondition
        };
        
        db.Condition.Remove(data);
        db.Add(entity);
        db.SaveChanges();
        

        return RedirectToAction(nameof(ShowConditions));
    }
}