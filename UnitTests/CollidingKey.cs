namespace UnitTests;

/// <summary>
/// A test key whose hash code is chosen by the test, so collisions can be forced
/// no matter what capacity the hash table uses. Two keys are equal when their Ids
/// match, so tests can look a key up with a new instance: ht.Get(new CollidingKey(1)).
/// </summary>
public class CollidingKey(int id, int hash = 42)
{
    public int Id { get; } = id;

    public override int GetHashCode() => hash;

    public override bool Equals(object? obj) => obj is CollidingKey other && other.Id == Id;

    public override string ToString() => $"CollidingKey({Id}, hash {hash})";
}
