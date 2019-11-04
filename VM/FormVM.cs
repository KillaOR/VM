using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DB;

namespace VM
{
    public partial class FormVM : Form
    {
        int Deposit { get; set; }

        public FormVM()
        {
            InitializeComponent();

            LoadUserPurse();
            LoadVMPurse();
            LoadGoods();           
        }

        /// <summary>
        /// Загрузка отображение кошелька пользователя.
        /// </summary>
        void LoadUserPurse()
        {
            Context db = new Context();
            var userPurse = (from u in db.UserPurse
                             join c in db.Coin
                             on u.CoinID equals c.CoinID
                             orderby c.CoinFaceValue
                             select new { u.CoinID, u.Count, c.CoinFaceValue })
                             .ToList();

            for (int i = 0; i < userPurse.Count; i++)
            {
                int pointButtonX = 12;
                int poinButtontY = 22 + (i * 76);
                Button buttonUserPurse = new Button()
                {
                    Name = String.Format("buttonUserPurse{0}", i + 1),
                    Text = String.Format("{0} руб.", userPurse[i].CoinFaceValue),
                    Tag = userPurse[i].CoinID,
                    Size = new Size(70, 70),
                    Location = new Point(pointButtonX, poinButtontY),
                };
                if (userPurse[i].Count == 0)
                    buttonUserPurse.Enabled = false;
                buttonUserPurse.Click += ButtonUserPurse_Click;
                groupBoxUserPurse.Controls.Add(buttonUserPurse);

                int pointLabelX = 88;
                int pointLabelY = 51 + (i * 76);
                Label labelUserPurse = new Label()
                {
                    Name = String.Format("labelUserPurse{0}", i + 1),
                    Text = String.Format("{0} шт.", userPurse[i].Count),
                    Location = new Point(pointLabelX, pointLabelY)
                };
                groupBoxUserPurse.Controls.Add(labelUserPurse);
            }
        }

        /// <summary>
        /// Загрузка и отображение кошелька VM.
        /// </summary>
        void LoadVMPurse()
        {
            Context db = new Context();
            var vmPurse = (from v in db.VMPurse
                           join c in db.Coin
                           on v.CoinID equals c.CoinID
                           orderby c.CoinFaceValue
                           select new { v.Count, c.CoinFaceValue })
                           .ToList();

            for (int i = 0; i < vmPurse.Count; i++)
            {
                int pointLabelX = 6;
                int pointLabelY = 30 + (i * 22);
                Label labelVMPurse = new Label()
                {
                    Name = String.Format("labelVMPurse{0}", i + 1),
                    Text = String.Format("{0} руб. - {1} шт.", vmPurse[i].CoinFaceValue, vmPurse[i].Count),
                    Location = new Point(pointLabelX, pointLabelY)
                };
                groupBoxVMPurse.Controls.Add(labelVMPurse);
            }
        }

        /// <summary>
        /// Загрузка и отображение товаров.
        /// </summary>
        void LoadGoods()
        {
            Context db = new Context();
            var goods = db.Good.ToList();

            for (int i = 0; i < goods.Count; i++)
            {
                int pointButtonX = 12;
                int poinButtontY = 22 + (i * 76);
                Button buttonGood = new Button()
                {
                    Name = String.Format("buttonGood{0}", i + 1),
                    Text = String.Format("{0}\n{1} руб.", goods[i].GoodName, goods[i].GoodPrice),
                    Tag = goods[i].GoodID,
                    Size = new Size(70, 70),
                    Location = new Point(pointButtonX, poinButtontY)
                };
                buttonGood.Click += ButtonGood_Click;
                if (goods[i].GoodCount == 0)
                    buttonGood.Enabled = false;
                groupBoxGoods.Controls.Add(buttonGood);

                int pointLabelX = 88;
                int pointLabelY = 51 + (i * 76);
                Label labelGood = new Label()
                {
                    Name = String.Format("labelGood{0}", i + 1),
                    Text = String.Format("{0} шт.", goods[i].GoodCount),
                    Location = new Point(pointLabelX, pointLabelY)
                };
                groupBoxGoods.Controls.Add(labelGood);
            }
        }

        private void ButtonGood_Click(object sender, EventArgs e)
        {
            Button buttonGood = sender as Button;
            string numberOfButton = buttonGood.Name.Replace("buttonGood", "");
            int goodID = Convert.ToInt32(buttonGood.Tag);

            Context db = new Context();
            var good = db.Good.Find(goodID);

            if (Deposit < good.GoodPrice)
            {
                MessageBox.Show("Недостаточно средств");
                return;
            }

            good.GoodCount--;
            db.SaveChanges();

            if (good.GoodCount == 0)
                buttonGood.Enabled = false;
            groupBoxGoods.Controls["labelGood" + numberOfButton].Text =
                String.Format("{0} шт.", good.GoodCount);

            Deposit -= good.GoodPrice;
            ChangeDepositText();

            MessageBox.Show("Спасибо!");
        }

