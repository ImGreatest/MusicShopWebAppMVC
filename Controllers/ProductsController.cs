using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics.Internal;
using MusicShopWebAppMVC.Models;

namespace MusicShopWebAppMVC.Controllers;

public class ProductsController : Controller
{
    // Вывод записей
    public IActionResult ShowProducts()
    {
        using ContextDB db = new ContextDB();
        var productsList = db.Product.ToList();

        return View(productsList);
    }
    
    // Добавление записи
    [HttpGet]
    public IActionResult Adding(int newProductID, string newProduct, string newLabel, string newStyles, int newAlbum, int newPerformer, string newCondition, int newCost)
    {
        var entity = new Product()
        {
            Id = newProductID,
            TypeProduct = newProduct,
            Label = newLabel,
            Style = newStyles,
            Album = newAlbum,
            Performer = newPerformer,
            Condition = newCondition,
            Cost = newCost,
        };

        using ContextDB db = new ContextDB();
        if (entity != null)
        {
            db.Add(entity);
            db.SaveChanges();
        }

        return RedirectToAction(nameof(ShowProducts));
    }

    // Удаление записи
    [HttpPost]
    public IActionResult Delete(string deleteProduct)
    {
        using ContextDB db = new ContextDB();
        Product data = db.Product.Find(deleteProduct);

        if (data != null)
        {
            db.Product.Remove(data);
            db.SaveChanges();
        }

        return RedirectToAction(nameof(ShowProducts));
    }

    // Обновление записи
    [HttpPost]
    public IActionResult Update(int? updatingProduct, int newCostCount)
    {
        using ContextDB db = new ContextDB();
        Product data = db.Product.Find(updatingProduct);

        data.Cost = newCostCount;
        db.SaveChanges();

        return RedirectToAction(nameof(ShowProducts));
    }
}