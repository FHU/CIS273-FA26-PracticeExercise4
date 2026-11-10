using PracticeExercise4;

namespace UnitTests;

[TestClass]
public class HashTableLinearProbingTests
{
    [TestMethod]
    public void Add_Get_String_Int()
    {
        var ht = new HashTableLinearProbing<string, int>();

        ht.Add("XBX", 1);
        ht.Add("XCD", 2);
        ht.Add("EP", 3);
        ht.Add("ON", 4);
        ht.Add("PKA", 5);
        ht.Add("PM", 6);

        Assert.AreEqual(6, ht.Count);
        Assert.AreEqual(6, ht.Get("PM"));
        Assert.AreEqual(4, ht.Get("ON"));
    }

    [TestMethod]
    public void Remove_String_Int()
    {
        var ht = new HashTableLinearProbing<string, int>();

        ht.Add("XBX", 1);
        ht.Add("XCD", 2);
        ht.Add("EP", 3);
        ht.Add("ON", 4);
        ht.Add("PKA", 5);

        Assert.AreEqual(5, ht.Count);
        Assert.AreEqual(1, ht.Get("XBX"));

        ht.Remove("XBX");

        Assert.AreEqual(4, ht.Count);
        Assert.IsFalse(ht.ContainsKey("XBX"));

        // remove a key that's not in the hashtable
        ht.Remove("XBX");
        Assert.AreEqual(4, ht.Count);

        ht.Remove("XCD");
        ht.Remove("EP");
        ht.Remove("ON");
        ht.Remove("PKA");

        Assert.AreEqual(0, ht.Count);
    }

    [TestMethod]
    public void Remove_ReturnValue_ExistingKey()
    {
        var ht = new HashTableLinearProbing<string, int>();

        ht.Add("XBX", 1);
        ht.Add("XCD", 2);
        ht.Add("EP", 3);

        bool wasRemoved = ht.Remove("XBX");
        Assert.IsTrue(wasRemoved, "Remove should return true when removing an existing key");
        Assert.AreEqual(2, ht.Count);
        Assert.IsFalse(ht.ContainsKey("XBX"));

        wasRemoved = ht.Remove("EP");
        Assert.IsTrue(wasRemoved, "Remove should return true when removing an existing key");
        Assert.AreEqual(1, ht.Count);
        Assert.IsFalse(ht.ContainsKey("EP"));
    }

    [TestMethod]
    public void Remove_ReturnValue_NonExistentKey()
    {
        var ht = new HashTableLinearProbing<string, int>();

        ht.Add("XBX", 1);
        ht.Add("XCD", 2);

        bool wasRemoved = ht.Remove("NonExistent");
        Assert.IsFalse(wasRemoved, "Remove should return false when key doesn't exist");
        Assert.AreEqual(2, ht.Count, "Count should not change when removing non-existent key");

        wasRemoved = ht.Remove("PM");
        Assert.IsFalse(wasRemoved, "Remove should return false when key doesn't exist");
        Assert.AreEqual(2, ht.Count);
    }

    [TestMethod]
    public void Remove_ReturnValue_EmptyHashTable()
    {
        var ht = new HashTableLinearProbing<string, int>();

        bool wasRemoved = ht.Remove("XBX");
        Assert.IsFalse(wasRemoved, "Remove should return false when hash table is empty");
        Assert.AreEqual(0, ht.Count);
    }

    [TestMethod]
    public void Remove_ReturnValue_AfterRemoval()
    {
        var ht = new HashTableLinearProbing<string, string>();

        ht.Add("key", "value");

        bool wasRemoved = ht.Remove("key");
        Assert.IsTrue(wasRemoved, "First removal should return true");
        Assert.AreEqual(0, ht.Count);

        wasRemoved = ht.Remove("key");
        Assert.IsFalse(wasRemoved, "Second removal of same key should return false");
        Assert.AreEqual(0, ht.Count);
    }

