using MoneyExtractor.Core;
using MoneyExtractor.Core.Entities;
using MoneyExtractor.Core.Logs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoneyExtractor.UI {
    public partial class Form1 : Form {

        public Form1() {
            InitializeComponent();
        }

        private void UxBtnPayment_Click(object sender, EventArgs e) {

            MoneyExtractorManager moneyExtractorManager = new MoneyExtractorManager();

            moneyExtractorManager.OnProcessorExecuted += moneyExtractorManager_OnProcessorExecuted;

            PaymentDataRequest paymentDataRequest = new PaymentDataRequest();
            paymentDataRequest.ProductAmountInCents = long.Parse(this.UxTxtProductAmount.Text);
            paymentDataRequest.PaidAmountInCents = long.Parse(this.UxTxtPaidAmount.Text);

            PaymentDataResponse paymentDataResponse = moneyExtractorManager.SellProduct(paymentDataRequest);
            
            this.UxTxtChange.AppendText(paymentDataResponse.Message ?? string.Empty);
            if (paymentDataResponse.ChangeData != null) {

                String changeInfo = string.Format("Valor do troco: {0}\r\n", ((decimal)paymentDataResponse.TotalAmountInCents / 100).ToString("N2"));

                foreach (KeyValuePair<ChangeType, Dictionary<long, long>> change in paymentDataResponse.ChangeData.ChangeTotalResult) {

                    foreach (KeyValuePair<long, long> item in change.Value) {

                        changeInfo += string.Format("{0} {1} de {2}\r\n", item.Value, change.Key, ((decimal)item.Key / 100).ToString("N2"));
                    }
                }

                this.UxTxtChange.AppendText(changeInfo);
            }
        }

        void moneyExtractorManager_OnProcessorExecuted(object sender, string e) {

            this.UxTxtChange.AppendText(e + Environment.NewLine);
        }
    }
}
