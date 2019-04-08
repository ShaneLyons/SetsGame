using System.Collections.Generic;

/// <summary>
/// A Set is a collection of SetObjects.
/// </summary>
public interface Set
{
    /// <summary>
    /// Return the items in the Set.
    /// </summary>
    /// <returns>A List of SetObjects in the Set.</returns>
    List<SetObject> Items();

    /// <summary>
    /// Get the size of the set.
    /// </summary>
    /// <returns>The size of the set.</returns>
    int Size();
}
