﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodAI.Arnold.Observation;
using GoodAI.Arnold.Visualization.Models;
using GoodAI.Logging;

namespace GoodAI.Arnold.Core
{
    public class NewModelEventArgs : EventArgs
    {
        public SimulationModel Model { get; }

        public NewModelEventArgs(SimulationModel model)
        {
            Model = model;
        }
    }

    public interface IModelProvider
    {
        ModelFilter Filter { set; }
        void GetNewModel();
        event EventHandler<NewModelEventArgs> ModelUpdated;
        SimulationModel LastReceivedModel { get; }
        IList<ObserverDefinition> ObserverRequests { set; }
    }

    public class ModelProvider : IModelProvider
    {
        private readonly IConductor m_conductor;
        
        // Injected.
        public ILog Log { get; set; } = NullLogger.Instance;

        public SimulationModel LastReceivedModel { get; private set; }

        public IList<ObserverDefinition> ObserverRequests
        {
            set
            {
                if (m_conductor.CoreState == CoreState.Disconnected)
                    return;

                m_conductor.CoreProxy.ModelUpdater.ObserverRequests = value;
            }
        }

        public event EventHandler<NewModelEventArgs> ModelUpdated;

        public ModelFilter Filter
        {
            set
            {
                if (m_conductor.CoreState == CoreState.Disconnected)
                    return;

                m_conductor.CoreProxy.ModelUpdater.Filter = value;
            }
        }

        public ModelProvider(IConductor conductor)
        {
            m_conductor = conductor;
        }

        public void GetNewModel()
        {
            if (m_conductor.CoreState == CoreState.Disconnected || m_conductor.CoreState == CoreState.Empty)
                return;

            try
            {
                SimulationModel newModel = m_conductor.CoreProxy.ModelUpdater.GetNewModel();
                if (newModel != null)
                    LastReceivedModel = newModel;

                ModelUpdated?.Invoke(this, new NewModelEventArgs(newModel));
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to get new model");
            }
        }
    }
}
