📦 SmartCargo - Akıllı Kargo Yönlendirme Sistemi

🚀 Proje Amacı

SmartCargo, e-ticaret sistemleri için geliştirilen bir Web API'dir. Siparişlerin, kargo firmalarının kapasite, şehir uyumu ve teslimat süresi gibi kriterlerine göre en uygun firmaya yönlendirilmesini sağlar.

🧱 Mimarisi

Proje, Onion Architecture mimarisi ile yapılandırılmıştır:

SmartCargo.API              --> Web API (Giriş noktasy)
SmartCargo.Application      --> CQRS, MediatR, DTO'lar, Event'ler
SmartCargo.Domain           --> Entity'ler, Interface tanımları
SmartCargo.Persistence      --> DbContext, Repository
SmartCargo.Infrastructure  --> ServiceRegistration, DI ayarları

🛠️ Teknolojiler

✅ ASP.NET Core Web API

✅ Entity Framework Core + PostgreSQL

✅ CQRS & MediatR

✅ MassTransit + RabbitMQ

✅ Swagger

✅ Global Exception Middleware

✅ Docker Desteği (isteğe bağlı)

⚙️ Kurulum

1. Gerekli paketleri yükle:

dotnet restore

2. Migration uygula ve veritabanını oluştur:

dotnet ef database update --project SmartCargo.API

3. Uygulamayı çalıştır:

dotnet run --project SmartCargo.API

4. Swagger Arayüzü:

📍 http://localhost:5146/swagger

🔗 API Uç Noktaları

Metot

Endpoint

Açıklama

POST

/api/shipment

Yeni gönderi oluşturur

GET

/api/shipment

Tüm gönderileri listeler

GET

/api/shipment/{id}

Belirli gönderi detayını getirir

📡 RabbitMQ Event Mekanizması

📤 ShipmentCreatedEvent fırlatılır →🎧 ShipmentCreatedEventConsumer bu eventi dinler ve loglar.

MassTransit + RabbitMQ kullanılarak event-driven yapı kurulmuştur.

🧺 Swagger ile Test Et

Swagger arayüzü üzerinden POST/GET işlemleri yapılabilir.

Örnek Request Body:

{
  "orderNumber": "ORD-12345",
  "description": "Dizüstü Bilgisayar",
  "destinationAddress": "İstanbul",
  "address": "Kadıköy, İstanbul",
  "carrierId": "GUID",
  "weight": 3.2,
  "deliveryTimePreference": "Hızlı",
  "assignedCarrier": "Yurtiçi Kargo"
}

🧰 Ekstra Özellikler



🧑‍💻 Katkıda Bulunmak

Her türlü katkıya ve geliştirici fikrine açığım! PR gönderin, issue açın veya forka alıp kendi çözümüzü üretin 👌👊

📋 Lisans

Bu proje eğitim amaçlıdır ve serbestçe kullanılabilir. Dilerseniz üzerinde değişiklik yapabilir, projelerinize dahil edebilirsiniz.

