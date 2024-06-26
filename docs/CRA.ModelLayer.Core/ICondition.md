# ICondition interface

Represents a condition that one or more VarInfo objects must satisfy. It is used to check the values of inputs/outputs/parameters of a strategy in the model layer context (see [`Preconditions`](./Preconditions.md) documentation for more info on the pre/post conditions tests)

```csharp
public interface ICondition
```

## Members

| name | description |
| --- | --- |
| [ApplicableVarInfoValueTypes](ICondition/ApplicableVarInfoValueTypes.md) { get; } | Returns the list of the VarInfoValueTypes for which the condition is applicable. |
| [ConditionName](ICondition/ConditionName.md) { get; } | The name used to identify the condition among the others. It is specified by the implementation of each condition, and cannot be changed by the consumers. |
| [ControlledVarInfos](ICondition/ControlledVarInfos.md) { get; } | Returns the list of the VarInfo objects "controlled" by the condition. 'Controlled' means that the VarInfos values are tested/used in the TestCondition method. |
| [IsApplicable](ICondition/IsApplicable.md)(…) | Returns true if the condition is applicable on the current VarInfo object(s), false otherwise. Usually the applicability is based on the VarInfoValueType of the VarInfo objects. |
| [TestCondition](ICondition/TestCondition.md)(…) | Tests the condition and return an error string. An empty string is returned if the condition is satisfied. |

## See Also

* namespace [CRA.ModelLayer.Core](../BioMA.ModelLayer.md)

<!-- DO NOT EDIT: generated by xmldocmd for BioMA.ModelLayer.dll -->
