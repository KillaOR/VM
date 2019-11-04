using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB
{
    public class Good
    {
        public int GoodID { get; set; }
        public string GoodName { get; set; }
        public int GoodPrice { get; set; }
        public int GoodCount { get; set; }
    }

    public class Coin
    {
        public int CoinID { get; set; }
        public int CoinFaceValue { get; set; }

        public VMPurse VMPurse { get; set; }
        public UserPurse UserPurse { get; set; }
    }

    public class VMPurse
    {
        public int CoinID { get; set; }
        public int Count { get; set; }

        public Coin CoinOf { get; set; }
    }

    public class UserPurse
    {
        public int CoinID { get; set; }
        public int Count { get; set; }

        public Coin CoinOf { get; set; }
    }
}
