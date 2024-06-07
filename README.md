# BioMA.ModelLayer

This package provides the foundational interfaces and classes for the development of modelling components in the [BioMA framework](https://en.wikipedia.org/wiki/BioMA).

## Usage

Simply refer to this NuGet package in projects.

## License

This package is licensed under the [MIT License](https://licenses.nuget.org/MIT).

## Codedoc

Available [here](https://github.com/davidefanchiniCREA/BioMA.ModelLayer/blob/main/docs/BioMA.ModelLayer.md).

The package is composed of various namespaces addressing different aspects of modelling in BioMA:

## Core Preconditions

Deals with developing components based on the [Design by Contract](https://en.wikipedia.org/wiki/Design_by_contract) paradigm, allowing to implement and test Preconditions and Postconditions in the domain of biophysical modelling.

## [Domain class interface](BioMA.ModelLayer\Core\IDomainClass.cs)

Allows implementation of classes describing the modelling domain, collecting all variables pertaining to a particular phenomenon.

Each variable is described by an associated [VarInfo](BioMA.ModelLayer\Core\IVarInfoClass.cs).

## Data

The [DataCollection](BioMA.ModelLayer\Data\DataCollection.cs) class is composed of various [Table](BioMA.ModelLayer\Data\Table.cs), allowing to represent a very general form of model output.

## ParametersManagement

This namespace contains classes and interfaces to manage parameters in a model.

## Strategy

This namespace contains classes and interfaces to manage strategies in a model.

