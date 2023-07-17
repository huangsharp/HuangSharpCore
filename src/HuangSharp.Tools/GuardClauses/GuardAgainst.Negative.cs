using System;
using System.Runtime.CompilerServices;

namespace HuangSharp.GuardClauses;

/// <summary>
///     守卫 Negative 扩展
/// </summary>
public static partial class GuardClauseExtensions
{
    /// <summary>
    ///     如果输入 <paramref name="input" /> 是负数，则抛出异常 <see cref="ArgumentException" /> 。
    /// </summary>
    /// <param name="guardClause"></param>
    /// <param name="input"></param>
    /// <param name="parameterName"></param>
    /// <param name="message">可选. 自定义异常</param>
    /// <returns><paramref name="input" /> 如果数值不是负值.</returns>
    /// <exception cref="ArgumentException"></exception>
    public static int Negative(this IGuardClause guardClause,
        int input,
        [CallerArgumentExpression("input")] string? parameterName = null,
        string? message = null)
    {
        return Negative<int>(guardClause, input, parameterName, message);
    }

    /// <summary>
    ///     如果输入 <paramref name="input" /> 是负数，则抛出异常 <see cref="ArgumentException" /> 。
    /// </summary>
    /// <param name="guardClause"></param>
    /// <param name="input"></param>
    /// <param name="parameterName"></param>
    /// <param name="message">可选. 自定义异常</param>
    /// <returns><paramref name="input" /> 如果数值不是负值.</returns>
    /// <exception cref="ArgumentException"></exception>
    public static long Negative(this IGuardClause guardClause,
        long input,
        [CallerArgumentExpression("input")] string? parameterName = null,
        string? message = null)
    {
        return Negative<long>(guardClause, input, parameterName, message);
    }

    /// <summary>
    ///     如果输入 <paramref name="input" /> 是负数，则抛出异常 <see cref="ArgumentException" /> 。
    /// </summary>
    /// <param name="guardClause"></param>
    /// <param name="input"></param>
    /// <param name="parameterName"></param>
    /// <param name="message">可选. 自定义异常</param>
    /// <returns><paramref name="input" /> 如果数值不是负值.</returns>
    /// <exception cref="ArgumentException"></exception>
    public static decimal Negative(this IGuardClause guardClause,
        decimal input,
        [CallerArgumentExpression("input")] string? parameterName = null,
        string? message = null)
    {
        return Negative<decimal>(guardClause, input, parameterName, message);
    }

    /// <summary>
    ///     如果输入 <paramref name="input" /> 是负数，则抛出异常 <see cref="ArgumentException" /> 。
    /// </summary>
    /// <param name="guardClause"></param>
    /// <param name="input"></param>
    /// <param name="parameterName"></param>
    /// <param name="message">可选. 自定义异常</param>
    /// <returns><paramref name="input" /> 如果数值不是负值.</returns>
    /// <exception cref="ArgumentException"></exception>
    public static float Negative(this IGuardClause guardClause,
        float input,
        [CallerArgumentExpression("input")] string? parameterName = null,
        string? message = null)
    {
        return Negative<float>(guardClause, input, parameterName, message);
    }

    /// <summary>
    ///     如果输入 <paramref name="input" /> 是负数，则抛出异常 <see cref="ArgumentException" /> 。
    /// </summary>
    /// <param name="guardClause"></param>
    /// <param name="input"></param>
    /// <param name="parameterName"></param>
    /// <param name="message">可选. 自定义异常</param>
    /// <returns><paramref name="input" /> 如果数值不是负值.</returns>
    /// <exception cref="ArgumentException"></exception>
    public static double Negative(this IGuardClause guardClause,
        double input,
        [CallerArgumentExpression("input")] string? parameterName = null,
        string? message = null)
    {
        return Negative<double>(guardClause, input, parameterName, message);
    }

    /// <summary>
    ///     如果输入 <paramref name="input" /> 是负数，则抛出异常 <see cref="ArgumentException" /> 。
    /// </summary>
    /// <param name="guardClause"></param>
    /// <param name="input"></param>
    /// <param name="parameterName"></param>
    /// <param name="message">可选. 自定义异常</param>
    /// <returns><paramref name="input" /> 如果数值不是负值.</returns>
    /// <exception cref="ArgumentException"></exception>
    public static TimeSpan Negative(this IGuardClause guardClause,
        TimeSpan input,
        [CallerArgumentExpression("input")] string? parameterName = null,
        string? message = null)
    {
        return Negative<TimeSpan>(guardClause, input, parameterName, message);
    }

