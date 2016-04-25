using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication.DAL
{
    public class StoreInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<StoreContext>
    {
        protected override void Seed(StoreContext context)
        {
            var books = new List<Book>
            {
                new Book() {BookTitle = "Title1", ISBN="ABC123"},
                new Book() {BookTitle = "Title2", ISBN="DEF456"},

            };
            books.ForEach(b => context.Books.Add(b));
            context.SaveChanges();

            var authors = new List<Author>()
            {
                new Author() {AuthorName = "Name1", AuthorSurname = "Surname1"},
                new Author() {AuthorName= "Name2", AuthorSurname = "Surname2"}
            };
            authors.ForEach(a => context.Authors.Add(a));
            context.SaveChanges();
      
        }
    }
}