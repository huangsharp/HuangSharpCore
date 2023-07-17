using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace HuangSharp.GuardClauses;

/// <summary>
///     守卫 NotFound 扩展
/// </summary>
public static partial class GuardClauseExtensions
{
    /// <summary>
    /// 如果输入 <paramref name="input" /> 中的 <paramref name="key" /> 不存在，则抛出异常 <see cref="NotFoundException" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="guardClause"></param>
    /// <param name="key"></param>
    /// <param name="input"></param>
    /// <param name="parameterName"></param>
    /// <returns><paramref name="input" /> if the value is not null.</returns>
    /// <exception cref="NotFoundException"></exception>
   
    public static T NotFound<T>(this IGuardClause guardClause,
        [NotNull][ValidatedNotNull] string key,
        [NotNull][ValidatedNotNull] T input,
        [CallerArgumentExpression("input")] string? parameterName = null)
    {
        guardClause.NullOrEmpty(key, nameof(key));

        if (input is null)
        {
            throw new NotFoundException(key, parameterName!);
        }

        return input;
    }

    /// <summary>
    /// 如果输入 <paramref name="input" /> 中的 <paramref name="key" /> 不存在，则抛出异常 <see cref="NotFoundException" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <param name="guardClause"></param>
    /// <param name="key"></param>
    /// <param name="input"></param>
    /// <param name="parameterName"></param>
    /// <returns><paramref name="input" /> if the value is not null.</returns>
    /// <exception cref="NotFoundException"></exception>
    public static T NotFound<TKey, T>(this IGuardClause guardClause,
        [NotNull][ValidatedNotNull] TKey key,
        [NotNull][ValidatedNotNull]T input,
        [CallerArgumentExpression("input")] string? parameterName = null) where TKey : struct
    {
        guardClause.Null(key, nameof(key));

        if (input is null)
        {
            throw new NotFoundException(key.ToString()!, parameterName!);
        }

        return input;
    }
}


/// <summary>
/// 如果按特定键查询的对象为空（未找到）时发生的错误
/// </summary>
public class NotFoundException : Exception
{
    /// <summary>
    /// 实例化一个新的 <see cref="NotFoundException"/> 对象的新实例
    /// </summary>
    /// <param name="objectName">查询对象名称</param>
    /// <param name="key">查询对象的值</param>
    public NotFoundException(string key, string objectName)
        : base($"查询对象 {objectName} 未找到, 关键字：{key}")
    {
    }

    /// <summary>
    /// 实例化一个新的 <see cref="NotFoundException"/> 对象的新实例
    /// </summary>
    /// <param name="objectName">查询对象名称.</param>
    /// <param name="key">查询对象的值</param>
    /// <param name="innerException">当前异常的起因</param>
    public NotFoundException(string key, string objectName, Exception innerException)
        : base($"查询对象 {objectName} 未找到, 关键字：{key}", innerException)
    {
    }
}
