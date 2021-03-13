using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineDemo
{
    public class ApplicationBuilder
    {
        // 里面放的不是真正的中间件，中间件的委托
        private static readonly IList<Func<RequestDelegate, RequestDelegate>> _components = 
            new List<Func<RequestDelegate, RequestDelegate>>();

        // 扩展Use
        public ApplicationBuilder Use(Func<HttpContext, Func<Task>, Task> middleware)
        {
            return Use(next =>
            {
                return context =>
                {
                    Task SimpleNext() => next(context);
                    return middleware(context, SimpleNext );
                };
            });
        }

        // 原始Use
        public ApplicationBuilder Use(Func<RequestDelegate, RequestDelegate> middleware)
        {
            // 添加中间件
            _components.Add(middleware);
            return this;
        }
	
        public RequestDelegate Build()
        {
            RequestDelegate app = context =>
            {
                Console.WriteLine("默认中间件");
                return Task.CompletedTask;
            };

            foreach (var component in _components.Reverse())
            {
                app = component(app);
            }

            return app;
        }
    }
}
