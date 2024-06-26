# IParameterEditor interface

Interface that a generic parameter editor must implement. The editor should be able to manage the [`IValuesReader`](./IValuesReader.md) and [`IValuesWriter`](./IValuesWriter.md) instances passed as parameters to read and write parameters from/to a persistence source (e.g. an XML file or a DB)

```csharp
public interface IParameterEditor
```

## Members

| name | description |
| --- | --- |
| [Launch](IParameterEditor/Launch.md)(…) | Launch the parameter editor |

## See Also

* namespace [CRA.ModelLayer.ParametersManagement](../BioMA.ModelLayer.md)

<!-- DO NOT EDIT: generated by xmldocmd for BioMA.ModelLayer.dll -->
