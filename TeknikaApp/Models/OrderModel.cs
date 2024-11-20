using TeknikaApp.Constants;

namespace TeknikaApp.Models;

public class OrderModel
{
    public int Id { get; set; }
    public bool Confirmed { get; set; }
    public DateTime ConfirmedDate { get; set; }
    public double Costs { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public int DdtId { get; set; }
    public int DdtNumber { get; set; }
    public DateTime DeliveryDate { get; set; }
    public DateTime DesiredDeliveryDate { get; set; }
    public int EstimationId { get; set; }
    public int EstimationNumber { get; set; }
    public DateTime GateDate { get; set; }
    public int InvoiceId { get; set; }
    public int InvoiceNumber { get; set; }
    public bool IsMq { get; set; }
    public bool IsRitiro { get; set; }
    public bool OrderAssembled { get; set; }
    public bool OrderCut { get; set; }
    public DateTime OrderDate { get; set; }
    public int OrderNumber { get; set; }
    public bool OrderPacked { get; set; }
    public string OrderRif { get; set; }
    public string OrderNote { get; set; }
    public double OrderTotal { get; set; }
    public int PackageType { get; set; }
    public string PaymentTypeName { get; set; }
    public string ShipmentTypeName { get; set; }
    public double PaymentCost { get; set; }
    public bool PaymentCostExemption { get; set; }
    public double DiscountSelf { get; set; }
    public bool DiscountSelfEnabled { get; set; }
    public double ProductsTotal { get; set; }
    public double ShipmentCost { get; set; }
    public double SubTotal { get; set; }
    public double Taxes { get; set; }
    public bool TransportExemption { get; set; }
    public bool Urgent { get; set; }
    public bool Draft { get; set; }
    public bool SelfService { get; set; }
}

public class OrderLineModel
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int OrderPosition { get; set; }
    public double Qty { get; set; }
    public double QtyLabel { get; set; }
    public int NumColli { get; set; }
    public UnityType UnityType { get; set; }
    public MeasureType MeasureType { get; set; }
    public double WidthInserted { get; set; }
    public double HeightInserted { get; set; }
    public bool OrderLineCut { get; set; }
    public bool OrderLineAssembled { get; set; }
    public bool OrderLinePacked { get; set; }
    public DateTime OrderLineCutDate { get; set; }
    public DateTime OrderLineAssembledDate { get; set; }
    public DateTime OrderLinePackedDate { get; set; }
    public string OrderLineRif { get; set; }
    public string OrderLineNote { get; set; }
    public string OrderLineNoteInternal { get; set; }
    public string RoomName { get; set; }
    public double TvaPercentage { get; set; }
    public double Discount { get; set; }
    public double DiscountAdd { get; set; }
    public bool WithoutWarranty { get; set; }
    public string AttachmentFilename { get; set; }
    public double UnitPrice { get; set; }
    public double UnitPriceManual { get; set; }
    public double RowPrice { get; set; }
    public double RowPriceDiscounted { get; set; }
    public double Taxes { get; set; }
    public double AgentCommission { get; set; }
    public int ColorId { get; set; }
    public string ColorName { get; set; }
    public string ColorCodeHtml { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string ProductNameCustom { get; set; }
    public string ProductCode { get; set; }
    public bool PriceToEstimate { get; set; }
    public List<int> OptionalSelected { get; set; }
    public List<OptionalModel> Optionals { get; set; }
    public bool Mq { get; set; }
    public string OrderLineNoteProduction { get; set; }
    public double WidthPrice { get; set; }
    public double HeightPrice { get; set; }
    public int CutterId { get; set; }
    public string CutterName { get; set; }
    public int AssemblerId { get; set; }
    public string AssemblerName { get; set; }
    public int PackerId { get; set; }
    public string PackerName { get; set; }
    public bool RequireCut { get; set; }
    public bool RequireAssembly { get; set; }
    public bool RequirePacking { get; set; }
}
