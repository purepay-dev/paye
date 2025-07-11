﻿// Copyright (c) 2023-2025, Payetools Ltd.
//
// Payetools Ltd licenses this file to you under the following license(s):
//
//   * The MIT License, see https://opensource.org/license/mit/

namespace Payetools.Testing.Data.EndToEnd;

public interface IEndToEndTestDataSet
{
    List<IDeductionsTestDataEntry> DeductionDefinitions { get; }
    List<IEarningsTestDataEntry> EarningsDefinitions { get; }
    List<IExpectedOutputTestDataEntry> ExpectedOutputs { get; }
    List<IPeriodInputTestDataEntry> PeriodInputs { get; }
    List<IPreviousYtdTestDataEntry> PreviousYtdInputs { get; }
    List<IStaticInputTestDataEntry> StaticInputs { get; }
    List<INiYtdHistoryTestDataEntry> NiYtdHistory { get; }
    List<IPensionSchemesTestDataEntry> PensionSchemes { get; }
    List<IPayRunInfoTestDataEntry> PayRunInfo { get; }
}