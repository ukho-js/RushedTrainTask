using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainDilemma.Class;
using TrainDilemma.Exceptions;
using TrainDilemma.Services.interfaces;

namespace TrainDilemma.Services
{
    public class TrainCompositionService : ITrainComposition
    {
        private readonly Train _train;
        private readonly ILogger<TrainCompositionService> _logger;

        public TrainCompositionService(ILogger<TrainCompositionService> logger)
        {
            _train = new Train();
            _logger = logger;
        }

        private bool HasCarriages()
        {
            return _train.Carriages.Any();
        }
        public void AttachLeft(int carriage)
        {
            if (HasCarriages())
            {
                _train.Carriages.Insert(0, carriage);
                _logger.LogInformation($"Added {carriage} to the left");
            }
            else
            {
                _train.Carriages.Add(carriage);
                _logger.LogInformation($"Added first {carriage}");
            }
        }

        public void AttachRight(int carriage)
        {
            _logger.LogInformation($"Added {carriage} to the right");
            _train.Carriages.Add(carriage);
        }

        public void DetachLeft()
        {
            if (HasCarriages())
            {
                _logger.LogInformation($"detached left carriage");
                _train.Carriages.RemoveAt(0);
            }
            else
            {
                _logger.LogError("Cannot detach carriage from an empty train!");
                throw new NoCarriageException();
            }
        }

        public void DetachRight()
        {
            if (HasCarriages())
            {
                _logger.LogInformation($"detached right carriage");
                _train.Carriages.RemoveAt(_train.Carriages.Count -1);
            }
            else
            {
                _logger.LogError("Cannot detach carriage from an empty train!");
                throw new NoCarriageException();
            }
        }

        public List<int> GetTrainCarriages()
        {
            _logger.LogInformation("Carriages requested!");
            return _train.Carriages;
        }
    }
}
