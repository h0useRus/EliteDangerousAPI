using System;
using NSW.EliteDangerous.API.Events;

namespace NSW.EliteDangerous.API.Handlers
{
    public class TradeHandler
    {
        private readonly API.EliteDangerousAPI _api;

        internal TradeHandler(API.EliteDangerousAPI api) { _api = api; }
        /// <summary>
        /// when asteroid cracked
        /// </summary>
        public event EventHandler<AsteroidCrackedEvent> AsteroidCracked;
        internal AsteroidCrackedEvent InvokeEvent(AsteroidCrackedEvent arg) { if(_api.ValidateEvent(arg)) AsteroidCracked?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when buying trade data in the galaxy map
        /// </summary>
        public event EventHandler<BuyTradeDataEvent> BuyTradeData;
        internal BuyTradeDataEvent InvokeEvent(BuyTradeDataEvent arg) { if(_api.ValidateEvent(arg)) BuyTradeData?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when scooping cargo from space or planet surface
        /// </summary>
        public event EventHandler<CollectCargoEvent> CollectCargo;
        internal CollectCargoEvent InvokeEvent(CollectCargoEvent arg) { if(_api.ValidateEvent(arg)) CollectCargo?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when cargo was ejected
        /// </summary>
        public event EventHandler<EjectCargoEvent> EjectCargo;
        internal EjectCargoEvent InvokeEvent(EjectCargoEvent arg) { if(_api.ValidateEvent(arg)) EjectCargo?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when purchasing goods in the market
        /// </summary>
        public event EventHandler<MarketBuyEvent> MarketBuy;
        internal MarketBuyEvent InvokeEvent(MarketBuyEvent arg) { if(_api.ValidateEvent(arg)) MarketBuy?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when selling goods in the market
        /// </summary>
        public event EventHandler<MarketSellEvent> MarketSell;
        internal MarketSellEvent InvokeEvent(MarketSellEvent arg) { if(_api.ValidateEvent(arg)) MarketSell?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when mining fragments are converted unto a unit of cargo by refinery
        /// </summary>
        public event EventHandler<MiningRefinedEvent> MiningRefined;
        internal MiningRefinedEvent InvokeEvent(MiningRefinedEvent arg) { if(_api.ValidateEvent(arg)) MiningRefined?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// at startup, when loading from main menu into game 
        /// </summary>
        public event EventHandler<MaterialsEvent> Materials;
        internal MaterialsEvent InvokeEvent(MaterialsEvent arg) { if(_api.ValidateEvent(arg)) Materials?.Invoke(_api, arg); return arg; }
    }
}