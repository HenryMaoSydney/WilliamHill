﻿namespace WilliamHill.Data.Models
{
    public class SettledBet
    {
        public int CustomerId { get; set; }
        public int Event { get; set; }
        public int Participant { get; set; }
        public int Stake { get; set; }
        public int Win { get; set; }

    }
}