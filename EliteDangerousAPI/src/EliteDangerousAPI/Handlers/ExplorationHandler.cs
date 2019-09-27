using System;
using NSW.EliteDangerous.API.Events;

namespace NSW.EliteDangerous.API.Handlers
{
    public class ExplorationHandler
    {
        private readonly API.EliteDangerousAPI _api;

        internal ExplorationHandler(API.EliteDangerousAPI api) { _api = api; }
        /// <summary>
        /// when a new discovery is added to the Codex 
        /// </summary>
        public event EventHandler<CodexEntryEvent> CodexEntry;
        internal CodexEntryEvent InvokeEvent(CodexEntryEvent arg) { if(_api.ValidateEvent(arg)) CodexEntry?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when a new discovery is added to the Codex 
        /// </summary>
        public event EventHandler<DiscoveryScanEvent> DiscoveryScan;
        internal DiscoveryScanEvent InvokeEvent(DiscoveryScanEvent arg) { if(_api.ValidateEvent(arg)) DiscoveryScan?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// detailed discovery scan of a star, planet or moon
        /// </summary>
        public event EventHandler<ScanEvent> Scan;
        internal ScanEvent InvokeEvent(ScanEvent arg) { if(_api.ValidateEvent(arg)) Scan?.Invoke(_api, arg); return arg; }
        /// <summary>
        ///  after having identified all bodies in the system 
        /// </summary>
        public event EventHandler<FssAllBodiesFoundEvent> FssAllBodiesFound;
        internal FssAllBodiesFoundEvent InvokeEvent(FssAllBodiesFoundEvent arg) { if(_api.ValidateEvent(arg)) FssAllBodiesFound?.Invoke(_api, arg); return arg; }
        /// <summary>
        ///  when performing a full system scan (“Honk”)
        /// </summary>
        public event EventHandler<FssDiscoveryScanEvent> FssDiscoveryScan;
        internal FssDiscoveryScanEvent InvokeEvent(FssDiscoveryScanEvent arg) { if(_api.ValidateEvent(arg)) FssDiscoveryScan?.Invoke(_api, arg); return arg; }
        /// <summary>
        ///  when zooming in on a signal using the FSS scanner
        /// </summary>
        public event EventHandler<FssSignalDiscoveredEvent> FssSignalDiscovered;
        internal FssSignalDiscoveredEvent InvokeEvent(FssSignalDiscoveredEvent arg) { if(_api.ValidateEvent(arg)) FssSignalDiscovered?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// whenever materials are collected
        /// </summary>
        public event EventHandler<MaterialCollectedEvent> MaterialCollected;
        internal MaterialCollectedEvent InvokeEvent(MaterialCollectedEvent arg) { if(_api.ValidateEvent(arg)) MaterialCollected?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// if materials are discarded
        /// </summary>
        public event EventHandler<MaterialDiscardedEvent> MaterialDiscarded;
        internal MaterialDiscardedEvent InvokeEvent(MaterialDiscardedEvent arg) { if(_api.ValidateEvent(arg)) MaterialDiscarded?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when a new material is discovered
        /// </summary>
        public event EventHandler<MaterialDiscoveredEvent> MaterialDiscovered;
        internal MaterialDiscoveredEvent InvokeEvent(MaterialDiscoveredEvent arg) { if(_api.ValidateEvent(arg)) MaterialDiscovered?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when selling exploration data in Cartographics, a page at a time
        /// </summary>
        public event EventHandler<MultiSellExplorationDataEvent> MultiSellExplorationData;
        internal MultiSellExplorationDataEvent InvokeEvent(MultiSellExplorationDataEvent arg) { if(_api.ValidateEvent(arg)) MultiSellExplorationData?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when scanning a navigation beacon, before the scan data for all the bodies in the system is written into the journal 
        /// </summary>
        public event EventHandler<NavBeaconScanEvent> NavBeaconScan;
        internal NavBeaconScanEvent InvokeEvent(NavBeaconScanEvent arg) { if(_api.ValidateEvent(arg)) NavBeaconScan?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// after using the “Surface Area Analysis” scanner
        /// </summary>
        public event EventHandler<SaaScanCompleteEvent> SaaScanComplete;
        internal SaaScanCompleteEvent InvokeEvent(SaaScanCompleteEvent arg) { if(_api.ValidateEvent(arg)) SaaScanComplete?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when using SAA scanner on a planet or rings
        /// </summary>
        public event EventHandler<SaaSignalsFoundEvent> SaaSignalsFound;
        internal SaaSignalsFoundEvent InvokeEvent(SaaSignalsFoundEvent arg) { if(_api.ValidateEvent(arg)) SaaSignalsFound?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when buying system data via the galaxy map
        /// </summary>
        public event EventHandler<BuyExplorationDataEvent> BuyExplorationData;
        internal BuyExplorationDataEvent InvokeEvent(BuyExplorationDataEvent arg) { if(_api.ValidateEvent(arg)) BuyExplorationData?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when selling exploration data in Cartographics
        /// </summary>
        public event EventHandler<SellExplorationDataEvent> SellExplorationData;
        internal SellExplorationDataEvent InvokeEvent(SellExplorationDataEvent arg) { if(_api.ValidateEvent(arg)) SellExplorationData?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when a screen snapshot is saved
        /// </summary>
        public event EventHandler<ScreenshotEvent> Screenshot;
        internal ScreenshotEvent InvokeEvent(ScreenshotEvent arg) { if(_api.ValidateEvent(arg)) Screenshot?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when scanning a data link
        /// </summary>
        public event EventHandler<DatalinkScanEvent> DatalinkScan;
        internal DatalinkScanEvent InvokeEvent(DatalinkScanEvent arg) { if(_api.ValidateEvent(arg)) DatalinkScan?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when scanning a datalink generates a reward
        /// </summary>
        public event EventHandler<DatalinkVoucherEvent> DatalinkVoucher;
        internal DatalinkVoucherEvent InvokeEvent(DatalinkVoucherEvent arg) { if(_api.ValidateEvent(arg)) DatalinkVoucher?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when scanning some types of data links
        /// </summary>
        public event EventHandler<DataScannedEvent> DataScanned;
        internal DataScannedEvent InvokeEvent(DataScannedEvent arg) { if(_api.ValidateEvent(arg)) DataScanned?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// when dropping from Supercruise at a Unidentified Signal Source (USS)
        /// </summary>
        public event EventHandler<UssDropEvent> UssDrop;
        internal UssDropEvent InvokeEvent(UssDropEvent arg) { if(_api.ValidateEvent(arg)) UssDrop?.Invoke(_api, arg); return arg; }
        /// <summary>
        /// When using a prospecting drone 
        /// </summary>
        public event EventHandler<ProspectedAsteroidEvent> ProspectedAsteroid;
        internal ProspectedAsteroidEvent InvokeEvent(ProspectedAsteroidEvent arg) { if(_api.ValidateEvent(arg)) ProspectedAsteroid?.Invoke(_api, arg); return arg; }
    }
}