# 🏦 Banking Credit System

**Banking Credit System** - .NET Core 9 ve Clean Architecture ile geliştirilmiş modern bankacılık kredilendirme sistemi

## 📋 Proje Tanımı

Bu proje, modern bankacılık sektörü için geliştirilmiş bir **kredilendirme sistemi**dir. Sistem, müşterilerin kredi başvurularını değerlendirme, kredi skorlarını hesaplama, risk analizi yapma ve otomatik kredi onay/red kararları verme süreçlerini dijitalleştirmektedir.

## 🛠️ Teknoloji Stack

- **Framework:** .NET Core 9
- **Programlama Dili:** C#
- **Mimari:** Clean Architecture (Temiz Mimari)
- **Pattern:** CQRS (Command Query Responsibility Segregation)
- **ORM:** Entity Framework Core 9.0
- **API:** RESTful Web API
- **Dokümantasyon:** Swagger/OpenAPI
- **Database:** SQL Server
- **Testing:** xUnit, Moq
- **Logging:** Serilog

## 🏗️ Mimari Yapısı

```
┌─────────────────────────────────────────────┐
│                  WebApi                     │ ← Presentation Layer
├─────────────────────────────────────────────┤
│                Persistence                  │ ← Infrastructure Layer
├─────────────────────────────────────────────┤
│               Application                   │ ← Application Layer (CQRS)
├─────────────────────────────────────────────┤
│                 Domain                      │ ← Domain Layer
├─────────────────────────────────────────────┤
│                  Core                       │ ← Core Layer (Shared)
└─────────────────────────────────────────────┘
```

## 📁 Proje Yapısı

```
BankingApp.CreditSystem/
├── BankingApp.CreditSystem.sln              ← Solution dosyası
├── BankingApp.CreditSystem.Core/            ← Core Katmanı (Çekirdek)
│   ├── Repositories/
│   │   ├── Entity.cs                        ← Base Entity sınıfı (Generic, Protected Constructor)
│   │   ├── IRepository.cs                   ← Generic Repository Interface (EF Core optimized)
│   │   └── PagedResult.cs                   ← Sayfalama sonuç modeli
│   └── BankingApp.CreditSystem.Core.csproj
├── BankingApp.CreditSystem.Domain/          ← Domain Katmanı (İş Kuralları)
│   ├── Entities/                            ← Concrete entity'ler
│   │   ├── Customer.cs                      ← Base müşteri sınıfı (Entity<Guid>)
│   │   ├── IndividualCustomer.cs            ← Bireysel müşteri
│   │   └── CorporateCustomer.cs             ← Kurumsal müşteri
│   └── BankingApp.CreditSystem.Domain.csproj
├── BankingApp.CreditSystem.Application/     ← Application Katmanı (CQRS)
│   ├── Services/
│   │   └── Repositories/                    ← Repository Interface'leri
│   │       ├── ICustomerRepository.cs       ← Customer repository interface
│   │       ├── IIndividualCustomerRepository.cs ← Individual customer repository interface
│   │       └── ICorporateCustomerRepository.cs  ← Corporate customer repository interface
│   └── BankingApp.CreditSystem.Application.csproj
├── BankingApp.CreditSystem.Persistence/     ← Persistence Katmanı (Veritabanı)
│   ├── Contexts/
│   │   └── BankingContext.cs                ← DbContext (TPH yaklaşımı)
│   ├── EntityConfigurations/                ← EF Core Configurations
│   │   ├── CustomerEntityConfiguration.cs   ← Customer entity config
│   │   ├── IndividualCustomerEntityConfiguration.cs ← Individual customer config
│   │   └── CorporateCustomerEntityConfiguration.cs  ← Corporate customer config
│   ├── Repositories/                        ← Repository Implementations
│   │   ├── EfRepository.cs                  ← Generic EF Core implementasyonu
│   │   ├── CustomerRepository.cs            ← Customer repository impl
│   │   ├── IndividualCustomerRepository.cs  ← Individual customer repository impl
│   │   └── CorporateCustomerRepository.cs   ← Corporate customer repository impl
│   ├── ServiceRegistration.cs               ← DI Container registration
│   └── BankingApp.CreditSystem.Persistence.csproj
├── BankingApp.CreditSystem.WebApi/          ← WebApi Katmanı (Presentation)
│   └── BankingApp.CreditSystem.WebApi.csproj
├── .gitignore                               ← Git ignore dosyası
├── README.md                                ← Bu dosya
└── todo.md                                  ← Proje roadmap'i
```

## 🎯 Uygulama Amaçları

