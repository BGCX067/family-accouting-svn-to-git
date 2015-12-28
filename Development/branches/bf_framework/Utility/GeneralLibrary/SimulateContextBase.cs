using System;
using System.Collections.Generic;
using System.Text;

namespace Wang.Velika.Utility.GeneralLibrary
{
    public abstract class SimulateContextBase<TSimulate> : IDisposable
    {
        protected TSimulate _cache;
        protected TSimulate Cache
        {
            get
            {
                return this._cache;
            }
            set
            {
                this._cache = value;
            }
        }

        protected SimulateContextBase()
        {
            this.Cache = this.BackupCurrentSimulationTarget();
        }

        protected SimulateContextBase(TSimulate simulatedValue)
            : this()
        {
            this.UpdateSimulationTarget(simulatedValue, true);
        }

        public void Dispose()
        {
            this.UpdateSimulationTarget(this.Cache, false);
        }


        protected abstract TSimulate BackupCurrentSimulationTarget();

        protected abstract void UpdateSimulationTarget(TSimulate v, bool simulating);
    }
}