    [TestMethod]
    public void Remove_ReturnValue_MultipleOperations()
    {
        var ht = new HashTableLinearProbing<int, string>();

        ht.Add(1, "one");
        ht.Add(2, "two");
        ht.Add(3, "three");

        Assert.IsTrue(ht.Remove(2), "Should successfully remove key 2");
        Assert.IsFalse(ht.Remove(2), "Second attempt to remove key 2 should fail");
        Assert.IsFalse(ht.Remove(5), "Removing non-existent key 5 should fail");
        Assert.IsTrue(ht.Remove(1), "Should successfully remove key 1");
        Assert.IsTrue(ht.Remove(3), "Should successfully remove key 3");
        Assert.AreEqual(0, ht.Count);
    }

    [TestMethod]
    public void ContainsKey_String_String()
    {
        var ht = new HashTableLinearProbing<string, string>();

        ht.Add("XBX", "bible");
        ht.Add("XCD", "hipster");
        ht.Add("EP", "toga");
        ht.Add("ON", "outcast");
        ht.Add("PKA", "redneck");

        Assert.AreEqual("bible", ht.Get("XBX"));
        Assert.IsTrue(ht.ContainsKey("XBX"));
        Assert.IsTrue(ht.ContainsKey("PKA"));
        Assert.IsTrue(ht.ContainsKey("XCD"));
        Assert.IsFalse(ht.ContainsKey("PM"));

        ht.Remove("XBX");

        Assert.IsFalse(ht.ContainsKey("XBX"));
    }


    [TestMethod]
    public void ContainsValue_String_String()
    {
        var ht = new HashTableLinearProbing<string, string>();

        ht.Add("XBX", "bible");
        ht.Add("XCD", "hipster");
        ht.Add("EP", "toga");
        ht.Add("ON", "outcast");
        ht.Add("PKA", "redneck");

        Assert.AreEqual("outcast", ht.Get("ON"));
        Assert.IsTrue(ht.ContainsValue("outcast"));
        Assert.IsTrue(ht.ContainsValue("toga"));
        Assert.IsTrue(ht.ContainsValue("redneck"));

        Assert.IsFalse(ht.ContainsValue("foo"));

        ht.Remove("XBX");

        Assert.IsFalse(ht.ContainsValue("bible"));
    }

    [TestMethod]
    public void AddDuplicate_String_String()
    {
        var ht = new HashTableLinearProbing<string, string>();

        ht.Add("XBX", "bible");
        ht.Add("XCD", "hipster");
        ht.Add("EP", "toga");
        ht.Add("ON", "outcast");
        ht.Add("PKA", "redneck");
        ht.Add("PKA", "tractor");
        ht.Add("PKA", "yeeeeet");

        Assert.AreEqual(5, ht.Count);
        Assert.AreEqual("yeeeeet", ht.Get("PKA"));
    }

    [TestMethod]
    public void Add_ReturnValue_NewKey()
    {
        var ht = new HashTableLinearProbing<string, int>();

        bool wasPresent = ht.Add("XBX", 1);
        Assert.IsFalse(wasPresent, "Add should return false for a new key");

        wasPresent = ht.Add("XCD", 2);
        Assert.IsFalse(wasPresent, "Add should return false for a new key");

        wasPresent = ht.Add("EP", 3);
        Assert.IsFalse(wasPresent, "Add should return false for a new key");

        Assert.AreEqual(3, ht.Count);
    }

    [TestMethod]
    public void Add_ReturnValue_ExistingKey()
    {
        var ht = new HashTableLinearProbing<string, int>();

        ht.Add("XBX", 1);
        ht.Add("XCD", 2);
        ht.Add("EP", 3);

        bool wasPresent = ht.Add("XBX", 100);
        Assert.IsTrue(wasPresent, "Add should return true when updating an existing key");
        Assert.AreEqual(100, ht.Get("XBX"));

        wasPresent = ht.Add("EP", 300);
        Assert.IsTrue(wasPresent, "Add should return true when updating an existing key");
        Assert.AreEqual(300, ht.Get("EP"));

        Assert.AreEqual(3, ht.Count, "Count should remain the same when updating existing keys");
    }

