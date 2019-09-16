using NSW.EliteDangerous.Events;
using System;
using System.IO;

namespace NSW.EliteDangerous.Handlers
{
    public class StatusHandler
    {
        private const string CargoFile = "Cargo.json";
        private const string MarketFile = "Market.json";
        private const string ModulesInfoFile = "ModulesInfo.json";
        private const string OutfittingFile = "Outfitting.json";
        private const string ShipyardFile = "Shipyard.json";
        private const string GameStatusFile = "Status.json";

        private readonly EliteDangerousAPI _api;
        private readonly bool _enabled;
        // file watchers
        private readonly FileSystemWatcher _cargoFileWatcher;
        private readonly FileSystemWatcher _marketFileWatcher;
        private readonly FileSystemWatcher _modulesInfoFileWatcher;
        private readonly FileSystemWatcher _outfittingFileWatcher;
        private readonly FileSystemWatcher _shipyardFileWatcher;
        private readonly FileSystemWatcher _gameStatusFileWatcher;


        internal StatusHandler(EliteDangerousAPI api)
        {
            _api = api;

            if (api.JournalDirectory.Exists)
            {
                _cargoFileWatcher = new FileSystemWatcher(_api.JournalDirectory.FullName, CargoFile)
                    {EnableRaisingEvents = true};
                _cargoFileWatcher.Changed += (sender, e) => CargoFileChanged(e);

                _marketFileWatcher = new FileSystemWatcher(_api.JournalDirectory.FullName, MarketFile)
                    {EnableRaisingEvents = true};
                _marketFileWatcher.Changed += (sender, e) => MarketFileChanged(e);

                _modulesInfoFileWatcher = new FileSystemWatcher(_api.JournalDirectory.FullName, ModulesInfoFile)
                    {EnableRaisingEvents = true};
                _modulesInfoFileWatcher.Changed += (sender, e) => ModulesInfoFileChanged(e);

                _outfittingFileWatcher = new FileSystemWatcher(_api.JournalDirectory.FullName, OutfittingFile)
                    {EnableRaisingEvents = true};
                _outfittingFileWatcher.Changed += (sender, e) => OutfittingFileChanged(e);

                _shipyardFileWatcher = new FileSystemWatcher(_api.JournalDirectory.FullName, ShipyardFile)
                    {EnableRaisingEvents = true};
                _shipyardFileWatcher.Changed += (sender, e) => ShipyardFileChanged(e);

                _gameStatusFileWatcher = new FileSystemWatcher(_api.JournalDirectory.FullName, GameStatusFile)
                    {EnableRaisingEvents = true};
                _gameStatusFileWatcher.Changed += (sender, e) => GameStatusFileChanged(e);
                _enabled = true;
            }
        }

        internal void Start()
        {
            if(!_enabled) return;

            CargoFileChanged(new FileSystemEventArgs(WatcherChangeTypes.All, _api.JournalDirectory.FullName, CargoFile));
            MarketFileChanged(new FileSystemEventArgs(WatcherChangeTypes.All, _api.JournalDirectory.FullName, MarketFile));
            ModulesInfoFileChanged(new FileSystemEventArgs(WatcherChangeTypes.All, _api.JournalDirectory.FullName, ModulesInfoFile));
            OutfittingFileChanged(new FileSystemEventArgs(WatcherChangeTypes.All, _api.JournalDirectory.FullName, OutfittingFile));
            ShipyardFileChanged(new FileSystemEventArgs(WatcherChangeTypes.All, _api.JournalDirectory.FullName, ShipyardFile));
            GameStatusFileChanged(new FileSystemEventArgs(WatcherChangeTypes.All, _api.JournalDirectory.FullName, GameStatusFile));

            _cargoFileWatcher.EnableRaisingEvents = 
                _marketFileWatcher.EnableRaisingEvents =
                    _modulesInfoFileWatcher.EnableRaisingEvents = 
                        _outfittingFileWatcher.EnableRaisingEvents =
                            _shipyardFileWatcher.EnableRaisingEvents =
                                _gameStatusFileWatcher.EnableRaisingEvents = true;
        }

        internal void Stop()
        {
            if(!_enabled) return;

            _cargoFileWatcher.EnableRaisingEvents =
                _marketFileWatcher.EnableRaisingEvents =
                    _modulesInfoFileWatcher.EnableRaisingEvents =
                        _outfittingFileWatcher.EnableRaisingEvents =
                            _shipyardFileWatcher.EnableRaisingEvents =
                                _gameStatusFileWatcher.EnableRaisingEvents = false;
        }

