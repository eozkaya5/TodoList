using ConsoleApp1.entities;
using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            TodoContext context = new TodoContext();


            //User user = new User
            //{
            //    Name = "Can",
            //    SurName = "KILIC",
            //    UserName = "can",
            //    Password = "123"
            //};
            //context.Users.Add(user);
            //context.SaveChanges();


            //Todo todo = new Todo
            //{
            //    Isim = "Filmler",
            //    Aciklama = "izlenecek filmler",
            //    OlusturmaTarihi = DateTime.Now,
            //    KullaniciId = user.Id

            //};
            //context.Todos.Add(todo);
            //context.SaveChanges();



            //TodoItem item1 = new TodoItem
            //{
            //    Durum = false,
            //    Isim = "Gora",
            //    Aciklama = "Cem Yılmaz Filmi",
            //    Oluşturmatarihi = DateTime.Now,
            //    TodoId = todo.Id
            //};


            //TodoItem item2 = new TodoItem
            //{
            //    Durum = false,
            //    Isim = "Arog",
            //    Aciklama = "Cem Yılmaz Filmi",
            //    Oluşturmatarihi = DateTime.Now,
            //    TodoId = todo.Id
            //};

            //context.TodoItems.Add(item1);
            //context.TodoItems.Add(item2);
            //context.SaveChanges();

            User user = context.Users.FirstOrDefault(x => x.UserName == "can");

            var KullanıcınınLıstelerı = context.Todos.Where(x => x.KullaniciId == user.Id).ToList();


            Console.WriteLine(user.UserName);

            foreach (var item in KullanıcınınLıstelerı)
            {
                Console.WriteLine(item.Isim);
            }
            var todoİtems = context.TodoItems.Where(x => x.TodoId == KullanıcınınLıstelerı[0].Id).ToList();

            foreach (var item in todoİtems)
            {
                Console.WriteLine(item.Isim);

            }



            Console.ReadLine();
        }
    }
}
