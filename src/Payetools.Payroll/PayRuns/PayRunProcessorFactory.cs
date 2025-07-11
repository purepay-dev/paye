﻿// Copyright (c) 2023-2025, Payetools Ltd.
//
// Payetools Ltd licenses this file to you under the following license(s):
//
//   * The MIT License, see https://opensource.org/license/mit/

using Payetools.AttachmentOrders.Factories;
using Payetools.Common.Model;
using Payetools.IncomeTax;
using Payetools.NationalInsurance;
using Payetools.Payroll.Model;
using Payetools.Pensions;
using Payetools.ReferenceData;
using Payetools.StudentLoans;

namespace Payetools.Payroll.PayRuns;

/// <summary>
/// Represents a factory object that creates payrun calculator instances that implement <see cref="IPayRunEntryProcessor"/>.
/// </summary>
public class PayRunProcessorFactory : IPayRunProcessorFactory
{
    internal class FactorySet
    {
        public IHmrcReferenceDataProvider HmrcReferenceDataProvider { get; }

        public ITaxCalculatorFactory TaxCalculatorFactory { get; }

        public INiCalculatorFactory NiCalculatorFactory { get; }

        public IStudentLoanCalculatorFactory StudentLoanCalculatorFactory { get; }

        public IPensionContributionCalculatorFactory PensionContributionCalculatorFactory { get; }

        public IAttachmentOrdersCalculatorFactory AttachmentOfEarningsCalculatorFactory { get; }

        public FactorySet(
            in IHmrcReferenceDataProvider hmrcReferenceDataProvider,
            in ITaxCalculatorFactory taxCalculatorFactory,
            in INiCalculatorFactory niCalculatorFactory,
            in IStudentLoanCalculatorFactory studentLoanCalculatorFactory,
            in IPensionContributionCalculatorFactory pensionContributionCalculatorFactory,
            in IAttachmentOrdersCalculatorFactory attachmentOfEarningsCalculatorFactory)
        {
            HmrcReferenceDataProvider = hmrcReferenceDataProvider;
            TaxCalculatorFactory = taxCalculatorFactory;
            NiCalculatorFactory = niCalculatorFactory;
            StudentLoanCalculatorFactory = studentLoanCalculatorFactory;
            PensionContributionCalculatorFactory = pensionContributionCalculatorFactory;
            AttachmentOfEarningsCalculatorFactory = attachmentOfEarningsCalculatorFactory;
        }
    }

    private readonly IHmrcReferenceDataProviderFactory? _hmrcReferenceDataProviderFactory;
    private readonly IHmrcReferenceDataProvider? _hmrcReferenceDataProvider;
    private readonly Uri? _referenceDataEndpoint;

    /// <summary>
    /// Initialises a new instance of <see cref="PayRunProcessorFactory"/>.
    /// </summary>
    /// <param name="hmrcReferenceDataProvider">HMRC reference data provider.</param>
    public PayRunProcessorFactory(in IHmrcReferenceDataProvider hmrcReferenceDataProvider)
    {
        _hmrcReferenceDataProvider = hmrcReferenceDataProvider;
    }

    /// <summary>
    /// Initialises a new instance of <see cref="PayRunProcessorFactory"/>.
    /// </summary>
    /// <param name="hmrcReferenceDataProviderFactory">HMRC reference data provider factory.</param>
    /// <param name="referenceDataEndpoint">HTTP(S) endpoint to retrieve reference data from.</param>
    public PayRunProcessorFactory(
        in IHmrcReferenceDataProviderFactory hmrcReferenceDataProviderFactory,
        in Uri referenceDataEndpoint)
    {
        _hmrcReferenceDataProviderFactory = hmrcReferenceDataProviderFactory;
        _referenceDataEndpoint = referenceDataEndpoint;
    }

    /// <summary>
    /// Gets a payrun processor for specified pay date and pay period.
    /// </summary>
    /// <param name="payDate">Applicable pay date for the required payrun processor.</param>
    /// <param name="payPeriod">Applicable pay period for required payrun processor.</param>
    /// <returns>An implementation of <see cref="IPayRunProcessor"/> for the specified pay date
    /// and pay period.</returns>
    public IPayRunProcessor GetProcessor(in PayDate payDate, in DateRange payPeriod)
    {
        var factories = GetFactories(_hmrcReferenceDataProvider ??
                throw new InvalidOperationException("An valid HMRC reference data provider must be provided"));

        var calculator = new PayRunEntryProcessor(
            factories.TaxCalculatorFactory,
            factories.NiCalculatorFactory,
            factories.PensionContributionCalculatorFactory,
            factories.StudentLoanCalculatorFactory,
            factories.AttachmentOfEarningsCalculatorFactory,
            payDate,
            payPeriod);

        return new PayRunProcessor(calculator);
    }

    /// <summary>
    /// Gets a payrun processor for specified pay run details.
    /// </summary>
    /// <param name="payRunDetails">Pay run detaiils that provide applicable pay date and
    /// pay period for the required payrun processor.</param>
    /// <returns>An implementation of <see cref="IPayRunProcessor"/> for the specified pay date
    /// and pay period.</returns>
    public IPayRunProcessor GetProcessor(in IPayRunDetails payRunDetails) =>
        GetProcessor(payRunDetails.PayDate, payRunDetails.PayPeriod);

    // Implementation note: Currently no effort is made to cache any of the factory types or the reference data
    // provider, on the basis that payruns are not created frequently.  However, in a large scale SaaS implementation,
    // we probably need to do something more sophisticated.  One advantage of the current approach is that reference
    // data is refreshed every time a payrun calculator is created; a mechanism to declare the data stale and
    // refresh it is probably needed in the long run.
    private static FactorySet GetFactories(in IHmrcReferenceDataProvider referenceDataProvider) =>
        new FactorySet(
            referenceDataProvider,
            new TaxCalculatorFactory(referenceDataProvider),
            new NiCalculatorFactory(referenceDataProvider),
            new StudentLoanCalculatorFactory(referenceDataProvider),
            new PensionContributionCalculatorFactory(referenceDataProvider),
            new AttachmentOrdersCalculatorFactory(referenceDataProvider));
}