﻿using System;
using NSW.EliteDangerous.Events;

namespace NSW.EliteDangerous.Handlers
{
    public class ExplorationHandler
    {
        internal ExplorationHandler() { }
        /// <summary>
        /// when a new discovery is added to the Codex 
        /// </summary>
        public event EventHandler<CodexEntryEvent> CodexEntry;
        internal CodexEntryEvent InvokeEvent(CodexEntryEvent arg) { CodexEntry?.Invoke(this, arg); return arg; }
        /// <summary>
        /// when a new discovery is added to the Codex 
        /// </summary>
        public event EventHandler<DiscoveryScanEvent> DiscoveryScan;
        internal DiscoveryScanEvent InvokeEvent(DiscoveryScanEvent arg) { DiscoveryScan?.Invoke(this, arg); return arg; }
        /// <summary>
        /// detailed discovery scan of a star, planet or moon
        /// </summary>
        public event EventHandler<ScanEvent> Scan;
        internal ScanEvent InvokeEvent(ScanEvent arg) { Scan?.Invoke(this, arg); return arg; }
        /// <summary>
        ///  after having identified all bodies in the system 
        /// </summary>
        public event EventHandler<FssAllBodiesFoundEvent> FssAllBodiesFound;
        internal FssAllBodiesFoundEvent InvokeEvent(FssAllBodiesFoundEvent arg) { FssAllBodiesFound?.Invoke(this, arg); return arg; }
        /// <summary>
        ///  when performing a full system scan (“Honk”)
        /// </summary>
        public event EventHandler<FssDiscoveryScanEvent> FssDiscoveryScan;
        internal FssDiscoveryScanEvent InvokeEvent(FssDiscoveryScanEvent arg) { FssDiscoveryScan?.Invoke(this, arg); return arg; }
        /// <summary>
        ///  when zooming in on a signal using the FSS scanner
        /// </summary>
        public event EventHandler<FssSignalDiscoveredEvent> FssSignalDiscovered;
        internal FssSignalDiscoveredEvent InvokeEvent(FssSignalDiscoveredEvent arg) { FssSignalDiscovered?.Invoke(this, arg); return arg; }
        /// <summary>
        /// whenever materials are collected
        /// </summary>
        public event EventHandler<MaterialCollectedEvent> MaterialCollected;
        internal MaterialCollectedEvent InvokeEvent(MaterialCollectedEvent arg) { MaterialCollected?.Invoke(this, arg); return arg; }
        /// <summary>
        /// if materials are discarded
        /// </summary>
        public event EventHandler<MaterialDiscardedEvent> MaterialDiscarded;
        internal MaterialDiscardedEvent InvokeEvent(MaterialDiscardedEvent arg) { MaterialDiscarded?.Invoke(this, arg); return arg; }
        /// <summary>
        /// when a new material is discovered
        /// </summary>
        public event EventHandler<MaterialDiscoveredEvent> MaterialDiscovered;
        internal MaterialDiscoveredEvent InvokeEvent(MaterialDiscoveredEvent arg) { MaterialDiscovered?.Invoke(this, arg); return arg; }
        /// <summary>
        /// when selling exploration data in Cartographics, a page at a time
        /// </summary>
        public event EventHandler<MultiSellExplorationDataEvent> MultiSellExplorationData;
        internal MultiSellExplorationDataEvent InvokeEvent(MultiSellExplorationDataEvent arg) { MultiSellExplorationData?.Invoke(this, arg); return arg; }
        /// <summary>
        /// when scanning a navigation beacon, before the scan data for all the bodies in the system is written into the journal 
        /// </summary>
        public event EventHandler<NavBeaconScanEvent> NavBeaconScan;
        internal NavBeaconScanEvent InvokeEvent(NavBeaconScanEvent arg) { NavBeaconScan?.Invoke(this, arg); return arg; }
        /// <summary>
        /// after using the “Surface Area Analysis” scanner
        /// </summary>
        public event EventHandler<SaaScanCompleteEvent> SaaScanComplete;
        internal SaaScanCompleteEvent InvokeEvent(SaaScanCompleteEvent arg) { SaaScanComplete?.Invoke(this, arg); return arg; }
        /// <summary>
        /// when buying system data via the galaxy map
        /// </summary>
        public event EventHandler<BuyExplorationDataEvent> BuyExplorationData;
        internal BuyExplorationDataEvent InvokeEvent(BuyExplorationDataEvent arg) { BuyExplorationData?.Invoke(this, arg); return arg; }
        /// <summary>
        /// when selling exploration data in Cartographics
        /// </summary>
        public event EventHandler<SellExplorationDataEvent> SellExplorationData;
        internal SellExplorationDataEvent InvokeEvent(SellExplorationDataEvent arg) { SellExplorationData?.Invoke(this, arg); return arg; }
        /// <summary>
        /// when a screen snapshot is saved
        /// </summary>
        public event EventHandler<ScreenshotEvent> Screenshot;
        internal ScreenshotEvent InvokeEvent(ScreenshotEvent arg) { Screenshot?.Invoke(this, arg); return arg; }
        /// <summary>
        /// when scanning a data link
        /// </summary>
        public event EventHandler<DatalinkScanEvent> DatalinkScan;
        internal DatalinkScanEvent InvokeEvent(DatalinkScanEvent arg) { DatalinkScan?.Invoke(this, arg); return arg; }
        /// <summary>
        /// when scanning a datalink generates a reward
        /// </summary>
        public event EventHandler<DatalinkVoucherEvent> DatalinkVoucher;
        internal DatalinkVoucherEvent InvokeEvent(DatalinkVoucherEvent arg) { DatalinkVoucher?.Invoke(this, arg); return arg; }
        /// <summary>
        /// when scanning some types of data links
        /// </summary>
        public event EventHandler<DataScannedEvent> DataScanned;
        internal DataScannedEvent InvokeEvent(DataScannedEvent arg) { DataScanned?.Invoke(this, arg); return arg; }
        /// <summary>
        /// when dropping from Supercruise at a Unidentified Signal Source (USS)
        /// </summary>
        public event EventHandler<UssDropEvent> UssDrop;
        internal UssDropEvent InvokeEvent(UssDropEvent arg) { UssDrop?.Invoke(this, arg); return arg; }
    }
}