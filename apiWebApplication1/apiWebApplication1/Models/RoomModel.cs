using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiWebApplication1.Models
{
    public class RoomModel
    {
        public string Building { get; set; }
        public int RoomNo { get; set; }
        public int Capacity { get; set; }

        public RoomModel(string building, int roomNo, int capacity)
        {
            Building = building;
            RoomNo = roomNo;
            Capacity = capacity;
        }
    }
}