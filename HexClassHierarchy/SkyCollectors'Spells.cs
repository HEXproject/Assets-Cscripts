using UnityEngine;

namespace Assets.HexClassHierarchy
{
    public class SteamHaze : SpellHex
    {
        public override void InitHex()
        {
            this.HexCost = new HexCost(0, 1, 0, 1);
        }
        public override void EnterOnSpecifiedTile(GameObject tile)
        {
            var deck = GetHexContainer("/Main Camera/HexUI/Deck");
            var hexType = "SpellHex";
            var hexTag = "BoostSpell";
            var spellsWithTag = GetHexByTypeFromContainer(deck, hexType);
            spellsWithTag = GetHexByTagFromIHexList(spellsWithTag, hexTag);
            foreach (var s in spellsWithTag)
            {
                s.HexCost.SpecialPoints -= 1;
            }
        }
    }

    public class OilExplosion : SpellHex
    {
        public override void InitHex()
        {
            HexCost = new HexCost(0, 0, 0, 1);
        }
        public override void EnterOnSpecifiedTile(GameObject tile)
        {
            //not ready :(
        }
    }
}