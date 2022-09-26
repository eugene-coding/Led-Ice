using LedIce.Data.Models;

using Microsoft.EntityFrameworkCore;

namespace LedIce.Data;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new Context(serviceProvider.GetRequiredService<DbContextOptions<Context>>());

        if (!context.Slides.Any())
        {
            context.Slides.AddRange(
                new Slide
                {
                    Title = "Снежинки",
                    Description = "<p>Снежинки из ударопрочного полимера двух размеров: 1000х1000 мм и 600х600 мм.</p><p>Снежинки могут работают как в монохромном цветовом режиме, так и использовать возможности RGB. Теперь каждую зиму они будут притягивать взгляды прохожих и дарить новогоднее настроение.</p>",
                    BackgroundImage = new Uri("images/5.webp", UriKind.Relative),
                    OverlayColor = "linear-gradient(90deg, rgb(47 43 108 / 78%) 0%, rgb(64 48 124 / 67%) 60%, rgb(82 82 82 / 0%) 100%);",
                    Enabled = true,
                    SortOrder = 1
                },
                new Slide
                {
                    Title = "Вазоны",
                    Description = "<p>Светодиодный вазон состоит из термостойкого и ударостойкого полимера, который выглядит красиво как в светящемся виде в ночное время, так и при выключенном состоянии днём.</p>",
                    BackgroundImage = new Uri("images/7.webp", UriKind.Relative),
                    OverlayColor = "linear-gradient(90deg, rgb(43 90 108 / 78%) 0%, rgb(48 85 124 / 67%) 60%, rgb(82 82 82 / 0%) 100%);",
                    Enabled = true,
                    SortOrder = 2
                },
                new Slide
                {
                    Title = "Колба для кальяна",
                    Description = "<p>Колба для кальяна, которая увеличит ваши продажи.</p><p>Тяга кальяна включает подстветку колбы, которая подталкивает клиентов делаеть ещё больше тяг и, тем самым, заказывать больше кальянов</p>",
                    BackgroundImage = new Uri("images/3.webp", UriKind.Relative),
                    OverlayColor = "linear-gradient(90deg, rgb(80 33 33 / 78%) 0%, rgb(90 35 35 / 67%) 60%, rgb(0 0 0 / 0%) 100%);",
                    Enabled = true,
                    SortOrder = 3
                },
                new Slide
                {
                    Title = "Светодиодные камыши",
                    Description = "<p>Светодиодные камыши создают оригинальную подсветку ландшафта.</p><p>Материал, из которого изготовлены камыши — это ударопрочный и термостойкий полимер, которой прослужит долгие годы, а также за счёт встроенных светодиодов будет экономично потреблять энергию.</p>",
                    BackgroundImage = new Uri("images/1.webp", UriKind.Relative),
                    OverlayColor = "linear-gradient(90deg, rgb(42 80 33 / 78%) 0%, rgb(35 90 44 / 67%) 60%, rgb(0 0 0 / 0%) 100%);",
                    Enabled = true,
                    SortOrder = 4
                }
                );
        }

        if (!context.PageMetas.Any())
        {
            context.PageMetas.AddRange(
                new PageMeta
                {
                    Seo = string.Empty,
                    Title = "Производство светодиодных акриловых фигур",
                    Description = "Единственная компания с собственным производством по изготовлению световых фигур из высокопрочного и термостойкого полимера. Изготавливаем фигуры как из каталога, так и под заказ на основе макетов или пожеланий клиента.",
                    Keyword = "Световые фигуры, светодиодные фигуры, производство в России, акриловые фигуры, уличные световые фигуры, световые фигуры в помещение, купить световые фигуры"
                },
                new PageMeta
                {
                    Seo = "contacts",
                    Title = "Контакты производства светодиодных акриловых фигур",
                    Description = " Как связаться и добраться до нас - контакты компании Led Ice с собственным производством по изготовлению световых фигур из высокопрочного и термостойкого полимера.",
                    Keyword = "Контакты производства, производство в Волгограде, световые фигуры, светодиодные фигуры, производство в России, акриловые фигуры, уличные световые фигуры, световые фигуры в помещение, купить световые фигуры"
                });
        }

        if (!context.Managers.Any())
        {
            context.Managers.AddRange(
                new Manager
                {
                    City = "Волгоград",
                    Name = "Михаил",
                    Phone = "+7 (903) 655-61-31",
                    Email = "mihail@led-ice.ru",
                    SortOrder = 0,
                    Enabled = false
                },
                new Manager
                {
                    City = "Волгоград",
                    Name = "Владислав",
                    Phone = "+7 (905) 333-22-32",
                    Email = "vlad@tdkatod.ru",
                    SortOrder = 1,
                    Enabled = true
                },
                new Manager
                {
                    City = "Краснодар",
                    Name = "Алексей",
                    Phone = "+7 (938) 545-77-75",
                    Email = "alex@tdkatod.ru",
                    SortOrder = 2,
                    Enabled = true
                });
        }

        if (!context.Locations.Any())
        {
            context.Locations.Add(
                new Location
                {
                    City = "Волгоград",
                    Street = "Милиционера Буханцева, 36",
                    Description = "Вход со стороны трамвайных путей.",
                    Phone = "+7 (903) 655-61-31",
                    Email = "info@led-ice.ru",
                    Map = "<script async src=\"https://api-maps.yandex.ru/services/constructor/1.0/js/?um=constructor%3Ab3d5dd9eed62d25c625724c51f7c943981b1e3465560759cbb7aaa1fe7aabf93&amp;width=100%25&amp;height=400&amp;lang=ru_RU&amp;scroll=true\"></script>",
                    WorkingHours = "Пн-Пт: 09:00-18:00",
                    WorkingHoursForSchema = "Mo-Fr 09:00-18:00"
                });
        }

        if (!context.Socials.Any())
        {
            context.Socials.AddRange(
            new Social
            {
                Link = new Uri("https://vk.com"),
                Icon = "vk",
                SortOrder = 1,
                Enabled = true
            },
            new Social
            {
                Link = new Uri("https://instagram.com"),
                Icon = "instagram",
                SortOrder = 3,
                Enabled = true
            },
            new Social
            {
                Link = new Uri("https://youtube.com"),
                Icon = "youtube",
                SortOrder = 2,
                Enabled = true
            });
        }

        context.SaveChanges();
    }
}
