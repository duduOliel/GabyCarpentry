using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GabyCarpenter.Models.Carpentry.Parts
{
    public enum BoardWoodTye
    {
        Oak, Pine, Birch
    }

    public class Board : WoodPart
    {
        public BoardWoodTye woodType {get; set;}
        
    }
}

