// -----------------------------------------------------------------------
//  <copyright file="AbstractBuilder.cs" company="OSharp开源团队">
//      Copyright (c) 2014 OSharp. All rights reserved.
//  </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2014:07:08 13:09</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using HuangSharp.Helpers;

namespace HuangSharp.Extensions;

/// <summary>
///     枚举<see cref="Enum" />的扩展辅助操作方法
/// </summary>
public static class EnumExtensions
{
    #region 获取枚举的全部的名称、值等

    /// <summary>
    ///     获取枚举的全部的名称、值等
    /// </summary>
    /// <param name="enum"></param>
    /// <returns></returns>
    public static IEnumerable<(int Value, string Code, string Name)> GetEnumNames(this Enum @enum)
    {
        return EnumHelper.GetEnumNames(@enum.GetType());
    }

    #endregion

    #region 获取Falgs枚举包含的全部枚举

    /// <summary>
    ///     获取Falgs枚举包含的全部枚举
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static IEnumerable<TEnum> GetEnumFalgsItems<TEnum>(this TEnum obj) where TEnum : struct, Enum
    {
        return EnumHelper.GetEnumFalgsItems(obj);
    }

    #endregion

    #region 判断枚举是否包含多个值,Flags标识的枚举可能包含多个值

    /// <summary>
    ///     判断枚举是否包含多个值,Flags标识的枚举可能包含多个值
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static bool IsEnumSingleValue<TEnum>(this TEnum obj) where TEnum : struct, Enum
    {
        return obj.GetEnumFalgsItems().Count() == 1;
    }

    #endregion

    #region 获取枚举上的DisplayAttribute特性的Name属性

    /// <summary>
    ///     获取枚举上的DisplayAttribute特性的Name属性
    /// </summary>
    /// <param name="enum"></param>
    /// <param name="isCulture">是否使用资源文件</param>
    /// <param name="inherit">是否同时查找从父类继承的特性</param>
    /// <returns></returns>
    public static string GetDisplayName(this Enum @enum, bool isCulture = true, bool inherit = false)
    {
        return AttributeHelper.GetDisplayName(@enum, isCulture, inherit);
    }

    /// <summary>
    ///     获取Flags标识的枚举值所包含的全部枚举的DisplayAttribute特性的Name属性
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <param name="enum"></param>
    /// <param name="isCulture"></param>
    /// <param name="inherit"></param>
    /// <returns></returns>
    public static IEnumerable<string> GetDisplayNames<TEnum>(this TEnum @enum, bool isCulture = true,
        bool inherit = false) where TEnum : struct, Enum
    {
        return EnumHelper.GetEnumFalgsItems(@enum).Select(m => m.GetDisplayName(isCulture, inherit));
    }

    #endregion

    #region 获取枚举上的DisplayAttribute特性的ShortName属性

    /// <summary>
    ///     获取枚举的DisplayAttribute的ShortName
    /// </summary>
    /// <param name="enum"></param>
    /// <param name="isCulture">是否使用资源文件</param>
    /// <param name="inherit">是否同时查找从父类继承的特性</param>
    /// <returns></returns>
    public static string GetDisplayShortName(this Enum @enum, bool isCulture = true, bool inherit = false)
    {
        return AttributeHelper.GetDisplayShortName(@enum, isCulture, inherit);
    }

    /// <summary>
    ///     获取Flags标识的枚举值所包含的全部枚举的DisplayAttribute特性的ShortName属性
    /// </summary>
    /// <param name="enum"></param>
    /// <param name="isCulture"></param>
    /// <param name="inherit"></param>
    /// <returns></returns>
    public static IEnumerable<string> GetDisplayShortNames<TEnum>(this TEnum @enum, bool isCulture = true,
        bool inherit = false) where TEnum : struct, Enum
    {
        return EnumHelper.GetEnumFalgsItems(@enum).Select(m => m.GetDisplayShortName(isCulture, inherit));
    }

    #endregion

    #region 获取枚举上的DisplayAttribute特性的Description属性

    /// <summary>
    ///     获取枚举上的DisplayAttribute特性的Description属性
    /// </summary>
    /// <param name="enum"></param>
    /// <param name="isCulture"></param>
    /// <param name="inherit"></param>
    /// <returns></returns>
    public static string GetDisplayDescription(this Enum @enum, bool isCulture = true, bool inherit = false)
    {
        return AttributeHelper.GetDisplayDescription(@enum, isCulture, inherit);
    }

    /// <summary>
    ///     获取Flags标识的枚举值所包含的全部枚举的DisplayAttribute特性的Description属性
    /// </summary>
    /// <param name="enum"></param>
    /// <param name="isCulture"></param>
    /// <param name="inherit"></param>
    /// <returns></returns>
    public static IEnumerable<string> GetDisplayDescriptions<TEnum>(this TEnum @enum, bool isCulture = true,
        bool inherit = false) where TEnum : struct, Enum
    {
        return EnumHelper.GetEnumFalgsItems(@enum).Select(m => m.GetDisplayDescription(isCulture, inherit));
    }

    #endregion

    #region 获取枚举的值

    /// <summary>
    ///     获取枚举的值
    /// </summary>
    /// <param name="enum"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte ToByte(this Enum @enum)
    {
        return (byte)@enum.GetHashCode();
    }

    /// <summary>
    ///     获取枚举的值
    /// </summary>
    /// <param name="enum"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static short ToShort(this Enum @enum)
    {
        return (short)@enum.GetHashCode();
    }

    /// <summary>
    ///     获取枚举的值
    /// </summary>
    /// <param name="enum"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int ToInt32(this Enum @enum)
    {
        return @enum.GetHashCode();
    }

    /// <summary>
    ///     获取枚举的值
    /// </summary>
    /// <param name="enum"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long ToInt64(this Enum @enum)
    {
        return @enum.GetHashCode();
    }

    #endregion

    #region 获取枚举的全部项

    /// <summary>
    ///     获取枚举的全部项
    /// </summary>
    /// <param name="enum"></param>
    /// <returns></returns>
    public static IEnumerable<Enum> GetEnumItems(this Enum @enum)
    {
        return EnumHelper.GetEnumItems(@enum.GetType());
    }

    /// <summary>
    ///     获取枚举的全部项
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <param name="enum"></param>
    /// <returns></returns>
    public static IEnumerable<TEnum> GetEnumItems<TEnum>(this TEnum @enum) where TEnum : struct, Enum
    {
        return EnumHelper.GetEnumItems<TEnum>();
    }

    #endregion
}
