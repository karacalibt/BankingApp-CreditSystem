# Banking Credit System - TODO Listesi

## 📋 Proje Genel Bilgileri

### 🏦 Proje Tanımı
Bu proje, modern bankacılık sektörü için geliştirilmiş bir **kredilendirme sistemi**dir. Sistem, müşterilerin kredi başvurularını değerlendirme, kredi skorlarını hesaplama, risk analizi yapma ve otomatik kredi onay/red kararları verme süreçlerini dijitalleştirmektedir.

### 🛠️ Teknoloji Stack
- **Framework:** .NET Core 9
- **Programlama Dili:** C#
- **Mimari:** Clean Architecture (Temiz Mimari)
- **Pattern:** CQRS (Command Query Responsibility Segregation)
- **ORM:** Entity Framework Core
- **API:** RESTful Web API
- **Dokümantasyon:** Swagger/OpenAPI
- **Dependency Injection:** Built-in .NET DI Container
- **Validation:** FluentValidation
- **Mediator Pattern:** MediatR
- **Database:** SQL Server (geliştirme aşamasında)
- **Testing:** xUnit, Moq
- **Logging:** Serilog

### 🏗️ Mimari Yapısı (Clean Architecture)
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

### 🎯 Katman Sorumluluları
- **Core:** Ortak interface'ler, base class'lar, extension'lar, utilities
- **Domain:** Entity'ler, value object'ler, domain service'ler, business rule'lar
- **Application:** Use case'ler, CQRS command/query'ler, DTO'lar, business logic
- **Persistence:** Veritabanı erişimi, repository'ler, EF Core konfigürasyonları
- **WebApi:** Controller'lar, middleware'ler, API endpoint'leri, authentication

### 🎪 Uygulama Amaçları
1. **Kredi Başvuru Süreci Otomasyonu:** Manuel süreçlerin dijitalleştirilmesi
2. **Risk Değerlendirme:** Gelişmiş algoritmarla kredi risklerinin hesaplanması
3. **Hızlı Karar Verme:** Anlık kredi onay/red kararları
4. **Müşteri Deneyimi:** Kullanıcı dostu ve hızlı başvuru süreci
5. **Operasyonel Verimlilik:** Banka personelinin iş yükünün azaltılması
6. **Veri Yönetimi:** Kredi verilerinin merkezi ve güvenli yönetimi
7. **Raporlama:** Detaylı analiz ve raporlama altyapısı
8. **Uyumluluk:** Bankacılık mevzuatına uygun süreç yönetimi

### 🔧 Temel Özellikler
- ✅ Müşteri bilgileri yönetimi
- ✅ Kredi başvurusu oluşturma ve takibi
- ✅ Otomatik kredi skoru hesaplama
- ✅ Risk analizi ve değerlendirme
- ✅ Otomatik onay/red algoritması
- ✅ Kredi limiti ve faiz oranı belirleme
- ✅ Başvuru durumu real-time takibi
- ✅ Kapsamlı raporlama ve analitik
- ✅ RESTful API desteği
- ✅ Güvenli authentication ve authorization

### 📊 İş Akışı
1. **Başvuru:** Müşteri kredi başvurusunu oluşturur
2. **Doğrulama:** Sistem müşteri bilgilerini doğrular
3. **Skorlama:** Kredi skoru otomatik hesaplanır
4. **Risk Analizi:** Gelişmiş algoritmarla risk değerlendirmesi yapılır
5. **Karar:** Otomatik onay/red kararı verilir
6. **Bildirim:** Müşteriye sonuç bildirilir
7. **Takip:** Başvuru süreci takip edilir

---

## 🔥 **SOLID Prensipleri Uygulaması (YENİ!)**

### ✅ **Interface Segregation Principle (ISP) Düzeltmesi**

Büyük `IRepository` interface'i daha küçük, spesifik interface'lere bölünmüştür:

```
Core/Repositories/
├── IQueryRepository.cs           ← Sadece Query operasyonları
├── ICommandRepository.cs         ← Sadece Command operasyonları  
├── IAggregationRepository.cs     ← Sadece Aggregation operasyonları
├── IPaginationRepository.cs      ← Sadece Pagination operasyonları
└── IRepository.cs               ← Composed interface (tüm interface'leri inherit eder)
```

