namespace BankingApp.CreditSystem.Application.Features.IndividualCustomers.Constants;

public static class IndividualCustomerConstants
{
    public static class ValidationMessages
    {
        public const string FirstNameRequired = "Ad alanı zorunludur.";
        public const string FirstNameMaxLength = "Ad en fazla 100 karakter olabilir.";
        public const string LastNameRequired = "Soyad alanı zorunludur.";
        public const string LastNameMaxLength = "Soyad en fazla 100 karakter olabilir.";
        public const string NationalIdRequired = "TC Kimlik Numarası zorunludur.";
        public const string NationalIdInvalid = "TC Kimlik Numarası geçerli değil.";
        public const string NationalIdLength = "TC Kimlik Numarası 11 haneli olmalıdır.";
        public const string DateOfBirthRequired = "Doğum tarihi zorunludur.";
        public const string DateOfBirthInvalid = "Doğum tarihi geçerli değil.";
        public const string AgeMinimum = "Müşteri en az 18 yaşında olmalıdır.";
        public const string AgeMaximum = "Müşteri en fazla 100 yaşında olabilir.";
        public const string PhoneNumberRequired = "Telefon numarası zorunludur.";
        public const string PhoneNumberInvalid = "Telefon numarası geçerli değil.";
        public const string EmailRequired = "E-posta adresi zorunludur.";
        public const string EmailInvalid = "E-posta adresi geçerli değil.";
        public const string AddressRequired = "Adres alanı zorunludur.";
        public const string AddressMaxLength = "Adres en fazla 500 karakter olabilir.";
        public const string MotherNameMaxLength = "Anne adı en fazla 200 karakter olabilir.";
        public const string FatherNameMaxLength = "Baba adı en fazla 200 karakter olabilir.";
    }

    public static class BusinessMessages
    {
        public const string CustomerCreated = "Bireysel müşteri başarıyla oluşturuldu.";
        public const string CustomerUpdated = "Bireysel müşteri bilgileri başarıyla güncellendi.";
        public const string CustomerDeleted = "Bireysel müşteri başarıyla silindi.";
        public const string CustomerNotFound = "Bireysel müşteri bulunamadı.";
        public const string CustomerAlreadyExists = "Bu TC Kimlik Numarası ile kayıtlı müşteri zaten mevcut.";
        public const string EmailAlreadyExists = "Bu e-posta adresi ile kayıtlı müşteri zaten mevcut.";
        public const string PhoneNumberAlreadyExists = "Bu telefon numarası ile kayıtlı müşteri zaten mevcut.";
    }

    public static class Rules
    {
        public const int MinimumAge = 18;
        public const int MaximumAge = 100;
        public const int NationalIdLength = 11;
        public const int FirstNameMaxLength = 100;
        public const int LastNameMaxLength = 100;
        public const int AddressMaxLength = 500;
        public const int MotherNameMaxLength = 200;
        public const int FatherNameMaxLength = 200;
        public const int PhoneNumberMaxLength = 20;
        public const int EmailMaxLength = 255;
    }
} 