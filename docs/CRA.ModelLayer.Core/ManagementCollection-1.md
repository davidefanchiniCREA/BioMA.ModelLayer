# ManagementCollection&lt;T&gt; class

Represents a collection of [`IManagementBase`](./IManagementBase.md) objects. This class is used to manage a certain set of managements alltogheter. The management objects must implement/extend type T. T is a valid implementation of [`IManagementBase`](./IManagementBase.md) interface. So, T represents a sub-type of IManagementBase, specific for the current configuration of the managements. For example, in case of the "AGROmanagement", T should be type interface "CRA.AgroManagement.IManagement" defined in library "CRA.AgroManagemet2014.dll".

```csharp
public class ManagementCollection<T>
    where T : IManagementBase
```

## Public Members

| name | description |
| --- | --- |
| [ManagementCollection](ManagementCollection-1/ManagementCollection.md)() | Builds an empty management collection |
| virtual [Management](ManagementCollection-1/Management.md) { get; set; } | This list contains the objects that represent the management published |
| [ProductionActivity](ManagementCollection-1/ProductionActivity.md) { get; set; } | Production activity |

## See Also

* interface [IManagementBase](./IManagementBase.md)
* namespace [CRA.ModelLayer.Core](../BioMA.ModelLayer.md)

<!-- DO NOT EDIT: generated by xmldocmd for BioMA.ModelLayer.dll -->