    [TestMethod]
    public void Add_ReturnValue_MultipleUpdates()
    {
        var ht = new HashTableLinearProbing<string, string>();

        bool wasPresent = ht.Add("key", "value1");
        Assert.IsFalse(wasPresent, "First add should return false");

        wasPresent = ht.Add("key", "value2");
        Assert.IsTrue(wasPresent, "Second add (update) should return true");

        wasPresent = ht.Add("key", "value3");
        Assert.IsTrue(wasPresent, "Third add (update) should return true");

        Assert.AreEqual(1, ht.Count);
        Assert.AreEqual("value3", ht.Get("key"));
    }


    [TestMethod]
    public void AddDuplicate_String_Int()
    {
        var ht = new HashTableLinearProbing<string, int>();

        ht.Add("XBX", 1);
        ht.Add("XCD", 2);
        ht.Add("EP", 3);
        ht.Add("ON", 4);
        ht.Add("PKA", 5);
        ht.Add("PM", 6);
        ht.Add("PM", 7);
        ht.Add("PM", 8);
        ht.Add("PM", 9);
        ht.Add("PM", 10);

        Assert.AreEqual(6, ht.Count);
        Assert.AreEqual(10, ht.Get("PM"));
    }

    [TestMethod]
    public void Resize_String_Int()
    {
        var ht = new HashTableLinearProbing<string, int>();

        ht.Add("a", 12);
        ht.Add("b", 12);
        ht.Add("c", 12);
        ht.Add("d", 12);
        ht.Add("e", 12);
        ht.Add("f", 12);
        ht.Add("g", 12);
        ht.Add("h", 12);
        ht.Add("i", 12);
        ht.Add("j", 12);
        ht.Add("k", 12);
        ht.Add("l", 12);
        ht.Add("m", 12);
        ht.Add("n", 12);
        ht.Add("o", 12);
        ht.Add("p", 12);
        ht.Add("q", 12);
        ht.Add("r", 12);
        ht.Add("s", 12);
        ht.Add("t", 12);
        ht.Add("u", 12);
        ht.Add("v", 12);
        ht.Add("w", 12);

        Assert.AreEqual(23, ht.Count);
        Assert.HasCount(23, ht.GetValues());

    }

    [TestMethod]
    public void GetKeys_EmptyHashTable()
    {
        var ht = new HashTableLinearProbing<string, int>();

        var keys = ht.GetKeys();

        Assert.IsNotNull(keys);
        Assert.IsEmpty(keys);
    }

    [TestMethod]
    public void GetKeys_String_Int()
    {
        var ht = new HashTableLinearProbing<string, int>();

        ht.Add("XBX", 1);
        ht.Add("XCD", 2);
        ht.Add("EP", 3);
        ht.Add("ON", 4);
        ht.Add("PKA", 5);

        var keys = ht.GetKeys();

        Assert.HasCount(5, keys);
        Assert.Contains("XBX", keys);
        Assert.Contains("XCD", keys);
        Assert.Contains("EP", keys);
        Assert.Contains("ON", keys);
        Assert.Contains("PKA", keys);
        Assert.DoesNotContain("PM", keys);
    }

    [TestMethod]
    public void GetKeys_String_String()
    {
        var ht = new HashTableLinearProbing<string, string>();

        ht.Add("apple", "red");
        ht.Add("banana", "yellow");
        ht.Add("grape", "purple");

        var keys = ht.GetKeys();

        Assert.HasCount(3, keys);
        Assert.Contains("apple", keys);
        Assert.Contains("banana", keys);
        Assert.Contains("grape", keys);
    }

    [TestMethod]
    public void GetKeys_AfterRemoval()
    {
        var ht = new HashTableLinearProbing<string, int>();

        ht.Add("XBX", 1);
        ht.Add("XCD", 2);
        ht.Add("EP", 3);
        ht.Add("ON", 4);
        ht.Add("PKA", 5);

        ht.Remove("XCD");
        ht.Remove("ON");

        var keys = ht.GetKeys();

        Assert.HasCount(3, keys);
        Assert.Contains("XBX", keys);
        Assert.Contains("EP", keys);
        Assert.Contains("PKA", keys);
        Assert.DoesNotContain("XCD", keys);
        Assert.DoesNotContain("ON", keys);
    }

