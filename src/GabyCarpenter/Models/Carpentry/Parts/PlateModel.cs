using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GabyCarpenter.Models.Carpentry.Parts
{
    public enum PlateMaterial
    {
        Plywood, Solid, MDF
    }
    public class PlateModel : WoodPart
    {
        public PlateMaterial MyProperty { get; set; }
    }
}
