using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Phone
{
    public int Id { get; set; }

    [Display(Name = "Название")]
    public string Name { get; set; } = "";

    [Display(Name = "Производитель")]
    public string Company { get; set; } = "";

    [Display(Name = "Цена в долларах")]
    public int Price { get; set; }

    [Display(Name = "Описание")]
    public string Description { get; set; } = "";

    [Display(Name = "Ссылка на фото")]
    public string ImageUrl { get; set; } = "";
}
