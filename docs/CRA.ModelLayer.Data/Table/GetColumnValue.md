# Table.GetColumnValue method

Returns the value, contained in the row passed as parameter, corresponding to the column with the name passed as parameter.

```csharp
public object GetColumnValue(object[] row, string columnName)
```

| parameter | description |
| --- | --- |
| row | The row whose values must be assessed. |
| columnName | The name of the field whose value must be assessed |

## Return Value

The value, contained in the row passed as parameter, corresponding to the column with the name passed as parameter

## Exceptions

| exception | condition |
| --- | --- |
| [DataCollectionException](../DataCollectionException.md) | If no column named as the 'columnName' passed as parameter is present in this Table. |

## See Also

* class [Table](../Table.md)
* namespace [CRA.ModelLayer.Data](../../BioMA.ModelLayer.md)

<!-- DO NOT EDIT: generated by xmldocmd for BioMA.ModelLayer.dll -->
