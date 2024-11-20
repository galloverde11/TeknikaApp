using TeknikaApp.Constants;

namespace TeknikaApp.Models;

public class ProductFamilyModel
{
    public int Id { get; set; }
    public string FamilyName { get; set; }
    public string ImageUrl { get; set; }
}

public class ProductSubFamilyModel
{
    public int Id { get; set; }
    public string SubFamilyName { get; set; }
    public int ProductFamilyId { get; set; }
    public string ProductFamilyName { get; set; }
    public bool IsConfigurator { get; set; }
    public int ConfigurationQuestionId { get; set; }
    public List<ConfigurationQuestionModel> Questions { get; set; }
    public string ImageUrl { get; set; }
}

public class ProductModel
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public string ProductCode { get; set; }
    public double MinWidth { get; set; }
    public double MinHeight { get; set; }
    public double PriceMQ { get; set; }
    public double MinBillable { get; set; }
    public string DescriptionHtml { get; set; }
    public string AlertApp { get; set; }
    public List<string> ImageUrls { get; set; }
    public List<OptionalModel> Optionals { get; set; }
    public List<ColorModel> Colors { get; set; }
    public bool NoColor { get; set; }
    public bool NoOptional { get; set; }
    public PriceCalculationType PriceCalculationType { get; set; }
    public List<ProductMeasureTypeModel> ProductMeasureTypes { get; set; }
    public bool PriceToEstimate { get; set; }
}

public class ColorModel
{
    public int Id { get; set; }
    public string ColorName { get; set; }
    public int Rank { get; set; }
}

public class OptionalModel
{
    public int Id { get; set; }
    public string OptionalName { get; set; }
    public bool Mandatory { get; set; }
    public bool Hidden { get; set; }
    public int Rank { get; set; }
    public int FirstSubProductFamilyId { get; set; }
}

public class ProductMeasureTypeModel
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public MeasureType MeasureType { get; set; }
    public string MeasureTypeName { get; set; }
    public string Notification { get; set; }
}