    [TestMethod]
    public void GetKeys_NoDuplicatesAfterUpdate()
    {
        var ht = new HashTableLinearProbing<string, int>();

        ht.Add("XBX", 1);
        ht.Add("XCD", 2);
        ht.Add("EP", 3);
        ht.Add("XBX", 100);  // Update existing key
        ht.Add("XCD", 200);  // Update existing key

        var keys = ht.GetKeys();

        Assert.HasCount(3, keys);
        Assert.Contains("XBX", keys);
        Assert.Contains("XCD", keys);
        Assert.Contains("EP", keys);

        // Verify no duplicates in the list
        var distinctKeys = keys.Distinct().ToList();
        Assert.HasCount(keys.Count, distinctKeys);
    }

    [TestMethod]
    public void GetKeys_AfterResize()
    {
        var ht = new HashTableLinearProbing<string, int>();

        // Add enough elements to trigger resize
        for (int i = 0; i < 20; i++)
        {
            ht.Add($"key{i}", i);
        }

        var keys = ht.GetKeys();

        Assert.HasCount(20, keys);
        for (int i = 0; i < 20; i++)
        {
            Assert.Contains($"key{i}", keys, $"Expected key{i} to be in the keys list");
        }
    }

    [TestMethod]
    public void GetKeys_Int_String()
    {
        var ht = new HashTableLinearProbing<int, string>();

        ht.Add(1, "one");
        ht.Add(2, "two");
        ht.Add(3, "three");
        ht.Add(4, "four");

        var keys = ht.GetKeys();

        Assert.HasCount(4, keys);
        Assert.Contains(1, keys);
        Assert.Contains(2, keys);
        Assert.Contains(3, keys);
        Assert.Contains(4, keys);
    }

    [TestMethod]
    public void GetValues_EmptyHashTable()
    {
        var ht = new HashTableLinearProbing<string, int>();

        var values = ht.GetValues();

        Assert.IsNotNull(values);
        Assert.IsEmpty(values);
    }

    [TestMethod]
    public void GetValues_String_Int()
    {
        var ht = new HashTableLinearProbing<string, int>();

        ht.Add("XBX", 1);
        ht.Add("XCD", 2);
        ht.Add("EP", 3);
        ht.Add("ON", 4);
        ht.Add("PKA", 5);

        var values = ht.GetValues();

        Assert.HasCount(5, values);
        Assert.Contains(1, values);
        Assert.Contains(2, values);
        Assert.Contains(3, values);
        Assert.Contains(4, values);
        Assert.Contains(5, values);
        Assert.DoesNotContain(6, values);
    }

    [TestMethod]
    public void GetValues_String_String()
    {
        var ht = new HashTableLinearProbing<string, string>();

        ht.Add("apple", "red");
        ht.Add("banana", "yellow");
        ht.Add("grape", "purple");
        ht.Add("orange", "orange");

        var values = ht.GetValues();

        Assert.HasCount(4, values);
        Assert.Contains("red", values);
        Assert.Contains("yellow", values);
        Assert.Contains("purple", values);
        Assert.Contains("orange", values);
        Assert.DoesNotContain("green", values);
    }

    [TestMethod]
    public void GetValues_AfterRemoval()
    {
        var ht = new HashTableLinearProbing<string, int>();

        ht.Add("XBX", 10);
        ht.Add("XCD", 20);
        ht.Add("EP", 30);
        ht.Add("ON", 40);
        ht.Add("PKA", 50);

        ht.Remove("XCD");
        ht.Remove("ON");

        var values = ht.GetValues();

        Assert.HasCount(3, values);
        Assert.Contains(10, values);
        Assert.Contains(30, values);
        Assert.Contains(50, values);
        Assert.DoesNotContain(20, values);
        Assert.DoesNotContain(40, values);
    }

    [TestMethod]
    public void GetValues_AfterUpdate()
    {
        var ht = new HashTableLinearProbing<string, int>();

        ht.Add("XBX", 1);
        ht.Add("XCD", 2);
        ht.Add("EP", 3);
        ht.Add("XBX", 100);  // Update existing key
        ht.Add("XCD", 200);  // Update existing key

        var values = ht.GetValues();

        Assert.HasCount(3, values);
        Assert.Contains(100, values);  // Updated value
        Assert.Contains(200, values);  // Updated value
        Assert.Contains(3, values);
        Assert.DoesNotContain(1, values);  // Old value should not be present
        Assert.DoesNotContain(2, values);  // Old value should not be present
    }

