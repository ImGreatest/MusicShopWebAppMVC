using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MusicShopWebAppMVC.Models;

namespace MusicShopWebAppMVC.Controllers;

public class AlbumsController : Controller
{
    public IActionResult ShowAlbums()
    {
        using ContextDB db = new ContextDB();
        var albumsList = db.Album.ToList();

        return View(albumsList);
    }

    // Добавление новой записи
    public IActionResult Adding(int newAlbumID, string newNameAlbum, string newCountryIssue, int newCountSongs,
        DateTime newIssue)
    {
        var entity = new Album()
        {
            Id = newAlbumID,
            NameAlbum = newNameAlbum,
            CountryIssue = newCountryIssue,
            CountSongs = newCountSongs,
            Issue = newIssue.ToUniversalTime()
        };
        
        using ContextDB db = new ContextDB();
        if (entity != null)
        {
            db.Add(entity);
            db.SaveChanges();
        }
        
        return RedirectToAction(nameof(ShowAlbums));
    }
    
    // Удаление записи
    [HttpPost]
    public IActionResult Delete(int deleteAlbumID)
    {
        using ContextDB db = new ContextDB();
        Album data = db.Album.Find(deleteAlbumID)!;
        
        
        if (data != null)
        {
            db.Album.Remove(data);
            db.SaveChanges();
        }
        
        //перезагрузка страницы
        return RedirectToAction(nameof(ShowAlbums));
    }

    [HttpPost]
    public IActionResult Update(int? updatingAlbum, string newAlbumName)
    {
        using ContextDB db = new ContextDB();
        Album data = db.Album.Find(updatingAlbum)!;

        data.NameAlbum = newAlbumName;
        db.SaveChanges();

        return RedirectToAction(nameof(ShowAlbums));
    }
}