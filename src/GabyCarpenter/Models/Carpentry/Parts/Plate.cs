namespace GabyCarpenter.Models.Carpentry.Parts
{
    public enum PlateMaterial
    {
        Plywood, Solid, Mdf
    }
    public class Plate : Part
    {
        public PlateMaterial PlateMaterial { get; set; }
    }
}
