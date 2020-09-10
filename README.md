# Stacker
Save the data to the binary

## Usage
Stacker can save multiple different types to the same file.
It uses binary, so its quite compact. Heres how you use it
to stack an `int` value:
```cs
    var byteStack = new ByteStack();
    byteStack.Add(new StackableInt(5));
    var bytes = byteStack.Stack(); // byte[]
    var unstacked = ByteStack.Unstack(bytes); // ByteStack
    if (unstacked.Stackables[0] is StackableInt stackableInt) {
        Console.WriteLine(stackableInt.Value);
    }
```
