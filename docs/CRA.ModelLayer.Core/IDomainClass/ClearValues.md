# IDomainClass.ClearValues method

Clears the values of the properties of the domain class. Returns true if the method succeeds. This method is useful for re-initialize all the properties of a domain class altogether. This operation should be implemented by using the [`CRA.ModelLayer.Core.IVarInfoConverter.GetConstructingString`](../IVarInfoConverter/GetConstructingString.md) method of the VarInfoValueType related to the type of the property (e.g. the string 'new double[3]' for a double array of size 3 or the string 'new DateTime()' for a Date). If the [`CRA.ModelLayer.Core.IVarInfoConverter.GetConstructingString`](../IVarInfoConverter/GetConstructingString.md) method returns null, the default value for the type of the property should be used (e.g '0' for numbers, 'the empty string' for strings, etc.)

```csharp
public bool ClearValues()
```

## See Also

* interface [IDomainClass](../IDomainClass.md)
* namespace [CRA.ModelLayer.Core](../../BioMA.ModelLayer.md)

<!-- DO NOT EDIT: generated by xmldocmd for BioMA.ModelLayer.dll -->