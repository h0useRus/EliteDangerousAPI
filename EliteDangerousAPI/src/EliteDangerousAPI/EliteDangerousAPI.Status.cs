using System;

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
    }
}