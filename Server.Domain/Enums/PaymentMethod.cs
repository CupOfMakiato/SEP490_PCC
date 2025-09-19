using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Enums
{
    public enum PaymentMethod
    {
        Unknown,
        CreditCard,
        DebitCard,
        BankTransfer,
        QRCode,
        EWallet
    }
}
