﻿// Copyright (c) 2023-2025, Payetools Ltd.
//
// Payetools Ltd licenses this file to you under the following license(s):
//
//   * The MIT License, see https://opensource.org/license/mit/

using Payetools.AttachmentOrders.ReferenceData;
using Payetools.IncomeTax.ReferenceData;
using Payetools.NationalInsurance.ReferenceData;
using Payetools.NationalMinimumWage.ReferenceData;
using Payetools.Pensions.ReferenceData;
using Payetools.ReferenceData.Employer;
using Payetools.StudentLoans.ReferenceData;

namespace Payetools.ReferenceData;

/// <summary>
/// Interface that HMRC reference data providers must implement.
/// </summary>
public interface IHmrcReferenceDataProvider :
    ITaxReferenceDataProvider,
    INiReferenceDataProvider,
    IPensionsReferenceDataProvider,
    INmwReferenceDataProvider,
    IStudentLoanReferenceDataProvider,
    IEmployerReferenceDataProvider,
    IAttachmentOrdersReferenceDataProvider
{
    /// <summary>
    /// Gets the human-readable 'health' of this reference data provider.
    /// </summary>
    string Health { get; }
}