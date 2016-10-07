using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GabyCarpenter.Models.Carpentry.Parts
{
    public enum HangerMaterial
    {
        Iron, Silver, Plastic, Wood
    }

    public class Hanger : Part
    {
        public HangerMaterial material { get; set; }
    }
}

