# Table.AddColumn method

Adds a new column to this Table, having the name and type passed has parameters.

```csharp
public void AddColumn(string name, Type type)
```

| parameter | description |
| --- | --- |
| name | The name of the new column. |
| type | The type of the new column. |

## Exceptions

| exception | condition |
| --- | --- |
| [DataCollectionException](../DataCollectionException.md) | If this Table already contains a column with the name passed as parameter. |

## See Also

* class [Table](../Table.md)
* namespace [CRA.ModelLayer.Data](../../BioMA.ModelLayer.md)

<!-- DO NOT EDIT: generated by xmldocmd for BioMA.ModelLayer.dll -->