    [TestMethod]
    public void GetValues_WithDuplicateValues()
    {
        var ht = new HashTableLinearProbing<string, int>();

        ht.Add("a", 10);
        ht.Add("b", 20);
        ht.Add("c", 10);  // Same value as "a"
        ht.Add("d", 30);
        ht.Add("e", 20);  // Same value as "b"

        var values = ht.GetValues();

        Assert.HasCount(5, values);
        // Should contain duplicate values since different keys can have same values
        var countOf10 = values.Count(v => v == 10);
        var countOf20 = values.Count(v => v == 20);
        Assert.AreEqual(2, countOf10);
        Assert.AreEqual(2, countOf20);
    }

    [TestMethod]
    public void GetValues_AfterResize()
    {
        var ht = new HashTableLinearProbing<string, int>();

        // Add enough elements to trigger resize
        for (int i = 0; i < 20; i++)
        {
            ht.Add($"key{i}", i * 10);
        }

        var values = ht.GetValues();

        Assert.HasCount(20, values);
        for (int i = 0; i < 20; i++)
        {
            Assert.Contains(i * 10, values, $"Expected value {i * 10} to be in the values list");
        }
    }

    [TestMethod]
    public void GetValues_Int_String()
    {
        var ht = new HashTableLinearProbing<int, string>();

        ht.Add(1, "one");
        ht.Add(2, "two");
        ht.Add(3, "three");
        ht.Add(4, "four");

        var values = ht.GetValues();

        Assert.HasCount(4, values);
        Assert.Contains("one", values);
        Assert.Contains("two", values);
        Assert.Contains("three", values);
        Assert.Contains("four", values);
    }

    // ------------------------------------------------------------------
    // Collisions
    // CollidingKey lets each test pick the hash code, so these keys are
    // guaranteed to collide whatever the table's capacity is.
    // ------------------------------------------------------------------

    [TestMethod]
    public void Collision_Add_Get_AllKeysFound()
    {
        var ht = new HashTableLinearProbing<CollidingKey, string>();

        for (int i = 1; i <= 5; i++)
        {
            Assert.IsFalse(ht.Add(new CollidingKey(i), $"v{i}"), $"Key {i} is new, so Add should return false");
        }

        Assert.AreEqual(5, ht.Count);
        for (int i = 1; i <= 5; i++)
        {
            Assert.AreEqual($"v{i}", ht.Get(new CollidingKey(i)));
        }
    }

    [TestMethod]
    public void Collision_Update_NoDuplicate()
    {
        var ht = new HashTableLinearProbing<CollidingKey, string>();

        ht.Add(new CollidingKey(1), "a");
        ht.Add(new CollidingKey(2), "b");
        ht.Add(new CollidingKey(3), "c");

        Assert.IsTrue(ht.Add(new CollidingKey(2), "new"), "Key 2 is already present, so Add should return true");
        Assert.AreEqual(3, ht.Count);
        Assert.AreEqual("new", ht.Get(new CollidingKey(2)));
        Assert.HasCount(3, ht.GetKeys());
    }

    [TestMethod]
    [DataRow(1, DisplayName = "Remove first key in cluster")]
    [DataRow(2, DisplayName = "Remove middle key in cluster")]
    [DataRow(3, DisplayName = "Remove last key in cluster")]
    public void Collision_Remove_OtherKeysStillFound(int removedId)
    {
        var ht = new HashTableLinearProbing<CollidingKey, string>();

        ht.Add(new CollidingKey(1), "v1");
        ht.Add(new CollidingKey(2), "v2");
        ht.Add(new CollidingKey(3), "v3");

        Assert.IsTrue(ht.Remove(new CollidingKey(removedId)));
        Assert.AreEqual(2, ht.Count);
        Assert.IsFalse(ht.ContainsKey(new CollidingKey(removedId)));
        Assert.ThrowsExactly<KeyNotFoundException>(() => ht.Get(new CollidingKey(removedId)));

        for (int i = 1; i <= 3; i++)
        {
            if (i == removedId) continue;
            Assert.IsTrue(ht.ContainsKey(new CollidingKey(i)), $"Key {i} should still be found after removing key {removedId}");
            Assert.AreEqual($"v{i}", ht.Get(new CollidingKey(i)));
        }
    }

