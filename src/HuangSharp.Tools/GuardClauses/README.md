# 参数检查守卫

预先检查无效输入参数，如果发现任何无效输入，则立即失败，并且抛出异常。

## 使用方法

```csharp

using HuangSharp.GuardClauses;

public void ProcessOrder(Order order)
{
    Guard.Against.Null(order, nameof(order));

    // process order here
}

// 或

public class Order
{
    private string _name;
    private int _quantity;
    private long _max;
    private decimal _unitPrice;
    private DateTime _dateCreated;

    public Order(string name, int quantity, long max, decimal unitPrice, DateTime dateCreated)
    {
        _name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
        _quantity = Guard.Against.NegativeOrZero(quantity, nameof(quantity));
        _max = Guard.Against.Zero(max, nameof(max));
        _unitPrice = Guard.Against.Negative(unitPrice, nameof(unitPrice));
        _dateCreated = Guard.Against.OutOfDateRange(dateCreated, nameof(dateCreated));
    }
}
```

## 目前支持的守卫

```csharp

Guard.Against.Null (throws if input is null)
Guard.Against.NullOrEmpty (throws if string, guid or array input is null or empty)
Guard.Against.NullOrWhiteSpace (throws if string input is null, empty or whitespace)
Guard.Against.OutOfRange (throws if integer/DateTime/enum input is outside a provided range)
Guard.Against.EnumOutOfRange (throws if an enum value is outside a provided Enum range)
Guard.Against.OutOfDateRange (throws if DateTime input is outside the valid range of DateTime values)
Guard.Against.Zero (throws if number input is zero)

```

## 扩展自定义守卫


```csharp
// 使用相同的命名空间这样可以确保你扩展的的代码无论在代码库中的哪个位置都能用
namespace HuangSharp.GuardClauses
{
    public static class ActorIdGuard
    {
        public static void CheckId(this IGuardClause guardClause, long id, string parameterName)
        {
            if (input <= 0)
                throw new ArgumentException("无效的id!", parameterName);
        }
    }
}

// 使用
public void SomeMethod(long id)
{
    // 验证 是否是有效的 long 类型的有意义的业务 id
    Guard.Against.CheckId(id, nameof(id));
}
```












