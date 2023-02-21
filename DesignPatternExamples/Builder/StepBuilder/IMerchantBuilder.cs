using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternExamples.Builder.StepBuilder
{
    public interface ILegalMerchantBuilder: IMerchantBuilder
    {
        ILegalMerchantBuilder WithCompanyRegistrationNumber(string companyRegistrationNumber);
        ILegalMerchantBuilder WithCompany(string companyRegistrationNumber);

    }
    public interface IIndividualMerchantBuilder: IMerchantBuilder
    {
        IIndividualMerchantBuilder WithName(string name);
        IIndividualMerchantBuilder WithNationalCode(string nationalCode);
    }
    public interface IMerchantTypeBuilder
    {
        ILegalMerchantBuilder Legal();
        IIndividualMerchantBuilder Individual();
    }
    public interface IMerchantBuilder
    {
        Merchant Build();

    }
}
