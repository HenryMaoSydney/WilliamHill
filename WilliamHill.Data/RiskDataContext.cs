using System;
using System.Collections.Generic;
using WilliamHill.Data.Models;

namespace WilliamHill.Data
{
    public class RiskDataContext : IRiskDataContext
    {
        private ISettlementFileLocator _settlementFileLocator;
        public RiskDataContext(ISettlementFileLocator settlementFileLocator)
        {
            _settlementFileLocator = settlementFileLocator;
            Load();
        }

        public List<SettledBet> SettledBets { get;    set; }
        public List<UnsettledBet> UnsettledBets { get;   set; }

        // Read csv files
        private void Load()
        {
            SettledBets = new List<SettledBet>();
            UnsettledBets = new List<UnsettledBet>();
            ReadSettledBetsCSV(_settlementFileLocator.LocateSettleCsv);
            ReadUnSettledBetsCSV(_settlementFileLocator.LocateUnSettleCsv);
        }


        private void ReadSettledBetsCSV(string fileName)
        {
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(fileName);
            while ( ( line = file.ReadLine()) != null)
            {
                 var token = line.Split(new char[] { ','}, StringSplitOptions.RemoveEmptyEntries);
                if (token.Length >= 5)
                {
                    SettledBet bet = new SettledBet();
                    try
                    {
                        bet.CustomerId = int.Parse(token[0]);
                        bet.Event = int.Parse(token[1]);
                        bet.Participant = int.Parse(token[2]);
                        bet.Stake = int.Parse(token[3]);
                        bet.Win = int.Parse(token[4]);
                        SettledBets.Add(bet);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
        }

        private void ReadUnSettledBetsCSV(string fileName)
        {
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(fileName);
            while ((line = file.ReadLine()) != null)
            {
                var token = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (token.Length >= 5)
                {
                    UnsettledBet bet = new UnsettledBet();
                    try
                    {
                        bet.CustomerId = int.Parse(token[0]);
                        bet.Event = int.Parse(token[1]);
                        bet.Participant = int.Parse(token[2]);
                        bet.Stake = int.Parse(token[3]);
                        bet.ToWin = int.Parse(token[4]);
                        UnsettledBets.Add(bet);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
        }
    }
}