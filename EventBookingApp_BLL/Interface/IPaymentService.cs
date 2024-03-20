using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBookingApp_BLL.Interface
{
    public interface IPaymentService
    {
        Task<string> FundWallet(decimal paymentAmount);
    }
}
