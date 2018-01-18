using System;

namespace OnionPattern.Mapping
{
    public abstract class BaseTypeConverter<TSource, TDestination> where TDestination : class, new()
    {
        protected void Guard(TSource source, ref TDestination destination)
        {
            if(source == null) {  throw new ArgumentNullException(nameof(source)); }
            if(destination == null) {  destination = new TDestination(); }
        } 
    }
}
