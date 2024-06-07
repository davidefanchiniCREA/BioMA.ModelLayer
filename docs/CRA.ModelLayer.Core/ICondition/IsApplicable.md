# ICondition.IsApplicable method

Returns true if the condition is applicable on the current VarInfo object(s), false otherwise. Usually the applicability is based on the VarInfoValueType of the VarInfo objects.

```csharp
public bool IsApplicable(out string nonApplicabilityError)
```

| parameter | description |
| --- | --- |
| nonApplicabilityError | The 'nonApplicabilityError' output argument contains the non applicability errors: the reason for the non applicability. If the condition is applicable, this string is null. |

## Return Value

true if the condition is applicable on the current VarInfo object(s), false otherwise

## See Also

* interface [ICondition](../ICondition.md)
* namespace [CRA.ModelLayer.Core](../../BioMA.ModelLayer.md)

<!-- DO NOT EDIT: generated by xmldocmd for BioMA.ModelLayer.dll -->