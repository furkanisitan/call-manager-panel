# CallManagerPanel

Bu projede amaç; ASP.NET MVC'de 'Role Based Authorization' ile ilgili örnek bir demo sunmaktır. 
Bunun dışında aşağıda belirtilen kütüphanelerle ilgili kullanım örnekleri de mevcuttur.

### Kullanılan Kütüphane ve Yazılımlar  

* [Entity Framework 6.4.0](https://www.nuget.org/packages/EntityFramework/6.4.0)
* [Postsharp 6.4.7](https://www.postsharp.net/downloads/postsharp-6.4/v6.4.7)
* [FluentValidation 8.6.1](https://www.nuget.org/packages/FluentValidation/8.6.1)
* [Ninject 3.3.4](https://www.nuget.org/packages/Ninject/3.3.4)
* [Bogus 29.0.1](https://www.nuget.org/packages/Bogus/29.0.1)
* [Datatables 1.20.20](https://cdn.datatables.net/1.10.20/)

### Projede Rol Tabanlı Yetkilendirme ile İlgili Kullanım Durumları
Projede web sayfası görüntüleme ve veritabanı işlemleri için yetki kontrolü yapılmaktadır. <br>
Aynı zamanda veritabanı işlemlerinde entity nesnesinin tamamı yerine sadece belirli alanlar/sütunlar(property) için yetki kontrolü 
yapılabilmektedir. <br> 
Örneğin projede bulunan entity sınıflarından 
__[Contact](https://github.com/furkanisitan/call-manager-panel/blob/master/CallManagerPanel.Entities/Concrete/Contact.cs)__ 
sınıfının bir veritabanı nesnesi için güncelleme yapılmak istendiğinde; 
__Date__ sütununu(property) sadece __Admin__ rolünde, __Phone__ sütununu ise __Admin__ veya __Manager__ rolündeki kişiler değiştirebilir.


| İşlem  | Yetkili Roller |
| ------------- | ------------- |
| Arama güncelleme  | Tüm roller |
| İletişim bilgisi veya arama ekleme  | Tüm roller |
| İletişim bilgisi veya arama silme  | Admin, Manager |
| İletişim bilgisi tarih güncelleme  | Admin |
| İletişim bilgisi telefon güncelleme  | Admin, Manager |
| İletişim bilgisi tarih, telefon harici güncellemeler  | Tüm roller |
| Arama kaydını ekleyen kullanıcının profilini görüntüleme  | Admin |

## Demo

Projeyi [buradan](http://callmanagerpanel.filabs.xyz) test edebilirsiniz. Kullanıcı adı ve şifreler aşağıda belirtilmiştir.

| Rol  | Kullanıcı Adı | Şifre |
| ------------- | ------------- | ------------- |
| Admin  | admin  | 1234 |
| Manager  | manager  | 1234 |
| Staff  | staff  | 1234 

Not: Projenin Visual Studio'da çalıştırılabilmesi için [Visual Studio Postsharp 6.4.7](https://www.postsharp.net/downloads/postsharp-6.4/v6.4.7) eklentisinin kurulması gerekmektedir.

