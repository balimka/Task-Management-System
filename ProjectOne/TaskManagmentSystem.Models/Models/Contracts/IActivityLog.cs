﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne.Models.Contracts
{
    public interface IActivityLog
    {
        IList<IEventLog> EventLogs { get; }
    }
}