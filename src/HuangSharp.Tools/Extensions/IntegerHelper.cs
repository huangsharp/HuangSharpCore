using System;
using System.Collections.Generic;
using System.Linq;

namespace HuangSharp.Extensions;

#region 整形相关操作助手

/// <summary>
///     整形相关操作助手
/// </summary>
public class IntegerHelper
{
    #region GUID转成一个数字

    /// <summary>
    ///     GUID转成一个数字
    /// </summary>
    /// <param name="guid">要处理的GUID</param>
    /// <returns></returns>
    public static long GuidToNumber(Guid guid)
    {
        return BitConverter.ToInt64(guid.ToByteArray(), 0);
    }

    #endregion

    #region 生成一组连续的整数

    /// <summary>
    ///     生成一组连续的整数
    /// </summary>
    /// <param name="start">开始的整数</param>
    /// <param name="end">结束的整数(小于end)</param>
    /// <returns></returns>
    public static List<int> GetRange(int start, int end)
    {
        return Enumerable.Range(start, end).ToList();
    }

    #endregion
}

#endregion
