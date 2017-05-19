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

        private bool CheckIfMachineBusy(int machineID)
        {
            CarWashMachine machine = CreateMachineIfNotExist(machineID);
            if (machine.Program == null)
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
            return machine.Program.Status();
        }

        private void StartStandardWash(int machineID)
        {
            CarWashMachine machine = CreateMachineIfNotExist(machineID);
            StandardWashHandler handler = new StandardWashHandler();

            handler.WashCarStandard(machineID);
            machine.Program = handler.carWash;
        }

        private void StartSilverWash(int machineID)
        {
            CarWashMachine machine = CreateMachineIfNotExist(machineID);
            SilverWashHandler handler = new SilverWashHandler();
            
            handler.WashCarSilver(machineID);
            machine.Program = handler.carWash;
        }

        private void StartGoldWash(int machineID)
        {

        }

        
    }
}
