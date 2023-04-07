namespace RDS_Commerce.Business.Extensions;
public static class DecimalForMoneyExtension
{
    public static decimal AddAmountValue(this decimal amount, int quantityProduct, decimal productValue)
    {
        return amount += productValue * quantityProduct;
    }
}
