﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodAI.Arnold.Network
{
    public interface ICoreControllerFactory
    {
        ICoreController Create(ICoreLink coreLink);
    }

    public class CoreControllerFactory : ICoreControllerFactory
    {
        public ICoreController Create(ICoreLink coreLink)
        {
            return new CoreController(coreLink);
        }
    }
}