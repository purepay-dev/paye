﻿// Copyright (c) 2023-2025, Payetools Ltd.
//
// Payetools Ltd licenses this file to you under the following license(s):
//
//   * The MIT License, see https://opensource.org/license/mit/

using Payetools.Common.Model;
using Payetools.Payroll.Model;

namespace Payetools.Payroll.PayRuns;

/// <summary>
/// Interface that represent types that can process an employee's set of input payroll data and
/// provide the results of the calculations in the form of an <see cref="IEmployeePayRunResult"/>.
/// </summary>
public interface IPayRunEntryProcessor : IEmployeePayRunProcessor
{
    /// <summary>
    /// Gets the pay date for this payrun calculator.
    /// </summary>
    PayDate PayDate { get; }

    /// <summary>
    /// Gets the pay period for this payrun calculator.
    /// </summary>
    DateRange PayPeriod { get; }

    /// <summary>
    /// Processes the supplied payrun entry calculating all the earnings and deductions, income tax, national insurance and
    /// other statutory deductions, and generating a result structure which includes the final net pay.
    /// </summary>
    /// <param name="entry">Instance of <see cref="IEmployeePayRunInputEntry"/> containing all the necessary input data for the
    /// payroll calculation.</param>
    /// <param name="result">An instance of <see cref="IEmployeePayRunResult"/> containing the results of the payroll calculations.</param>
    [Obsolete("Use IEmployeePayRunProcessor.Process instead. Scheduled for removal in v3.0.0.", false)]
    void Process(in IEmployeePayRunInputEntry entry, out IEmployeePayRunResult result);
}