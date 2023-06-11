using System;
using System.Collections.Generic;
using System.Text;

namespace Modix.Common
{
    public abstract class ContributionHost<TContribution> : IContributionHost where TContribution : IContribution
    {
        void IContributionHost.Register(IContribution contribution)
        {
            this.OnRegister((TContribution)contribution);
        }

        void IContributionHost.Unregister(IContribution contribution)
        {
            this.OnUnregister((TContribution)contribution);
        }

        protected abstract void OnRegister(TContribution contribution);
        protected abstract void OnUnregister(TContribution contribution);
    }
}
