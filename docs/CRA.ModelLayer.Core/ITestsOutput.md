# ITestsOutput interface

ITestsOutput is the interface that represents a listener to the output of pre and post conditions test results. A valid implementation of this interface can be used by setting it in the [`Preconditions`](./Preconditions.md) using the StrategyTestsOutput property of Preconditions class.

```csharp
public interface ITestsOutput
```

## Members

| name | description |
| --- | --- |
| [TestsOut](ITestsOutput/TestsOut.md)(…) | Writes/saves the output of pre and post condition test. |

## See Also

* namespace [CRA.ModelLayer.Core](../BioMA.ModelLayer.md)

<!-- DO NOT EDIT: generated by xmldocmd for BioMA.ModelLayer.dll -->
