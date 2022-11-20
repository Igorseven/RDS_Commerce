﻿using System.ComponentModel;
using System.Reflection;

namespace RDS_Commerce.Business.Extensions;
public static class MessageExtension
{
    public static string GetDescription<T>(this T message)
    {
        var type = message.GetType();
        var memberInfo =  type.GetMember(message.ToString());
        var attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

        return ((DescriptionAttribute)attributes[0]).Description;
    }

    public static T GetEnum<T>(this string description) where T : Enum
    {
        var type = typeof(T);
        if (!type.GetTypeInfo().IsEnum)
            throw new ArgumentException();

        var field = type.GetFields().SelectMany(f => f
                    .GetCustomAttributes(typeof(DescriptionAttribute), false), (f, a) => new { Field = f, Att = a })
                    .Where(a => ((DescriptionAttribute)a.Att).Description == description)
                    .SingleOrDefault();

        return field == null ? default(T) : (T)field.Field.GetRawConstantValue();
    }
}
