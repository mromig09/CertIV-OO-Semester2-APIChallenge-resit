using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiWebApplication1.Models
{
    public class RoomsWithComputersModel
    {
        public string Building { get; set; }
        public int RoomNo { get; set; }
        public int Capacity { get; set; }
        //public ComputerModel RoomsComputer { get; set; }

        public RoomsWithComputersModel(string building, int roomNo, int capacity) //int number, int assembledYear, string cBuilding, int cRoomNo)
        {
            Building = building;
            RoomNo = roomNo;
            Capacity = capacity;
            //RoomsComputer = new ComputerModel(number, assembledYear, cBuilding, cRoomNo);

        }
    }
}