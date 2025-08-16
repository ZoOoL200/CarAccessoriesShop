using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarAccessoriesShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_trigger_ForTotalSales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE TRIGGER trg_UpdateSaleInvoiceTotal
                             ON SalesDetails
                             AFTER INSERT, UPDATE, DELETE
                             AS
                             BEGIN
                             SET NOCOUNT ON;

                             UPDATE I
                             SET TotalAmount = 
                             (
                             SELECT ISNULL(SUM(TotalPrice), 0) FROM SalesDetails d 
                             WHERE d.InvoiceID = I.Id 
                             )
           
                             FROM SalesInvoices I
                             WHERE I.Id IN 
                             (
                             SELECT DISTINCT InvoiceID  FROM inserted
                             UNION
                             SELECT DISTINCT InvoiceID  FROM deleted
                             )
                             END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP TRIGGER IF EXISTS trg_UpdateSaleInvoiceTotal;");
        }
    }
}
