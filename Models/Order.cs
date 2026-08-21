using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Order
{
    public int Id { get; set; }

    [Display(Name = "Имя покупателя")]
    public string Name { get; set; } = "";

    [Display(Name = "Адрес доставки")]
    public string Address { get; set; } = "";

    [Display(Name = "Номер телефона")]
    public string ContactPhone { get; set; } = "";

    public int PhoneId { get; set; }

    [Display(Name = "Смартфон")]
    public Phone Phone { get; set; } = null!;
}
