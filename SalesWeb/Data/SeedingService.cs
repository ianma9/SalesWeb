using SalesWeb.Models;
using SalesWeb.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWeb.Data
{
    public class SeedingService
    {
        private SalesWebContext _context;

        public SeedingService(SalesWebContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() ||
                _context.Seller.Any() ||
                _context.SalesRecord.Any())
            {
                return; // DB has been seeded
            }

            Department d1 = new Department() { Name = "Computers" };
            Department d2 = new Department() { Name = "Electronics" };
            Department d3 = new Department() { Name = "Fashion" };
            Department d4 = new Department() { Name = "Books" };



            Seller s1 = new Seller() { Name = "Bob Brown", Email = "bob@gmail.com", BirthDate = new DateTime(1998, 4, 21), BaseSalary = 1000.0, Department = d1 };
            Seller s2 = new Seller() { Name = "Maria Green", Email = "maria@gmail.com", BirthDate = new DateTime(1979, 12, 31), BaseSalary = 3500.0, Department = d2 };
            Seller s3 = new Seller() { Name = "Alex Grey", Email = "alex@gmail.com", BirthDate = new DateTime(1988, 1, 15), BaseSalary = 2200.0, Department = d1 };
            Seller s4 = new Seller() { Name = "Martha Red", Email = "martha@gmail.com", BirthDate = new DateTime(1993, 11, 30), BaseSalary = 3000.0, Department = d4 };
            Seller s5 = new Seller() { Name = "Donald Blue", Email = "donald@gmail.com", BirthDate = new DateTime(2000, 1, 9), BaseSalary = 4000.0, Department = d3 };
            Seller s6 = new Seller() { Name = "Alex Pink", Email = "bob@gmail.com", BirthDate = new DateTime(1997, 3, 4), BaseSalary = 3000.0, Department = d2 };



            SalesRecord r1 = new SalesRecord() { Date = new DateTime(2018, 09, 25), Amount = 11000.0, Status = SaleStatus.Billed, Seller = s1 };
            SalesRecord r2 = new SalesRecord() { Date = new DateTime(2018, 09, 25), Amount = 12000.0, Status = SaleStatus.Billed, Seller = s2 };

            _context.Department.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6);

            _context.SalesRecord.AddRange(r1, r2 );

            _context.SaveChanges();
        }
    }
}
