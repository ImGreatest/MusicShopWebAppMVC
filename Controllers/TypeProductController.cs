using Microsoft.AspNetCore.Mvc;
using MusicShopWebAppMVC.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MusicShopWebAppMVC.Controllers;

public class TypeProductController : Controller
{
    public IActionResult ShowTypes()
    {
        using ContextDB db = new ContextDB();
        var typeList = db.TypeProduct.ToList();

        return View(typeList);
    }

    [HttpPost]
    public IActionResult Adding(string newType)
    {
        var entity = new TypeProduct()
        {
            TypeName = newType
        };

        using ContextDB db = new ContextDB();
        if (entity != null)
        {
            db.Add(entity);
            db.SaveChanges();
        }

        return RedirectToAction(nameof(ShowTypes));
    }

    [HttpPost]
    public IActionResult Delete(string deleteType)
    {
        using ContextDB db = new ContextDB();
        TypeProduct data = db.TypeProduct.Find(deleteType);

        if (data != null)
        {
            db.TypeProduct.Remove(data);
            db.SaveChanges();
        }

        return RedirectToAction(nameof(ShowTypes));
    }


    [HttpPost]
    public IActionResult Update(string? updatingType, string newType)
    {
        using ContextDB db = new ContextDB();
        TypeProduct data = db.TypeProduct.Find(updatingType);

        var entity = new TypeProduct()
        {
            TypeName = newType
        };

        db.TypeProduct.Remove(data);
        db.Add(entity);
        db.SaveChanges();

        return RedirectToAction(nameof(ShowTypes));
    }
}