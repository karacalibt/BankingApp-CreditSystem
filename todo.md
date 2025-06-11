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

## 🏗️ Proje Yapısı

```
BankingApp.CreditSystem/
├── BankingApp.CreditSystem.sln              ← Solution dosyası
├── BankingApp.CreditSystem.Core/            ← Core Katmanı (Çekirdek)
│   ├── Repositories/
│   │   └── Entity.cs                        ← Base Entity sınıfı (Generic, Protected Constructor, default!)
│   └── BankingApp.CreditSystem.Core.csproj
├── BankingApp.CreditSystem.Domain/          ← Domain Katmanı (İş Kuralları)
│   ├── Entities/                            ← Concrete entity'ler
│   │   ├── Customer.cs                      ← Base müşteri sınıfı (Entity<Guid>)
│   │   ├── IndividualCustomer.cs            ← Bireysel müşteri (sadeleştirilmiş)
│   │   └── CorporateCustomer.cs             ← Kurumsal müşteri (sadeleştirilmiş)
│   └── BankingApp.CreditSystem.Domain.csproj
├── BankingApp.CreditSystem.Application/     ← Application Katmanı (CQRS)
│   └── BankingApp.CreditSystem.Application.csproj
├── BankingApp.CreditSystem.Persistence/     ← Persistence Katmanı (Veritabanı)
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
- **Core:** `BankingApp.CreditSystem.Core.Repositories`
- **Domain:** `BankingApp.CreditSystem.Domain.Entities`
- **Application:** `BankingApp.CreditSystem.Application.*`
- **Persistence:** `BankingApp.CreditSystem.Persistence.*`
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
- [ ] IRepository interface'i tanımlanması
- [ ] IUnitOfWork interface'i tanımlanması
- [ ] Common value objects oluşturulması
- [ ] Domain events için base class'lar oluşturulması
- [ ] Pagination için helper class'lar oluşturulması
- [ ] Result pattern implementasyonu
- [ ] Exception handling için custom exception class'ları

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

## 💼 Application Katmanı (CQRS) Geliştirme
- [ ] MediatR package'ının eklenmesi
- [ ] Command ve Query base class'larının oluşturulması
- [ ] DTO (Data Transfer Object) class'larının oluşturulması

### Commands
- [ ] Create Credit Application Command
- [ ] Update Credit Application Command
- [ ] Approve Credit Application Command
- [ ] Reject Credit Application Command
- [ ] Delete Credit Application Command

### Queries
- [ ] Get Credit Application by Id Query
- [ ] Get Credit Applications by Customer Query
- [ ] Get Pending Credit Applications Query
- [ ] Search Credit Applications Query

### Handlers
- [ ] Command handler'larının implementasyonu
- [ ] Query handler'larının implementasyonu
- [ ] Validation behavior'u eklenmesi
- [ ] Logging behavior'u eklenmesi

## 💾 Persistence Katmanı Geliştirme
- [ ] Entity Framework Core package'larının eklenmesi
- [ ] ApplicationDbContext oluşturulması
- [ ] Entity configuration'larının yazılması
- [ ] Migration'ların oluşturulması
- [ ] Repository pattern implementasyonu
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

## 🎨 İyileştirmeler ve Optimizasyonlar
- [ ] Caching strategy implementasyonu (Redis)
- [ ] Background job processing (Hangfire)
- [ ] Email notification sistemi
- [ ] SMS notification sistemi
- [ ] Audit logging sistemi
- [ ] Soft delete implementasyonu
- [ ] Data archiving stratejisi
- [ ] Performance optimization

---

## 📅 Proje Durumu
**Başlangıç Tarihi:** $(Get-Date -Format "dd/MM/yyyy")  
**Son Güncelleme:** 11/06/2025 18:00  
**Tamamlanma Oranı:** %13 (15/119 görev)

---

## 📋 Notlar
- Bu proje Clean Architecture ve CQRS pattern'leri kullanılarak geliştirilmektedir
- .NET Core 9 ve C# kullanılmaktadır
- Tüm katmanlar arasındaki bağımlılıklar Clean Architecture prensiplere uygun şekilde kurulmuştur
- Her katmanın kendi sorumluluğu vardır ve test edilebilir yapıda tasarlanmıştır
- Entity'lerde XML dokümantasyon yorumları (///) kullanılmamaktadır - temiz kod prensibi
- Customer entity'leri Entity<Guid> kullanarak sadeleştirilmiş formatta tasarlanmıştır 