# 📦 SmartCargo - Akıllı Kargo Yönlendirme Sistemi

## 🚀 Proje Amacı

**SmartCargo**, e-ticaret sistemleri için geliştirilen bir Web API'dir.  
Siparişlerin, kargo firmalarının **kapasite**, **şehir uyumu** ve **teslimat süresi** gibi kriterlere göre en uygun firmaya yönlendirilmesini sağlar.

---

## 🧱 Mimarisi

Proje, **Onion Architecture** prensiplerine göre katmanlı olarak yapılandırılmıştır:


---

## 🛠️ Kullanılan Teknolojiler

- ✅ ASP.NET Core Web API  
- ✅ Entity Framework Core + PostgreSQL  
- ✅ CQRS & MediatR  
- ✅ MassTransit + RabbitMQ  
- ✅ Swagger UI  
- ✅ Global Exception Middleware  
- ✅ Docker Desteği (opsiyonel)

---

## ⚙️ Kurulum

1. Gerekli NuGet paketlerini yükle:
   ```bash
   dotnet restore
2.Migration’ları veritabanına uygula:
dotnet ef database update --project SmartCargo.API
3.Uygulamayı başlat:
dotnet run --project SmartCargo.API
4.Swagger arayüzü ile test et: http://localhost:5146/swagger

🔗 API Uç Noktaları

Metot	Endpoint	Açıklama
POST	/api/shipment	Yeni gönderi oluşturur
GET	/api/shipment	Tüm gönderileri listeler
GET	/api/shipment/{id}	Gönderi detayını getirir
📡 RabbitMQ Event Mekanizması
📤 ShipmentCreatedEvent yayınlanır.

🎧 ShipmentCreatedEventConsumer, bu eventi dinler ve işlemler yapabilir.

MassTransit + RabbitMQ kullanılarak event-driven yapı kurulmuştur.

🧪 Swagger Test Örneği
json
Kopyala
Düzenle
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
 Global Exception Middleware

 Swagger UI entegrasyonu

 Event Driven yapı (MassTransit + RabbitMQ)

 Katmanlı mimari (Onion Architecture)



👩‍💻 Katkıda Bulunmak
Her türlü katkıya ve fikre açığım!
Fork'layın, issue açın veya pull request gönderin 🙌

📋 Lisans
Bu proje eğitim amaçlıdır ve tamamen özgürce kullanılabilir.
İsterseniz projelerinize dahil edebilir, geliştirebilir ya da paylaşabilirsiniz.
