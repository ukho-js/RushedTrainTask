using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainDilemma.Class;

namespace TrainDilemma.Services.interfaces
{
    public interface ITrainComposition
    {
        public List<int> GetTrainCarriages();
        public void AttachLeft(int carriage);
        public void AttachRight(int carriage);
        public void DetachLeft();
        public void DetachRight();
    }
}
