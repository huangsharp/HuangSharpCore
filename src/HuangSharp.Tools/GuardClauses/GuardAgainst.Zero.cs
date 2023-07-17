using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace HuangSharp.GuardClauses;

/// <summary>
///     守卫 Zero 扩展
/// </summary>
public static partial class GuardClauseExtensions
{
    /// <summary>
    ///     如果输入参数 <paramref name="input" /> 为 0，则抛出异常<see cref="ArgumentException" />
    /// </summary>
    /// <param name="guardClause"></param>
    /// <param name="input"></param>
    /// <param name="parameterName"></param>
    /// <param name="message">可选，自定义异常消息</param>
    /// <returns><paramref name="input" /> 如果值不是0.</returns>
    /// <exception cref="ArgumentException"></exception>
    public static int Zero(this IGuardClause guardClause,
        int input,
        [CallerArgumentExpression("input")] string? parameterName = null,
        string? message = null)
    {
        return Zero<int>(guardClause, input, parameterName!, message);
    }

    /// <summary>
    ///     如果输入参数 <paramref name="input" /> 为 0，则抛出异常<see cref="ArgumentException" />
    /// </summary>
    /// <param name="guardClause"></param>
    /// <param name="input"></param>
    /// <param name="parameterName"></param>
    /// <param name="message">可选，自定义异常消息</param>
    /// <returns><paramref name="input" /> 如果值不是0.</returns>
    /// <exception cref="ArgumentException"></exception>
    public static long Zero(this IGuardClause guardClause,
        long input,
        [CallerArgumentExpression("input")] string? parameterName = null,
        string? message = null)
    {
        return Zero<long>(guardClause, input, parameterName!, message);
    }

    /// <summary>
    ///     如果输入参数 <paramref name="input" /> 为 0，则抛出异常<see cref="ArgumentException" />
    /// </summary>
    /// <param name="guardClause"></param>
    /// <param name="input"></param>
    /// <param name="parameterName"></param>
    /// <param name="message">可选，自定义异常消息</param>
    /// <returns><paramref name="input" /> 如果值不是0.</returns>
    /// <exception cref="ArgumentException"></exception>
    public static decimal Zero(this IGuardClause guardClause,
        decimal input,
        [CallerArgumentExpression("input")] string? parameterName = null,
        string? message = null)
    {
        return Zero<decimal>(guardClause, input, parameterName!, message);
    }

    /// <summary>
    ///     如果输入参数 <paramref name="input" /> 为 0，则抛出异常<see cref="ArgumentException" />
    /// </summary>
    /// <param name="guardClause"></param>
    /// <param name="input"></param>
    /// <param name="parameterName"></param>
    /// <param name="message">可选，自定义异常消息</param>
    /// <returns><paramref name="input" /> 如果值不是0.</returns>
    /// <exception cref="ArgumentException"></exception>
    public static float Zero(this IGuardClause guardClause,
        float input,
        [CallerArgumentExpression("input")] string? parameterName = null,
        string? message = null)
    {
        return Zero<float>(guardClause, input, parameterName!, message);
    }

    /// <summary>
    ///     如果输入参数 <paramref name="input" /> 为 0，则抛出异常<see cref="ArgumentException" />
    /// </summary>
    /// <param name="guardClause"></param>
    /// <param name="input"></param>
    /// <param name="parameterName"></param>
    /// <param name="message">可选，自定义异常消息</param>
    /// <returns><paramref name="input" /> 如果值不是0.</returns>
    /// <exception cref="ArgumentException"></exception>
    public static double Zero(this IGuardClause guardClause,
        double input,
        [CallerArgumentExpression("input")] string? parameterName = null,
        string? message = null)
    {
        return Zero<double>(guardClause, input, parameterName!, message);
    }

    /// <summary>
    ///     如果输入参数 <paramref name="input" /> 为 0，则抛出异常<see cref="ArgumentException" />
    /// </summary>
    /// <param name="guardClause"></param>
    /// <param name="input"></param>
    /// <param name="parameterName"></param>
    /// <returns><paramref name="input" /> 如果值不是0.</returns>
    /// <exception cref="ArgumentException"></exception>
    public static TimeSpan Zero(this IGuardClause guardClause,
        TimeSpan input,
        [CallerArgumentExpression("input")] string? parameterName = null)
    {
        return Zero<TimeSpan>(guardClause, input, parameterName!);
    }

    /// <summary>
    ///     如果输入参数 <paramref name="input" /> 为 0，则抛出异常<see cref="ArgumentException" />
    /// </summary>
    /// <param name="guardClause"></param>
    /// <param name="input"></param>
    /// <param name="parameterName"></param>
    /// <param name="message">可选，自定义异常消息</param>
    /// <returns><paramref name="input" /> 如果值不是0.</returns>
    /// <exception cref="ArgumentException"></exception>
    private static T Zero<T>(this IGuardClause guardClause, T input, string parameterName, string? message = null)
        where T : struct
    {
        if (EqualityComparer<T>.Default.Equals(input, default))
        {
            throw new ArgumentException(message ?? $"输入参数 {parameterName} 不能为0.", parameterName);
        }

        return input;
    }
}
