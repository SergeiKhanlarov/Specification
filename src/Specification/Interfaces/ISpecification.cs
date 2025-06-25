namespace Specification.Interfaces;

/// <summary>
/// Интерфейс спецификации
/// </summary>
/// <typeparam name="T">Тип сущности</typeparam>
public interface ISpecification<T>
{
    /// <summary>
    /// Удовлетворяет ли сущность условию
    /// </summary>
    /// <param name="candidate">Сущность</param>
    /// <returns></returns>
    bool IsSatisfiedBy(T candidate);

    /// <summary>
    /// Удовлетворяет ли сущность условию
    /// </summary>
    /// <returns></returns>
    Expression<Func<T, bool>> IsSatisfiedByExpression();

    /// <summary>
    /// Добавить спецификацию
    /// </summary>
    /// <param name="other"><see cref="ISpecification{T}"/></param>
    /// <returns></returns>
    ISpecification<T> And(ISpecification<T> other);

    /// <summary>
    /// Добавить спецификацию
    /// </summary>
    /// <param name="other"><see cref="ISpecification{T}"/></param>
    /// <returns></returns>
    ISpecification<T> AndNot(ISpecification<T> other);

    /// <summary>
    /// Добавить спецификацию
    /// </summary>
    /// <param name="other"><see cref="ISpecification{T}"/></param>
    /// <returns></returns>
    ISpecification<T> Or(ISpecification<T> other);

    /// <summary>
    /// Добавить спецификацию
    /// </summary>
    /// <param name="other"><see cref="ISpecification{T}"/></param>
    /// <returns></returns>
    ISpecification<T> OrNot(ISpecification<T> other);

    /// <summary>
    /// Инверировать спецификацию
    /// </summary>
    /// <returns></returns>
    ISpecification<T> Not();
}