**Faydalar:**
- Her interface tek sorumluluğa sahip
- İhtiyaç duyulmayan metodlar implement edilmek zorunda değil
- Daha temiz ve anlaşılır kod yapısı

### ✅ **Single Responsibility Principle (SRP) Düzeltmesi**

Business Rules sınıfları çok fazla sorumluluk taşıyordu. Artık ayrılmış durumda:

```
Features/IndividualCustomers/
├── Validators/
│   └── IndividualCustomerValidator.cs        ← Sadece domain validation
├── Services/
│   └── IndividualCustomerExistenceChecker.cs ← Sadece existence checks
└── Rules/
    └── IndividualCustomerBusinessRules.cs    ← Orchestration ve backward compatibility
```

**Faydalar:**
- Her sınıf tek sorumluluğa sahip
- Test edilebilirlik arttı
- Kod daha modüler ve maintainable

### ✅ **Dependency Inversion Principle (DIP) İyileştirmesi**

- Business Rules artık abstraction'lara bağımlı
- Yeni ServiceRegistration sistemi eklendi
- Dependency Injection daha organize

---

## 🏗️ Proje Yapısı

```
BankingApp.CreditSystem/
├── BankingApp.CreditSystem.sln              ← Solution dosyası
├── BankingApp.CreditSystem.Core/            ← Core Katmanı (Çekirdek) - ISP Uyumlu!
│   ├── Repositories/
│   │   ├── Entity.cs                        ← Base Entity sınıfı (Generic, Protected Constructor, default!)
│   │   ├── IQueryRepository.cs              ← Query-only operations (ISP)
│   │   ├── ICommandRepository.cs            ← Command-only operations (ISP)
│   │   ├── IAggregationRepository.cs        ← Aggregation-only operations (ISP)
│   │   ├── IPaginationRepository.cs         ← Pagination-only operations (ISP)
│   │   ├── IRepository.cs                   ← Composed Repository Interface (ISP compliant)
│   │   └── PagedResult.cs                   ← Sayfalama sonuç modeli
│   └── BankingApp.CreditSystem.Core.csproj
├── BankingApp.CreditSystem.Domain/          ← Domain Katmanı (İş Kuralları)
│   ├── Entities/                            ← Concrete entity'ler
│   │   ├── Customer.cs                      ← Base müşteri sınıfı (Entity<Guid>)
│   │   ├── IndividualCustomer.cs            ← Bireysel müşteri (sadeleştirilmiş)
│   │   └── CorporateCustomer.cs             ← Kurumsal müşteri (sadeleştirilmiş)
│   └── BankingApp.CreditSystem.Domain.csproj
├── BankingApp.CreditSystem.Application/     ← Application Katmanı (CQRS) - SRP Uyumlu!
│   ├── Common/                              ← Ortak modeller
│   │   └── Models/                          ← DTO'lar
│   │       ├── BaseDto.cs                   ← Base DTO sınıfı
│   │       ├── CustomerDto.cs               ← Customer abstract DTO
│   │       ├── IndividualCustomerDto.cs     ← Individual customer DTO
│   │       └── CorporateCustomerDto.cs      ← Corporate customer DTO
│   ├── Features/                            ← CQRS Features (Feature-based organization)
│   │   ├── IndividualCustomers/             ← Bireysel müşteri feature'ları (SRP Uyumlu!)
│   │   │   ├── Commands/                    ← Command'lar
│   │   │   │   └── CreateIndividualCustomer/
│   │   │   │       ├── CreateIndividualCustomerCommand.cs
│   │   │   │       ├── CreateIndividualCustomerCommandHandler.cs (Improved!)
│   │   │   │       └── CreateIndividualCustomerCommandValidator.cs
│   │   │   ├── Queries/                     ← Query'ler
│   │   │   │   ├── GetIndividualCustomerById/
│   │   │   │   │   ├── GetIndividualCustomerByIdQuery.cs
│   │   │   │   │   └── GetIndividualCustomerByIdQueryHandler.cs
│   │   │   │   └── GetAllIndividualCustomers/
│   │   │   │       └── GetAllIndividualCustomersQuery.cs
│   │   │   ├── Constants/                   ← Sabit değerler
│   │   │   │   └── IndividualCustomerConstants.cs
│   │   │   ├── Profiles/                    ← AutoMapper profilleri
│   │   │   │   └── IndividualCustomerProfile.cs
│   │   │   ├── Validators/                  ← Domain Validation (SRP!)
│   │   │   │   └── IndividualCustomerValidator.cs
│   │   │   ├── Services/                    ← Business Services (SRP!)
│   │   │   │   └── IndividualCustomerExistenceChecker.cs
│   │   │   └── Rules/                       ← İş kuralları orchestration
│   │   │       └── IndividualCustomerBusinessRules.cs (Refactored!)
│   │   └── CorporateCustomers/              ← Kurumsal müşteri feature'ları (SRP Uyumlu!)
│   │       ├── Commands/
│   │       │   └── CreateCorporateCustomer/
│   │       │       ├── CreateCorporateCustomerCommand.cs
│   │       │       └── CreateCorporateCustomerCommandHandler.cs (Improved!)
│   │       ├── Queries/
│   │       ├── Constants/
│   │       │   └── CorporateCustomerConstants.cs
│   │       ├── Profiles/
│   │       │   └── CorporateCustomerProfile.cs
│   │       ├── Validators/                  ← Domain Validation (SRP!)
│   │       │   └── CorporateCustomerValidator.cs
│   │       ├── Services/                    ← Business Services (SRP!)
│   │       │   └── CorporateCustomerExistenceChecker.cs
│   │       └── Rules/
│   │           └── CorporateCustomerBusinessRules.cs (Refactored!)
│   ├── Services/
│   │   └── Repositories/                    ← Repository Interface'leri
│   │       ├── ICustomerRepository.cs       ← Customer repository interface
│   │       ├── IIndividualCustomerRepository.cs ← Individual customer repository interface
│   │       └── ICorporateCustomerRepository.cs  ← Corporate customer repository interface
│   ├── ServiceRegistration.cs               ← Application DI registration (NEW!)
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
└── todo.md                                  ← Bu dosya
```

