# CompositeStrategyVarInfo constructor (1 of 2)

Creates the CompositeStrategyVarInfo from the associated strategy and the associated strategy's VarInfo name

```csharp
public CompositeStrategyVarInfo(IStrategy childStrategy, string varInfoName)
```

| parameter | description |
| --- | --- |
| childStrategy |  |
| varInfoName |  |

## See Also

* interface [IStrategy](../IStrategy.md)
* class [CompositeStrategyVarInfo](../CompositeStrategyVarInfo.md)
* namespace [CRA.ModelLayer.Strategy](../../BioMA.ModelLayer.md)

---

# CompositeStrategyVarInfo constructor (2 of 2)

Creates the CompositeStrategyVarInfo from the associated strategy and the associated strategy's VarInfo. The name of the associated strategy's VarInfo can be different from the name of the VarInfo in the strategy

```csharp
public CompositeStrategyVarInfo(IStrategy childStrategy, string varInfoNameInTheCompositeStrategy, 
    string varInfoNameinTheAssociatedStrategy)
```

| parameter | description |
| --- | --- |
| childStrategy |  |
| varInfoNameInTheCompositeStrategy | VarInfo name in the composite (parent) strategy |
| varInfoNameinTheAssociatedStrategy | VarInfo name in the associated (child) strategy |

## See Also

* interface [IStrategy](../IStrategy.md)
* class [CompositeStrategyVarInfo](../CompositeStrategyVarInfo.md)
* namespace [CRA.ModelLayer.Strategy](../../BioMA.ModelLayer.md)

<!-- DO NOT EDIT: generated by xmldocmd for BioMA.ModelLayer.dll -->