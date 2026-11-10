namespace PracticeExercise4;

public class HashTableLinearProbing<K, V> : IHashTable<K, V>
{
    private HashEntry<K, V>[] hashEntries;

    private int initialCapacity = 13;

    public readonly double MAX_LOAD_FACTOR = 0.6;

    public HashTableLinearProbing()
    {
        // init all hash entries 
    }

    private int count;
    public int Count => count;

    public double LoadFactor => (double)count / hashEntries.Length;

    public bool Add(K key, V value)
    {
        // if key is already present, update its value


        // resize if needed


        // get the hash of the key


        // find the array index for this hash


        // if there's a collision at that index, find the next available index
        // (an EmptyAfterRemoval slot can be reused, since Update already
        // confirmed the key isn't further along the probe sequence)


        // save key/value pair at correct index


        return false;

    }

    // If key is present, update its value and return true; otherwise return false.
    private bool Update(K key, V value)
    {
        // find starting index


        // keep probing past Full and EmptyAfterRemoval slots;
        // stop at EmptySinceStart, since the key can't be beyond a never-used slot


        return false;
    }

    public bool ContainsKey(K key)
    {
        throw new NotImplementedException();
    }

    public bool ContainsValue(V value)
    {
        throw new NotImplementedException();
    }

    public V Get(K key)
    {
        throw new NotImplementedException();
    }

    public List<K> GetKeys()
    {
        throw new NotImplementedException();
    }

    public List<V> GetValues()
    {
        throw new NotImplementedException();
    }

    public bool Remove(K key)
    {
        throw new NotImplementedException();
    }

    private int Hash(K key)
    {
        // clear the sign bit (Math.Abs throws on int.MinValue)
        return key.GetHashCode() & 0x7FFFFFFF;
    }

    private void Resize()
    {
        int newSize = NextPrime(2 * hashEntries.Length);
        var newBuckets = new HashEntry<K, V>[newSize];
        var oldBuckets = hashEntries;

        // initialize the new buckets array 
        for (int i = 0; i < newBuckets.Length; i++)
        {
            newBuckets[i] = new HashEntry<K, V>();
        }

        hashEntries = newBuckets;
        count = 0;

        // re-add all the old buckets into the new array
        foreach (var bucket in oldBuckets)
        {
            if (bucket.State == HashEntryState.Full)
            {
                Add(bucket.Key, bucket.Value);
            }
        }
    }

    private static bool IsPrime(int n)
    {
        if (n < 2) return false;
        if (n < 4) return true;           // 2 and 3
        if (n % 2 == 0) return false;

        for (int d = 3; (long)d * d <= n; d += 2)
        {
            if (n % d == 0) return false;
        }
        return true;
    }

    private static int NextPrime(int n)
    {
        if (n <= 2) return 2;
        int candidate = (n % 2 == 0) ? n + 1 : n;   // only odd numbers can be prime past 2
        while (!IsPrime(candidate))
        {
            candidate += 2;
        }
        return candidate;
    }
}
