# Preconditions.VerifyPreconditions method

Tests a collection of pre-conditions and returns errors

```csharp
public string VerifyPreconditions(ConditionsCollection condCollection, string callID)
```

| parameter | description |
| --- | --- |
| condCollection | Object containing a collection of conditions to test (see [`ConditionsCollection`](../ConditionsCollection.md) documentation) |
| callID | An identifier of the test, to be inserted in the logged error, to trace the context in which the condition test was called (for example, to trace the name of model component that triggered the test) |

## Return Value

A string containing the pre-condition tests errors. Returns an empty string if the pre-conditions are all satisfied.

## See Also

* class [ConditionsCollection](../ConditionsCollection.md)
* class [Preconditions](../Preconditions.md)
* namespace [CRA.ModelLayer.Core](../../BioMA.ModelLayer.md)

<!-- DO NOT EDIT: generated by xmldocmd for BioMA.ModelLayer.dll -->
