/// <summary>
/// Computes a Set from two other sets.
/// </summary>
public interface DoubleOperator
{
    /// <summary>
    /// Computes an operation on two sets.
    /// </summary>
    /// <param name="setX">The first set to be operated on.</param>
    /// <param name="setY">The second set to b operated on.</param>
    /// <returns>A new Set.</returns>
    Set Calculate(Set setX, Set setY);
}
