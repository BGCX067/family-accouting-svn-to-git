using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Wang.Velika.Utility.GeneralLibrary;

namespace Wang.Velika.Utility.WCFExtension
{
    public abstract class OperationContextExtensionBase : IExtension<OperationContext>, IDisposable
    {
        public static TExtension GetOrCreateExtension<TExtension>(InstanceConstuctor<TExtension> create)
            where TExtension : OperationContextExtensionBase
        {
            TExtension ret = OperationContext.Current.Extensions.Find<TExtension>();
            if (ret == null)
            {
                ret = create();
                OperationContext.Current.Extensions.Add(ret);
            }

            return ret;
        }


        protected virtual void Dispose()
        {
        }

        private void OnWCFOperationCompleted(object sender, EventArgs e)
        {
            this.Dispose();
            OperationContext.Current.Extensions.Remove(this);
        }

        protected virtual void OnAttach(OperationContext owner)
        {
        }

        protected virtual void OnDetach(OperationContext owner)
        {
        }


        #region IExtension<OperationContext> Members

        void IExtension<OperationContext>.Attach(OperationContext owner)
        {
            this.OnAttach(owner);

            owner.OperationCompleted += new EventHandler(this.OnWCFOperationCompleted);
        }

        void IExtension<OperationContext>.Detach(OperationContext owner)
        {
            this.OnDetach(owner);
        }

        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            this.Dispose();
        }

        #endregion
    }
}
