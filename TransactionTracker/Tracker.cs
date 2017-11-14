using System;
using UnityEngine;
using System.IO;

namespace TransactionTracker
{
    [KSPAddon(KSPAddon.Startup.MainMenu, true)]
    public class Tracker : MonoBehaviour
    {
        string filePath
        {
            get
            {
                return KSPUtil.ApplicationRootPath + "/saves/" + HighLogic.SaveFolder + "/";
            }
        }
        public void Start()
        {
            GameEvents.OnFundsChanged.Add(OnFundsChanged);
            GameEvents.OnScienceChanged.Add(OnScienceChanged);
            GameEvents.OnReputationChanged.Add(OnReputationChanged);
        }

        public void OnFundsChanged(double amount, TransactionReasons reason)
        {
            string output = string.Format("{0},{1},{2}",HighLogic.CurrentGame.UniversalTime, amount, reason);
            string fileName = "funds.csv";
            File.AppendAllText(filePath + fileName, output+System.Environment.NewLine);
        }

        public void OnScienceChanged(float amount, TransactionReasons reason)
        {
            string output = string.Format("{0},{1},{2}", HighLogic.CurrentGame.UniversalTime, amount, reason);
            string fileName = "science.csv";
            File.AppendAllText(filePath + fileName, output + System.Environment.NewLine);
        }

        public void OnReputationChanged(float amount, TransactionReasons reason)
        {
            string output = string.Format("{0},{1},{2}", HighLogic.CurrentGame.UniversalTime, amount, reason);
            string fileName = "reputation.csv";
            File.AppendAllText(filePath + fileName, output + System.Environment.NewLine);
        }
    }
}
