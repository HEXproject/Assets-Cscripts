namespace Assets.HexClassHierarchy
{
    public class HexCost
    {
        public int CommandPoints { get; set; }
        public int TalentPoints { get; set; }
        public int FaithPoints { get; set; }
        public int SpecialPoints { get; set; }

        public HexCost(int commandPoints,int talentPoints, int faithPoints, int specialPoints)
        {
            CommandPoints = commandPoints;
            TalentPoints = talentPoints;
            FaithPoints = faithPoints;
            SpecialPoints = specialPoints;
        }
    }
}
