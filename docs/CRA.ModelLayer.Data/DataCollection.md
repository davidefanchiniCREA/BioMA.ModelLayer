# DataCollection class

Lightweight version of the [`DataSet`](./DataCollection/DataSet.md).

```csharp
public class DataCollection
```

## Public Members

| name | description |
| --- | --- |
| [DataCollection](DataCollection/DataCollection.md)() | The default constructor. |
| [DataSet](DataCollection/DataSet.md) { get; } | Builds and returns a [`DataSet`](./DataCollection/DataSet.md) representation of this DataCollection. |
| [Tables](DataCollection/Tables.md) { get; } | Returns an enumeration of the [`Table`](./Table.md)s in this DataCollection. |
| [AddTable](DataCollection/AddTable.md)(…) |  (2 methods) |
| [GetTable](DataCollection/GetTable.md)(…) | Returns the [`Table`](./Table.md) in this DataCollection having the name passed as parameter. |

## Remarks

Like in the version of the Microsoft framework, it is possible to add Tables counterparts, but no verification of primary key nor relationships is performed (in fact none of these can be enforced in this lightweight version). This in order to keep overhead in using this class to a minimum. A [`DataSet`](./DataCollection/DataSet.md) version of a DataCollection can be built by invoking the property [`DataCollection.DataSet`](./DataCollection/DataSet.md), but again on the obtained object no primary key nor relationship constraint is enforced.

## See Also

* namespace [CRA.ModelLayer.Data](../BioMA.ModelLayer.md)

<!-- DO NOT EDIT: generated by xmldocmd for BioMA.ModelLayer.dll -->