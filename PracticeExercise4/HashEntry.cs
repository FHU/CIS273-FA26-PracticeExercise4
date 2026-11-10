namespace PracticeExercise4;

public enum HashEntryState
{
	EmptySinceStart,
	EmptyAfterRemoval,
	Full
}

public class HashEntry<K, V>
{
	public K Key { get; set; }
	public V Value { get; set; }
	public HashEntryState State { get; set; }

	public HashEntry()
	{
		State = HashEntryState.EmptySinceStart;
	}

	public HashEntry(K key, V value)
	{
		Key = key;
		Value = value;
		State = HashEntryState.Full;
	}

	public void Clear()
	{
		Key = default;
		Value = default;
		State = HashEntryState.EmptyAfterRemoval;
	}
}

