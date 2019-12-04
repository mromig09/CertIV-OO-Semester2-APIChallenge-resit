using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiWebApplication1.Models
{
    public class ComputerModel
    {
        public int Number { get; set; }
        public int AssembledYear { get; set; }
        public string Building { get; set; }
        public int RoomNo { get; set; }

        public ComputerModel(int number, int assembledYear, string cBuilding, int cRoomNo)
        {
            Number = number;
            AssembledYear = assembledYear;
            Building = cBuilding;
            RoomNo = cRoomNo;
        }
    }
}