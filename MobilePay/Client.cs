using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePay
{
    public class Client
    {
        public string ClientCode {get;set;}
        public FeeRule Rule { get; set; }
        public decimal CurrentTransactionPersantageFee { get; set; }
        public decimal CurrentTransactionPersantageFeeDiscount { get; set; }
        public decimal CurrentInvoiceFixedFee { get; set; }

        public Client(string clientCode, FeeRule feeRule)
        {
            ClientCode = clientCode;
            Rule = feeRule;
            SetFeesByRule();
        }

        public void SetFeesByRule()
        { 
            CurrentTransactionPersantageFee = Rule.TransactionPersantageFee;
            CurrentTransactionPersantageFeeDiscount = Rule.TransactionPersantageFeeDiscount;
            CurrentInvoiceFixedFee = Rule.InvoiceFixedFee;
        }

        void SetCurrentInvoiceFixedFee(decimal invoiceFixedFee)
        {
            CurrentInvoiceFixedFee = invoiceFixedFee;
        }
    }
}
