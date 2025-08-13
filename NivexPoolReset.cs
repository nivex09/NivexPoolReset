using Oxide.Core.Libraries.Covalence;
using System.Collections.Generic;

namespace Oxide.Plugins
{
    [Info("Nivex Pool Reset", "nivex", "0.1.1")]
    [Description("Reset the List<Item> pool.")]
    public class NivexPoolReset : RustPlugin
    {
        private void OnServerInitialized(bool isStartup)
        {
            AddCovalenceCommand("np.reset", nameof(CommandReset));
            AddCovalenceCommand("np.info", nameof(CommandInfo));

            Puts("Use 'np.reset' to reset the List<Item> pool, or 'np.info' to show information on the List<Item> pool only.");
        }

        private void CommandReset(IPlayer user, string command, string[] args)
        {
            if (!user.IsAdmin) { user.Reply("nope."); return; }
            var c = Facepunch.Pool.FindCollection<List<Item>>();
            ShowBeforeReset(user, c);
            c.Reset();
            ShowAfterReset(user, c);
        }

        private void CommandInfo(IPlayer user, string command, string[] args)
        {
            if (!user.IsAdmin) { user.Reply("nope."); return; }
            var c = Facepunch.Pool.FindCollection<List<Item>>();
            ShowBeforeReset(user, c);
        }

        private static void ShowBeforeReset(IPlayer user, Facepunch.Pool.PoolCollection<List<Item>> c)
        {
            user.Message(string.Format("[before reset] ItemsCapacity={0} ItemsInStack={1} ItemsInUse={2} ItemsTaken={3} ItemsCreated={4} ItemsSpilled={5} MaxItemsInUse={6}", c.ItemsCapacity, c.ItemsInStack, c.ItemsInUse, c.ItemsTaken, c.ItemsCreated, c.ItemsSpilled, c.MaxItemsInUse));
            if (c.ItemsInUse < 0) user.Message("ItemsInUse is in the negative, causing items to not drop from destroyed boxes.");
        }

        private static void ShowAfterReset(IPlayer user, Facepunch.Pool.PoolCollection<List<Item>> c)
        {
            user.Message(string.Format("[after reset] ItemsCapacity={0} ItemsInStack={1} ItemsInUse={2} ItemsTaken={3} ItemsCreated={4} ItemsSpilled={5} MaxItemsInUse={6}", c.ItemsCapacity, c.ItemsInStack, c.ItemsInUse, c.ItemsTaken, c.ItemsCreated, c.ItemsSpilled, c.MaxItemsInUse));
            user.Message("List<Item> pool has been reset, loot dropped from destroyed boxes should work correctly again.");
        }
    }
}
