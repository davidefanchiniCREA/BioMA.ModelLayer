# VarInfoValueTypes.ConcatenateKeyAndValue method

Returns a string representation of dictionary-like entries, in the form of "value" + "$" + "key".

```csharp
public static string ConcatenateKeyAndValue(string key, string value)
```

| parameter | description |
| --- | --- |
| key | The "key" part of the entry representation |
| value | The "value" part of the entry representation. If null, the empty string is used. |

## Return Value

The concatenation of "value" + "$" + "key".

## Exceptions

| exception | condition |
| --- | --- |
| ArgumentNullException | If the parameter 'key' is `null`. |

## See Also

* class [VarInfoValueTypes](../VarInfoValueTypes.md)
* namespace [CRA.ModelLayer.Core](../../BioMA.ModelLayer.md)

<!-- DO NOT EDIT: generated by xmldocmd for BioMA.ModelLayer.dll -->
