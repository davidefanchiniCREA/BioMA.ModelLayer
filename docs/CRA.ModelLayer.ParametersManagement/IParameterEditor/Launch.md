# IParameterEditor.Launch method

Launch the parameter editor

```csharp
public object Launch(object objArg, IValuesReader reader, IValuesWriter writer, 
    string parametersKey)
```

| parameter | description |
| --- | --- |
| objArg | A generic object argument |
| reader | An instance of [`IValuesReader`](../IValuesReader.md) to use in the parameter editor |
| writer | An instance of [`IValuesWriter`](../IValuesWriter.md) to use in the parameter editor |
| parametersKey | The current value of the parameter key to be viewed/modified in the parameter editor |

## Return Value

The parameter editor output

## See Also

* class [IValuesReader](../IValuesReader.md)
* interface [IValuesWriter](../IValuesWriter.md)
* interface [IParameterEditor](../IParameterEditor.md)
* namespace [CRA.ModelLayer.ParametersManagement](../../BioMA.ModelLayer.md)

<!-- DO NOT EDIT: generated by xmldocmd for BioMA.ModelLayer.dll -->