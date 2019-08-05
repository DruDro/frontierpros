using System;
using System.Collections.Generic;
using System.Text;

namespace FrontierPros.Services.Customers
{
    public interface ISmsProviderService
    {
        bool SendSms(string phoneNumber, string text, object settings = null);
    }
}
