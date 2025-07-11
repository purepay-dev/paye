﻿// Copyright (c) 2023-2025, Payetools Ltd.
//
// Payetools Ltd licenses this file to you under the following license(s):
//
//   * The MIT License, see https://opensource.org/license/mit/

using Shouldly;
using Payetools.Common.Model;

namespace Payetools.Common.Tests;

public static class TaxCodeTestHelper
{
    private static readonly TaxYear _testTaxYear = new(TaxYearEnding.Apr5_2022);

    public static void RunFixedCodeTest(string input, TaxTreatment expectedTreatment)
    {
        var result = TaxCode.TryParse(input.ToLower(), _testTaxYear, out var taxCode);

        result.ShouldBeTrue($"Tax code: {input}");
        result.ShouldNotHaveDefaultValue($"Tax code: {input}");
        taxCode.TaxTreatment.ShouldBe(expectedTreatment, $"Tax code: {input}");

        result = TaxCode.TryParse(input.ToUpper(), out taxCode);

        result.ShouldBeTrue($"Tax code: {input}");
        result.ShouldNotHaveDefaultValue($"Tax code: {input}");
        taxCode.TaxTreatment.ShouldBe(expectedTreatment, $"Tax code: {input}");
    }

    public static void RunInvalidCodeTest(string input)
    {
        var result = TaxCode.TryParse(input.ToLower(), _testTaxYear, out var taxCode);

        result.ShouldBeFalse($"Tax code: {input}");
        result.ShouldHaveDefaultValue($"Tax code: {input}");

        result = TaxCode.TryParse(input.ToUpper(), out taxCode);

        result.ShouldBeFalse($"Tax code: {input}");
        result.ShouldHaveDefaultValue($"Tax code: {input}");
    }

    public static void RunValidNonCumulativeCodeTest(string input, TaxTreatment expectedTreatment)
    {
        var result = TaxCode.TryParse(input.ToLower(), _testTaxYear, out var taxCode);

        result.ShouldBeTrue($"Tax code: {input}");
        result.ShouldNotHaveDefaultValue($"Tax code: {input}");
        taxCode.IsNonCumulative.ShouldBeTrue($"Tax code: {input}");

        result = TaxCode.TryParse(input.ToUpper(), out taxCode);

        result.ShouldBeTrue($"Tax code: {input}");
        result.ShouldNotHaveDefaultValue($"Tax code: {input}");
        taxCode.IsNonCumulative.ShouldBeTrue($"Tax code: {input}");
        taxCode.TaxTreatment.ShouldBe(expectedTreatment);
    }

    public static void RunFixedCodeCountrySpecificTest(string input,
        TaxYear taxYear,
        TaxTreatment expectedTreatment,
        CountriesForTaxPurposes expectedCountries)
    {
        var result = TaxCode.TryParse(input.ToLower(), taxYear, out var taxCode);

        result.ShouldBeTrue($"Tax code: {input}");
        result.ShouldNotHaveDefaultValue($"Tax code: {input}");
        taxCode.TaxTreatment.ShouldBe(expectedTreatment, $"Tax code: {input}");
        taxCode.ApplicableCountries.ShouldBe(expectedCountries);

        result = TaxCode.TryParse(input.ToUpper(), taxYear, out taxCode);

        result.ShouldBeTrue($"Tax code: {input}");
        result.ShouldNotHaveDefaultValue($"Tax code: {input}");
        taxCode.TaxTreatment.ShouldBe(expectedTreatment, $"Tax code: {input}");
        taxCode.ApplicableCountries.ShouldBe(expectedCountries, $"Tax code: {input}");
    }

    public static void RunStandardCodeTest(string input,
        TaxYear taxYear,
        TaxTreatment expectedTreatment,
        int expectedAllowance,
        CountriesForTaxPurposes expectedCountries)
    {
        var result = TaxCode.TryParse(input.ToLower(), taxYear, out var taxCode);

        result.ShouldBeTrue($"Tax code: {input}");
        result.ShouldNotHaveDefaultValue($"Tax code: {input}");
        taxCode.TaxTreatment.ShouldBe(expectedTreatment, $"Tax code: {input}");
        taxCode.ApplicableCountries.ShouldBe(expectedCountries, $"Tax code: {input}");
        taxCode.NotionalAllowance.ShouldBe(expectedAllowance, $"Tax code: {input}");

        result = TaxCode.TryParse(input.ToUpper(), taxYear, out taxCode);

        result.ShouldBeTrue($"Tax code: {input}");
        result.ShouldNotHaveDefaultValue($"Tax code: {input}");
        taxCode.TaxTreatment.ShouldBe(expectedTreatment, $"Tax code: {input}");
        taxCode.ApplicableCountries.ShouldBe(expectedCountries, $"Tax code: {input}");
        taxCode.NotionalAllowance.ShouldBe(expectedAllowance, $"Tax code: {input}");
    }

    public static void RunToStringTest(string input, string expectedOutput, bool expectedIsNonCumulative)
    {
        TaxCode.TryParse(input.ToLower(), _testTaxYear, out var taxCode).ShouldBeTrue();
        taxCode.ToString().ShouldBe(expectedOutput, $"Tax code: {input}");
        taxCode.IsNonCumulative.ShouldBe(expectedIsNonCumulative, $"Tax code: {input}");

        TaxCode.TryParse(input.ToUpper(), _testTaxYear, out taxCode).ShouldBeTrue();
        taxCode.ToString().ShouldBe(expectedOutput, $"Tax code: {input}");
        taxCode.IsNonCumulative.ShouldBe(expectedIsNonCumulative, $"Tax code: {input}");
    }

    public static void RunToFullStringTest(string input, string expectedOutput, bool expectedIsNonCumulative)
    {
        TaxCode.TryParse(input.ToLower(), _testTaxYear, out var taxCode).ShouldBeTrue($"Tax code: {input}");
        taxCode.ToString(true, true).ShouldBe(expectedOutput, $"Tax code: {input}");
        taxCode.IsNonCumulative.ShouldBe(expectedIsNonCumulative, $"Tax code: {input}");

        TaxCode.TryParse(input.ToUpper(), _testTaxYear, out taxCode).ShouldBeTrue($"Tax code: {input}");
        taxCode.ToString(true, true).ShouldBe(expectedOutput, $"Tax code: {input}");
        taxCode.IsNonCumulative.ShouldBe(expectedIsNonCumulative, $"Tax code: {input}");
    }
}