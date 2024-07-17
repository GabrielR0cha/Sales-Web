using SalesWebMvc.Data;
using SalesWebMvc.Models.Enums;
using SalesWebMvc.Models;

public class SeedingService
{
    private readonly SalesWebMvcContext _context;

    public SeedingService(SalesWebMvcContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        if (_context.Department.Any() || _context.Sellers.Any() || _context.SalesRecords.Any())
        {
            return; // DB has been seeded
        }

        // Departments
        Department d1 = new Department(1, "Computers");
        Department d2 = new Department(2, "Electronics");
        Department d3 = new Department(3, "Fashions");
        Department d4 = new Department(4, "Books");
        Department d5 = new Department(5, "Toys");
        Department d6 = new Department(6, "Home & Kitchen");

        // Sellers
        Seller s1 = new Seller(1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
        Seller s2 = new Seller(2, "Felipe Hayashi", "hayashii@gmail.com", new DateTime(2000, 5, 11), 1000.0, d2);
        Seller s3 = new Seller(3, "Colono", "old@gmail.com", new DateTime(1978, 1, 27), 1000.0, d1);
        Seller s4 = new Seller(4, "Rafael Langer", "rafaelanger@gmail.com", new DateTime(2004, 11, 30), 1200.0, d3);
        Seller s5 = new Seller(5, "Anna Smith", "anna@gmail.com", new DateTime(1985, 3, 17), 1100.0, d4);
        Seller s6 = new Seller(6, "John Doe", "john@gmail.com", new DateTime(1992, 9, 5), 900.0, d5);
        Seller s7 = new Seller(7, "Jane Roe", "jane@gmail.com", new DateTime(1988, 2, 10), 1300.0, d6);

        // Sales Records
        SalesRecord r1 = new SalesRecord(1, new DateTime(2024, 5, 2), 12000.0, SalesStatus.Billed, s1);
        SalesRecord r2 = new SalesRecord(2, new DateTime(2024, 5, 2), 8000.0, SalesStatus.Billed, s2);
        SalesRecord r3 = new SalesRecord(3, new DateTime(2024, 5, 3), 15000.0, SalesStatus.Pending, s3);
        SalesRecord r4 = new SalesRecord(4, new DateTime(2024, 5, 4), 7000.0, SalesStatus.Canceled, s4);
        SalesRecord r5 = new SalesRecord(5, new DateTime(2024, 6, 5), 20000.0, SalesStatus.Billed, s5);
        SalesRecord r6 = new SalesRecord(6, new DateTime(2024, 7, 7), 3000.0, SalesStatus.Pending, s6);
        SalesRecord r7 = new SalesRecord(7, new DateTime(2024, 8, 9), 17000.0, SalesStatus.Billed, s7);
        SalesRecord r8 = new SalesRecord(8, new DateTime(2024, 9, 10), 9000.0, SalesStatus.Billed, s1);
        SalesRecord r9 = new SalesRecord(9, new DateTime(2024, 10, 11), 5000.0, SalesStatus.Pending, s2);
        SalesRecord r10 = new SalesRecord(10, new DateTime(2024, 11, 12), 4000.0, SalesStatus.Canceled, s3);

        // Add Departments, Sellers and Sales Records to the context
        _context.Department.AddRange(d1, d2, d3, d4, d5, d6);
        _context.Sellers.AddRange(s1, s2, s3, s4, s5, s6, s7);
        _context.SalesRecords.AddRange(r1, r2, r3, r4, r5, r6, r7, r8, r9, r10);

        await _context.SaveChangesAsync();
    }
}
