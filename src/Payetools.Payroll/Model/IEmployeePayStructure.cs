﻿// Copyright (c) 2023-2025, Payetools Ltd.
//
// Payetools Ltd licenses this file to you under the following license(s):
//
//   * The MIT License, see https://opensource.org/license/mit/

using Payetools.Common.Model;

namespace Payetools.Payroll.Model;

/// <summary>
/// Interface that represents an employee's pay structure.
/// </summary>
public interface IEmployeePayStructure
{
    /// <summary>
    /// Gets the unique ID for this pay structure.
    /// </summary>
    Guid Id { get; }

    /// <summary>
    /// Gets the rate of pay.  The type of this rate of pay is given by <see cref="PayRateType"/>.
    /// </summary>
    decimal PayRate { get; }

    /// <summary>
    /// Gets the type of pay that <see cref="PayRate"/> represents.
    /// </summary>
    PayRateType PayRateType { get; }

    /// <summary>
    /// Gets the pay component that this pay structure is based on.
    /// </summary>
    IEarningsDetails PayComponent { get; }
}