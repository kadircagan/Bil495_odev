# Bil495_odev

Hocam mikrofonum bozulduğu için maalesef sesli video çekemiyorum onun yerine burdan yazmaya çalışacağım. Öncelikle uygulamaya bakalım.
Sondaki verelieri yolladı ve her yeni veri gelişi olduğunda burayı güncelliyoruz. Aynı zamanda unitiyde de yeni verisi olup
olmadığını kontrol ediyoruz. Deprem verileri genis aralıklarla geldiği için bu videoda gösteremiycem ama denedim. Periodu
ayarlamak için orayı kullanıyoruz consolda da 1 dkde bir arama yaptığını görebiliriz. Burada bir root result list 
tutuyor. Deprem verilerini çekip objeye dönüştürüyorum. STartta ilk defa geliyosa son 3ünü de veritabanınıa yazması için first time değişkenimi 
true yapıyorum. Send to sql hocamızın attığı dökümandaki kodun biraz değiştirilmiş hali. Set datada da veriyi güncelliyorum ve yeni veri
girişi olduysa veritabanıa yazıyorum. Bu kodu internetten bakarak yazdım. Url ile iletişime geçip verileri çekiyoruz.
Son olarak da updatenin içnde period kontrolü yaparak getdata methodunu çağarıyoruz.

https://youtu.be/j8_0HVOfH1Y
