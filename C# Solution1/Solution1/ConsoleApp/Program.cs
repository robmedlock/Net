﻿//using ClassLibrary.Repository.EF;
using ClassLibrary.Repository.Sql;
using System;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            new ClassLibrary.Repository.EF.ProductRepository(
                new ClassLibrary.Repository.EF.EcommerceContext()).SelectAll().ToList().ForEach(p => Console.WriteLine(p.Name));
            
            //string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=ecommerce;User ID=sa;Password=carpond";
            //new ClassLibrary.Repository.Sql.SqlProductRepository(connectionString).SelectAll().ToList().ForEach(p => Console.WriteLine(p.Name));
        }
    }
}