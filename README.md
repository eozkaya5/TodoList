# TodoList



Projenin çalışabilmesi için öncelikle veri tabanı ekliyoruz.
Visual Studio programında ki menüden Tools > NuGet Package Maneger > Package Manager Console açıyoruz.

Açılan sayfaya login için;
"add-migration init -context AppDbContext" ekliyoruz. (init ismini istediğiniz gibi değiştirebilirsiniz)
" update-database -context AppDbContext" güncelleyerek veri tabanını ekliyoruz.

Versiye defteri için;
"add-migration init -context "TodoDbContext" ekliyoruz. (init ismini istediğiniz gibi değiştirebilirsiniz)
" update-database -context "TodoDbContext" güncelleyerek veri tabanını ekliyoruz.

Son olarak appstring.json sayfasındaki ConnectionString 'i değiştir.

Şifremi Unuttum ? için;
Security Controller'daki PasswordReset' daki E-mail değiştirip, https://myaccount.google.com/u/2/lesssecureapps
linke tıkla ve ardından daha az güvenli uygulamalara izin ver kısmını aç.

F5 veya Debug > Start Debugging tıklayarak projeyi çalıştırıyoruz.

