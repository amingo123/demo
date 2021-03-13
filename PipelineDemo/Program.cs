using System;
using System.Threading.Tasks;

namespace PipelineDemo
{
    public delegate Task RequestDelegate(HttpContext context);
    public class HttpContext { }

    class Program
    {
        static void Main(string[] args)
        {
            var app = new ApplicationBuilder();

            app.Use(async (context, next) =>
            {
                Console.WriteLine("中间件1号 Begin");
                await next();
                Console.WriteLine("中间件1号 End");
            });

            app.Use(async (context, next) =>
            {
                Console.WriteLine("中间件2号 Begin");
                await next();
                Console.WriteLine("中间件2号 End");
            });

            var firstMiddleware = app.Build();

            // 主机就拿到管道的第一个中间件
            // 请求进来的时候，
            firstMiddleware(new HttpContext());
        }
    }
}