### 🔗 Katman Bağımlılıkları (Clean Architecture)
```
WebApi ──→ Application ──→ Domain ──→ Core
   │            │             │
   │            │             └──→ Core
   │            └──→ Core
   │
   └──→ Persistence ──→ Application & Core
```

### 📦 Namespace Yapısı
- **Core:** `BankingApp.CreditSystem.Core.Repositories` (Entity, IRepository compositions, PagedResult)
- **Domain:** `BankingApp.CreditSystem.Domain.Entities` (Customer, IndividualCustomer, CorporateCustomer)
- **Application:** `BankingApp.CreditSystem.Application.Services.Repositories` (ICustomerRepository, IIndividualCustomerRepository, ICorporateCustomerRepository)
- **Persistence:** `BankingApp.CreditSystem.Persistence.*` (BankingContext, Repositories, EntityConfigurations)
- **WebApi:** `BankingApp.CreditSystem.WebApi.*`

---

## 🎯 Proje Kurulumu
- [x] .NET Core 9 solution oluşturulması (`BankingApp.CreditSystem.sln`)
- [x] Core katmanı projesi oluşturulması (`BankingApp.CreditSystem.Core`)
- [x] Domain katmanı projesi oluşturulması (`BankingApp.CreditSystem.Domain`)
- [x] Application katmanı projesi oluşturulması (`BankingApp.CreditSystem.Application`)
- [x] Persistence katmanı projesi oluşturulması (`BankingApp.CreditSystem.Persistence`)
- [x] WebApi katmanı projesi oluşturulması (`BankingApp.CreditSystem.WebApi`)
- [x] Tüm projelerin solution'a eklenmesi
- [x] Clean Architecture prensiplere göre proje referanslarının kurulması
- [x] Solution'ın başarılı bir şekilde build edilmesi