        /// <summary>
        /// Обновить отображенную внесенную сумму на форме.
        /// </summary>
        void ChangeDepositText()
        {
            labelDeposit.Text = String.Format("Внесенная сумма {0} руб.", Deposit);
        }

        private void ButtonUserPurse_Click(object sender, EventArgs e)
        {
            Button buttonUserPurse = sender as Button;
            string numberOfButton = buttonUserPurse.Name.Replace("buttonUserPurse", "");
            int coinID = Convert.ToInt32(buttonUserPurse.Tag);

            Context db = new Context();
            var userCoin = db.UserPurse.Find(coinID);
            userCoin.Count--;

            if (userCoin.Count == 0)
                buttonUserPurse.Enabled = false;
            groupBoxUserPurse.Controls["labelUserPurse" + numberOfButton].Text =
                String.Format("{0} шт.", userCoin.Count);

            var faceValue = db.Coin.Find(coinID);
            Deposit += faceValue.CoinFaceValue;
            ChangeDepositText();

            var vmCoin = db.VMPurse.Find(coinID);
            vmCoin.Count++;

            groupBoxVMPurse.Controls["labelVMPurse" + numberOfButton].Text =
                String.Format("{0} руб. - {1} шт.", faceValue.CoinFaceValue, vmCoin.Count);

            db.SaveChanges();
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            Context db = new Context();
            var vmPurse = (from v in db.VMPurse
                           join c in db.Coin
                           on v.CoinID equals c.CoinID
                           orderby c.CoinFaceValue descending
                           select new { v.CoinID, v.Count, c.CoinFaceValue })
                            .ToList();

            for (int i = 0; i < vmPurse.Count; i++)
            {
                int faceValue = vmPurse[i].CoinFaceValue;
                int needAmountCoins = Deposit / faceValue;

                if (needAmountCoins > vmPurse[i].Count)
                    needAmountCoins = vmPurse[i].Count;

                Deposit -= needAmountCoins * faceValue;

                var coinsInVM = db.VMPurse.Find(vmPurse[i].CoinID);
                coinsInVM.Count -= needAmountCoins;

                var coinsUser = db.UserPurse.Find(vmPurse[i].CoinID);
                coinsUser.Count += needAmountCoins;

                db.SaveChanges();
            }

            ChangeDepositText();

            ReLoadUserPurse();
            ReLoadVMPurse();

            if (Deposit > 0)
                MessageBox.Show("В автомате недостаточно монет для сдачи.\n" +
                    "Для получения остатка обратитесь в службу поддержки.\n" +
                    "А лучше добавьте еще монет и купите что-нибудь :)");
        }

        /// <summary>
        /// Обновить кошелек пользователя на форме.
        /// </summary>
        void ReLoadUserPurse()
        {
            Context db = new Context();
            var userPurse = (from u in db.UserPurse
                             join c in db.Coin
                             on u.CoinID equals c.CoinID
                             orderby c.CoinFaceValue
                             select u.Count)
                            .ToList();

            for (int i = 0; i < userPurse.Count; i++)
            {
                groupBoxUserPurse.Controls["labelUserPurse" + (i + 1)].Text =
                    String.Format("{0} шт.", userPurse[i]);

                if (userPurse[i] == 0)
                    groupBoxUserPurse.Controls["buttonUserPurse" + (i + 1)].Enabled = false;
                else
                    groupBoxUserPurse.Controls["buttonUserPurse" + (i + 1)].Enabled = true;

            }
        }

        /// <summary>
        /// Обновить кошелек VM на форме.
        /// </summary>
        void ReLoadVMPurse()
        {
            Context db = new Context();
            var vmPurse = (from v in db.VMPurse
                           join c in db.Coin
                           on v.CoinID equals c.CoinID
                           orderby c.CoinFaceValue
                           select new { v.Count, c.CoinFaceValue })
                            .ToList();

            for (int i = 0; i < vmPurse.Count; i++)
            {
                groupBoxVMPurse.Controls["labelVMPurse" + (i + 1)].Text =
                    String.Format("{0} руб. - {1} шт.", vmPurse[i].CoinFaceValue, vmPurse[i].Count);
            }
        }
    }
}
