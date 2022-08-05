# `Span<T>` Discussion

## Types of Memory 🧠
---

### Managed Memory (new operator) 🧑‍💼
---
- Small objects < 85K (generational part of managed head).
- Large objects > 85K (Large Object Heap, LOH).
- Both released by GC.

### Unmanaged Memory 🔥
---
- Allocated on the unmanaged heap with Marshal.AllocHGlobal/CoTaskMem.
- Released with Marshal.FreeHGlobal/CoTaskMem.
- GC not involved (memory invisible to this process).

### Stack Memory 🧱
---
- Very fast allocation/deallocation.
- Very small (typically < 1MB), overallocate and you get stack overflow/process dies.
- Method-scoped: method ends, stack unwinds.
- Nobody uses it in reality.

## Problem that `Span<T>` Addresses 📝
---
- Imagine you want to refer to a part of a string.
  - ...without making a copy.
- You could refer to the start/end indices of use pointers.
- More generally, you could refer to:
  - Location where a memory range begins.
  - Location/index where you need to start taking the values.
  - How many values to take/index of the final element.
- We need a *general* way of referring to a range of values in memory (for reading, copying, etc.).
- That generalisation is expressed as `Span<T>`.

## Ref Struct Type (C# 7.2) 🏗️
---
***NOTE: Covers the lay of the land as per C#7.2, will flesh this out further for newer versions as covered (this relates to the warnings noted also).***

- A value type that *must* be stack-allocated.
- Can never be created on the heap as a member of another class.
- Main motivation to support `Span<T>`.
- Compiler-enforced rules:
  - Cannot box a ref struct (i.e. cannot assign to an object, dynamic or an interface type).
  - Cannot declare a ref struct as a member of a class or normal struct.
  - Cannot declare local ref struct variables in async methods or synchronous methods that return Task or Task-like types.
  - Cannot declare ref struct locals in iterators.
  - Cannot capture ref struct vars in lambda expressions or local functions.
- Rules prevent a ref struct from being promoted to the managed heap.
- ***WARNING: in .NET Framework, current `Span<T>` in `System.Memory` NuGet is *not* a ref struct, therefore all of these limitations have not yet kicked in.***

***NOTE: As per C# 7.2. Will flesh out notes as we progress further.***
