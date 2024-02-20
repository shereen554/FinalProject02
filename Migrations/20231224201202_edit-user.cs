using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class edituser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    MediCine_ID = table.Column<int>(type: "int", nullable: false),
                    MediCine_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    MediCine_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    MediCine_EffectiveMaterial = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    MediCine_CoastPrice = table.Column<double>(type: "float", nullable: false),
                    MediCine_SellingPrice = table.Column<double>(type: "float", nullable: false),
                    MediCine_Availability = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    MediCine_ProductionDate = table.Column<DateTime>(type: "date", nullable: false),
                    MediCine_ExpirationDate = table.Column<DateTime>(type: "date", nullable: false),
                    MediCine_Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Medicine__29A3F3318FE0C250", x => x.MediCine_ID);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Offer_ID = table.Column<int>(type: "int", nullable: false),
                    Offer_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Offer_Discount = table.Column<double>(type: "float", nullable: false),
                    Offer_Description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Offer_Period = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Offer_StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    Offer_EndDAte = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Offers__66E8916E2908E76A", x => x.Offer_ID);
                });

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    Shift_ID = table.Column<int>(type: "int", nullable: false),
                    Shift_Day = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Shift_StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Shift_EndTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Shifts__527AD6B753DDCF0E", x => x.Shift_ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    U_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    U_Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    U_AdminID = table.Column<int>(type: "int", nullable: true),
                    U_DeliveryID = table.Column<int>(type: "int", nullable: true),
                    U_PharmacyID = table.Column<int>(type: "int", nullable: true),
                    U_CustomerID = table.Column<int>(type: "int", nullable: true),
                    U_Email = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    U_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__5A2040DB206DA6EF", x => x.U_ID);
                });

            migrationBuilder.CreateTable(
                name: "Offer_Medicine",
                columns: table => new
                {
                    Offer_ID = table.Column<int>(type: "int", nullable: false),
                    Medicine_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Offer_Me__2318814D95613585", x => new { x.Offer_ID, x.Medicine_ID });
                    table.ForeignKey(
                        name: "FK_Offer_Medicine_Medicines",
                        column: x => x.Medicine_ID,
                        principalTable: "Medicines",
                        principalColumn: "MediCine_ID");
                    table.ForeignKey(
                        name: "FK_Offer_Medicine_Offers",
                        column: x => x.Offer_ID,
                        principalTable: "Offers",
                        principalColumn: "Offer_ID");
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Customer_ID = table.Column<int>(type: "int", nullable: false),
                    Customer_BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    Customer_Gender = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Customer_Email = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Customer_Phone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Customer_Address = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    Customer_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Order_ID = table.Column<int>(type: "int", nullable: false),
                    U_CustomerID = table.Column<int>(type: "int", nullable: false),
                    Customer_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__8CB286B97F8A9188", x => x.Customer_ID);
                    table.ForeignKey(
                        name: "FK_Customer_Users_U_CustomerID",
                        column: x => x.U_CustomerID,
                        principalTable: "Users",
                        principalColumn: "U_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Delivery",
                columns: table => new
                {
                    Delivery_ID = table.Column<int>(type: "int", nullable: false),
                    Delivery_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Delivery_Address = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    Delivery_Email = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Delivery_Phone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    U_DeliveryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Delivery__AA55A01952BF9524", x => x.Delivery_ID);
                    table.ForeignKey(
                        name: "FK_Delivery_Users_U_DeliveryID",
                        column: x => x.U_DeliveryID,
                        principalTable: "Users",
                        principalColumn: "U_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pharmacy",
                columns: table => new
                {
                    Pharmacy_ID = table.Column<int>(type: "int", nullable: false),
                    Pharmacy_Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Pharmacy_Phone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Pharmacy_Email = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    U_PharmacyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Pharmacy__726449249C1FFFF4", x => x.Pharmacy_ID);
                    table.ForeignKey(
                        name: "FK_Pharmacy_Users_U_PharmacyID",
                        column: x => x.U_PharmacyID,
                        principalTable: "Users",
                        principalColumn: "U_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Delivery_shift",
                columns: table => new
                {
                    Shift_ID = table.Column<int>(type: "int", nullable: false),
                    Delivery_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Delivery__D8DF8CB62E483601", x => new { x.Shift_ID, x.Delivery_ID });
                    table.ForeignKey(
                        name: "FK_Delivery_shift_Delivery",
                        column: x => x.Delivery_ID,
                        principalTable: "Delivery",
                        principalColumn: "Delivery_ID");
                    table.ForeignKey(
                        name: "FK_Delivery_shift_Shifts",
                        column: x => x.Shift_ID,
                        principalTable: "Shifts",
                        principalColumn: "Shift_ID");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Order_ID = table.Column<int>(type: "int", nullable: false),
                    Order_Date = table.Column<DateTime>(type: "date", nullable: false),
                    Order_Price = table.Column<double>(type: "float", nullable: false),
                    Customer_ID = table.Column<int>(type: "int", nullable: false),
                    Pharmacy_ID = table.Column<int>(type: "int", nullable: false),
                    Delivery_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Orders__F1E4639B0610592F", x => x.Order_ID);
                    table.ForeignKey(
                        name: "FK_Orders_Delivery",
                        column: x => x.Delivery_ID,
                        principalTable: "Delivery",
                        principalColumn: "Delivery_ID");
                });

            migrationBuilder.CreateTable(
                name: "Pharmacy_Location",
                columns: table => new
                {
                    Pharmacy_ID = table.Column<int>(type: "int", nullable: false),
                    Pharmacy_Location = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Pharmacy__D131D73588B21F34", x => new { x.Pharmacy_ID, x.Pharmacy_Location });
                    table.ForeignKey(
                        name: "FK_Pharmacy_Location_Pharmacy",
                        column: x => x.Pharmacy_ID,
                        principalTable: "Pharmacy",
                        principalColumn: "Pharmacy_ID");
                });

            migrationBuilder.CreateTable(
                name: "Pharmacy_Medicine",
                columns: table => new
                {
                    Pharmacy_ID = table.Column<int>(type: "int", nullable: false),
                    Medicine_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Pharmacy__37945907603DEF96", x => new { x.Pharmacy_ID, x.Medicine_ID });
                    table.ForeignKey(
                        name: "FK_Pharmacy_Medicine_Medicines",
                        column: x => x.Medicine_ID,
                        principalTable: "Medicines",
                        principalColumn: "MediCine_ID");
                    table.ForeignKey(
                        name: "FK_Pharmacy_Medicine_Pharmacy",
                        column: x => x.Pharmacy_ID,
                        principalTable: "Pharmacy",
                        principalColumn: "Pharmacy_ID");
                });

            migrationBuilder.CreateTable(
                name: "Pharmacy_Offer",
                columns: table => new
                {
                    Pharmacy_ID = table.Column<int>(type: "int", nullable: false),
                    Offer_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Pharmacy__840AC032AB3E0FEB", x => new { x.Pharmacy_ID, x.Offer_ID });
                    table.ForeignKey(
                        name: "FK_Pharmacy_Offer_Offers",
                        column: x => x.Offer_ID,
                        principalTable: "Offers",
                        principalColumn: "Offer_ID");
                    table.ForeignKey(
                        name: "FK_Pharmacy_Offer_Pharmacy",
                        column: x => x.Pharmacy_ID,
                        principalTable: "Pharmacy",
                        principalColumn: "Pharmacy_ID");
                });

            migrationBuilder.CreateTable(
                name: "Customer_Order",
                columns: table => new
                {
                    Customer_ID = table.Column<int>(type: "int", nullable: false),
                    Order_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__23ACC080D66EBADD", x => new { x.Customer_ID, x.Order_ID });
                    table.ForeignKey(
                        name: "FK_Customer_Order_Customer",
                        column: x => x.Customer_ID,
                        principalTable: "Customer",
                        principalColumn: "Customer_ID");
                    table.ForeignKey(
                        name: "FK_Customer_Order_Orders",
                        column: x => x.Order_ID,
                        principalTable: "Orders",
                        principalColumn: "Order_ID");
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Invoice_ID = table.Column<int>(type: "int", nullable: false),
                    Invoice_date = table.Column<DateTime>(type: "date", nullable: false),
                    Payment_ID = table.Column<int>(type: "int", nullable: false),
                    Order_ID = table.Column<int>(type: "int", nullable: false),
                    Pharmacy_ID = table.Column<int>(type: "int", nullable: false),
                    Delivery_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Invoices__0DE60494F14439C7", x => x.Invoice_ID);
                    table.ForeignKey(
                        name: "FK_Invoices_Delivery",
                        column: x => x.Delivery_ID,
                        principalTable: "Delivery",
                        principalColumn: "Delivery_ID");
                    table.ForeignKey(
                        name: "FK_Invoices_Orders",
                        column: x => x.Order_ID,
                        principalTable: "Orders",
                        principalColumn: "Order_ID");
                    table.ForeignKey(
                        name: "FK_Invoices_Pharmacy",
                        column: x => x.Pharmacy_ID,
                        principalTable: "Pharmacy",
                        principalColumn: "Pharmacy_ID");
                });

            migrationBuilder.CreateTable(
                name: "Medicine_Order",
                columns: table => new
                {
                    Medicine_ID = table.Column<int>(type: "int", nullable: false),
                    Order_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Medicine__F01F440C5101BE57", x => new { x.Medicine_ID, x.Order_ID });
                    table.ForeignKey(
                        name: "FK_Medicine_Order_Medicines",
                        column: x => x.Medicine_ID,
                        principalTable: "Medicines",
                        principalColumn: "MediCine_ID");
                    table.ForeignKey(
                        name: "FK_Medicine_Order_Orders",
                        column: x => x.Order_ID,
                        principalTable: "Orders",
                        principalColumn: "Order_ID");
                });

            migrationBuilder.CreateTable(
                name: "Pharmacy_order",
                columns: table => new
                {
                    Pharmacy_ID = table.Column<int>(type: "int", nullable: false),
                    Order_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Pharmacy__DD7A0F1D317B69E2", x => new { x.Pharmacy_ID, x.Order_ID });
                    table.ForeignKey(
                        name: "FK_Pharmacy_order_Orders",
                        column: x => x.Order_ID,
                        principalTable: "Orders",
                        principalColumn: "Order_ID");
                    table.ForeignKey(
                        name: "FK_Pharmacy_order_Pharmacy",
                        column: x => x.Pharmacy_ID,
                        principalTable: "Pharmacy",
                        principalColumn: "Pharmacy_ID");
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Pay_ID = table.Column<int>(type: "int", nullable: false),
                    Pay_Method = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Pay_Date = table.Column<DateTime>(type: "date", nullable: false),
                    Pay_Status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Inoice_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Payment__6F137505152EC252", x => x.Pay_ID);
                    table.ForeignKey(
                        name: "FK_Payment_Invoices",
                        column: x => x.Inoice_ID,
                        principalTable: "Invoices",
                        principalColumn: "Invoice_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_U_CustomerID",
                table: "Customer",
                column: "U_CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Order_Order_ID",
                table: "Customer_Order",
                column: "Order_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_U_DeliveryID",
                table: "Delivery",
                column: "U_DeliveryID");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_shift_Delivery_ID",
                table: "Delivery_shift",
                column: "Delivery_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_Delivery_ID",
                table: "Invoices",
                column: "Delivery_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_Order_ID",
                table: "Invoices",
                column: "Order_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_Pharmacy_ID",
                table: "Invoices",
                column: "Pharmacy_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Medicine_Order_Order_ID",
                table: "Medicine_Order",
                column: "Order_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_Medicine_Medicine_ID",
                table: "Offer_Medicine",
                column: "Medicine_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Delivery_ID",
                table: "Orders",
                column: "Delivery_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_Inoice_ID",
                table: "Payment",
                column: "Inoice_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacy_U_PharmacyID",
                table: "Pharmacy",
                column: "U_PharmacyID");

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacy_Medicine_Medicine_ID",
                table: "Pharmacy_Medicine",
                column: "Medicine_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacy_Offer_Offer_ID",
                table: "Pharmacy_Offer",
                column: "Offer_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacy_order_Order_ID",
                table: "Pharmacy_order",
                column: "Order_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer_Order");

            migrationBuilder.DropTable(
                name: "Delivery_shift");

            migrationBuilder.DropTable(
                name: "Medicine_Order");

            migrationBuilder.DropTable(
                name: "Offer_Medicine");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Pharmacy_Location");

            migrationBuilder.DropTable(
                name: "Pharmacy_Medicine");

            migrationBuilder.DropTable(
                name: "Pharmacy_Offer");

            migrationBuilder.DropTable(
                name: "Pharmacy_order");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Pharmacy");

            migrationBuilder.DropTable(
                name: "Delivery");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