        /// <summary>
        /// On Cargo file changed
        /// </summary>
        public event EventHandler<CargoEvent> Cargo;
        internal CargoEvent InvokeCargoEvent(CargoEvent arg) { Cargo?.Invoke(this, arg); return arg; }
        private void CargoFileChanged(FileSystemEventArgs fileArgs)
        {
            if(!_enabled) return;

            if ((fileArgs.ChangeType & WatcherChangeTypes.Created) != 0 ||
                (fileArgs.ChangeType & WatcherChangeTypes.Changed) != 0)
            {
                var @event = _api.FromJsonFile<CargoEvent>(fileArgs.FullPath);
                if (@event != null)
                    InvokeCargoEvent(@event);
            }
        }
        /// <summary>
        /// On Market file changed
        /// </summary>
        public event EventHandler<MarketEvent> Market;
        internal MarketEvent InvokeMarketEvent(MarketEvent arg) { Market?.Invoke(this, arg); return arg; }
        private void MarketFileChanged(FileSystemEventArgs fileArgs)
        {
            if(!_enabled) return;

            if ((fileArgs.ChangeType & WatcherChangeTypes.Created) != 0 ||
                (fileArgs.ChangeType & WatcherChangeTypes.Changed) != 0)
            {
                var @event = _api.FromJsonFile<MarketEvent>(fileArgs.FullPath);
                if (@event != null)
                    InvokeMarketEvent(@event);
            }
        }
        /// <summary>
        /// On ModuleInfo file changed
        /// </summary>
        public event EventHandler<ModuleInfoEvent> ModuleInfo;
        internal ModuleInfoEvent InvokeModuleInfoEvent(ModuleInfoEvent arg) { ModuleInfo?.Invoke(this, arg); return arg; }
        private void ModulesInfoFileChanged(FileSystemEventArgs fileArgs)
        {
            if(!_enabled) return;

            if ((fileArgs.ChangeType & WatcherChangeTypes.Created) != 0 ||
                (fileArgs.ChangeType & WatcherChangeTypes.Changed) != 0)
            {
                var @event = _api.FromJsonFile<ModuleInfoEvent>(fileArgs.FullPath);
                if (@event != null)
                    InvokeModuleInfoEvent(@event);
            }
        }
        /// <summary>
        /// On Outfitting file changed
        /// </summary>
        public event EventHandler<OutfittingEvent> Outfitting;
        internal OutfittingEvent InvokeOutfittingEvent(OutfittingEvent arg) { Outfitting?.Invoke(this, arg); return arg; }
        private void OutfittingFileChanged(FileSystemEventArgs fileArgs)
        {
            if(!_enabled) return;

            if ((fileArgs.ChangeType & WatcherChangeTypes.Created) != 0 ||
                (fileArgs.ChangeType & WatcherChangeTypes.Changed) != 0)
            {
                var @event = _api.FromJsonFile<OutfittingEvent>(fileArgs.FullPath);
                if (@event != null)
                    InvokeOutfittingEvent(@event);
            }
        }
        /// <summary>
        /// On Shipyard file changed
        /// </summary>
        public event EventHandler<ShipyardEvent> Shipyard;
        internal ShipyardEvent InvokeShipyardEvent(ShipyardEvent arg) { Shipyard?.Invoke(this, arg); return arg; }
        private void ShipyardFileChanged(FileSystemEventArgs fileArgs)
        {
            if(!_enabled) return;

            if ((fileArgs.ChangeType & WatcherChangeTypes.Created) != 0 ||
                (fileArgs.ChangeType & WatcherChangeTypes.Changed) != 0)
            {
                var @event = _api.FromJsonFile<ShipyardEvent>(fileArgs.FullPath);
                if (@event != null)
                    InvokeShipyardEvent(@event);
            }
        }
        /// <summary>
        /// On Status file changed
        /// </summary>
        public event EventHandler<GameStatusEvent> GameStatus;
        internal GameStatusEvent InvokeGameStatusEvent(GameStatusEvent arg) { GameStatus?.Invoke(this, arg); return arg; }
        private void GameStatusFileChanged(FileSystemEventArgs fileArgs)
        {
            if(!_enabled) return;

            if ((fileArgs.ChangeType & WatcherChangeTypes.Created) != 0 ||
                (fileArgs.ChangeType & WatcherChangeTypes.Changed) != 0)
            {
                var @event = _api.FromJsonFile<GameStatusEvent>(fileArgs.FullPath);
                if (@event != null)
                    InvokeGameStatusEvent(@event);
            }
        }
    }
}
