﻿// Copyright (c) 2023-2025, Payetools Ltd.
//
// Payetools Ltd licenses this file to you under the following license(s):
//
//   * The MIT License, see https://opensource.org/license/mit/

using System;
using Xunit.Abstractions;

namespace Payetools.Testing.Data.EndToEnd;

public static class EndToEndTestDataSource
{
    public static IEndToEndTestDataSet GetAllData(ITestOutputHelper output)
    {
        using var db = new TestDataRepository("End-to-end", output);

        return new EndToEndTestDataSet()
        {
            DeductionDefinitions = db.GetTestData<IDeductionsTestDataEntry>(TestSource.Paytools, TestScope.EndToEnd).ToList(),
            EarningsDefinitions = db.GetTestData<IEarningsTestDataEntry>(TestSource.Paytools, TestScope.EndToEnd).ToList(),
            ExpectedOutputs = db.GetTestData<IExpectedOutputTestDataEntry>(TestSource.Paytools, TestScope.EndToEnd).ToList(),
            PeriodInputs = db.GetTestData<IPeriodInputTestDataEntry>(TestSource.Paytools, TestScope.EndToEnd).ToList(),
            PreviousYtdInputs = db.GetTestData<IPreviousYtdTestDataEntry>(TestSource.Paytools, TestScope.EndToEnd).ToList(),
            StaticInputs = db.GetTestData<IStaticInputTestDataEntry>(TestSource.Paytools, TestScope.EndToEnd).ToList(),
            NiYtdHistory = db.GetTestData<INiYtdHistoryTestDataEntry>(TestSource.Paytools, TestScope.EndToEnd).ToList(),
            PensionSchemes = db.GetTestData<IPensionSchemesTestDataEntry>(TestSource.Paytools, TestScope.EndToEnd).ToList(),
            PayRunInfo = db.GetTestData<IPayRunInfoTestDataEntry>(TestSource.Paytools, TestScope.EndToEnd).ToList()
        };
    }
}
