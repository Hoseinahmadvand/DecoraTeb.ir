using DecoraTeb.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DecoraTeb.Data.Seed;

public class WebPageSeeder : IEntityTypeConfiguration<WebPage>
{
    public void Configure(EntityTypeBuilder<WebPage> builder)
    {
        builder.HasData(

            new WebPage
            {
                Id = 1,

                Title = "درباره ما",
                ShortDescription = "آشنایی با مجموعه دکوراطب",
                Content = "<p>محتوای صفحه درباره ما...</p>",

                Type = WebPageType.AboutUs,

                BannerImage = "",
               

                SortOrder = 1,
                IsActive = true,

                Slug = "about",
                SeoTitle = "درباره دکوراطب",
                SeoDescription = "آشنایی با مجموعه دکوراطب",
                SeoKeywords = "دکوراطب, طراحی داخلی مطب",
                CanonicalUrl = "/aboutus",
                Robots = "aboutus",
                CreateAt = new DateTime(2026, 1, 1)
            },

            new WebPage
            {
                Id = 2,

                Title = "تماس با ما",
                ShortDescription = "راه های ارتباط با دکوراطب",
                Content = "<p>محتوای صفحه تماس با ما...</p>",

                Type = WebPageType.Contact,

                BannerImage = "",
                //Icon = "fa fa-phone",

                SortOrder = 2,
                IsActive = true,

                Slug = "contact",
                SeoTitle = "تماس با دکوراطب",
                SeoDescription = "راه های ارتباط با دکوراطب",
                SeoKeywords = "تماس, دکوراطب",
                CanonicalUrl = "/contact",
                Robots = "contact",
                CreateAt = new DateTime(2026, 1, 1)
            },

            //new WebPage
            //{
            //    Id = 3,

            //    Title = "قوانین و مقررات",
            //    ShortShortDescription = "شرایط استفاده از سایت",
            //    Content = "<p>قوانین و مقررات سایت...</p>",

            //    Type = WebPageType.ru,

            //    BannerImage = "",
               

            //    SortOrder = 3,
            //    IsActive = true,

            //    Slug = "rules",
            //    SeoTitle = "قوانین و مقررات",
            //    SeoShortDescription = "قوانین استفاده از سایت",
            //    SeoKeywords = "قوانین سایت",
            //    CanonicalUrl = "/rules",

            //    CreateAt = new DateTime(2026, 1, 1)
            //},

            new WebPage
            {
                Id = 3,

                Title = "حریم خصوصی",
                ShortDescription = "حفظ اطلاعات کاربران",
                Content = "<p>متن حریم خصوصی...</p>",

                Type = WebPageType.Privacy,

                BannerImage = "",
                //Icon = "fa fa-shield",

                SortOrder = 4,
                IsActive = true,

                Slug = "privacy",
                SeoTitle = "حریم خصوصی",
                SeoDescription = "حریم خصوصی کاربران",
                SeoKeywords = "حریم خصوصی",
                CanonicalUrl = "/privacy",
                Robots= "privacy",
                CreateAt = new DateTime(2026, 1, 1)
            }

            //new WebPage
            //{
            //    Id = 5,

            //    Title = "همکاری با ما",
            //    ShortDescription = "فرصت های همکاری",
            //    Content = "<p>همکاری با دکوراطب...</p>",

            //    Type = WebPageType.Cooperation,

            //    BannerImage = "",
            //    //Icon = "fa fa-handshake-o",

            //    SortOrder = 5,
            //    IsActive = true,

            //    Slug = "cooperation",
            //    SeoTitle = "همکاری با دکوراطب",
            //    SeoDescription = "فرصت های همکاری",
            //    SeoKeywords = "همکاری, استخدام",
            //    CanonicalUrl = "/cooperation",

            //    CreateAt = new DateTime(2026, 1, 1)
            //}

        );
    }
}