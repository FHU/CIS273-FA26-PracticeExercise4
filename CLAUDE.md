# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

A .NET 10 C# practice exercise for a data structures course (CIS 273). It implements a generic hash table interface two ways: linear probing and separate chaining. Parts of the implementation are intentionally left as `NotImplementedException` stubs for students to complete, with an MSTest suite to check their work.

## Build and Test Commands

```bash
dotnet build                                   # build the solution
dotnet test                                    # run all tests
dotnet test --filter "ClassName~HashTableLinearProbing"                               # one test class
dotnet test --filter "FullyQualifiedName~HashTableLinearProbingTests.Add_Get_String_Int"  # one test
dotnet run --project PracticeExercise4/PracticeExercise4.csproj                       # run Program.cs
```

## Architecture

- **[IHashTable.cs](PracticeExercise4/IHashTable.cs)**: the interface: `Add` (returns true if the key already existed and was updated), `Get` (throws `KeyNotFoundException` for a missing key), `Remove`, `ContainsKey`, `ContainsValue`, `GetKeys`, `GetValues`, `Count`, `LoadFactor`.
- **[HashEntry.cs](PracticeExercise4/HashEntry.cs)**: a key/value pair with a `State` of `EmptySinceStart`, `EmptyAfterRemoval`, or `Full`. `Clear()` marks the slot `EmptyAfterRemoval` (a tombstone).
- **[HashTableLinearProbing.cs](PracticeExercise4/HashTableLinearProbing.cs)**: a `HashEntry<K,V>[]` array. Collisions are resolved by probing forward one slot at a time, wrapping around.
- **[HashTableChaining.cs](PracticeExercise4/HashTableChaining.cs)**: a `List<HashEntry<K,V>>[]` array. Each bucket is a list of entries; `State` is not used.

### Shared design

- **Hash function**: `key.GetHashCode() & 0x7FFFFFFF`, then `% capacity`. (Not `Math.Abs`, which throws on `int.MinValue`.)
- **Load factor**: `Count / capacity`. Both classes start at capacity 16 and double capacity in `Add` when the load factor exceeds `MAX_LOAD_FACTOR` (0.6). Linear probing checks only when inserting a new key; chaining checks on every `Add`, including updates.
- **Resize**: allocate a 2x array, initialize every slot/bucket, reset `count`, and re-`Add` every live entry. Tombstones are dropped.

### Linear probing rules

- Searches (`Get`, `ContainsKey`, `Remove`, `Update`) continue past `Full` and `EmptyAfterRemoval` slots and stop at `EmptySinceStart`.
- Searches must also stop if they wrap back to the starting index. Otherwise a table with no `EmptySinceStart` slots left loops forever.
- `Add` first calls `Update` to search the full probe sequence for the key. Only if the key is absent does it insert at the first non-`Full` slot (reusing a tombstone if one comes first).

## Implementation Status

Implemented:
- Chaining: `Add`, `Get`, `GetKeys`, `LoadFactor`, `Resize`, `Hash`.
- Linear probing: `Add`, `Update`, `LoadFactor`, `Resize`, `Hash`.

Still stubs (student work): chaining `Remove`, `ContainsKey`, `ContainsValue`, `GetValues`; linear probing `Get`, `Remove`, `ContainsKey`, `ContainsValue`, `GetKeys`, `GetValues`.

Because this is a teaching exercise, don't fill in the stubs unless asked to.

## Testing

[HashTableLinearProbingTests.cs](UnitTests/HashTableLinearProbingTests.cs) and [HashTableChainingTests.cs](UnitTests/HashTableChainingTests.cs) hold the same 30 tests, differing only in the class under test. They cover add/get, updates and `Add`'s return value, removal and `Remove`'s return value, contains, `GetKeys`/`GetValues`, and resize (by count).

Known gaps:
- **Collisions aren't tested deterministically.** .NET randomizes `string.GetHashCode()` per process, so string-key tests may or may not collide. Use `int` keys (whose hash is the value itself) to force collisions, e.g. 1, 17, 33 all land in slot 1 at capacity 16.
- Not tested: `LoadFactor`, `Get` on a missing key, tombstone handling (remove a key in the middle of a cluster, then get/update a key past it), wrap-around probing, and `Get` for every key after a resize.

Keep the two test files in sync when adding tests.
