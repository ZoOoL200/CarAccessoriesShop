using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarAccessoriesShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_purchaseTrigger : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE TRIGGER trg_UpdatePurchaseInvoiceTotal
                      ON PurchaseDetails
                      AFTER INSERT, UPDATE, DELETE
                      AS
                      BEGIN
                      SET NOCOUNT ON;

                      UPDATE I
                      SET TotalAmount = 
                      (
                      SELECT ISNULL(SUM(TotalPrice), 0) FROM PurchaseDetails d 
                      WHERE d.PurchaseInvoiceId = I.Id 
                      )
    
                      FROM PurchaseInvoices I
                      WHERE I.Id IN 
                      (
                      SELECT DISTINCT PurchaseInvoiceId FROM inserted
                      UNION
                      SELECT DISTINCT PurchaseInvoiceId FROM deleted
                      )
                      END");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP TRIGGER IF EXISTS trg_UpdatePurchaseInvoiceTotal;");
        }
    }
}
