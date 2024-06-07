# IParameters interface

Represents a parameter's class. A parameter class is a well-defined set of parameters plus the methods to read/write the parameters from/to a form of persitence (e.g. an XMl file or a DB). A parameter is a [`VarInfo`](../CRA.ModelLayer.Core/VarInfo.md) object. The parameters belonging to the class can assume different values. Each set of values is called parameters set. The parameters set is identified by a specific value of the ParametersKey The code of a class realizing IParameters is typically generated via the code generator DCC (Domain Class Coder). The file name is automatically assigned by DCC according to the following convention: FullClassName_parameters.xml

```csharp
public interface IParameters : IDomainClass
```

## Members

| name | description |
| --- | --- |
| [Reader](IParameters/Reader.md) { get; set; } | The reader to read the values of the parameters from a form of persistence |
| [Strategy](IParameters/Strategy.md) { get; set; } |  |
| [Writer](IParameters/Writer.md) { get; set; } | The writer to write the values of the parameters to a form of persistence |
| event [ParameterClassPropertyValueSet](IParameters/ParameterClassPropertyValueSet.md) | Event triggered when the property of this parameters class is set |
| [SaveParameters](IParameters/SaveParameters.md)(…) | Saves the parameters set identified by the specified parameters key to the form of persistence |
| [SetParameters](IParameters/SetParameters.md)(…) | Sets to the parameters properties the values taken from the specified list of [`VarInfo`](../CRA.ModelLayer.Core/VarInfo.md) objects |

## See Also

* interface [IDomainClass](../CRA.ModelLayer.Core/IDomainClass.md)
* namespace [CRA.ModelLayer.ParametersManagement](../BioMA.ModelLayer.md)

<!-- DO NOT EDIT: generated by xmldocmd for BioMA.ModelLayer.dll -->