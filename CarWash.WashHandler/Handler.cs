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

        public Handler()
        {
            machineList = new List<CarWashMachine>();
        }

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

        private bool CheckIfMachineBusy(int machineID)
        {
            CarWashMachine machine = CreateMachineIfNotExist(machineID);
            if (machine.WashHandler == null)
            {
                return false;
            }
            return true;
        }

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

        public int GetWashStatus(int machineID)
        {
            CarWashMachine machine = CreateMachineIfNotExist(machineID);
            return machine.WashHandler.WashProgram.Status();
        }

        private void StartStandardWash(int machineID, CancellationTokenSource progressBarCts)
        {
            CarWashMachine machine = CreateMachineIfNotExist(machineID);
            StandardWashHandler handler = new StandardWashHandler();

            handler.WashCarStandard(machineID, progressBarCts);
            machine.WashHandler = handler;
        }

        private void StartSilverWash(int machineID, CancellationTokenSource progressBarCts)
        {
            CarWashMachine machine = CreateMachineIfNotExist(machineID);
            SilverWashHandler handler = new SilverWashHandler();
            
            handler.WashCarSilver(machineID, progressBarCts);
            machine.WashHandler = handler;
        }

        private void StartGoldWash(int machineID, CancellationTokenSource progressBarCts)
        {
            CarWashMachine machine = CreateMachineIfNotExist(machineID);
            GoldWashHandler handler = new GoldWashHandler();

            handler.WashCarGold(machineID, progressBarCts);
            machine.WashHandler = handler;
        }

        public void CancelWash(int machineID, CancellationTokenSource cts)
        {
            CarWashMachine machine = CreateMachineIfNotExist(machineID);
            machine.WashHandler.Cancel();
            
        }
    }
}
