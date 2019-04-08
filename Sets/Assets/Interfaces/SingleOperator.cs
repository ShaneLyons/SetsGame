/// <summary>
/// An operator takes a single set and does an operation on it.
/// </summary>
public interface SingletonOperator
{
    /// <summary>
    /// Compute an operation on a set.
    /// </summary>
    /// <oaram name="set">The set to be oeprated on.</param>
    /// <returns>A new Set.</returns>
    Set Calculate(Set set);
}
