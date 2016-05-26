﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodAI.Arnold.Core;
using GoodAI.Arnold.Graphics.Models;
using GoodAI.Logging;

namespace GoodAI.Arnold.Network
{
    public interface IModelProvider
    {
        SimulationModel GetNewModel();
        SimulationModel LastReceivedModel { get; }
    }

    public class ModelProvider : IModelProvider
    {
        private readonly IConductor m_conductor;
        
        // Injected.
        public ILog Log { get; set; } = NullLogger.Instance;

        public SimulationModel LastReceivedModel { get; private set; }
        
        public ModelProvider(IConductor conductor)
        {
            m_conductor = conductor;
        }

        public SimulationModel GetNewModel()
        {
            // NOTE: the idea was that we would get empty model when core state is Empty,
            // but in reality there is some time in the Empty state when the core is not really connected yet
            // You can comment out "m_conductor.CoreState == CoreState.Empty" to debug model retrieval error handling.
            if (m_conductor.CoreState == CoreState.Disconnected || m_conductor.CoreState == CoreState.Empty)
            {
                return null;
            }

            try
            {
                SimulationModel newModel = m_conductor.CoreProxy.ModelUpdater.GetNewModel();
                if (newModel != null)
                    LastReceivedModel = newModel;

                return newModel;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to get new model");
            }

            return null;
        }
    }
}
