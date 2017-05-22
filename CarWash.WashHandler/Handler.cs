using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWash.Models;
using CarWash.Models.Interfaces;
using System.Threading;

namespace CarWash.WashHandler
{
    public class Handler
    {
        List<CarWashMachine> machineList;

        /// <summary>
        /// Initialize the Wash Handler
        /// </summary>
        public Handler()
        {
            machineList = new List<CarWashMachine>();
        }

        /// <summary>
        /// Start a carwash
        /// </summary>
        /// <param name="machineID">ID of the machine</param>
        /// <param name="selectedWash">ID of the selected wash</param>
        /// <param name="progressBarCts">The Cancellation token source of the progress bar used to show progress of the wash</param>
        public void StartWash(int machineID, int selectedWash, CancellationTokenSource progressBarCts)
        {
            switch (selectedWash)
            {
                case 1:
                    StartStandardWash(machineID, progressBarCts);
                    break;
                case 2:
                    StartSilverWash(machineID, progressBarCts);
                    break;
                case 3:
                    StartGoldWash(machineID, progressBarCts);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Shows if the machine is running
        /// </summary>
        /// <param name="machineID">ID of the machine</param>
        /// <returns></returns>
        private bool CheckIfMachineBusy(int machineID)
        {
            CarWashMachine machine = CreateMachineIfNotExist(machineID);
            if (machine.WashHandler == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Returns an existing machine object or creates a new one if a machine with the ID does not exist
        /// </summary>
        /// <param name="machineID">ID of the machine</param>
        /// <returns></returns>
        private CarWashMachine CreateMachineIfNotExist(int machineID)
        {
            CarWashMachine machine;
            if (!machineList.Exists(i => i.Id() == machineID))
            {
                machine = new CarWashMachine(machineID);
                machineList.Add(machine);
            }
            else
            {
                machine = machineList.Find(i => i.Id() == machineID);
            }
            
            return machine;
        }

        /// <summary>
        /// Gets the status of the current running wash
        /// </summary>
        /// <param name="machineID">ID of the machine</param>
        /// <returns></returns>
        public int GetWashStatus(int machineID)
        {
            CarWashMachine machine = CreateMachineIfNotExist(machineID);
            return machine.WashHandler.WashProgram.Status();
        }

        /// <summary>
        /// Starts the standard wash
        /// </summary>
        /// <param name="machineID">ID of the machine</param>
        /// <param name="progressBarCts">The Cancellation token source of the progress bar used to show progress of the wash</param>
        private void StartStandardWash(int machineID, CancellationTokenSource progressBarCts)
        {
            CarWashMachine machine = CreateMachineIfNotExist(machineID);
            StandardWashHandler handler = new StandardWashHandler();

            handler.WashCarStandard(machineID, progressBarCts);
            machine.WashHandler = handler;
        }

        /// <summary>
        /// Starts the Silver wash
        /// </summary>
        /// <param name="machineID">ID of the machine</param>
        /// <param name="progressBarCts">The Cancellation token source of the progress bar used to show progress of the wash</param>
        private void StartSilverWash(int machineID, CancellationTokenSource progressBarCts)
        {
            CarWashMachine machine = CreateMachineIfNotExist(machineID);
            SilverWashHandler handler = new SilverWashHandler();
            
            handler.WashCarSilver(machineID, progressBarCts);
            machine.WashHandler = handler;
        }

        /// <summary>
        /// Starts the Gold wash
        /// </summary>
        /// <param name="machineID">ID of the machine</param>
        /// <param name="progressBarCts">The Cancellation token source of the progress bar used to show progress of the wash</param>
        private void StartGoldWash(int machineID, CancellationTokenSource progressBarCts)
        {
            CarWashMachine machine = CreateMachineIfNotExist(machineID);
            GoldWashHandler handler = new GoldWashHandler();

            handler.WashCarGold(machineID, progressBarCts);
            machine.WashHandler = handler;
        }

        /// <summary>
        /// Cancels the current running wash
        /// </summary>
        /// <param name="machineID">ID of the machine</param>
        public void CancelWash(int machineID)
        {
            CarWashMachine machine = CreateMachineIfNotExist(machineID);
            machine.WashHandler.Cancel();
            
        }
    }
}
