using System;
using NSW.EliteDangerous.Statuses;

namespace NSW.EliteDangerous
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

        public GameStatus GameStatus { get; private set; }
        public LocationStatus LocationStatus { get; private set; }
        public PlayerStatus PlayerStatus { get; private set; }
        public ShipStatus ShipStatus { get; private set; }

        private void InitStatuses()
        {
            GameStatus = new GameStatus(this);
            LocationStatus = new LocationStatus(this);
            PlayerStatus = new PlayerStatus(this);
            ShipStatus = new ShipStatus(this);
        }

        internal void InvokeGameStatusChanged(GameStatus status) => GameStatusChanged?.Invoke(this, status);
        internal void InvokePlayerStatusChanged(PlayerStatus status) => PlayerStatusChanged?.Invoke(this, status);
        internal void InvokeLocationStatusChanged(LocationStatus status) => LocationStatusChanged?.Invoke(this, status);
        internal void InvokeShipStatusChanged(ShipStatus status) => ShipStatusChanged?.Invoke(this, status);

        public EventHandler<GameStatus> GameStatusChanged;
        public EventHandler<PlayerStatus> PlayerStatusChanged;
        public EventHandler<LocationStatus> LocationStatusChanged;
        public EventHandler<ShipStatus> ShipStatusChanged;
    }
}