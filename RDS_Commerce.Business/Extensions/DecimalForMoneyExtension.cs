namespace RDS_Commerce.Business.Extensions;
public static class DecimalForMoneyExtension
{
    public static decimal AddAmountValue(this decimal amount, int quantityProduct, decimal productValue)
    {
        return amount += productValue * quantityProduct;
    }

    public static decimal CreateValueOfInstallment(this decimal amount, int installmentNumber)
    {
        return amount / installmentNumber;
    }
}
