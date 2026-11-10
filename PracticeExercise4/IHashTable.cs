using System;
namespace PracticeExercise4
{
	public interface IHashTable<K, V>
	{
		/// <summary>
		/// Add key value pair or update value if key is already present.
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		/// <returns>Return true if the key was already present in hash table, false if the key is a new key </returns>
		bool Add(K key, V value);

		/// <summary>
        /// Get the value for the given key
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Value for the given key</returns>
        /// <exception cref="KeyNotFoundException">The key is not in the hash table</exception>
		V Get(K key);

		/// <summary>
		/// Remove the key and its value from the hash table, if present.
		/// </summary>
		/// <param name="key"></param>
		/// <returns>Return true if the key was in the hash table (and was removed), false otherwise</returns>
		bool Remove(K key);

		/// <summary>
        /// Determine if the key is present in the hash table
        /// </summary>
        /// <param name="key"></param>
        /// <returns>true if the given key is present in the hash table</returns>
		bool ContainsKey(K key);

		/// <summary>
        /// Determine if the value is present in the hash table
        /// </summary>
        /// <param name="value"></param>
        /// <returns>true if the value is present as a value in the hash table</returns>
		bool ContainsValue(V value);

		/// <summary>
        /// The number of key/value pairs in the hash table
        /// </summary>
		int Count { get; }

		/// <summary>
        /// Get a list of all keys in the hash table
        /// </summary>
        /// <returns>A list of keys in the hash table (not ordered)</returns>
		List<K> GetKeys();

		/// <summary>
        /// Get a list of all values in the hash table
        /// </summary>
        /// <returns>A list of values in the hash table (not ordered)</returns>
		List<V> GetValues();

		/// <summary>
		/// The current load factor of the hash table, i.e., the number of key/value pairs
		/// divided by the number of buckets (Count / capacity). With chaining this can exceed 1.
		/// </summary>
		double LoadFactor { get; }
	}
}

