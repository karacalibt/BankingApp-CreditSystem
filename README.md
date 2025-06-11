# 🏦 Banking Credit System

**Banking Credit System** - .NET Core 9 ve Clean Architecture ile geliştirilmiş modern bankacılık kredilendirme sistemi

## 📋 Proje Tanımı

Bu proje, modern bankacılık sektörü için geliştirilmiş bir **kredilendirme sistemi**dir. Sistem, müşterilerin kredi başvurularını değerlendirme, kredi skorlarını hesaplama, risk analizi yapma ve otomatik kredi onay/red kararları verme süreçlerini dijitalleştirmektedir.

## 🛠️ Teknoloji Stack

- **Framework:** .NET Core 9
- **Programlama Dili:** C#
- **Mimari:** Clean Architecture (Temiz Mimari)
- **Pattern:** CQRS (Command Query Responsibility Segregation)
- **ORM:** Entity Framework Core
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
│   │   └── Entity.cs                        ← Base Entity sınıfı (Generic)
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

- ✅ Müşteri bilgileri yönetimi (Bireysel & Kurumsal)
- ✅ Kredi başvurusu oluşturma ve takibi
- ⏳ Otomatik kredi skoru hesaplama (Geliştirme aşamasında)
- ⏳ Risk analizi ve değerlendirme (Geliştirme aşamasında)
- ⏳ Otomatik onay/red algoritması (Geliştirme aşamasında)
- ⏳ Kredi limiti ve faiz oranı belirleme (Geliştirme aşamasında)
- ⏳ Başvuru durumu real-time takibi (Geliştirme aşamasında)
- ⏳ Kapsamlı raporlama ve analitik (Geliştirme aşamasında)
- ⏳ RESTful API desteği (Geliştirme aşamasında)
- ⏳ Güvenli authentication ve authorization (Geliştirme aşamasında)

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

- .NET 9 SDK
- SQL Server (LocalDB desteklenir)
- Visual Studio 2022 veya Visual Studio Code

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

## 📝 Geliştirme Durumu

Proje aktif geliştirme aşamasındadır. Güncel durum için `todo.md` dosyasına bakınız.

**Tamamlanma Oranı:** %13 (15/119 görev)

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