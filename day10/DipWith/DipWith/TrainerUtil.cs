using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DipWith
{
    internal class TrainerUtil
    {
        private ItrainerData iTrainerData;

        public TrainerUtil(ItrainerData iTrainerData)
        {
            this.iTrainerData = iTrainerData;
        }

        public void ShowInfo()
        {
            iTrainerData.Name();
            iTrainerData.City();
            iTrainerData.Email();
        }
    }

}
