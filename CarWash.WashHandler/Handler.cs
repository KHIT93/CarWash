using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.WashHandler
{
    public class Handler
    {
        public void StartWash(int machineID, int selectedWash)
        {
            switch (selectedWash)
            {
                case 1:
                    StartStandardWash(machineID);
                    break;
                case 2:
                    StartSilverWash(machineID);
                    break;
                case 3:
                    StartGoldWash(machineID);
                    break;
                default:
                    break;
            }
        }

        private void StartStandardWash(int machineID)
        {

        }

        private void StartSilverWash(int machineID)
        {
            SilverWashHandler handler = new SilverWashHandler();
            handler.WashCarSilver(machineID);
        }

        private void StartGoldWash(int machineID)
        {

        }
    }
}
