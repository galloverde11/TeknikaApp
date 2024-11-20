using TeknikaApp.Constants;

namespace TeknikaApp.Models;

public class ConfigurationQuestionModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Question { get; set; }

    public int SubProductFamilyId { get; set; }
    public string SubProductFamilyName { get; set; }

    public int ParentId { get; set; }
    public string ParentName { get; set; }

    public List<ConfigurationAnswerModel> Children { get; set; }
    public string ImageUrl { get; set; }
}

public class ConfigurationAnswerModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Answer { get; set; }
    public int Rank { get; set; }

    public int ParentId { get; set; }
    public string ParentName { get; set; }
    public List<ProductConfigurationModel> ProductConfigurations { get; set; }
    public List<ConfigurationQuestionModel> Children { get; set; }

    public string ImageUrl { get; set; }
}

public class ProductConfigurationModel
{
    public int Id { get; set; }
    public string ProductConfigurationName { get; set; }
    public string Description { get; set; }
    public int ProductId { get; set; }
    public ProductModel Product { get; set; }
    public string ImageUrl { get; set; }
    public MeasureType MeasureType { get; set; }
    public bool MisureAvvolgibili { get; set; }

    public List<OptionalModel> Optionals { get; set; }
    public string CheckoutSentence { get; set; }
    public int CheckoutProductId { get; set; }
}
