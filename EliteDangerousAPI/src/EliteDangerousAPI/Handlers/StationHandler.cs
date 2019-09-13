using System;
using NSW.EliteDangerous.Events;

namespace NSW.EliteDangerous.Handlers
{
    public class StationHandler
    {
        private readonly EliteDangerousAPI _api;

        internal StationHandler(EliteDangerousAPI api) { _api = api; }
        /// <summary>
        /// when purchasing ammunition
        /// </summary>
        public event EventHandler<BuyAmmoEvent> BuyAmmo;
        internal BuyAmmoEvent InvokeEvent(BuyAmmoEvent arg) { BuyAmmo?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when purchasing drones
        /// </summary>
        public event EventHandler<BuyDronesEvent> BuyDrones;
        internal BuyDronesEvent InvokeEvent(BuyDronesEvent arg) { BuyDrones?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when collecting or delivering cargo for a wing mission, or if a wing member updates progress
        /// </summary>
        public event EventHandler<CargoDepotEvent> CargoDepot;
        internal CargoDepotEvent InvokeEvent(CargoDepotEvent arg) { CargoDepot?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when checking the status of a community goal
        /// </summary>
        public event EventHandler<CommunityGoalEvent> CommunityGoal;
        internal CommunityGoalEvent InvokeEvent(CommunityGoalEvent arg) { CommunityGoal?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when opting out of a community goal 
        /// </summary>
        public event EventHandler<CommunityGoalDiscardEvent> CommunityGoalDiscard;
        internal CommunityGoalDiscardEvent InvokeEvent(CommunityGoalDiscardEvent arg) { CommunityGoalDiscard?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when signing up to a community goal 
        /// </summary>
        public event EventHandler<CommunityGoalJoinEvent> CommunityGoalJoin;
        internal CommunityGoalJoinEvent InvokeEvent(CommunityGoalJoinEvent arg) { CommunityGoalJoin?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when receiving a reward for a community goal
        /// </summary>
        public event EventHandler<CommunityGoalRewardEvent> CommunityGoalReward;
        internal CommunityGoalRewardEvent InvokeEvent(CommunityGoalRewardEvent arg) { CommunityGoalReward?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when offering items cash or bounties to an Engineer to gain access
        /// </summary>
        public event EventHandler<EngineerContributionEvent> EngineerContribution;
        internal EngineerContributionEvent InvokeEvent(EngineerContributionEvent arg) { EngineerContribution?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when requesting an engineer upgrade
        /// </summary>
        public event EventHandler<EngineerCraftEvent> EngineerCraft;
        internal EngineerCraftEvent InvokeEvent(EngineerCraftEvent arg) { EngineerCraft?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when a player increases their access to an engineer
        /// </summary>
        public event EventHandler<EngineerProgressEvent> EngineerProgress;
        internal EngineerProgressEvent InvokeEvent(EngineerProgressEvent arg) { EngineerProgress?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when requesting a module is transferred from storage at another station 
        /// </summary>
        public event EventHandler<FetchRemoteModuleEvent> FetchRemoteModule;
        internal FetchRemoteModuleEvent InvokeEvent(FetchRemoteModuleEvent arg) { FetchRemoteModule?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when requesting a module is transferred from storage at another station 
        /// </summary>
        public event EventHandler<MarketEvent> Market;
        internal MarketEvent InvokeEvent(MarketEvent arg) { Market?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when putting multiple modules into storage 
        /// </summary>
        public event EventHandler<MaterialTradeEvent> MaterialTrade;
        internal MaterialTradeEvent InvokeEvent(MaterialTradeEvent arg) { MaterialTrade?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when exchanging materials at the Material trader contact  
        /// </summary>
        public event EventHandler<MassModuleStoreEvent> MassModuleStore;
        internal MassModuleStoreEvent InvokeEvent(MassModuleStoreEvent arg) { MassModuleStore?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when a mission has been abandoned 
        /// </summary>
        public event EventHandler<MissionAbandonedEvent> MissionAbandoned;
        internal MissionAbandonedEvent InvokeEvent(MissionAbandonedEvent arg) { MissionAbandoned?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when starting a mission
        /// </summary>
        public event EventHandler<MissionAcceptedEvent> MissionAccepted;
        internal MissionAcceptedEvent InvokeEvent(MissionAcceptedEvent arg) { MissionAccepted?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when a mission is completed
        /// </summary>
        public event EventHandler<MissionCompletedEvent> MissionCompleted;
        internal MissionCompletedEvent InvokeEvent(MissionCompletedEvent arg) { MissionCompleted?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when a mission has failed
        /// </summary>
        public event EventHandler<MissionFailedEvent> MissionFailed;
        internal MissionFailedEvent InvokeEvent(MissionFailedEvent arg) { MissionFailed?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when a mission has failed
        /// </summary>
        public event EventHandler<MissionRedirectedEvent> MissionRedirected;
        internal MissionRedirectedEvent InvokeEvent(MissionRedirectedEvent arg) { MissionRedirected?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when buying a module in outfitting 
        /// </summary>
        public event EventHandler<ModuleBuyEvent> ModuleBuy;
        internal ModuleBuyEvent InvokeEvent(ModuleBuyEvent arg) { ModuleBuy?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when fetching a previously stored module 
        /// </summary>
        public event EventHandler<ModuleRetrieveEvent> ModuleRetrieve;
        internal ModuleRetrieveEvent InvokeEvent(ModuleRetrieveEvent arg) { ModuleRetrieve?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when selling a module in outfitting 
        /// </summary>
        public event EventHandler<ModuleSellEvent> ModuleSell;
        internal ModuleSellEvent InvokeEvent(ModuleSellEvent arg) { ModuleSell?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when selling a module in storage at another station 
        /// </summary>
        public event EventHandler<ModuleSellRemoteEvent> ModuleSellRemote;
        internal ModuleSellRemoteEvent InvokeEvent(ModuleSellRemoteEvent arg) { ModuleSellRemote?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when storing a module in Outfitting 
        /// </summary>
        public event EventHandler<ModuleStoreEvent> ModuleStore;
        internal ModuleStoreEvent InvokeEvent(ModuleStoreEvent arg) { ModuleStore?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when moving a module to a different slot on the ship 
        /// </summary>
        public event EventHandler<ModuleSwapEvent> ModuleSwap;
        internal ModuleSwapEvent InvokeEvent(ModuleSwapEvent arg) { ModuleSwap?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when accessing the outfitting menu  
        /// </summary>
        public event EventHandler<OutfittingEvent> Outfitting;
        internal OutfittingEvent InvokeEvent(OutfittingEvent arg) { Outfitting?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when paying off bounties 
        /// </summary>
        public event EventHandler<PayBountiesEvent> PayBounties;
        internal PayBountiesEvent InvokeEvent(PayBountiesEvent arg) { PayBounties?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when paying fines 
        /// </summary>
        public event EventHandler<PayFinesEvent> PayFines;
        internal PayFinesEvent InvokeEvent(PayFinesEvent arg) { PayFines?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when paying legacy fines 
        /// </summary>
        public event EventHandler<PayLegacyFinesEvent> PayLegacyFines;
        internal PayLegacyFinesEvent InvokeEvent(PayLegacyFinesEvent arg) { PayLegacyFines?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when claiming payment for combat bounties and bonds
        /// </summary>
        public event EventHandler<RedeemVoucherEvent> RedeemVoucher;
        internal RedeemVoucherEvent InvokeEvent(RedeemVoucherEvent arg) { RedeemVoucher?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when re-fuelling (full tank) 
        /// </summary>
        public event EventHandler<RefuelAllEvent> RefuelAll;
        internal RefuelAllEvent InvokeEvent(RefuelAllEvent arg) { RefuelAll?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when refuelling (10%)
        /// </summary>
        public event EventHandler<RefuelPartialEvent> RefuelPartial;
        internal RefuelPartialEvent InvokeEvent(RefuelPartialEvent arg) { RefuelPartial?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when repairing the ship 
        /// </summary>
        public event EventHandler<RepairEvent> Repair;
        internal RepairEvent InvokeEvent(RepairEvent arg) { Repair?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when repairing everything 
        /// </summary>
        public event EventHandler<RepairAllEvent> RepairAll;
        internal RepairAllEvent InvokeEvent(RepairAllEvent arg) { RepairAll?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when purchasing an SRV or Fighter
        /// </summary>
        public event EventHandler<RestockVehicleEvent> RestockVehicle;
        internal RestockVehicleEvent InvokeEvent(RestockVehicleEvent arg) { RestockVehicle?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when contributing materials to a "research" community goal 
        /// </summary>
        public event EventHandler<ScientificResearchEvent> ScientificResearch;
        internal ScientificResearchEvent InvokeEvent(ScientificResearchEvent arg) { ScientificResearch?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when delivering items to a Search and Rescue contact  
        /// </summary>
        public event EventHandler<SearchAndRescueEvent> SearchAndRescue;
        internal SearchAndRescueEvent InvokeEvent(SearchAndRescueEvent arg) { SearchAndRescue?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when selling unwanted drones back to the market 
        /// </summary>
        public event EventHandler<SellDronesEvent> SellDrones;
        internal SellDronesEvent InvokeEvent(SellDronesEvent arg) { SellDrones?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when selling a stored ship to raise funds when on insurance/rebuy screen  
        /// </summary>
        public event EventHandler<SellShipOnRebuyEvent> SellShipOnRebuy;
        internal SellShipOnRebuyEvent InvokeEvent(SellShipOnRebuyEvent arg) { SellShipOnRebuy?.Invoke(_api, arg); return arg; }
        /// <summary>
        ///  when assigning a name to the ship in Starport Services
        /// </summary>
        public event EventHandler<SetUserShipNameEvent> SetUserShipName;
        internal SetUserShipNameEvent InvokeEvent(SetUserShipNameEvent arg) { SetUserShipName?.Invoke(_api, arg); return arg; }
        /// <summary>
        ///  when accessing shipyard in a station 
        /// </summary>
        public event EventHandler<ShipyardEvent> Shipyard;
        internal ShipyardEvent InvokeEvent(ShipyardEvent arg) { Shipyard?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when buying a new ship in the shipyard 
        /// </summary>
        public event EventHandler<ShipyardBuyEvent> ShipyardBuy;
        internal ShipyardBuyEvent InvokeEvent(ShipyardBuyEvent arg) { ShipyardBuy?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// after a new ship has been purchased 
        /// </summary>
        public event EventHandler<ShipyardNewEvent> ShipyardNew;
        internal ShipyardNewEvent InvokeEvent(ShipyardNewEvent arg) { ShipyardNew?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when selling a ship stored in the shipyard 
        /// </summary>
        public event EventHandler<ShipyardSellEvent> ShipyardSell;
        internal ShipyardSellEvent InvokeEvent(ShipyardSellEvent arg) { ShipyardSell?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when requesting a ship at another station be transported to this station
        /// </summary>
        public event EventHandler<ShipyardTransferEvent> ShipyardTransfer;
        internal ShipyardTransferEvent InvokeEvent(ShipyardTransferEvent arg) { ShipyardTransfer?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when switching to another ship already stored at this station
        /// </summary>
        public event EventHandler<ShipyardSwapEvent> ShipyardSwap;
        internal ShipyardSwapEvent InvokeEvent(ShipyardSwapEvent arg) { ShipyardSwap?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when first visiting Outfitting, and when the set of stored modules has changed
        /// </summary>
        public event EventHandler<StoredModulesEvent> StoredModules;
        internal StoredModulesEvent InvokeEvent(StoredModulesEvent arg) { StoredModules?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when visiting shipyard 
        /// </summary>
        public event EventHandler<StoredShipsEvent> StoredShips;
        internal StoredShipsEvent InvokeEvent(StoredShipsEvent arg) { StoredShips?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when using the Technology Broker to unlock new purchasable technology
        /// </summary>
        public event EventHandler<TechnologyBrokerEvent> TechnologyBroker;
        internal TechnologyBrokerEvent InvokeEvent(TechnologyBrokerEvent arg) { TechnologyBroker?.Invoke(_api, arg); return arg; }
    }
}