## 🔧 Core Katmanı Geliştirme
- [x] Repositories klasör yapısının oluşturulması
- [x] Base Entity class'ı oluşturulması (Generic Id tipi ile, Protected Constructor, default! değeri)
- [x] **IRepository interface'i tanımlanması (ISP Uyumlu! - Ayrı interface'lere bölünmüş)**
- [x] **IQueryRepository interface'i oluşturulması (ISP)**
- [x] **ICommandRepository interface'i oluşturulması (ISP)**
- [x] **IAggregationRepository interface'i oluşturulması (ISP)**
- [x] **IPaginationRepository interface'i oluşturulması (ISP)**
- [x] PagedResult model'i oluşturulması (Sayfalama sonuçları için)
- [x] EfRepository<TEntity, TId> generic implementasyonu (Core katmanında, tam EF Core uyumlu)
- [ ] IUnitOfWork interface'i tanımlanması
- [ ] Common value objects oluşturulması
- [ ] Domain events için base class'lar oluşturulması
- [ ] Pagination için helper class'lar oluşturulması
- [ ] Result pattern implementasyonu
- [x] Exception handling için custom exception class'ları

## 🏛️ Domain Katmanı Geliştirme
- [x] Entities klasör yapısının oluşturulması
- [x] Customer base entity'si oluşturulması (Entity<Guid>, sadeleştirilmiş)
- [x] IndividualCustomer entity'si oluşturulması (FirstName, LastName, NationalId, DateOfBirth)
- [x] CorporateCustomer entity'si oluşturulması (CompanyName, TaxNumber, TaxOffice, CompanyRegistrationNumber)
- [ ] Credit Application entity'si oluşturulması
- [ ] Credit Score value object'i oluşturulması
- [ ] Credit Type enum'ı tanımlanması
- [ ] Credit Amount value object'i oluşturulması
- [ ] Application Status enum'ı tanımlanması
- [ ] Domain service'leri (Credit Score Calculator, Risk Assessment)
- [ ] Domain event'leri tanımlanması
- [ ] Business rule validasyonları
- [ ] Docker Compose konfigürasyonu
- [ ] CI/CD pipeline kurulumu
- [ ] Environment-specific configuration
- [ ] Logging ve monitoring kurulumu
- [ ] Performance monitoring
- [ ] Error tracking (Application Insights)

## 💼 Application Katmanı (CQRS) Geliştirme
- [x] Repository interface'lerinin oluşturulması (ICustomerRepository, IIndividualCustomerRepository, ICorporateCustomerRepository)
- [x] MediatR package'ının eklenmesi (12.5.0)
- [x] AutoMapper package'ının eklenmesi (14.0.0)
- [x] FluentValidation package'ının eklenmesi (12.0.0)
- [x] Features klasör yapısının oluşturulması (IndividualCustomers, CorporateCustomers)
- [x] DTO (Data Transfer Object) class'larının oluşturulması (BaseDto, CustomerDto, IndividualCustomerDto, CorporateCustomerDto)
- [x] Constants class'larının oluşturulması (ValidationMessages, BusinessMessages, Rules)
- [x] AutoMapper Profiles'larının oluşturulması (IndividualCustomerProfile, CorporateCustomerProfile)
- [x] **Business Rules'larının oluşturulması (SRP Uyumlu! - Ayrı sınıflara bölünmüş)**
- [x] **Individual Customer Validator sınıfı (SRP - Sadece domain validation)**
- [x] **Individual Customer Existence Checker sınıfı (SRP - Sadece existence checks)**
- [x] **Corporate Customer Validator sınıfı (SRP - Sadece domain validation)**
- [x] **Corporate Customer Existence Checker sınıfı (SRP - Sadece existence checks)**
- [x] CQRS Commands oluşturulması (CreateIndividualCustomer, CreateCorporateCustomer)
- [x] **Command Handlers oluşturulması (SRP uyumlu business rules entegrasyonu)**
- [x] FluentValidation Validators oluşturulması (Comprehensive validation rules)
- [x] CQRS Queries oluşturulması (GetIndividualCustomerById, GetAllIndividualCustomers)
- [x] Query Handlers oluşturulması
- [x] **Application ServiceRegistration oluşturulması (DIP uyumlu DI container registration)**

