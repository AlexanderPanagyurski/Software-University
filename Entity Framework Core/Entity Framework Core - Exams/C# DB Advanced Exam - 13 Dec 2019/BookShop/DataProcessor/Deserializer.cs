namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using BookShop.XmlHelper;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            const string xmlRoot = "Books";

            var booksResult = XMLConverter.Deserializer<ImportBookDto>(xmlString, xmlRoot);

            var validBooks = new List<Book>();

            foreach (var importBookDto in booksResult)
            {
                if (!IsValid(importBookDto))
                {
                    sb.Append(ErrorMessage + Environment.NewLine);
                    continue;
                }
                DateTime publishedOn;
                bool isDateValid = DateTime.TryParseExact(importBookDto.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out publishedOn);

                if (!isDateValid)
                {
                    sb.Append(ErrorMessage + Environment.NewLine);
                    continue;
                }
                Book validBook = new Book
                {
                    Name=importBookDto.Name,
                    Genre=(Genre)importBookDto.Genre,
                    Price=importBookDto.Price,
                    Pages=importBookDto.Pages,
                    PublishedOn=publishedOn
                };
                validBooks.Add(validBook);
                sb.Append(String.Format(SuccessfullyImportedBook, validBook.Name, validBook.Price)+Environment.NewLine);
            }

            context.Books.AddRange(validBooks);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var authorsDtos = JsonConvert.DeserializeObject<ImportAuthorDto[]>(jsonString);

            var authors = new List<Author>();

            foreach (var authorDto in authorsDtos)
            {
                if (!IsValid(authorDto))
                {
                    sb.Append(ErrorMessage + Environment.NewLine);
                    continue;
                }

                if (authors.Any(a => a.Email == authorDto.Email))
                {
                    sb.Append(ErrorMessage + Environment.NewLine);
                    continue;
                }

                Author author = new Author
                {
                    FirstName=authorDto.FirstName,
                    LastName=authorDto.LastName,
                    Email=authorDto.Email,
                    Phone = authorDto.Phone,
                };

                foreach (var bookDto in authorDto.Books)
                {
                    if (!bookDto.BookId.HasValue)
                    {
                        continue;
                    }
                    Book book = context
                            .Books
                            .FirstOrDefault(b => b.Id == bookDto.BookId);

                    if (book == null)
                    {
                        continue;
                    }
                    author.AuthorsBooks.Add(new AuthorBook
                    {
                        Author = author,
                        Book = book
                    });

                    if (author.AuthorsBooks.Count == 0)
                    {
                        sb.Append(ErrorMessage + Environment.NewLine);
                        continue;
                    }

                    authors.Add(author);
                    sb.Append(String.Format(SuccessfullyImportedAuthor, $"{author.FirstName} {author.LastName}", author.AuthorsBooks.Count) + Environment.NewLine);
                }
            }
            context.Authors.AddRange(authors);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}