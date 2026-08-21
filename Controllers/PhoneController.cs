using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class PhoneController : Controller
{
    private readonly MobileContext _context;
    private readonly IWebHostEnvironment _environment;

    public PhoneController(MobileContext context, IWebHostEnvironment environment)
    {
        _context = context;
        _environment = environment;
    }

    public IActionResult Index()
    {
        List<Phone> phones = _context.Phones.ToList();
        return View(phones);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Phone? phone)
    {
        if (phone != null)
        {
            _context.Phones.Add(phone);
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }

    public IActionResult Edit(int? id)
    {
        if (id.HasValue)
        {
            Phone? phone = _context.Phones.FirstOrDefault(p => p.Id == id);
            if (phone != null)
            {
                return View(phone);
            }
        }

        return NotFound();
    }

    [HttpPost]
    public IActionResult Edit(Phone? phone)
    {
        if (phone != null)
        {
            _context.Phones.Update(phone);
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }

    public IActionResult Delete(int? id)
    {
        if (id.HasValue)
        {
            Phone? phone = _context.Phones.FirstOrDefault(p => p.Id == id);
            if (phone != null)
            {
                return View(phone);
            }
        }

        return NotFound();
    }

    public IActionResult ConfirmDelete(int? id)
    {
        if (id.HasValue)
        {
            Phone? phone = _context.Phones.FirstOrDefault(p => p.Id == id);
            if (phone != null)
            {
                _context.Remove(phone);
                _context.SaveChanges();
            }
        }

        return RedirectToAction("Index");
    }

    public IActionResult Details(int? id)
    {
        if (id.HasValue)
        {
            Phone? phone = _context.Phones.FirstOrDefault(p => p.Id == id);
            if (phone != null)
            {
                ViewBag.Currencies = ReadCurrencies();
                return View(phone);
            }
        }

        return NotFound();
    }

    private List<Currency> ReadCurrencies()
    {
        string filePath = Path.Combine(_environment.WebRootPath, "currencies.json");

        if (!System.IO.File.Exists(filePath))
        {
            return [];
        }

        string json = System.IO.File.ReadAllText(filePath);

        return JsonSerializer.Deserialize<List<Currency>>(
            json,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? [];
    }
}
