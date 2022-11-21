namespace RDS_Commerce.ApplicationServices.AutoMapperSettings;
public static class AutoMapperExtension
{
    public static TDestiantion MapTo<TSource, TDestiantion>(this TSource source) =>
        AutoMapperFactoryConfigurations.Mapper.Map<TSource, TDestiantion>(source);

    public static TDestiantion MapTo<TSource, TDestiantion>(this TSource source, TDestiantion destiantion) => 
        AutoMapperFactoryConfigurations.Mapper.Map(source, destiantion);
}
