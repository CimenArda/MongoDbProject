# FoodMart MongoDb Projesi

FoodMart projesi,ASP.NET CORE ve MongoDB ile geliştirilmiş,UI ile Admin paneli içeren bir market  platformudur. Bu projede kullanıcıların ürünleri görüntüleyip, satışları takip edebileceği ve yöneticilerin admin panelinden  yönetimini yapabileceği bir sistem tasarlanmıştır.

## Kullanılan Teknolojiler ve Yapılar

- **ASP.NET Core (6.0)**
- **MongoDB**
- **AutoMapper**
- **MailKit** (Mail Gönderme)
- **View Components ve Areas**
- **JavaScript İşlemleri**
- **DTO Kullanımları**
- **BCrypt.Net** (Şifre Hashleme)
- **Session Management** (Oturum Yönetimi)

## Admin Paneli Özellikleri

Admin paneli üzerinden aşağıdaki işlemleri gerçekleştirebilirsiniz:

- **Login/Register**: Admin paneline giriş yapabilir veya yeni bir hesap oluşturabilirsiniz.
- **Profil Yönetimi**: Profil bilgilerinizi görüntüleyip, güncelleyebilirsiniz.
- **Şifre Güvenliği**: BCrypt.Net kütüphanesi ile şifreleriniz hashlenmiş olarak veritabanında güvenli bir şekilde saklanır.
- **Kategori ve Ürün Yönetimi**: Kategori tablosunda kategoriye ait ürünleri listeleyebilir ve ürünlerin CRUD işlemlerini yapabilirsiniz.
- **Satışlar**: Satışlar tablosunda yapılan satışları girebilir ve bu veriler UI tarafındaki **En Çok Satanlar** tablosuna dinamik olarak yansıtılır.

## UI Tarafı Özellikleri

UI tarafında kullanıcı deneyimini iyileştirmek için çeşitli dinamik özellikler eklenmiştir:

- **Arama Alanı**: Ürün arama fonksiyonu dinamik olarak çalışır.
- **Öne Çıkanlar ve İndirimler**: Öne çıkan ürünler ve indirimli ürünler listelenir.
- **Kategoriler**: Kategoriler listelenir ve kullanıcılar bir kategoriye tıkladığında, o kategoriye ait ürünler görüntülenir.
- **En Son Eklenen Ürünler**: En son eklenen 10 ürün listelenir.
- **En Çok Satanlar**: Bu tablonun içeriği dinamik olarak satış verileriyle güncellenir ve 7 üründen oluşur.
- **Mail Gönderme**: Kullanıcı, mail gönderme alanına bir e-posta girerek indirim kodu alabilir.

# Projeden Bazı Görseller
## Admin
![Ekran görüntüsü 2025-01-29 122401](https://github.com/user-attachments/assets/62de0d5b-37bc-4457-a405-2c1685eb3778)
![Ekran görüntüsü 2025-01-29 122423](https://github.com/user-attachments/assets/6a94fca3-ec68-4a02-be16-87ac58a9efad)
![Ekran görüntüsü 2025-01-29 122501](https://github.com/user-attachments/assets/90d8ce74-3704-43ef-b9b5-6cfa34ac7cf8)
![Ekran görüntüsü 2025-01-29 123608](https://github.com/user-attachments/assets/1d106e05-a035-48f1-919c-450434fa8915)
![Ekran görüntüsü 2025-01-29 122526](https://github.com/user-attachments/assets/1b75e3cf-71b4-476b-8f57-7fd60b54767f)
![Ekran görüntüsü 2025-01-29 122618](https://github.com/user-attachments/assets/0b1ca784-28e8-43fc-9006-58ed69c24cfd)
![Ekran görüntüsü 2025-01-29 122646](https://github.com/user-attachments/assets/e657a0b8-058d-4fa2-88c7-90dad99b74e8)
![Ekran görüntüsü 2025-01-29 123303](https://github.com/user-attachments/assets/d35198fc-39eb-480d-b854-0911380dbff7)

## UI
![Ekran görüntüsü 2025-01-29 122755](https://github.com/user-attachments/assets/6ae20b5b-622f-4dc1-b1cb-746e7ec56818)
![Ekran görüntüsü 2025-01-29 122824](https://github.com/user-attachments/assets/72ac336e-f74c-4292-ae2e-232a84de3a7a)
![Ekran görüntüsü 2025-01-29 122855](https://github.com/user-attachments/assets/80275279-7497-4b06-99c9-204c073cb2b9)
![Ekran görüntüsü 2025-01-29 122924](https://github.com/user-attachments/assets/fb84a27d-f43a-4702-befe-89640df373a1)
![Ekran görüntüsü 2025-01-29 123000](https://github.com/user-attachments/assets/e0f47552-5bff-4218-ab44-e6a0e2bfd20d)




























