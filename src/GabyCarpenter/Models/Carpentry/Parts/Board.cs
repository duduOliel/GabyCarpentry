namespace GabyCarpenter.Models.Carpentry.Parts
{
    public enum BoardWoodTye
    {
        Oak, Pine, Birch
    }

    public class Board : Part
    {
        public BoardWoodTye WoodType { get; set; }

    }
}