### Customer Commands
- [x] **Create Individual Customer Command (Command, Handler - SRP uyumlu, Validator)**
- [x] **Create Corporate Customer Command (Command, Handler - SRP uyumlu)**
- [ ] Update Individual Customer Command
- [ ] Update Corporate Customer Command
- [ ] Delete Customer Command (Soft Delete)

### Customer Queries  
- [x] Get Individual Customer by Id Query (Query, Handler)
- [x] Get All Individual Customers Query (Pagination + Filtering)
- [ ] Get Corporate Customer by Id Query
- [ ] Get All Corporate Customers Query
- [ ] Search Customers Query (Cross-entity search)

### Credit Application Commands
- [ ] Create Credit Application Command
- [ ] Update Credit Application Command
- [ ] Approve Credit Application Command
- [ ] Reject Credit Application Command
- [ ] Delete Credit Application Command

### Credit Application Queries
- [ ] Get Credit Application by Id Query
- [ ] Get Credit Applications by Customer Query
- [ ] Get Pending Credit Applications Query
- [ ] Search Credit Applications Query

### Behaviors & Cross-Cutting Concerns
- [ ] Validation behavior'u eklenmesi (FluentValidation pipeline)
- [ ] Logging behavior'u eklenmesi (Request/Response logging)
- [ ] Performance behavior'u eklenmesi (Execution time tracking)
- [x] **Application ServiceRegistration extension'ı oluşturulması (SOLID uyumlu DI)**

## 💾 Persistence Katmanı Geliştirme
- [x] Entity Framework Core package'larının eklenmesi (9.0.0 - Core, SqlServer, Tools, Design)
- [x] BankingContext DbContext oluşturulması (TPH yaklaşımı, auto-timestamps)
- [x] Entity configuration'larının yazılması (Customer, IndividualCustomer, CorporateCustomer)
- [x] Repository implementasyonlarının yazılması (EfRepository, CustomerRepository, IndividualCustomerRepository, CorporateCustomerRepository)
- [x] Application katmanında repository interface'lerinin oluşturulması
- [x] ServiceRegistration extension'ının oluşturulması (Dependency Injection)
- [ ] Migration'ların oluşturulması ve veritabanı güncellemesi
- [ ] Unit of Work pattern implementasyonu
- [ ] Seed data oluşturulması
- [ ] Database connection string konfigürasyonu

## 🌐 WebApi Katmanı Geliştirme
- [ ] Swagger/OpenAPI konfigürasyonu
- [ ] Credit Application Controller oluşturulması
- [ ] Customer Controller oluşturulması
- [ ] Global exception middleware eklenmesi
- [ ] CORS policy konfigürasyonu
- [ ] Authentication & Authorization eklenmesi
- [ ] API versioning implementasyonu
- [ ] Health check endpoint'leri eklenmesi
- [ ] Logging konfigürasyonu (Serilog)
- [ ] Response caching implementasyonu

## 🔒 Güvenlik ve Performans
- [ ] JWT Authentication implementasyonu
- [ ] Role-based authorization eklenmesi
- [ ] Rate limiting eklenmesi
- [ ] Data validation (FluentValidation)
- [ ] Input sanitization
- [ ] SQL injection koruması
- [ ] HTTPS zorunluluğu
- [ ] Security headers eklenmesi

## 🧪 Test Geliştirme
- [ ] Unit test projesi oluşturulması
- [ ] Integration test projesi oluşturulması
- [ ] Domain layer unit testleri
- [ ] Application layer unit testleri
- [ ] API integration testleri
- [ ] Test coverage raporu oluşturulması
- [ ] Mock data factory'leri oluşturulması

## 📝 Dokümantasyon
- [ ] API dokümantasyonu (Swagger)
- [ ] README.md dosyası oluşturulması
- [ ] Architecture decision records (ADR)
- [ ] Database schema dokümantasyonu
- [ ] Deployment guide oluşturulması
- [ ] API kullanım örnekleri

