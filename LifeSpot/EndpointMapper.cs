using System;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LifeSpot
{
    public static class EndpointMapper
    {
        /// <summary>
        ///  Маппинг CSS
        /// </summary>
        public static void MapCss(this IEndpointRouteBuilder builder)
        {
            var cssFiles = new[] { "index.css" };

            foreach(var fileName in cssFiles)
            {
                builder.MapGet($"/Static/CSS/{fileName}", async context => 
                {
                    var cssPath = Path.Combine(Directory.GetCurrentDirectory(), "Static", "CSS", fileName);
                    var css = await File.ReadAllTextAsync(cssPath);
                    await context.Response.WriteAsync(css);
                });
            }
        }

        /// <summary>
        ///  Маппинг JS
        /// </summary>
        public static void MapJs(this IEndpointRouteBuilder builder)
        {
            var jsFiles = new[] { "index.js", "about.js", "testing.js", "slider.js" };

            foreach(var fileName in jsFiles)
            {
                builder.MapGet($"/Static/JS/{fileName}", async context =>
                {
                    var jsPath = Path.Combine(Directory.GetCurrentDirectory(), "Static", "JS", fileName);
                    var js = await File.ReadAllTextAsync(jsPath);
                    await context.Response.WriteAsync(js);
                });
            }
        }

        /// <summary>
        ///  Маппинг картинок
        /// </summary>
        public static void MapImg(this IEndpointRouteBuilder builder)
        {
            var imgFiles = new[] { "london.jpg", "ny.jpg", "spb.jpg", "la.jpg", "shanghai.jpg" };

            foreach (var fileName in imgFiles)
            {
                builder.MapGet($"/Static/Images/{fileName}", async context =>
                {
                    var imgPath = Path.Combine(Directory.GetCurrentDirectory(), "Static", "Images", fileName);
                    context.Response.ContentType = "image/jpg";  // устанавливаем заголовок Content-Type
                    var img = File.ReadAllBytes(imgPath);
                    await context.Response.Body.WriteAsync(img);
                });
            }
        }

        /// <summary>
        ///  Маппинг HTML
        /// </summary>
        public static void MapHtml(this IEndpointRouteBuilder builder)
        {
            string footerHtml = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Views", "Shared", "footer.html"));
            string sideBarHtml = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Views", "Shared", "sidebar.html"));
            string sliderHtml = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Views", "Shared", "slider.html"));

            builder.MapGet("/", async context =>
            {
                var viewPath = Path.Combine(Directory.GetCurrentDirectory(), "Views", "index.html");
                
                // Загружаем шаблон страницы, вставляя в него элементы
                var html =  new StringBuilder(await File.ReadAllTextAsync(viewPath))
                    .Replace("<!--SIDEBAR-->", sideBarHtml)
                    .Replace("<!--FOOTER-->", footerHtml);
                
                await context.Response.WriteAsync(html.ToString());
            });
              
            builder.MapGet("/testing", async context =>
            {
                var viewPath = Path.Combine(Directory.GetCurrentDirectory(), "Views", "testing.html");
                
                // Загружаем шаблон страницы, вставляя в него элементы
                var html =  new StringBuilder(await File.ReadAllTextAsync(viewPath))
                    .Replace("<!--SIDEBAR-->", sideBarHtml)
                    .Replace("<!--FOOTER-->", footerHtml);
                
                await context.Response.WriteAsync(html.ToString());
            });

            builder.MapGet("/about", async context =>
            {
                var viewPath = Path.Combine(Directory.GetCurrentDirectory(), "Views", "about.html");
                
                var html = new StringBuilder(await File.ReadAllTextAsync(viewPath))
                    .Replace("<!--SIDEBAR-->", sideBarHtml)
                    .Replace("<!--SLIDER-->", sliderHtml)
                    .Replace("<!--FOOTER-->", footerHtml);
                
                await context.Response.WriteAsync(html.ToString());
            });
        }
    }
}