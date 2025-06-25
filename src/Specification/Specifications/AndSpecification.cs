namespace Specification.Specifications;

/// <summary>
/// "И" спецификация
/// </summary>
/// <typeparam name="T">Параметр</typeparam>
/// <param name="left"><see cref="ISpecification{T}"/></param>
/// <param name="right"><see cref="ISpecification{T}"/></param>
public class AndSpecification<T>(ISpecification<T> left, ISpecification<T> right) : CompositeSpecification<T>
{
    /// <inheritdoc/>
    public override Expression<Func<T, bool>> IsSatisfiedByExpression()
    {
        var param = Expression.Parameter(typeof(T), "x");
        var body = Expression.And(Expression.Invoke(left.IsSatisfiedByExpression(), param),
                                  Expression.Invoke(right.IsSatisfiedByExpression(), param));
        return Expression.Lambda<Func<T, bool>>(body, param);
    }
}
