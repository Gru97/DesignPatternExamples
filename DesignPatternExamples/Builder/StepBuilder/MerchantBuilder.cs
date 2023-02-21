namespace DesignPatternExamples.Builder.StepBuilder;

public class MerchantBuilder: ILegalMerchantBuilder, IIndividualMerchantBuilder, IMerchantTypeBuilder
{
    private string _name;
    private string _company;
    private string _companyRegistrationCode;
    private string _nationalCode;
    public static IMerchantTypeBuilder New() => new MerchantBuilder();
    public ILegalMerchantBuilder Legal()
    {
        return this;
    }
    private MerchantBuilder(){}
    public IIndividualMerchantBuilder Individual ()
    {
        return this;
    }

    public IIndividualMerchantBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IIndividualMerchantBuilder WithNationalCode(string nationalCode)
    {
        _nationalCode = nationalCode;
        return this;

    }
    public ILegalMerchantBuilder WithCompany(string company)
    {
        _company = company;
        return this;
    }
    public ILegalMerchantBuilder WithCompanyRegistrationNumber(string companyRegistrationNumber)
    {
        _companyRegistrationCode = companyRegistrationNumber;
        return this;
    }

    public Merchant Build()
    {
        return new Merchant()
        {
            Company = _company,
            CompanyRegisterationNumber = _companyRegistrationCode,
            Name = _name,
            NationalCode = _nationalCode
        };
    }
}