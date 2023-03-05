namespace RDS_Commerce.Domain.Enums;
public enum EOrderStatus : ushort
{
    UnderConstruction = 1,
    Waiting,
    PaidOut,
    InPreparation,
    Sending
}
