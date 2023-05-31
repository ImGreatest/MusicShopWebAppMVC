using System.Diagnostics;
using MusicShopWebAppMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace MusicShopWebAppMVC.Controllers;

public class CountryController : Controller
{
    // Вывод существующих записей
    public IActionResult ShowCountries()
    {
        using ContextDB db = new ContextDB();
        var countryList = db.Country.ToList();
        
        return View(countryList);
    }
    
    // Добавление новой записи
    [HttpPost]
    public IActionResult Adding(string newCountry)
    {
        var entity = new Country()
        {
            NameCountry = newCountry
        };
        
        using ContextDB db = new ContextDB();
        if (entity != null)
        {
            db.Add(entity);
            db.SaveChanges();
        }
        
        return RedirectToAction(nameof(ShowCountries));
    }
    
    // Удаление записи
    [HttpPost]
    public IActionResult Delete(string deleteCountry)
    {
        using ContextDB db = new ContextDB();
        Country data = db.Country.Find(deleteCountry)!;

        if (data != null)
        {
            db.Country.Remove(data);
            db.SaveChanges();
        }
        
        return RedirectToAction(nameof(ShowCountries));
    }
    
    // Обновление данных
    [HttpPost]
    public IActionResult Update(string? updatingCountry, string newCountry)
    {
        using ContextDB db = new ContextDB();
        Country data = db.Country.Find(updatingCountry)!;

        var entity = new Country()
        {
            NameCountry = newCountry
        };
        
        db.Country.Remove(data);
        db.Add(entity);
        db.SaveChanges();
        

        return RedirectToAction(nameof(ShowCountries));
    }
}