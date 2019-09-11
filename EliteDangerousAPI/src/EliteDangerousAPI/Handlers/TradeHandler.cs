using System;
using NSW.EliteDangerous.Events;

namespace NSW.EliteDangerous.Handlers
{
    public class TradeHandler
    {
        private readonly EliteDangerousAPI _api;

        internal TradeHandler(EliteDangerousAPI api) { _api = api; }
        /// <summary>
        /// when asteroid cracked
        /// </summary>
        public event EventHandler<AsteroidCrackedEvent> AsteroidCracked;
        internal AsteroidCrackedEvent InvokeEvent(AsteroidCrackedEvent arg) { AsteroidCracked?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when buying trade data in the galaxy map
        /// </summary>
        public event EventHandler<BuyTradeDataEvent> BuyTradeData;
        internal BuyTradeDataEvent InvokeEvent(BuyTradeDataEvent arg) { BuyTradeData?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when scooping cargo from space or planet surface
        /// </summary>
        public event EventHandler<CollectCargoEvent> CollectCargo;
        internal CollectCargoEvent InvokeEvent(CollectCargoEvent arg) { CollectCargo?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when cargo was ejected
        /// </summary>
        public event EventHandler<EjectCargoEvent> EjectCargo;
        internal EjectCargoEvent InvokeEvent(EjectCargoEvent arg) { EjectCargo?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when purchasing goods in the market
        /// </summary>
        public event EventHandler<MarketBuyEvent> MarketBuy;
        internal MarketBuyEvent InvokeEvent(MarketBuyEvent arg) { MarketBuy?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when selling goods in the market
        /// </summary>
        public event EventHandler<MarketSellEvent> MarketSell;
        internal MarketSellEvent InvokeEvent(MarketSellEvent arg) { MarketSell?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when mining fragments are converted unto a unit of cargo by refinery
        /// </summary>
        public event EventHandler<MiningRefinedEvent> MiningRefined;
        internal MiningRefinedEvent InvokeEvent(MiningRefinedEvent arg) { MiningRefined?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// at startup, when loading from main menu into game 
        /// </summary>
        public event EventHandler<MaterialsEvent> Materials;
        internal MaterialsEvent InvokeEvent(MaterialsEvent arg) { Materials?.Invoke(_api, arg); return arg; }
    }
}