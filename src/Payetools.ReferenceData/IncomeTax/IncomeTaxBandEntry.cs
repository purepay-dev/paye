﻿// Copyright (c) 2023-2025, Payetools Ltd.
//
// Payetools Ltd licenses this file to you under the following license(s):
//
//   * The MIT License, see https://opensource.org/license/mit/

using Payetools.Common.Model;
using Payetools.IncomeTax.ReferenceData;
using System.Collections.Immutable;

namespace Payetools.ReferenceData.IncomeTax;

/// <summary>
/// Record that represents a set of tax bands for a given tax regime (as specified by the <see cref="ApplicableCountries"/> property).
/// </summary>
public class IncomeTaxBandEntry
{
    /// <summary>
    /// Gets the set of countries within the UK that this set of tax bands refer to.
    /// </summary>
    public CountriesForTaxPurposes ApplicableCountries { get; init; }

    /// <summary>
    /// Gets the set of personal allowances applicable to this tax regime.
    /// </summary>
    public ImmutableArray<PersonalAllowance> PersonalAllowances { get; init; } = ImmutableArray<PersonalAllowance>.Empty;

    /// <summary>
    /// Gets the set of tax bands applicable.
    /// </summary>
    public ImmutableArray<IncomeTaxDeductionBand> TaxBands { get; init; } = ImmutableArray<IncomeTaxDeductionBand>.Empty;

    /// <summary>
    /// Gets an array of <see cref="TaxBandwidthEntry"/>s that correspond to the elements of the <see cref="TaxBands"/> property.
    /// </summary>
    /// <returns>Tax bandwidth entries as an array of <see cref="TaxBandwidthEntry"/>s.</returns>
    public TaxBandwidthEntry[] GetTaxBandwidthEntries()
    {
        var taxBandwidthEntries = new TaxBandwidthEntry[TaxBands.Length];

        // NB Can't easily use LINQ due to the need to refer to the previous item (although see Jon Skeet's StackOverflow post:
        // https://stackoverflow.com/questions/3683105/calculate-difference-from-previous-item-with-linq/3683217#3683217)
        for (int i = 0; i < TaxBands.Length; i++)
        {
            taxBandwidthEntries[i] = new TaxBandwidthEntry(TaxBands[i].Description,
                TaxBands[i].Rate,
                TaxBands[i].To,
                TaxBands[i].IsTopRate,
                i > 0 ? taxBandwidthEntries[i - 1] : null);
        }

        return taxBandwidthEntries;
    }
}