    [TestMethod]
    public void Collision_UpdateAfterRemoval_NoDuplicate()
    {
        var ht = new HashTableLinearProbing<CollidingKey, string>();

        ht.Add(new CollidingKey(1), "a");
        ht.Add(new CollidingKey(2), "b");
        ht.Add(new CollidingKey(3), "c");
        ht.Remove(new CollidingKey(1));

        // key 3 must be found and updated, not inserted again into key 1's old slot
        Assert.IsTrue(ht.Add(new CollidingKey(3), "new"), "Key 3 is already present, so Add should return true");
        Assert.AreEqual(2, ht.Count);
        Assert.AreEqual("new", ht.Get(new CollidingKey(3)));
        Assert.HasCount(2, ht.GetKeys());
    }

    [TestMethod]
    public void Collision_RemoveThenReAdd()
    {
        var ht = new HashTableLinearProbing<CollidingKey, string>();

        ht.Add(new CollidingKey(1), "a");
        ht.Add(new CollidingKey(2), "b");
        ht.Remove(new CollidingKey(1));

        Assert.IsFalse(ht.Add(new CollidingKey(1), "again"), "Key 1 was removed, so Add should treat it as new");
        Assert.AreEqual(2, ht.Count);
        Assert.AreEqual("again", ht.Get(new CollidingKey(1)));
        Assert.AreEqual("b", ht.Get(new CollidingKey(2)));
    }

    [TestMethod]
    public void Collision_MissingKey()
    {
        var ht = new HashTableLinearProbing<CollidingKey, string>();

        ht.Add(new CollidingKey(1), "a");
        ht.Add(new CollidingKey(2), "b");
        ht.Add(new CollidingKey(3), "c");

        // key 4 has the same hash as the others but isn't in the table
        Assert.IsFalse(ht.ContainsKey(new CollidingKey(4)));
        Assert.IsFalse(ht.Remove(new CollidingKey(4)));
        Assert.AreEqual(3, ht.Count);
        Assert.ThrowsExactly<KeyNotFoundException>(() => ht.Get(new CollidingKey(4)));
    }

    [TestMethod]
    public void Collision_ContainsValue_AfterRemoval()
    {
        var ht = new HashTableLinearProbing<CollidingKey, string>();

        ht.Add(new CollidingKey(1), "x");
        ht.Add(new CollidingKey(2), "y");
        ht.Add(new CollidingKey(3), "z");
        ht.Remove(new CollidingKey(2));

        Assert.IsTrue(ht.ContainsValue("x"));
        Assert.IsFalse(ht.ContainsValue("y"));
        Assert.IsTrue(ht.ContainsValue("z"));
    }

    [TestMethod]
    public void Collision_EveryHomeSlot_IncludingWrapAround()
    {
        // Try every home slot from 0 to 63. Whatever the capacity, one of these
        // lands in the last index of the array, so a cluster starting there must
        // wrap around to index 0.
        for (int hash = 0; hash < 64; hash++)
        {
            var ht = new HashTableLinearProbing<CollidingKey, string>();

            ht.Add(new CollidingKey(1, hash), "a");
            ht.Add(new CollidingKey(2, hash), "b");
            ht.Add(new CollidingKey(3, hash), "c");
            ht.Remove(new CollidingKey(2, hash));

            Assert.AreEqual(2, ht.Count, $"hash {hash}");
            Assert.IsTrue(ht.ContainsKey(new CollidingKey(1, hash)), $"hash {hash}");
            Assert.IsFalse(ht.ContainsKey(new CollidingKey(2, hash)), $"hash {hash}");
            Assert.AreEqual("c", ht.Get(new CollidingKey(3, hash)), $"hash {hash}");
            Assert.IsTrue(ht.Add(new CollidingKey(3, hash), "new"), $"hash {hash}: key 3 should be updated, not re-added");
            Assert.AreEqual(2, ht.Count, $"hash {hash}");
        }
    }