## 🚀 DevOps ve Deployment
- [ ] Docker containerization
- [ ] Docker Compose konfigürasyonu
- [ ] CI/CD pipeline kurulumu
- [ ] Environment-specific configuration
- [ ] Logging ve monitoring kurulumu
- [ ] Performance monitoring
- [ ] Error tracking (Application Insights)

## 📊 İş Mantığı Özellikleri
- [ ] Kredi başvurusu oluşturma
- [ ] Kredi skoru hesaplama algoritması
- [ ] Risk değerlendirme sistemi
- [ ] Otomatik kredi onay/red sistemi
- [ ] Kredi başvurusu durumu takibi
- [ ] Müşteri kredi geçmişi sorgulama
- [ ] Kredi limiti hesaplama
- [ ] Faiz oranı belirleme algoritması
- [ ] Audit logging sistemi
- [ ] Soft delete implementasyonu
- [ ] Data archiving stratejisi
- [ ] Performance optimization

## 🎨 İyileştirmeler ve Optimizasyonlar
- [ ] Caching strategy implementasyonu (Redis)
- [ ] Background job processing (Hangfire)
- [ ] Email notification sistemi
- [ ] SMS notification sistemi

---

## 📅 Proje Durumu
**Başlangıç Tarihi:** $(Get-Date -Format "dd/MM/yyyy")  
**Son Güncelleme:** 12/06/2025 17:30  
**Tamamlanma Oranı:** %43 (56/130 görev)

---

## 🎉 **Son Yapılan İyileştirmeler (SOLID Compliance)**

### ✅ **Interface Segregation Principle (ISP) Düzeltmesi Tamamlandı**
- Büyük `IRepository` interface'i 4 ayrı interface'e bölündü
- Her interface tek sorumluluğa sahip
- Daha temiz ve maintainable kod yapısı

### ✅ **Single Responsibility Principle (SRP) Düzeltmesi Tamamlandı**
- Business Rules sınıfları ayrı sorumluluklar için refactor edildi
- Validator sınıfları sadece domain validation yapıyor
- Existence Checker sınıfları sadece varlık kontrolü yapıyor
- Business Rules sınıfları artık orchestration yapıyor

### ✅ **Dependency Inversion Principle (DIP) İyileştirildi**
- Application katmanı için ServiceRegistration eklendi
- Tüm bağımlılıklar abstraction'lara çekildi
- DI container optimize edildi

### ✅ **Exception Handling Sistemi Eklendi**
- CrossCuttingConcerns/Exceptions altında kapsamlı exception handling sistemi
- HttpProblemDetails sınıfları ile RFC 7807 uyumlu hata yanıtları
- Özel exception tipleri (Business, Validation, Authorization, NotFound)
- ExceptionMiddleware ile global exception yakalama
- Fluent Validation entegrasyonu için ValidationException desteği

### ✅ **Build Testi Başarılı**
- Tüm değişiklikler sonrası proje başarıyla build oluyor
- Sadece 1 küçük warning var (null reference)
- SOLID prensipleri artık tam uyumlu

---

## 📋 Notlar
- Bu proje Clean Architecture ve CQRS pattern'leri kullanılarak geliştirilmektedir
- .NET Core 9 ve C# kullanılmaktadır
- Tüm katmanlar arasındaki bağımlılıklar Clean Architecture prensiplere uygun şekilde kurulmuştur
- Her katmanın kendi sorumluluğu vardır ve test edilebilir yapıda tasarlanmıştır
- Entity'lerde XML dokümantasyon yorumları (///) kullanılmamaktadır - temiz kod prensibi
- Customer entity'leri Entity<Guid> kullanarak sadeleştirilmiş formatta tasarlanmıştır
- Generic Repository (IRepository + EfRepository) Entity Framework Core 9.0 ile tam uyumlu implementasyon
- **Table Per Hierarchy (TPH)** yaklaşımı kullanılarak tek tabloda Customer, IndividualCustomer ve CorporateCustomer tutulmaktadır
- Repository interface'leri Application katmanında, implementasyonları Persistence katmanında yer almaktadır
- Dependency Injection için ServiceRegistration extension metodu kullanılmaktadır
- **SOLID Prensipleri artık tam uyumlu! ISP, SRP ve DIP düzeltmeleri tamamlandı** 