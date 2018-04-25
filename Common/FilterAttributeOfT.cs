using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace Filter.Common
{
    //通用特性过滤器
    public class FilterAttribute : Attribute, IFilterFactory
    {
        private readonly Type type;
        public FilterAttribute(Type T)
        {
            //父类.IsAssignableFrom(子类) true
            //From 从。
            if (!typeof(IFilterMetadata).IsAssignableFrom(T))
            {
                throw new InvalidOperationException("T must inherit from IFilterMetadata");
            }
            type = T;
        }
        public bool IsReusable => true;

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetService(type) as IFilterMetadata;
        }
    }
}
