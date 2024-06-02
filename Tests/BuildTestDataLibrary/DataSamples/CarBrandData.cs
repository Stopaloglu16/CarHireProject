﻿using Application.Aggregates.CarBrandAggregate.Commands.Create;
using Domain.Entities;
using System.Collections;

namespace BuildTestDataLibrary.DataSamples;

public class CarBrandListGenerator
{
    public static IEnumerable<CarBrand> Creates =>
    new List<CarBrand>
    {
        new() {  Name = "Toyota" },
        new() {  Name = "BMW" },
        new() {  Name = "Vauxhall" }
    };
}


public class CarBrandGenerator : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        foreach (CarBrand data in CarBrandListGenerator.Creates)
            yield return new object[] { data };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

/// <summary>
/// Create list of CreateCarBrandRequest data from generator
/// </summary>
public class CarBrandRequestGenerator : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        foreach (CarBrand data in CarBrandListGenerator.Creates)
            yield return new object[] { new CreateCarBrandRequest() { BrandName = data.Name } };
    }
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
