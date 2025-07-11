﻿// Copyright (c) 2023-2025, Payetools Ltd.
//
// Payetools Ltd licenses this file to you under the following license(s):
//
//   * The MIT License, see https://opensource.org/license/mit/

using Payetools.AttachmentOrders.Model;
using Payetools.Common.Model;

namespace Payetools.AttachmentOrders.Tests;

internal class AttachmentOrder : IAttachmentOrder
{
    public AttachmentOrderCalculationTraits CalculationBehaviours { get; init; }

    public DateOnly? IssueDate { get; init; }

    public DateOnly ReceivedDate { get; init; }

    public DateOnly EffectiveDate { get; init; }

    public AttachmentOrderRateType? RateType { get; init;  }

    public AttachmentOrderPayFrequency EmployeePayFrequency { get; init; }

    public CountriesForTaxPurposes ApplicableJurisdiction { get; init; }

}
