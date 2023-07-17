using System;
using System.Threading.Tasks;


namespace HuangSharp.GuardClauses;

/// <summary>
/// 守卫 Expression 扩展
/// </summary>
public static partial class GuardClauseExtensions
{
    /// <summary>
    /// 如果给定的输入 <paramref name="input"/> 在表达式 <paramref name="func"/> 中评估的返回值为 false 则抛出异常 <see cref="ArgumentException" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="func"></param>
    /// <param name="guardClause"></param>
    /// <param name="input"></param>
    /// <param name="message"></param>
    /// <returns>  如果 <paramref name="func"/> 评估为 true ，返回原始输入 <paramref name="input"/></returns>
    /// <exception cref="ArgumentException"></exception>
    public static T AgainstExpression<T>(this IGuardClause guardClause,
        Func<T, bool> func,
        T input,
        string message) where T : struct
    {
        if (!func(input))
        {
            throw new ArgumentException(message);
        }

        return input;
    }

    /// <summary>
    /// 如果给定的输入 <paramref name="input"/> 在表达式 <paramref name="func"/> 中评估的返回值为 false 则抛出异常 <see cref="ArgumentException" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="func"></param>
    /// <param name="guardClause"></param>
    /// <param name="input"></param>
    /// <param name="message"></param>
    /// <returns>  如果 <paramref name="func"/> 评估为 true ，返回原始输入 <paramref name="input"/></returns>
    /// <exception cref="ArgumentException"></exception>
    public static async Task<T> AgainstExpressionAsync<T>(this IGuardClause guardClause,
        Func<T, Task<bool>> func,
        T input,
        string message) where T : struct
    {
        if (!await func(input))
        {
            throw new ArgumentException(message);
        }

        return input;
    }
}
