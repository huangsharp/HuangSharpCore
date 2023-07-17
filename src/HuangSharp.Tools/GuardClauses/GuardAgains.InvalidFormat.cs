using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HuangSharp.GuardClauses;

/// <summary>
///     守卫 InvalidFormat 扩展
/// </summary>
public static partial class GuardClauseExtensions
{
    /// <summary>
    ///     如果 输入 <paramref name="input" /> 不匹配指定的 <paramref name="regexPattern" /> 则抛出异常 <see cref="ArgumentException" />
    /// </summary>
    /// <param name="guardClause"></param>
    /// <param name="input"></param>
    /// <param name="parameterName"></param>
    /// <param name="regexPattern"></param>
    /// <param name="message">可选，自定义异常消息</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static string InvalidFormat(this IGuardClause guardClause,
        string input,
        string parameterName,
        string regexPattern,
        string? message = null)
    {
        var m = Regex.Match(input, regexPattern);
        if (!m.Success || input != m.Value)
        {
            throw new ArgumentException(message ?? $"参数 {parameterName} 不符合要求的格式", parameterName);
        }

        return input;
    }

    /// <summary>
    ///     如果 输入 <paramref name="input" /> 不满足指定的 <paramref name="predicate" /> 函数，则抛出异常 <see cref="ArgumentException" />
    /// </summary>
    /// <param name="guardClause"></param>
    /// <param name="input"></param>
    /// <param name="parameterName"></param>
    /// <param name="predicate"></param>
    /// <param name="message">可选. 自定义异常消息</param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static T InvalidInput<T>(this IGuardClause guardClause, T input, string parameterName,
        Func<T, bool> predicate, string? message = null)
    {
        if (!predicate(input))
        {
            throw new ArgumentException(message ?? $"参数{parameterName}不满足表达式要求", parameterName);
        }

        return input;
    }

    /// <summary>
    ///     如果输出  <paramref name="input" /> 不满足指定的 <paramref name="predicate" /> 函数要求，则抛出异常 <see cref="ArgumentException" />
    /// </summary>
    /// <param name="guardClause"></param>
    /// <param name="input"></param>
    /// <param name="parameterName"></param>
    /// <param name="predicate"></param>
    /// <param name="message">可选. 自定义异常消息</param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static async Task<T> InvalidInputAsync<T>(this IGuardClause guardClause,
        T input,
        string parameterName,
        Func<T, Task<bool>> predicate,
        string? message = null)
    {
        if (!await predicate(input))
        {
            throw new ArgumentException(message ?? $"Input {parameterName} did not satisfy the options", parameterName);
        }

        return input;
    }
}