    [TestMethod]
    public void Collision_ManyKeys_ThroughResize()
    {
        var ht = new HashTableLinearProbing<CollidingKey, int>();

        // enough keys to force several resizes, all in a single cluster/bucket
        for (int i = 0; i < 30; i++)
        {
            ht.Add(new CollidingKey(i), i * 10);
        }

        Assert.AreEqual(30, ht.Count);
        for (int i = 0; i < 30; i++)
        {
            Assert.AreEqual(i * 10, ht.Get(new CollidingKey(i)), $"key {i}");
        }

        for (int i = 0; i < 30; i += 2)
        {
            Assert.IsTrue(ht.Remove(new CollidingKey(i)), $"key {i}");
        }

        Assert.AreEqual(15, ht.Count);
        for (int i = 0; i < 30; i++)
        {
            Assert.AreEqual(i % 2 == 1, ht.ContainsKey(new CollidingKey(i)), $"key {i}");
        }
    }

    // ------------------------------------------------------------------
    // Default values
    // Empty and removed slots hold default(K) and default(V) (0 for int),
    // so an implementation that doesn't check State can find "ghost" keys
    // and values that were never added.
    // ------------------------------------------------------------------

    [TestMethod]
    public void ContainsKey_DefaultKey_EmptyTable()
    {
        var ht = new HashTableLinearProbing<int, int>();

        Assert.IsFalse(ht.ContainsKey(0), "Key 0 was never added");
    }

    [TestMethod]
    public void Get_DefaultKey_EmptyTable_Throws()
    {
        var ht = new HashTableLinearProbing<int, int>();

        Assert.ThrowsExactly<KeyNotFoundException>(() => ht.Get(0));
    }

    [TestMethod]
    public void Remove_DefaultKey_EmptyTable()
    {
        var ht = new HashTableLinearProbing<int, int>();

        Assert.IsFalse(ht.Remove(0), "Key 0 was never added");
        Assert.AreEqual(0, ht.Count);
    }

    [TestMethod]
    public void ContainsValue_DefaultValue_NotPresent()
    {
        var ht = new HashTableLinearProbing<int, int>();

        ht.Add(1, 10);
        ht.Add(2, 20);

        Assert.IsFalse(ht.ContainsValue(0), "No key has the value 0");
    }

    [TestMethod]
    public void DefaultKey_AfterRemoval()
    {
        var ht = new HashTableLinearProbing<int, int>();

        ht.Add(0, 5);
        ht.Add(1, 6);

        Assert.IsTrue(ht.ContainsKey(0));
        Assert.AreEqual(5, ht.Get(0));

        Assert.IsTrue(ht.Remove(0));
        Assert.IsFalse(ht.ContainsKey(0), "Key 0 was removed");
        Assert.IsFalse(ht.Remove(0), "Key 0 was already removed");
        Assert.AreEqual(1, ht.Count);

        var keys = ht.GetKeys();
        Assert.HasCount(1, keys);
        Assert.DoesNotContain(0, keys);
    }

    [TestMethod]
    public void DefaultValue_AfterRemoval()
    {
        var ht = new HashTableLinearProbing<int, int>();

        ht.Add(1, 0);   // a real value that happens to equal default(int)
        ht.Add(2, 7);

        Assert.IsTrue(ht.ContainsValue(0), "Key 1 has the value 0");

        ht.Remove(1);

        Assert.IsFalse(ht.ContainsValue(0), "The only key with value 0 was removed");
        var values = ht.GetValues();
        Assert.HasCount(1, values);
        Assert.Contains(7, values);
    }

    // ------------------------------------------------------------------
    // Missing keys
    // ------------------------------------------------------------------

    [TestMethod]
    public void Get_MissingKey_Throws()
    {
        var ht = new HashTableLinearProbing<string, int>();

        ht.Add("XBX", 1);
        ht.Add("XCD", 2);
        ht.Add("EP", 3);

        Assert.ThrowsExactly<KeyNotFoundException>(() => ht.Get("PM"));
    }

    [TestMethod]
    public void Get_EmptyTable_Throws()
    {
        var ht = new HashTableLinearProbing<string, int>();

        Assert.ThrowsExactly<KeyNotFoundException>(() => ht.Get("XBX"));
    }

