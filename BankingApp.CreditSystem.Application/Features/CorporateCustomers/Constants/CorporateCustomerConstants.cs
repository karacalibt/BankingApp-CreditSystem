namespace BankingApp.CreditSystem.Application.Features.CorporateCustomers.Constants;

public static class CorporateCustomerConstants
{
    public static class ValidationMessages
    {
        public const string CompanyNameRequired = "Şirket adı zorunludur.";
        public const string CompanyNameMaxLength = "Şirket adı en fazla 300 karakter olabilir.";
        public const string TaxNumberRequired = "Vergi numarası zorunludur.";
        public const string TaxNumberInvalid = "Vergi numarası geçerli değil.";
        public const string TaxNumberLength = "Vergi numarası 10 haneli olmalıdır.";
        public const string TaxOfficeRequired = "Vergi dairesi zorunludur.";
        public const string TaxOfficeMaxLength = "Vergi dairesi en fazla 200 karakter olabilir.";
        public const string CompanyRegistrationNumberRequired = "Ticaret sicil numarası zorunludur.";
        public const string CompanyRegistrationNumberMaxLength = "Ticaret sicil numarası en fazla 20 karakter olabilir.";
        public const string AuthorizedPersonNameRequired = "Yetkili kişi adı zorunludur.";
        public const string AuthorizedPersonNameMaxLength = "Yetkili kişi adı en fazla 200 karakter olabilir.";
        public const string CompanyFoundationDateRequired = "Şirket kuruluş tarihi zorunludur.";
        public const string CompanyFoundationDateInvalid = "Şirket kuruluş tarihi geçerli değil.";
        public const string CompanyAgeMinimum = "Şirket en az 1 yaşında olmalıdır.";
        public const string CompanyAgeMaximum = "Şirket en fazla 200 yaşında olabilir.";
        public const string PhoneNumberRequired = "Telefon numarası zorunludur.";
        public const string PhoneNumberInvalid = "Telefon numarası geçerli değil.";
        public const string EmailRequired = "E-posta adresi zorunludur.";
        public const string EmailInvalid = "E-posta adresi geçerli değil.";
        public const string AddressRequired = "Adres alanı zorunludur.";
        public const string AddressMaxLength = "Adres en fazla 500 karakter olabilir.";
    }

    public static class BusinessMessages
    {
        public const string CustomerCreated = "Kurumsal müşteri başarıyla oluşturuldu.";
        public const string CustomerUpdated = "Kurumsal müşteri bilgileri başarıyla güncellendi.";
        public const string CustomerDeleted = "Kurumsal müşteri başarıyla silindi.";
        public const string CustomerNotFound = "Kurumsal müşteri bulunamadı.";
        public const string CustomerAlreadyExists = "Bu vergi numarası ile kayıtlı müşteri zaten mevcut.";
        public const string EmailAlreadyExists = "Bu e-posta adresi ile kayıtlı müşteri zaten mevcut.";
        public const string PhoneNumberAlreadyExists = "Bu telefon numarası ile kayıtlı müşteri zaten mevcut.";
        public const string RegistrationNumberAlreadyExists = "Bu ticaret sicil numarası ile kayıtlı müşteri zaten mevcut.";
    }

    public static class Rules
    {
        public const int MinimumCompanyAge = 1;
        public const int MaximumCompanyAge = 200;
        public const int TaxNumberLength = 10;
        public const int CompanyNameMaxLength = 300;
        public const int TaxOfficeMaxLength = 200;
        public const int CompanyRegistrationNumberMaxLength = 20;
        public const int AuthorizedPersonNameMaxLength = 200;
        public const int AddressMaxLength = 500;
        public const int PhoneNumberMaxLength = 20;
        public const int EmailMaxLength = 255;
    }
} 