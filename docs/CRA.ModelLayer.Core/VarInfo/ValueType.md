# VarInfo.ValueType property

Gets/sets the variable value type (from typesafe enumeration [`VarInfoValueTypes`](../VarInfoValueTypes.md)). The set can happen only once: once the ValueType is set, it cannot be changed. In case of a second set, an Exception is thrown.

```csharp
public VarInfoValueTypes ValueType { get; set; }
```

## See Also

* class [VarInfoValueTypes](../VarInfoValueTypes.md)
* class [VarInfo](../VarInfo.md)
* namespace [CRA.ModelLayer.Core](../../BioMA.ModelLayer.md)

<!-- DO NOT EDIT: generated by xmldocmd for BioMA.ModelLayer.dll -->