    /// <summary>
    ///     如果输入 <paramref name="input" /> 是负数，则抛出异常 <see cref="ArgumentException" /> 。
    /// </summary>
    /// <param name="guardClause"></param>
    /// <param name="input"></param>
    /// <param name="parameterName"></param>
    /// <param name="message">可选. 自定义异常</param>
    /// <returns><paramref name="input" /> 如果数值不是负值.</returns>
    /// <exception cref="ArgumentException"></exception>
    private static T Negative<T>(this IGuardClause guardClause,
        T input,
        [CallerArgumentExpression("input")] string? parameterName = null,
        string? message = null) where T : struct, IComparable
    {
        if (input.CompareTo(default(T)) < 0)
        {
            throw new ArgumentException(message ?? $"参数 {parameterName} 不能为负值。",
                parameterName);
        }

        return input;
    }

    /// <summary>
    ///     Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is negative 或 0.
    /// </summary>
    /// <param name="guardClause"></param>
    /// <param name="input"></param>
    /// <param name="parameterName"></param>
    /// <param name="message">可选. 自定义异常</param>
    /// <returns><paramref name="input" /> 如果数值不是负值 或 0.</returns>
    public static int NegativeOrZero(this IGuardClause guardClause,
        int input,
        [CallerArgumentExpression("input")] string? parameterName = null,
        string? message = null)
    {
        return NegativeOrZero<int>(guardClause, input, parameterName, message);
    }

    /// <summary>
    ///     Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is negative 或 0.
    /// </summary>
    /// <param name="guardClause"></param>
    /// <param name="input"></param>
    /// <param name="parameterName"></param>
    /// <param name="message">可选. 自定义异常</param>
    /// <returns><paramref name="input" /> 如果数值不是负值 或 0.</returns>
    public static long NegativeOrZero(this IGuardClause guardClause,
        long input,
        [CallerArgumentExpression("input")] string? parameterName = null,
        string? message = null)
    {
        return NegativeOrZero<long>(guardClause, input, parameterName, message);
    }

    /// <summary>
    ///     Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is negative 或 0.
    /// </summary>
    /// <param name="guardClause"></param>
    /// <param name="input"></param>
    /// <param name="parameterName"></param>
    /// <param name="message">可选. 自定义异常</param>
    /// <returns><paramref name="input" /> 如果数值不是负值 或 0.</returns>
    public static decimal NegativeOrZero(this IGuardClause guardClause,
        decimal input,
        [CallerArgumentExpression("input")] string? parameterName = null,
        string? message = null)
    {
        return NegativeOrZero<decimal>(guardClause, input, parameterName, message);
    }

    /// <summary>
    ///     Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is negative 或 0.
    /// </summary>
    /// <param name="guardClause"></param>
    /// <param name="input"></param>
    /// <param name="parameterName"></param>
    /// <param name="message">可选. 自定义异常</param>
    /// <returns><paramref name="input" /> 如果数值不是 负值 或 0.</returns>
    public static float NegativeOrZero(this IGuardClause guardClause,
        float input,
        [CallerArgumentExpression("input")] string? parameterName = null,
        string? message = null)
    {
        return NegativeOrZero<float>(guardClause, input, parameterName, message);
    }

    /// <summary>
    ///     Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is negative 或 0.
    /// </summary>
    /// <param name="guardClause"></param>
    /// <param name="input"></param>
    /// <param name="parameterName"></param>
    /// <param name="message">可选. 自定义异常</param>
    /// <returns><paramref name="input" /> 如果数值不是 负值 或 0.</returns>
    public static double NegativeOrZero(this IGuardClause guardClause,
        double input,
        [CallerArgumentExpression("input")] string? parameterName = null,
        string? message = null)
    {
        return NegativeOrZero<double>(guardClause, input, parameterName, message);
    }

    /// <summary>
    ///     Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is negative 或 0.
    /// </summary>
    /// <param name="guardClause"></param>
    /// <param name="input"></param>
    /// <param name="parameterName"></param>
    /// <param name="message">可选. 自定义异常</param>
    /// <returns><paramref name="input" /> 如果数值不是负值 或 0.</returns>
    public static TimeSpan NegativeOrZero(this IGuardClause guardClause,
        TimeSpan input,
        [CallerArgumentExpression("input")] string? parameterName = null,
        string? message = null)
    {
        return NegativeOrZero<TimeSpan>(guardClause, input, parameterName, message);
    }

    /// <summary>
    ///     Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is negative 或 0.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="guardClause"></param>
    /// <param name="input"></param>
    /// <param name="parameterName"></param>
    /// <param name="message">可选. 自定义异常</param>
    /// <returns><paramref name="input" /> 如果数值不是负值 或 0.</returns>
    private static T NegativeOrZero<T>(this IGuardClause guardClause,
        T input,
        [CallerArgumentExpression("input")] string? parameterName = null,
        string? message = null) where T : struct, IComparable
    {
        if (input.CompareTo(default(T)) <= 0)
        {
            throw new ArgumentException(message ?? $"参数 {parameterName} 不能为 0 或负值。",
                parameterName);
        }

        return input;
    }
}