1. **Kredi Başvuru Süreci Otomasyonu:** Manuel süreçlerin dijitalleştirilmesi
2. **Risk Değerlendirme:** Gelişmiş algoritmarla kredi risklerinin hesaplanması
3. **Hızlı Karar Verme:** Anlık kredi onay/red kararları
4. **Müşteri Deneyimi:** Kullanıcı dostu ve hızlı başvuru süreci
5. **Operasyonel Verimlilik:** Banka personelinin iş yükünün azaltılması
6. **Veri Yönetimi:** Kredi verilerinin merkezi ve güvenli yönetimi
7. **Raporlama:** Detaylı analiz ve raporlama altyapısı
8. **Uyumluluk:** Bankacılık mevzuatına uygun süreç yönetimi

## 🔧 Temel Özellikler

- ✅ **Müşteri bilgileri yönetimi** (Bireysel & Kurumsal)
- ✅ **Generic Repository Pattern** (IRepository + EfRepository)
- ✅ **Entity Framework Core 9.0** entegrasyonu
- ✅ **Clean Architecture** yapısı
- ✅ **Base Entity** sistem (Id, CreatedDate, UpdatedDate, DeletedDate)
- ✅ **Sayfalama desteği** (PagedResult)
- ✅ **DbContext implementasyonu** (BankingContext - TPH yaklaşımı)
- ✅ **Entity Configurations** (EF Core mapping configurations)
- ✅ **Repository implementasyonları** (Customer, IndividualCustomer, CorporateCustomer)
- ✅ **Dependency Injection** (ServiceRegistration extension)
- ✅ **🎯 CQRS Pattern** (MediatR implementation)
- ✅ **🎯 Features-based Architecture** (Vertical slice architecture)
- ✅ **🎯 AutoMapper Integration** (Entity ↔ DTO mapping)
- ✅ **🎯 FluentValidation** (Comprehensive validation rules)
- ✅ **🎯 Business Rules Engine** (Turkish ID/Tax validation algorithms)
- ✅ **🎯 Constants Management** (Centralized messages & rules)
- ⏳ Kredi başvurusu oluşturma ve takibi (Geliştirme aşamasında)
- ⏳ Otomatik kredi skoru hesaplama (Geliştirme aşamasında)
- ⏳ Risk analizi ve değerlendirme (Geliştirme aşamasında)
- ⏳ Otomatik onay/red algoritması (Geliştirme aşamasında)
- ⏳ RESTful API desteği (Geliştirme aşamasında)
- ⏳ Güvenli authentication ve authorization (Geliştirme aşamasında)

## 🎨 Generic Repository Özellikleri

Repository pattern Entity Framework Core 9.0 ile tam uyumlu şekilde geliştirilmiştir:

### 📊 Temel Özellikler:
- **IQueryable Support** - Direct LINQ erişimi
- **No-Tracking Support** - Performance optimization
- **Include Navigation** - Related entity loading
- **OrderBy Support** - Flexible sorting
- **Pagination** - Full pagination with metadata
- **Aggregations** - Count, Sum, Max, Min, Average
- **Bulk Operations** - AddRange, UpdateRange, DeleteRange

### 💡 Kullanım Örneği:
```csharp
// Repository kullanımı
var customerRepository = new CustomerRepository(bankingContext);

// Include ile related data
var customer = await customerRepository.GetByIdAsync(customerId);

// Pagination ile listeleme
var pagedResult = await customerRepository.GetPagedListAsync(
    predicate: c => c.IsActive,
    orderBy: q => q.OrderByDescending(c => c.CreatedDate),
    pageIndex: 0, pageSize: 10);

// Spesifik repository metodları
var activeCustomers = await customerRepository.GetActiveCustomersAsync();
var emailExists = await customerRepository.IsEmailExistsAsync("test@example.com");

// Individual customer repository
var individualRepository = new IndividualCustomerRepository(bankingContext);
var customerByNationalId = await individualRepository.GetByNationalIdAsync("12345678901");
var customersByAge = await individualRepository.GetCustomersByAgeRangeAsync(25, 65);
```

## 🎯 CQRS Pattern Kullanımı

Bu projede **MediatR** ile CQRS pattern implementasyonu yapılmıştır. İşte temel kullanım örnekleri:

