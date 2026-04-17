using Il2Cpp;

namespace DNFC_Redux_Library
{
    /// <summary>
    /// Library class for economy-related mod functionality.
    /// </summary>
    public class EconomyLib
    {
        
        public EconomyLib()
        {
            
        }
        public readonly Util _utility = CoreLib.Utility;
        public int GetBankBalance()
        {
            _utility.LogMessage($"EconomyLib: Current bank balance is {BankManager.BankBalance}.");
            return BankManager.BankBalance;
        }
        public void AddBankBalance(int bankBalance)
        {
            BankManager.AdjustBankBalance(bankBalance);
            _utility.LogMessage($"EconomyLib: Added {bankBalance} to bank balance. New balance is {BankManager.BankBalance}.");
        }
    }
}