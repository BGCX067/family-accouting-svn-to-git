using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using System.Data.Objects.DataClasses;

namespace Wang.Velika.FamilyAccounting.Application.Framework.History
{
    internal class ChangeEntry
    {
        public ChangeMonitorBase Monitor { get; private set; }

        public EntityObject Source { get; private set; }

        public EntityObject Target { get; private set; }

        public ChangeActionKind Action { get; private set; }


        public ChangeEntry(ChangeMonitorBase monitor, EntityObject source, EntityObject target, ChangeActionKind action)
        {
            if (monitor == null)
            {
                throw new ArgumentNullException("monitor");
            }
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (target == null)
            {
                throw new ArgumentNullException("target");
            }

            this.Monitor = monitor;
            this.Source = source;
            this.Target = target;
            this.Action = action;
        }
    }
}
