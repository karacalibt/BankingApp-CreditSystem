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
│   │   ├── EfRepository.cs                  ← Generic EF Core implementasyonu
│   │   └── PagedResult.cs                   ← Sayfalama sonuç modeli
│   └── BankingApp.CreditSystem.Core.csproj
├── BankingApp.CreditSystem.Domain/          ← Domain Katmanı (İş Kuralları)
│   ├── Entities/                            ← Concrete entity'ler
│   │   ├── Customer.cs                      ← Base müşteri sınıfı (Entity<Guid>)
│   │   ├── IndividualCustomer.cs            ← Bireysel müşteri
│   │   └── CorporateCustomer.cs             ← Kurumsal müşteri
│   └── BankingApp.CreditSystem.Domain.csproj
├── BankingApp.CreditSystem.Application/     ← Application Katmanı (CQRS)
│   └── BankingApp.CreditSystem.Application.csproj
├── BankingApp.CreditSystem.Persistence/     ← Persistence Katmanı (Veritabanı)
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
var repository = new EfRepository<Customer, Guid>(dbContext);

// Include ile related data
var customer = await repository.GetByIdAsync(id, 
    c => c.CreditApplications);

// Pagination ile listeleme
var pagedResult = await repository.GetPagedListAsync(
    predicate: c => c.IsActive,
    orderBy: q => q.OrderByDescending(c => c.CreatedDate),
    pageIndex: 0, pageSize: 10);
```

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

### Persistence Katmanı:
- `Microsoft.EntityFrameworkCore` (9.0.0)
- `Microsoft.EntityFrameworkCore.SqlServer` (9.0.0)
- `Microsoft.EntityFrameworkCore.Tools` (9.0.0)

### WebApi Katmanı:
- `Microsoft.EntityFrameworkCore.Design` (9.0.0)

## 📝 Geliştirme Durumu

Proje aktif geliştirme aşamasındadır. Güncel durum için `todo.md` dosyasına bakınız.

**Tamamlanma Oranı:** %17 (20/119 görev)
**Son Güncelleme:** 11/06/2025 23:03

### ✅ Tamamlanan Özellikler:
- Solution ve proje yapısı oluşturulması
- Clean Architecture katman referansları
- Base Entity sınıfı (Generic)
- Generic Repository Interface (EF Core optimized)
- Generic Repository Implementation (EfRepository)
- PagedResult pagination modeli
- Customer entity hierarchy (Individual/Corporate)
- Entity Framework Core 9.0 entegrasyonu

### 🚧 Geliştirilmekte:
- DbContext ve Entity Configurations
- CQRS pattern implementation (Application layer)
- Domain services ve business rules
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