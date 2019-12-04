using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiWebApplication1.Models
{
    public class RoomUsedModel
    {
        public string Building { get; set; }
        public int RoomNo { get; set; }
        public int Capacity { get; set; }
        //public ClassModel Used { get; set; }

        public RoomUsedModel(string building, int roomNo, int capacity)// string classCode, string name, string cLbuilding, int cLRoomNo)
        {
            Building = building;
            RoomNo = roomNo;
            Capacity = capacity;
            //Used = new ClassModel(classCode, name, cLbuilding, cLRoomNo);
            
        }
    }
}