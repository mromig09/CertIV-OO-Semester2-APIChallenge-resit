using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiWebApplication1.Models
{
    public class ClassModel
    {
        public string ClassCode { get; set; }
        public string Name { get; set; }
        public string Building { get; set; }
        public int RoomNo { get; set; }

        public ClassModel(string classCode, string name, string cLbuilding, int cLRoomNo)
        {
            ClassCode = classCode;
            Name = name;
            Building = cLbuilding;
            RoomNo = cLRoomNo;
        }

        public ClassModel()
        {}


    }
}