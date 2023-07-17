using System;

namespace HuangSharp.GuardClauses;

/// <summary>
///     添加到方法中以便于检查输入是否为空，如果输入为空，则抛出异常
/// </summary>
[AttributeUsage(AttributeTargets.Parameter)]
public sealed class ValidatedNotNullAttribute : Attribute
{
}
