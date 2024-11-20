using TeknikaApp.Constants;

namespace TeknikaApp.Models;

public class CartItemModel
{
    public long Id { get; set; }
    public int Position { get; set; }
    public long UserId { get; set; }
    public int Qty { get; set; }
    public MeasureType MeasureType { get; set; }
    public decimal WidthInserted { get; set; }
    public decimal HeightInserted { get; set; }
    public string CartItemNote { get; set; }
    public string CartItemRif { get; set; }
    public string RoomName { get; set; }
    public int Discount { get; set; }
    public int DiscountAdd { get; set; }
    public decimal DiscountExtra { get; set; }
    public int TvaPercentage { get; set; }

    #region money
    public decimal UnitPrice { get; set; }
    public decimal UnitPriceManual { get; set; }
    public decimal RowPrice { get; set; }
    public decimal RowPriceDiscounted { get; set; }
    public decimal Taxes { get; set; }
    #endregion

    public long? ColorId { get; set; }
    public string ColorName { get; set; }
    public long? ColorFondaleId { get; set; }
    public string ColorFondaleName { get; set; }
    public string ColorCodeHtml { get; set; }

    public long ProductId { get; set; }
    public string ProductName { get; set; }
    public string ProductNameCustom { get; set; }
    public long? ProductConfigurationId { get; set; }

    public string ProductCode { get; set; }
    public bool PriceToEstimate { get; set; }
    public string ImageUrl { get; set; }

    public bool Mq { get; set; }
    public decimal WidthPrice { get; set; }
    public decimal HeightPrice { get; set; }

    public decimal A { get; set; }
    public decimal B { get; set; }
    public decimal C { get; set; }
    public decimal D1 { get; set; }
    public decimal D2 { get; set; }
    public decimal E { get; set; }
    public decimal F { get; set; }
    public decimal G1 { get; set; }
    public decimal G2 { get; set; }
    public decimal H { get; set; }
    public decimal I { get; set; }
    public decimal L { get; set; }
    public decimal M { get; set; }
    public decimal N { get; set; }
    public decimal S { get; set; }
    public decimal DC { get; set; }
    public decimal CN { get; set; }
    public decimal K { get; set; }

    public IEnumerable<long> OptionalSelected { get; set; }
    public IEnumerable<OptionalModel> Optionals { get; set; }
}

