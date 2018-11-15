using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePay
{
    public class CalculateFee
    {
        #region properties
        public FeeRule standartFeeRule;
        public List<Client> Clients { get; set; }
        #endregion

        #region  methods
        public CalculateFee()
        {
            Clients = new List<Client>();
            SetFeeRules();
        }

        private void SetFeeRules()
        {
            standartFeeRule = new FeeRule(1, 0, 29);
            SetSpecificFeeRules();
        }

        private void SetSpecificFeeRules()
        {
            AddClient("TELIA", new FeeRule(1, 10, 29));
            AddClient("CIRCLE_K", new FeeRule(1, 20, 29));
        }

        private void AddClient(string clientCode, FeeRule feeRule)
        {
            Clients.Add(new Client(clientCode, feeRule));
        }

        public decimal CalculateClientFees(
            string clientCode, decimal amount)
        {
            decimal clientFees = 0;
            Client client = Clients.FirstOrDefault(
                x => x.ClientCode == clientCode);

            if (client == null)
            {
                client = new Client(clientCode, standartFeeRule);
                Clients.Add(client);
            }

            clientFees = Math.Round(
                amount * client.CurrentTransactionPersantageFee / 100
                * (100 - client.CurrentTransactionPersantageFeeDiscount) / 100
                , 2);
            if (clientFees > 0)
            {
                clientFees += client.CurrentInvoiceFixedFee;
                client.CurrentInvoiceFixedFee = 0;
            }

            return clientFees;
        }
        #endregion

    }
}
