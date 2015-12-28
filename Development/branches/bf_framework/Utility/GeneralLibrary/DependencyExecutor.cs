using System;
using System.Collections.Generic;
using System.Text;

namespace Wang.Velika.Utility.GeneralLibrary
{
    public class DependencyExecutor<TDependency>
    {
        private Action action;

        private List<TDependency> dependencies;


        public DependencyExecutor(Action action)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            this.action = action;
            this.dependencies = new List<TDependency>();
        }


        public void RegisterDependency(TDependency dependency)
        {
            this.dependencies.Add(dependency);
        }

        public void CheckExecute(TDependency dependency)
        {
            this.dependencies.Remove(dependency);
            this.TryRun();
        }

        private void TryRun()
        {
            if (this.dependencies.Count <= 0)
            {
                this.action();
            }
        }
    }
}
