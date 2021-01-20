using System;

namespace SwedbankPay.Sdk
{
    public interface IIdentifiable
    {
        Uri Id { get; }
    }
}