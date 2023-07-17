using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace HuangSharp.GuardClauses;

/// <summary>
/// 守卫 outofRange 扩展
/// </summary>
public static partial class GuardClauseExtensions
{
    /// <summary>
    /// 如果输入参数 <paramref name="input"/> 不是有效的枚举值，则抛出异常 <see cref="InvalidEnumArgumentException" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="guardClause"></param>
    /// <param name="input"></param>
    /// <param name="parameterName"></param>
    /// <param name="message">可选，自定义异常消息</param>
    /// <returns><paramref name="input" /> 如果值没有超出范围.</returns>
    /// <exception cref="InvalidEnumArgumentException"></exception>
    public static int EnumOutOfRange<T>(this IGuardClause guardClause,
        int input,
        [CallerArgumentExpression("input")] string? parameterName = null,
        string? message = null) where T : struct, Enum
    {
        if (!Enum.IsDefined(typeof(T), input))
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new InvalidEnumArgumentException(parameterName, input, typeof(T));
            }
            throw new InvalidEnumArgumentException(message);
        }

        return input;
    }

    /// <summary>
    /// 如果输入参数 <paramref name="input"/> 不是有效的枚举值，则抛出异常 <see cref="InvalidEnumArgumentException" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="guardClause"></param>
    /// <param name="input"></param>
    /// <param name="parameterName"></param>
    /// /// <param name="message">可选，自定义异常消息</param>
    /// <returns><paramref name="input" /> 如果值没有超出范围.</returns>
    /// <exception cref="InvalidEnumArgumentException"></exception>
    public static T EnumOutOfRange<T>(this IGuardClause guardClause,
        T input,
        [CallerArgumentExpression("input")] string? parameterName = null,
        string? message = null) where T : struct, Enum
    {
        if (!Enum.IsDefined(typeof(T), input))
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new InvalidEnumArgumentException(parameterName, Convert.ToInt32(input), typeof(T));
            }
            throw new InvalidEnumArgumentException(message);
        }

        return input;
    }

    /// <summary>
    /// 如果任何输入参数 <paramref name="input"/>的 item 小于 <paramref name="rangeFrom"/> 或 大于<paramref name="rangeTo"/>，则抛出<see cref="ArgumentOutOfRangeException" />。
    /// </summary>
    /// <param name="guardClause"></param>
    /// <param name="input"></param>
    /// <param name="parameterName"></param>
    /// <param name="rangeFrom"></param>
    /// <param name="rangeTo"></param>
    /// <param name="message">可选，自定义异常消息</param>
    /// <returns><paramref name="input" /> 任意一项都不能超出范围.</returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static IEnumerable<T> OutOfRange<T>(this IGuardClause guardClause, IEnumerable<T> input, string parameterName, T rangeFrom, T rangeTo, string? message = null) where T : IComparable, IComparable<T>
    {
        if (rangeFrom.CompareTo(rangeTo) > 0)
        {
            throw new ArgumentException(message ?? $"{nameof(rangeFrom)}应小于或等于{nameof(rangeTo)}。", parameterName);
        }

        if (input.Any(x => x.CompareTo(rangeFrom) < 0 || x.CompareTo(rangeTo) > 0))
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentOutOfRangeException(parameterName, message ?? $"输入参数{parameterName}有超出范围的项");
            }
            throw new ArgumentOutOfRangeException(parameterName, message);
        }

        return input;
    }
    
    /// <summary>
    /// 如果输入参数 <paramref name="input" /> 不是一个友好且有效的时间范围内的值，则抛出异常  <see cref="ArgumentOutOfRangeException" />
    /// </summary>
    /// <param name="guardClause"></param>
    /// <param name="input"></param>
    /// <param name="parameterName"></param>
    /// <param name="message">可选，自定义异常消息。</param>
    /// <returns> <paramref name="input" /> 如果值是一个有好的且有效的时间范围内的值。</returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static DateTime OutOfDateRange(this IGuardClause guardClause,
        DateTime input,
        [CallerArgumentExpression("input")] string? parameterName = null,
        string? message = null)
    {
        const long minDateTicks = 552877920000000000;
        const long maxDateTicks = 3155378975999970000;

        return OutOfRange<DateTime>(guardClause, input, parameterName!, new DateTime(minDateTicks), new DateTime(maxDateTicks), message);
    }
   

    /// <summary>
    /// 如果输入参数 <paramref name="input"/> 小于 <paramref name="rangeFrom"/> 或 大于 <paramref name="rangeTo"/>，则抛出<see cref="ArgumentOutOfRangeException" />异常。
    /// </summary>
    /// <param name="guardClause"></param>
    /// <param name="input"></param>
    /// <param name="parameterName"></param>
    /// <param name="rangeFrom"></param>
    /// <param name="rangeTo"></param>
    /// <param name="message">可选，自定义异常消息</param>
    /// <returns><paramref name="input" /> 如果值没有超出范围.</returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static T OutOfRange<T>(this IGuardClause guardClause, T input,
        string parameterName,
        T rangeFrom,
        T rangeTo,
        string? message = null) where T : IComparable, IComparable<T>
    {
        if (rangeFrom.CompareTo(rangeTo) > 0)
        {
            throw new ArgumentException(message ?? $"{nameof(rangeFrom)}应小于或等于{nameof(rangeTo)}。", parameterName);
        }

        if (input.CompareTo(rangeFrom) < 0 || input.CompareTo(rangeTo) > 0)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentOutOfRangeException(parameterName, $"输入{parameterName}超出范围");
            }
            throw new ArgumentOutOfRangeException(parameterName, message);
        }

        return input;
    }

}
