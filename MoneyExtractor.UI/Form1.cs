using MoneyExtractor.Core;
using MoneyExtractor.Core.Entities;
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

            MoneyExtractorManager moneyExtractorManger = new MoneyExtractorManager();
            PaymentDataRequest paymentDataRequest = new PaymentDataRequest();
            paymentDataRequest.ProductAmountInCents = long.Parse(this.UxTxtProductAmount.Text);
            paymentDataRequest.PaidAmountInCents = long.Parse(this.UxTxtPaidAmount.Text);

            PaymentDataResponse paymentDataResponse = moneyExtractorManger.SellProduct(paymentDataRequest);

            this.UxTxtChange.Text = paymentDataResponse.Message;
            if (paymentDataResponse.ChangeData != null) {

                String changeInfo = string.Format("Valor do troco: {0}\r\n", ((decimal)paymentDataResponse.TotalAmountInCents / 100).ToString("N2"));

                foreach (KeyValuePair<ChangeType, Dictionary<long, long>> change in paymentDataResponse.ChangeData.ChangeTotalResult) {

                    foreach (KeyValuePair<long, long> item in change.Value) {

                        changeInfo += string.Format("{0} {1} de {2}\r\n", item.Value, change.Key, ((decimal)item.Key / 100).ToString("N2"));
                    }
                }

                this.UxTxtChange.Text = this.UxTxtChange.Text + changeInfo;
            }
        }
    }
}
