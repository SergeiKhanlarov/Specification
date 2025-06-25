namespace Specification.Specifications;

/// <summary>
/// "НЕ" спецификация
/// </summary>
/// <typeparam name="T">Параметр</typeparam>
/// <param name="other"><see cref="ISpecification{T}"/></param>
public class NotSpecification<T>(ISpecification<T> other) : CompositeSpecification<T>
{
    /// <inheritdoc/>
    public override Expression<Func<T, bool>> IsSatisfiedByExpression()
    {
        var param = Expression.Parameter(typeof(T), "x");
        return Expression.Lambda<Func<T, bool>>(Expression.Not(Expression.Invoke(other.IsSatisfiedByExpression(), param)), param);
    }
}