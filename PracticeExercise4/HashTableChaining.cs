namespace PracticeExercise4;

public class HashTableChaining<K, V> : IHashTable<K, V>
{
    List<HashEntry<K, V>>[] entryListArray;

    private int initialCapacity = 13;

    public readonly double MAX_LOAD_FACTOR = 0.6;

    public HashTableChaining()
    {
        // init all entry lists
        
    }

    private int count;
    public int Count => count;

    public double LoadFactor => (double)count / entryListArray.Length;

    public bool Add(K key, V value)
    {
        // resize if needed
        

        // get the hash of the key
        

        // find the correct array index / element
        

        // check if key is already present
        

        // add the new key/value pair to the correct list
       

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
        // hash the key
        

        // find the correct index of the list
        

        // find the entry with the given key (in the correct list)
        
        return default;
    }

    public List<K> GetKeys()
    {
        return null;
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
        int newSize = NextPrime(2 * entryListArray.Length);
        var newEntryListArray = new List<HashEntry<K, V>>[newSize];
        var oldEntryListArray = entryListArray;

        // initialize the new entry list array 
        for (int i = 0; i < newEntryListArray.Length; i++)
        {
            newEntryListArray[i] = new List<HashEntry<K, V>>();
        }

        entryListArray = newEntryListArray;
        count = 0;

        // re-add all the old buckets into the new array
        foreach (var list in oldEntryListArray)
        {
            foreach (var entry in list)
            {
                Add(entry.Key, entry.Value);
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


