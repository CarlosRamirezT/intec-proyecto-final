using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace intec_proyecto_final_t_3.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    StateId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: true),
                    Street2 = table.Column<string>(type: "text", nullable: true),
                    CityId = table.Column<int>(type: "integer", nullable: true),
                    StateId = table.Column<int>(type: "integer", nullable: true),
                    CountryId = table.Column<int>(type: "integer", nullable: true),
                    ZipCode = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Mobile = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    StateId = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    DateInvoice = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: DateTime.Now),
                    DateDue = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: DateTime.Now),
                    AmountUntaxed = table.Column<double>(type: "double precision", nullable: true),
                    AmountTax = table.Column<double>(type: "double precision", nullable: true),
                    AmountTotal = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoicesLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InvoiceId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Quantity = table.Column<double>(type: "double precision", nullable: false, defaultValue: 1),
                    UnitPrice = table.Column<double>(type: "double precision", nullable: false, defaultValue: 1),
                    Subtotal = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoicesLines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceStates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceStates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InvoiceId = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: DateTime.Now)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    cost = table.Column<double>(type: "double precision", nullable: true),
                    Price = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CountryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });

            migrationBuilder.Sql(@"
                create or replace view ""AddressStatesView"" as (
                    select
                    states.""Id"",
                    states.""Name"",
                    countries.""Name"" as ""Country""
                    from public.""States"" as states
                    join public.""Countries"" as countries on countries.""Id"" = states.""CountryId""
                );
            ");

            migrationBuilder.Sql(@"
                create or replace view ""CitiesView"" as (
                    select
                    cities.""Id"",
                    cities.""Name"",
                    states.""Name"" as ""State""
                    from public.""Cities"" as cities
                    join public.""States"" as states on states.""Id"" = cities.""StateId""
                );      
            ");

            migrationBuilder.Sql(@"
                create or replace view ""CustomersView"" as(
                    select
                    customer.""Id"",
                    customer.""Name"",
                    customer.""Street"",
                    customer.""Street2"",
                    city.""Name"" as ""City"",
                    state.""Name"" as ""State"",
                    customer.""ZipCode"",
                    country.""Name"" as ""Country"",
                    customer.""Phone"",
                    customer.""Mobile"",
                    customer.""Email"",
                    customer.""Note""
                    from public.""Customers"" as customer
                    join public.""Cities"" as city on customer.""CityId"" = city.""Id""
	                join public.""States"" as state on customer.""StateId"" = state.""Id""
	                join public.""Countries"" as country on customer.""CountryId"" = country.""Id""
                );
            ");

            migrationBuilder.Sql(@"
                create or replace view ""InvoicesView"" as(
                    select
                    invoice.""Id"",
                    customer.""Name"" as ""Customer"",
                    invoice.""DateInvoice"",
                    invoice.""DateDue"",
                    states.""Name"" as ""State"",
                    (select coalesce(sum(""Subtotal""), 0) from public.""InvoicesLines"" where ""InvoiceId"" = invoice.""Id"") as ""AmountUntaxed"",
	                (select coalesce(""AmountUntaxed"" * 0.18, 0)) as ""AmountTax"",
	                (select coalesce(""AmountUntaxed"" + ""AmountTax"", 0)) as ""AmountTotal"",
	                (select coalesce(sum(""Amount""), 0) from public.""Payments"" where ""InvoiceId"" = invoice.""Id"") as ""AmountPaid"",
	                (select coalesce (""AmountTotal"" - (select sum(""Amount"") from public.""Payments"" where ""InvoiceId"" = invoice.""Id""), ""AmountTotal"")) as ""AmountDue""
	                from public.""Invoices"" as invoice
                    join public.""Customers"" as customer on customer.""Id"" = invoice.""CustomerId""
	                join public.""InvoiceStates"" as states on invoice.""StateId"" = states.""Id""
                );
            ");

            migrationBuilder.Sql(@"
                create or replace view ""InvoicesLinesView"" as(
                    select
                    invoice_lines.""Id"",
                    invoice_lines.""InvoiceId"",
                    products.""Name"" as ""Product"",
                    invoice_lines.""Description"",
                    invoice_lines.""Quantity"",
                    invoice_lines.""UnitPrice"",
                    (select coalesce(invoice_lines.""Quantity"" * invoice_lines.""UnitPrice"", 0)) as ""Subtotal""
                    from public.""InvoicesLines"" as invoice_lines
                    join public.""Products"" as products on products.""Id"" = invoice_lines.""ProductId""
                );
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "InvoicesLines");

            migrationBuilder.DropTable(
                name: "InvoiceStates");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.Sql(@"
                drop view public.""AddressStatesView"";
            ");

            migrationBuilder.Sql(@"
                drop view public.""CitiesView"";
            ");

            migrationBuilder.Sql(@"
                drop view public.""CustomersView"";
            ");

            migrationBuilder.Sql(@"
                drop view public.""InvoicesView"";
            ");


            migrationBuilder.Sql(@"
                drop view public.""InvoicesLinesView"";
            ");

        }
    
    }
}
