﻿// Copyright (c) 2023-2025, Payetools Ltd.
//
// Payetools Ltd licenses this file to you under the following license(s):
//
//   * The MIT License, see https://opensource.org/license/mit/

#pragma warning disable SA1649 // File name should match first type name

namespace Payetools.Common.Model;

/// <summary>
/// Enum representing a given tax year based on the last day of the tax year (i.e., 5 April 20xx).
/// </summary>
/// <remarks>This enumeration is updated each tax year to provide access to the forthcoming tax year.</remarks>
public enum TaxYearEnding
{
    /// <summary>No tax year specified.</summary>
    Unspecified,

    /// <summary>2018-2019.</summary>
    Apr5_2019 = 2019,

    /// <summary>2019-2020.</summary>
    Apr5_2020 = 2020,

    /// <summary>2020-2021.</summary>
    Apr5_2021 = 2021,

    /// <summary>2021-2022.</summary>
    Apr5_2022 = 2022,

    /// <summary>2022-2023.</summary>
    Apr5_2023 = 2023,

    /// <summary>2023-2024.</summary>
    Apr5_2024 = 2024,

    /// <summary>2024-2025.</summary>
    Apr5_2025 = 2025,

    /// <summary>2024-2025.</summary>
    Apr5_2026 = 2026,

    /// <summary>Minimum value supported for TaxYearEnding.</summary>
    MinValue = 2019,

    /// <summary>Maximum value supported for TaxYearEnding.</summary>
    MaxValue = 2026
}

/// <summary>
/// Extension methods for TaxYearEnding enum.
/// </summary>
public static class TaxYearEndingExtensions
{
    /// <summary>
    /// Converts a TaxYearEnding enumerated value into a string.
    /// </summary>
    /// <param name="value">An instance of TaxYearEnding.</param>
    /// <returns>Year as string, e.g., "2020", indicating the year that the tax year ends in.</returns>
    public static string YearAsString(/* in */ this TaxYearEnding value) =>
        $"{(int)value:0000}";
}