### 📋 Command Örneği (Bireysel Müşteri Oluşturma)
```csharp
// Command (Request)
public class CreateIndividualCustomerCommand : IRequest<IndividualCustomerDto>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalId { get; set; }
    public DateTime DateOfBirth { get; set; }
    // ... diğer propertyler
}

// Handler (Business Logic)
public class CreateIndividualCustomerCommandHandler : IRequestHandler<CreateIndividualCustomerCommand, IndividualCustomerDto>
{
    public async Task<IndividualCustomerDto> Handle(CreateIndividualCustomerCommand request, CancellationToken cancellationToken)
    {
        // Business rules validation
        await _businessRules.CheckIfNationalIdExistsAsync(request.NationalId);
        _businessRules.ValidateNationalId(request.NationalId);
        
        // Entity creation
        var customer = new IndividualCustomer { ... };
        var createdCustomer = await _repository.AddAsync(customer);
        
        return _mapper.Map<IndividualCustomerDto>(createdCustomer);
    }
}

// Validation (FluentValidation)
public class CreateIndividualCustomerCommandValidator : AbstractValidator<CreateIndividualCustomerCommand>
{
    public CreateIndividualCustomerCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(100);
        RuleFor(x => x.NationalId).NotEmpty().Length(11).Must(BeNumeric);
        // ... diğer kurallar
    }
}
```

### 📋 Query Örneği (Müşteri Sorgulama)
```csharp
// Query (Request)
public class GetIndividualCustomerByIdQuery : IRequest<IndividualCustomerDto?>
{
    public Guid Id { get; set; }
}

// Handler (Data Retrieval)
public class GetIndividualCustomerByIdQueryHandler : IRequestHandler<GetIndividualCustomerByIdQuery, IndividualCustomerDto?>
{
    public async Task<IndividualCustomerDto?> Handle(GetIndividualCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await _repository.GetByIdAsync(request.Id, cancellationToken);
        return customer == null ? null : _mapper.Map<IndividualCustomerDto>(customer);
    }
}
```

### 📋 Controller Kullanımı (Gelecek WebAPI implementasyonu)
```csharp
[ApiController]
[Route("api/[controller]")]
public class IndividualCustomersController : ControllerBase
{
    private readonly IMediator _mediator;

    [HttpPost]
    public async Task<ActionResult<IndividualCustomerDto>> Create(CreateIndividualCustomerCommand command)
    {
        var result = await _mediator.Send(command);
        return Created($"/api/individualcustomers/{result.Id}", result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IndividualCustomerDto>> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetIndividualCustomerByIdQuery(id));
        return result == null ? NotFound() : Ok(result);
    }
}
```

### 🏗️ Features-Based Organization

Projede **Vertical Slice Architecture** kullanılmıştır:

```
Features/
├── IndividualCustomers/
│   ├── Commands/CreateIndividualCustomer/    ← Müşteri oluşturma
│   ├── Queries/GetIndividualCustomerById/    ← Müşteri sorgulama
│   ├── Constants/                            ← Sabit değerler
│   ├── Profiles/                             ← AutoMapper mappings
│   └── Rules/                                ← Business rules
└── CorporateCustomers/
    └── ... (benzer yapı)
```

## 🗄️ Veritabanı Yapısı

Bu projede **Table Per Hierarchy (TPH)** yaklaşımı kullanılmaktadır. Tüm customer türleri tek tabloda saklanır ve bir discriminator kolonu ile ayırt edilir.

### 📋 Customers Tablosu (TPH)
```sql
Customers (Table Per Hierarchy)
├── Id (Guid, PK) - NEWID() default
├── CustomerType (nvarchar, Discriminator) - "Individual" / "Corporate"
├── PhoneNumber (nvarchar(20), Unique Index)
├── Email (nvarchar(255), Unique Index)
├── Address (nvarchar(500))
├── IsActive (bit, Default: true)
├── CreatedDate (datetime2, Default: GETUTCDATE())
├── UpdatedDate (datetime2, nullable)
├── DeletedDate (datetime2, nullable)
├── -- Individual Customer Fields --
├── FirstName (nvarchar(100))
├── LastName (nvarchar(100))
├── NationalId (nchar(11), Unique Index)
├── DateOfBirth (date)
├── MotherName (nvarchar(200), nullable)
├── FatherName (nvarchar(200), nullable)
├── -- Corporate Customer Fields --
├── CompanyName (nvarchar(300))
├── TaxNumber (nchar(10), Unique Index)
├── TaxOffice (nvarchar(200))
├── CompanyRegistrationNumber (nvarchar(20), Unique Index)
├── AuthorizedPersonName (nvarchar(200))
└── CompanyFoundationDate (date)
```

### 📈 Performans Optimizasyonları
- **Unique Index'ler:** Email, PhoneNumber, NationalId, TaxNumber, CompanyRegistrationNumber
- **Composite Index:** FirstName + LastName (Individual customers için)
- **Filtreleme Index'leri:** IsActive, DateOfBirth, CompanyFoundationDate
- **Discriminator Index:** CustomerType üzerinde otomatik index

## 📊 İş Akışı

