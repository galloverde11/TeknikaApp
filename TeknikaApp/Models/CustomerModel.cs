using TeknikaApp.Constants;

namespace TeknikaApp.Models;

public class CustomerIndexModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string CustomerName { get; set; }
    public string Email { get; set; }
}

public class CustomerModel
{
    public int Id { get; set; }
    public string EmailPec { get; set; }
    public string CodeSDI { get; set; }
    public string InitialPassword { get; set; }
    public string Piva { get; set; }
    public string CodiceFiscale { get; set; }
    public string BankIban { get; set; }
    public string AgentCode { get; set; }
    public string Login { get; set; }
    public double Discount { get; set; }
    public double DiscountAdd { get; set; }
    public List<CustDiscountModel> CustDiscounts { get; set; }
    public List<AddressModel> Addresses { get; set; }
    public List<PhoneNumberModel> PhoneNumbers { get; set; }
    public string PaymentTypeName { get; set; }
}

public class CustDiscountModel
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public double Discount { get; set; }
    public double DiscountAdd { get; set; }
}

public class AddressModel
{
    public int Id { get; set; }
    public AddressType AddressType { get; set; }
    public string StreetName { get; set; }
    public string StreetNumber { get; set; }
    public string ZipCode { get; set; }
    public string City { get; set; }
    public string ProvinceCode { get; set; }
    public string CountryCode { get; set; }
}

public class PhoneNumberModel
{
    public int Id { get; set; }
    public string Number { get; set; }
    public string NumberDescription { get; set; }
    public NumberType NumberType { get; set; }
}
