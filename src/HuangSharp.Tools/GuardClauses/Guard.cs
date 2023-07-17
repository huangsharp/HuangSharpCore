
namespace HuangSharp.GuardClauses;

/// <summary>
///     守卫最小 单元接口，简单的接口提供了一种通用机制，用于从中构建保护子句扩展方法。
/// </summary>
public interface IGuardClause
{
}

/// <summary>
///     守卫默认实现类
/// </summary>
public class Guard : IGuardClause
{
    private Guard() { }

    /// <summary>
    ///     守卫入口
    /// </summary>
    /// <example>
    ///     Guard.Against.Null(order, nameof(order));
    /// </example>
    public static IGuardClause Against { get; } = new Guard();
}
