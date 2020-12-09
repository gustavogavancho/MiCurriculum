using System;

namespace MiCurriculum.COMMON.Entidades
{
    public class BaseEntity
    {
        private bool _isDisposed;
        public string Id { get; set; }
        public DateTime FechaHoraCreacion { get; set; }
        public bool SePuedeEliminar { get; set; }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                this._isDisposed = true;
                GC.SuppressFinalize(this);
            }
        }
    }
}
