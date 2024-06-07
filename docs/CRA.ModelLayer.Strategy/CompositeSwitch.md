# CompositeSwitch class

[` CRA.ModelLayer.Strategy.Switch`](./Switch.md) extension to manage manage the Value of the Switch of a composite strategy accordingly to the Value of the Switch of the simple class behind

```csharp
public class CompositeSwitch : Switch
```

## Public Members

| name | description |
| --- | --- |
| [CompositeSwitch](CompositeSwitch/CompositeSwitch.md)(…) | Creates a CompositeSwitch from the instance of the associated strategy, the associated strategy's switch name and the associated strategy's switch description |
| override [SwitchValue](CompositeSwitch/SwitchValue.md) { get; set; } | Get/set the current value for the switch on the basis of the value of the switch of the child strategy |

## See Also

* class [Switch](./Switch.md)
* namespace [CRA.ModelLayer.Strategy](../BioMA.ModelLayer.md)

<!-- DO NOT EDIT: generated by xmldocmd for BioMA.ModelLayer.dll -->