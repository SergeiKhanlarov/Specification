using Specification.Specifications;

namespace Specification.Abstractions;

/// <inheritdoc cref="ISpecification{T}"/>
public abstract class CompositeSpecification<T> : ISpecification<T>
{
    /// <inheritdoc/>
    public bool IsSatisfiedBy(T candidate) => IsSatisfiedByExpression().Compile()(candidate);

    /// <inheritdoc/>
    public abstract Expression<Func<T, bool>> IsSatisfiedByExpression();

    /// <inheritdoc/>
    public ISpecification<T> And(ISpecification<T> other) => new AndSpecification<T>(this, other);

    /// <inheritdoc/>
    public ISpecification<T> AndNot(ISpecification<T> other) => new AndNotSpecification<T>(this, other);

    /// <inheritdoc/>
    public ISpecification<T> Or(ISpecification<T> other) => new OrSpecification<T>(this, other);

    /// <inheritdoc/>
    public ISpecification<T> OrNot(ISpecification<T> other) => new OrNotSpecification<T>(this, other);

    /// <inheritdoc/>
    public ISpecification<T> Not() => new NotSpecification<T>(this);
}
