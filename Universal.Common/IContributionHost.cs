﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Universal.Common
{
    public interface IContributionHost
    {
        void Register(IContribution contribution);
        void Unregister(IContribution contribution);
    }
}
