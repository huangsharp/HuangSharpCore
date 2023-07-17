using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;

namespace HuangSharp.GuardClauses;

/// <summary>
///     守卫 Null 扩展
/// </summary>
public static partial class GuardClauseExtensions
{
    /// <summary>
    ///     如果 输入 <paramref name="input" /> 为 null ，则抛出异常 <see cref="ArgumentNullException" /> 。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="guardClause"></param>
    /// <param name="input"></param>
    /// <param name="parameterName"></param>
    /// <param name="message">可选，自定义异常消息</param>
    /// <returns><paramref name="input" /> 如果值不为 null.</returns>
    public static T Null<T>(this IGuardClause guardClause,
        [NotNull] [ValidatedNotNull] T input,
        [CallerArgumentExpression("input")] string? parameterName = null,
        string? message = null)
    {
        if (input is null)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException(parameterName);
            }

            throw new ArgumentNullException(parameterName, message);
        }

        return input;
    }

    /// <summary>
    ///     如果 输入 <paramref name="input" /> 为 null 或 空字符串，则抛出异常 <see cref="ArgumentNullException" /> 。
    /// </summary>
    /// <param name="guardClause"></param>
    /// <param name="input"></param>
    /// <param name="parameterName"></param>
    /// <param name="message">可选，自定义异常消息</param>
    /// <returns><paramref name="input" /> 如果值不是 空字符串 或 null.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public static string NullOrEmpty(this IGuardClause guardClause,
        [NotNull] [ValidatedNotNull] string? input,
        [CallerArgumentExpression("input")] string? parameterName = null,
        string? message = null)
    {
        Guard.Against.Null(input, parameterName, message);
        if (input == string.Empty)
        {
            throw new ArgumentException(message ?? $"参数 {parameterName} 为空.", parameterName);
        }

        return input;
    }

    /// <summary>
    ///     如果 输入 <paramref name="input" /> 为 null 或 Empty guid，则抛出异常 <see cref="ArgumentNullException" /> 。
    /// </summary>
    /// <param name="guardClause"></param>
    /// <param name="input"></param>
    /// <param name="parameterName"></param>
    /// <param name="message">可选，自定义异常消息</param>
    /// <returns><paramref name="input" /> 如果值不为 empty guid 或 null.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public static Guid NullOrEmpty(this IGuardClause guardClause,
        [NotNull] [ValidatedNotNull] Guid? input,
        [CallerArgumentExpression("input")] string? parameterName = null,
        string? message = null)
    {
        Guard.Against.Null(input, parameterName, message);
        if (input == Guid.Empty)
        {
            throw new ArgumentException(message ?? $"参数 {parameterName} 为空", parameterName);
        }

        return input.Value;
    }

    /// <summary>
    ///     如果 输入 <paramref name="inputs" /> 为 null ，则抛出异常 <see cref="ArgumentNullException" /> 。
    ///     Throws an <see cref="ArgumentException" /> if <paramref name="inputs" /> is an empty enumerable.
    /// </summary>
    /// <param name="guardClause"></param>
    /// <param name="inputs"></param>
    /// <param name="parameterName"></param>
    /// <param name="message">可选，自定义异常消息</param>
    /// <returns><paramref name="inputs" /> if the value is not an empty enumerable or null.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public static IEnumerable<T> NullOrEmpty<T>(this IGuardClause guardClause,
        [NotNull] [ValidatedNotNull] IEnumerable<T>? inputs,
        [CallerArgumentExpression("inputs")] string? parameterName = null,
        string? message = null)
    {
        Guard.Against.Null(inputs, parameterName, message);
        if (!inputs.Any())
        {
            throw new ArgumentException(message ?? $"参数 {parameterName} 为空.", parameterName);
        }

        return inputs;
    }

    /// <summary>
    ///     如果 输入 <paramref name="input" /> 为 null ，则抛出异常 <see cref="ArgumentNullException" /> 。
    ///     Throws an <see cref="ArgumentException" /> if <paramref name="input" /> is an empty or white space string.
    /// </summary>
    /// <param name="guardClause"></param>
    /// <param name="input"></param>
    /// <param name="parameterName"></param>
    /// <param name="message">可选，自定义异常消息</param>
    /// <returns><paramref name="input" /> if the value is not an empty or whitespace string.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public static string NullOrWhiteSpace(this IGuardClause guardClause,
        [NotNull] [ValidatedNotNull] string? input,
        [CallerArgumentExpression("input")] string? parameterName = null,
        string? message = null)
    {
        Guard.Against.NullOrEmpty(input, parameterName, message);
        if (String.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentException(message ?? $"参数 {parameterName} 为空.", parameterName);
        }

        return input;
    }

    /// <summary>
    ///     如果输入参数 <paramref name="input" /> 是指定类型的默认值，则抛出异常。
    /// </summary>
    /// <param name="guardClause"></param>
    /// <param name="input"></param>
    /// <param name="parameterName"></param>
    /// <param name="message">可选，自定义异常消息</param>
    /// <returns><paramref name="input" /> 如果值不是是指定类型的默认值</returns>
    /// <exception cref="ArgumentException"></exception>
    public static T Default<T>(this IGuardClause guardClause,
        [AllowNull] [NotNull] T input,
        [CallerArgumentExpression("input")] string? parameterName = null,
        string? message = null)
    {
        if (EqualityComparer<T>.Default.Equals(input, default!) || input is null)
        {
            throw new ArgumentException(message ?? $"参数 [{parameterName}] 为 {typeof(T).Name}的默认值", parameterName);
        }

        return input;
    }


    /// <summary>
    ///     如果输入参数 <paramref name="input" /> 为 null，则抛出异常 <see cref="ArgumentNullException" />
    ///     如果输入参数 <paramref name="input" /> 不满足 <paramref name="predicate" /> 函数，则抛出异常 <see cref="ArgumentException" />
    /// </summary>
    /// <param name="guardClause"></param>
    /// <param name="input"></param>
    /// <param name="parameterName"></param>
    /// <param name="predicate"></param>
    /// <param name="message">可选，自定义异常消息</param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    public static T NullOrInvalidInput<T>(this IGuardClause guardClause,
        T input,
        string parameterName,
        Func<T, bool> predicate,
        string? message = null)
    {
        Guard.Against.Null(input, parameterName, message);

        return Guard.Against.InvalidInput(input, parameterName, predicate, message);
    }
}