1. **Başvuru:** Müşteri kredi başvurusunu oluşturur
2. **Doğrulama:** Sistem müşteri bilgilerini doğrular
3. **Skorlama:** Kredi skoru otomatik hesaplanır
4. **Risk Analizi:** Gelişmiş algoritmarla risk değerlendirmesi yapılır
5. **Karar:** Otomatik onay/red kararı verilir
6. **Bildirim:** Müşteriye sonuç bildirilir
7. **Takip:** Başvuru süreci takip edilir

## 🚀 Kurulum

### Ön Gereksinimler

- **.NET 9 SDK**
- **SQL Server** (LocalDB desteklenir)
- **Visual Studio 2022** veya **Visual Studio Code**

### Adımlar

1. **Repository'yi klonlayın:**
   ```bash
   git clone https://github.com/karacalibt/BankingApp-CreditSystem.git
   cd BankingApp-CreditSystem
   ```

2. **Projeyi restore edin:**
   ```bash
   dotnet restore
   ```

3. **Projeyi build edin:**
   ```bash
   dotnet build
   ```

4. **WebAPI'yi çalıştırın:**
   ```bash
   cd BankingApp.CreditSystem.WebApi
   dotnet run
   ```

## 🧪 Test

```bash
dotnet test
```

## 📦 NuGet Paketleri

### Core Katmanı:
- `Microsoft.EntityFrameworkCore` (9.0.0)

### Application Katmanı:
- `MediatR` (12.5.0) - CQRS pattern implementation
- `AutoMapper` (14.0.0) - Object-to-object mapping
- `FluentValidation` (12.0.0) - Validation rules engine

### Persistence Katmanı:
- `Microsoft.EntityFrameworkCore` (9.0.0)
- `Microsoft.EntityFrameworkCore.SqlServer` (9.0.0)
- `Microsoft.EntityFrameworkCore.Tools` (9.0.0)

### WebApi Katmanı:
- `Microsoft.EntityFrameworkCore.Design` (9.0.0)

## 📝 Geliştirme Durumu

Proje aktif geliştirme aşamasındadır. Güncel durum için `todo.md` dosyasına bakınız.

**Tamamlanma Oranı:** %35 (45/130 görev)
**Son Güncelleme:** 12/06/2025 16:50

### ✅ Tamamlanan Özellikler:
- Solution ve proje yapısı oluşturulması
- Clean Architecture katman referansları
- Base Entity sınıfı (Generic)
- Generic Repository Interface (EF Core optimized)
- Generic Repository Implementation (EfRepository)
- PagedResult pagination modeli
- Customer entity hierarchy (Individual/Corporate)
- Entity Framework Core 9.0 entegrasyonu
- **BankingContext DbContext implementasyonu** (TPH yaklaşımı)
- **Entity Configurations** (Customer, IndividualCustomer, CorporateCustomer)
- **Repository implementasyonları** (Generic + Spesifik repository'ler)
- **Application layer repository interface'leri** (Clean Architecture uyumlu)
- **Dependency Injection** (ServiceRegistration extension)
- **📋 CQRS Pattern implementasyonu** (MediatR 12.5.0)
- **📋 Features-based organization** (IndividualCustomers, CorporateCustomers)
- **📋 DTO Models** (BaseDto, CustomerDto, IndividualCustomerDto, CorporateCustomerDto)
- **📋 AutoMapper Profiles** (Entity ↔ DTO mapping, computed properties)
- **📋 Constants & Validation Messages** (Turkish localization)
- **📋 Business Rules** (TC Kimlik No & Vergi No algorithms)
- **📋 CQRS Commands** (CreateIndividualCustomer, CreateCorporateCustomer)
- **📋 Command Handlers** (Business rules integration)
- **📋 FluentValidation** (Comprehensive validation rules)
- **📋 CQRS Queries** (GetIndividualCustomerById, GetAllIndividualCustomers)
- **📋 Query Handlers** (Repository integration)

### 🚧 Geliştirilmekte:
- Database migration'ları ve veritabanı güncellemesi
- Application ServiceRegistration extension (MediatR, AutoMapper, FluentValidation)
- Validation ve Logging behaviors (MediatR pipeline)
- WebAPI controllers ve endpoints

## 🤝 Katkıda Bulunma

1. Fork edin
2. Feature branch oluşturun (`git checkout -b feature/amazing-feature`)
3. Commit edin (`git commit -m 'Add amazing feature'`)
4. Branch'i push edin (`git push origin feature/amazing-feature`)
5. Pull Request oluşturun

## 📄 Lisans

Bu proje MIT lisansı altında lisanslanmıştır.

## 📞 İletişim

Proje sahibi: [@karacalibt](https://github.com/karacalibt)

---

⭐ **Bu projeyi beğendiyseniz star vermeyi unutmayın!** 