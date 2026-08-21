namespace WebApplication1.Models;

public static class SeedData
{
    private static readonly Phone[] DemoPhones =
    [
        new Phone
        {
            Name = "iPhone 15",
            Company = "Apple",
            Price = 799,
            Description = "Смартфон Apple с OLED-дисплеем, камерой 48 Мп, процессором A16 Bionic и поддержкой USB-C.",
            ImageUrl = "https://placehold.co/600x400?text=iPhone+15"
        },
        new Phone
        {
            Name = "Samsung Galaxy S24",
            Company = "Samsung",
            Price = 859,
            Description = "Флагманский смартфон Samsung с ярким AMOLED-дисплеем, мощным процессором и набором AI-функций.",
            ImageUrl = "https://placehold.co/600x400?text=Galaxy+S24"
        },
        new Phone
        {
            Name = "Xiaomi 14",
            Company = "Xiaomi",
            Price = 699,
            Description = "Компактный Android-смартфон с производительным чипом, быстрой зарядкой и камерой Leica.",
            ImageUrl = "https://placehold.co/600x400?text=Xiaomi+14"
        },
        new Phone
        {
            Name = "Google Pixel 8",
            Company = "Google",
            Price = 699,
            Description = "Смартфон Google с чистым Android, хорошей камерой и встроенными функциями обработки фото.",
            ImageUrl = "https://placehold.co/600x400?text=Pixel+8"
        },
        new Phone
        {
            Name = "OnePlus 12",
            Company = "OnePlus",
            Price = 799,
            Description = "Производительный смартфон с большим AMOLED-экраном, быстрой зарядкой и камерой Hasselblad.",
            ImageUrl = "https://placehold.co/600x400?text=OnePlus+12"
        }
    ];

    public static void Initialize(MobileContext context)
    {
        if (!context.Phones.Any())
        {
            context.Phones.AddRange(DemoPhones.Select(ClonePhone));
            context.SaveChanges();
            return;
        }

        List<Phone> incompletePhones = context.Phones
            .Where(phone => string.IsNullOrWhiteSpace(phone.Description) || string.IsNullOrWhiteSpace(phone.ImageUrl))
            .OrderBy(phone => phone.Id)
            .Take(DemoPhones.Length)
            .ToList();

        for (int i = 0; i < incompletePhones.Count; i++)
        {
            Phone source = DemoPhones[i];
            Phone target = incompletePhones[i];
            target.Name = source.Name;
            target.Company = source.Company;
            target.Price = source.Price;
            target.Description = source.Description;
            target.ImageUrl = source.ImageUrl;
        }

        if (incompletePhones.Count > 0)
        {
            context.SaveChanges();
        }
    }

    private static Phone ClonePhone(Phone phone)
    {
        return new Phone
        {
            Name = phone.Name,
            Company = phone.Company,
            Price = phone.Price,
            Description = phone.Description,
            ImageUrl = phone.ImageUrl
        };
    }
}
