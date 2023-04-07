using RDS_Commerce.ApplicationServices.Dtos.Request.BillingRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDS_Commerce.ApplicationServices.Handlers.Builders.CreditCard;
public sealed class CreditCardHolderInfoBuilder
{
    private string _name = "";
    private string _email = "";
    private string _cpfCnpj = "";
    private string _postalCode = "";
    private string _addressNumber = "";
    private string _addressComplement = "";
    private string _phone = "";
    private string _mobilePhone = "";

    public static CreditCardHolderInfoBuilder NewObject() => new();

    public CreditCardHolderInfoRequest DomainRequest() =>
        new()
        {
            Name = _name,
            CpfCnpj = _cpfCnpj,
            Phone = _phone,
            Email = _email,
            AddressNumber = _addressNumber,
            MobilePhone = _mobilePhone,
            PostalCode = _postalCode,
            AddressComplement = _addressComplement
        };


    public CreditCardHolderInfoBuilder WithName(string name)
    {
        if (name.Length > 0)
            _name = name;

        return this;
    }

    public CreditCardHolderInfoBuilder WithCpfCnpj(string cpfOrCnpj)
    {
        if (cpfOrCnpj.Length > 0)
            _cpfCnpj = cpfOrCnpj;

        return this;
    }

    public CreditCardHolderInfoBuilder WithPhone(string phone)
    {
        if (phone.Length > 0)
            _phone = phone;

        return this;
    }

    public CreditCardHolderInfoBuilder WithMobilePhone(string mobilePhone)
    {
        if (mobilePhone.Length > 0)
            _mobilePhone = mobilePhone;

        return this;
    }

    public CreditCardHolderInfoBuilder WithEmail(string email)
    {
        if (email.Length > 0)
            _email = email;

        return this;
    }

    public CreditCardHolderInfoBuilder WithPostalCode(string postalCode)
    {
        if (postalCode.Length > 0)
            _postalCode = postalCode;

        return this;
    }

    public CreditCardHolderInfoBuilder WithAddressNumber(string number)
    {
        if (number.Length > 0)
            _addressNumber = number;

        return this;
    }

    public CreditCardHolderInfoBuilder WithAddressComplement(string addressComplement)
    {
        if (addressComplement.Length > 0)
            _addressComplement = addressComplement;

        return this;
    }
}
