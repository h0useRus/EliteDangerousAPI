using System;
using NSW.EliteDangerous.API.Statuses;

namespace NSW.EliteDangerous.API
{
    partial class EliteDangerousAPI
    {
        #region API Status
        private ApiStatus _status;
        public ApiStatus Status
        {
            get => _status;
            private set
            {
                if (_status != value)
                {
                    _status = value;
                    StatusChanged?.Invoke(this, _status);
                }
            }
        }
        public event EventHandler<ApiStatus> StatusChanged;
        #endregion

        public GameStatus Game { get; private set; }
        public LocationStatus Location { get; private set; }
        public PlayerStatus Player { get; private set; }
        public ShipStatus Ship { get; private set; }

        private void InitStatuses()
        {
            Game = new GameStatus(this);
            Location = new LocationStatus(this);
            Player = new PlayerStatus(this);
            Ship = new ShipStatus(this);
        }

        internal void InvokeGameStatusChanged(GameStatus status) => GameChanged?.Invoke(this, status);
        internal void InvokePlayerStatusChanged(PlayerStatus status) => PlayerChanged?.Invoke(this, status);
        internal void InvokeLocationStatusChanged(LocationStatus status) => LocationChanged?.Invoke(this, status);
        internal void InvokeShipStatusChanged(ShipStatus status) => ShipChanged?.Invoke(this, status);

        public event EventHandler<GameStatus> GameChanged;
        public event EventHandler<PlayerStatus> PlayerChanged;
        public event EventHandler<LocationStatus> LocationChanged;
        public event EventHandler<ShipStatus> ShipChanged;
    }
}