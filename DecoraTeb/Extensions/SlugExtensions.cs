using System.Text;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
namespace DecoraTeb.Extensions;

public static class SlugExtensions
{
    public static string ToSlug(this string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return Guid.NewGuid().ToString("N");

        text = text.Trim().ToLowerInvariant();

        // فارسی و انگلیسی
        text = text.Replace("ي", "ی")
                   .Replace("ك", "ک");

        // حذف کاراکترهای نامعتبر
        text = Regex.Replace(text, @"[^\u0600-\u06FFa-z0-9\s-]", "");

        // فاصله -> -
        text = Regex.Replace(text, @"\s+", "-");

        // چند خط فاصله
        text = Regex.Replace(text, @"-+", "-");

        return text.Trim('-');
    }

    public static async Task<string> ToUniqueSlug<TEntity>(
        this string title,
        DbSet<TEntity> table,
        Func<TEntity, string> selector)
        where TEntity : class
    {
        var slug = title.ToSlug();

        var exists =  table
            .AsNoTracking()
            .Select(selector)
            .ToList();

        if (!exists.Contains(slug))
            return slug;

        int i = 2;

        while (exists.Contains($"{slug}-{i}"))
            i++;

        return $"{slug}-{i}";
    }
}
