﻿using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace SportShop.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Kajak",
                        Description = "Łódka przeznaczoana dla jednej osoby",
                        Category = "Sporty wodne",
                        Price = 275
                    },
                     new Product
                     {
                         Name = "Kamizelaka ratunkowa",
                         Description = "Chroni i dodaje uroku",
                         Category = "Sporty wodne",
                         Price = 48.95m
                     },
                      new Product
                      {
                          Name = "Piłka",
                          Description = "Zatwierdzoana przez fife rozmiar i waga",
                          Category = "Piłka nożna",
                          Price = 19.50m
                      },
                       new Product
                       {
                           Name = "Falgi narożne",
                           Description = "Nadadzą twoiejmu boisku profesionalny wygląd",
                           Category = "Piłka nożna",
                           Price = 34.95m
                       },
                        new Product
                        {
                            Name = "Stadion",
                            Description = "Składany stadion na 35 000 osób",
                            Category = "Piłka nożna",
                            Price = 79500
                        },
                         new Product
                         {
                             Name = "Czapka",
                             Description = "Zwieksza efektywność muzgu o 75%",
                             Category = "Szachy",
                             Price = 16
                         },
                          new Product
                          {
                              Name = "Niestabilne krzesło",
                              Description = "Zmniejsza szanse przeciwnika",
                              Category = "Szachy",
                              Price = 29.95m
                          },
                           new Product
                           {
                               Name = "Ludzka szachownica",
                               Description = "Przyjemna gra dla całej rodziny",
                               Category = "Szachy",
                               Price = 75
                           },
                            new Product
                            {
                                Name = "Błyszczący król",
                                Description = "Figura pokryta złotem i wysadzana diamentami",
                                Category = "Szachy",
                                Price = 1200
                            }

                    );
                context.SaveChanges();
            }
        }
    }
}