    [TestMethod]
    public void Get_AfterRemoval_Throws()
    {
        var ht = new HashTableLinearProbing<string, int>();

        ht.Add("XBX", 1);
        ht.Add("XCD", 2);
        ht.Remove("XBX");

        Assert.ThrowsExactly<KeyNotFoundException>(() => ht.Get("XBX"));
        Assert.AreEqual(2, ht.Get("XCD"));
    }

    [TestMethod]
    public void ContainsKey_EmptyTable()
    {
        var ht = new HashTableLinearProbing<string, string>();

        Assert.IsFalse(ht.ContainsKey("XBX"));
    }

    [TestMethod]
    public void ContainsValue_EmptyTable()
    {
        var ht = new HashTableLinearProbing<string, string>();

        Assert.IsFalse(ht.ContainsValue("bible"));
    }

    // ------------------------------------------------------------------
    // LoadFactor
    // Capacity is private, so these tests work it out as Count / LoadFactor
    // and don't depend on the initial capacity.
    // ------------------------------------------------------------------

    private static int Capacity<K, V>(IHashTable<K, V> ht) => (int)Math.Round(ht.Count / ht.LoadFactor);

    [TestMethod]
    public void LoadFactor_EmptyTable()
    {
        var ht = new HashTableLinearProbing<string, int>();

        Assert.AreEqual(0.0, ht.LoadFactor);
    }

    [TestMethod]
    public void LoadFactor_TracksCount()
    {
        var ht = new HashTableLinearProbing<string, int>();

        ht.Add("a", 1);
        Assert.IsGreaterThan(0.0, ht.LoadFactor);
        int capacity = Capacity(ht);

        ht.Add("b", 2);
        Assert.AreEqual(2.0 / capacity, ht.LoadFactor, 1e-9, "LoadFactor should be Count / capacity");

        ht.Add("c", 3);
        Assert.AreEqual(3.0 / capacity, ht.LoadFactor, 1e-9);

        ht.Add("c", 30);   // update: Count doesn't change
        Assert.AreEqual(3.0 / capacity, ht.LoadFactor, 1e-9, "Updating a key shouldn't change LoadFactor");

        ht.Remove("a");
        Assert.AreEqual(2.0 / capacity, ht.LoadFactor, 1e-9, "LoadFactor should go down after Remove");

        ht.Remove("missing");
        Assert.AreEqual(2.0 / capacity, ht.LoadFactor, 1e-9, "Removing a missing key shouldn't change LoadFactor");
    }

    [TestMethod]
    public void LoadFactor_StaysBounded_AsTableGrows()
    {
        var ht = new HashTableLinearProbing<string, int>();

        ht.Add("key0", 0);
        int initialCapacity = Capacity(ht);

        for (int i = 1; i < 200; i++)
        {
            ht.Add($"key{i}", i);

            // Add checks the load factor before inserting, so the table can sit
            // one entry above MAX_LOAD_FACTOR until the next Add resizes it.
            int capacity = Capacity(ht);
            double loadWithoutNewest = (ht.Count - 1) / (double)capacity;
            Assert.IsLessThanOrEqualTo(ht.MAX_LOAD_FACTOR + 1e-9, loadWithoutNewest,
                $"After {ht.Count} keys, capacity {capacity}: the table should have resized");
        }

        Assert.IsGreaterThan(initialCapacity, Capacity(ht), "Capacity should have grown");
    }

    [TestMethod]
    public void LoadFactor_DropsAfterResize()
    {
        var ht = new HashTableLinearProbing<string, int>();

        ht.Add("key0", 0);
        int capacity = Capacity(ht);

        // add keys until the capacity changes
        int i = 1;
        double loadBefore;
        do
        {
            loadBefore = ht.LoadFactor;
            ht.Add($"key{i}", i);
            i++;
        } while (Capacity(ht) == capacity && i < 1000);

        Assert.IsGreaterThan(capacity, Capacity(ht), "The table should have resized");
        Assert.IsLessThan(loadBefore, ht.LoadFactor, "LoadFactor should drop after a resize");
    }
}
