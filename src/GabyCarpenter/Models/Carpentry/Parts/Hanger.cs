namespace GabyCarpenter.Models.Carpentry.Parts
{
    public enum HangerMaterial
    {
        Iron, Silver, Plastic, Wood
    }

    public class Hanger : Part
    {
        public HangerMaterial Material { get; set; }
    }
}

