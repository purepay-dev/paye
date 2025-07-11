﻿// Copyright (c) 2023-2025, Payetools Ltd.
//
// Payetools Ltd licenses this file to you under the following license(s):
//
//   * The MIT License, see https://opensource.org/license/mit/

using Payetools.Common.Model;
using Payetools.NationalInsurance.ReferenceData;

namespace Payetools.ReferenceData.NationalInsurance;

/// <summary>
/// Represents a set of National Insurance rates across all NI categories.  Each NI
/// category specifies its own set rate of rates across the various NI thresholds.
/// </summary>
public class NiCategoryRateSet
{
    private readonly Dictionary<NiCategory, INiCategoryRatesEntry> _categories;

    /// <summary>
    /// Initialises a new instance of <see cref="NiCategoryRateSet"/>.
    /// </summary>
    public NiCategoryRateSet()
    {
        _categories = new Dictionary<NiCategory, INiCategoryRatesEntry>();
    }

    /// <summary>
    /// Gets the set of NI rates applicable to the specified <see cref="NiCategory"/>.
    /// </summary>
    /// <param name="category">NI category to retrieve the applicable rates for.</param>
    /// <returns>Set of rates applicable to the specified NI category.</returns>
    public INiCategoryRatesEntry GetRatesForCategory(NiCategory category)
    {
        return _categories[category];
    }

    internal void Add(NiCategory category, NiCategoryRatesEntry rates)
    {
        _categories.TryAdd(category, rates);
    }
}