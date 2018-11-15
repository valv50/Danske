using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePay
{
    public class FeeRule
    {
        #region properties
        public decimal TransactionPersantageFee { get; set; }
        public decimal TransactionPersantageFeeDiscount { get; set; }
        public decimal InvoiceFixedFee { get; set; }
        #endregion

        public FeeRule()
        { }


        public FeeRule(
            decimal transactionPersantageFee,
            decimal transactionPersantageFeeDiscount,
            decimal invoiceFixedFee)
        { 
            TransactionPersantageFee = transactionPersantageFee;
            TransactionPersantageFeeDiscount = transactionPersantageFeeDiscount;
            InvoiceFixedFee = invoiceFixedFee;
        }
    }
}
