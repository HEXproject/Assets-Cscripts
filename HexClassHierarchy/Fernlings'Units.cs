using UnityEngine;

namespace Assets.HexClassHierarchy
{
    public class FernWolf : UnitHex
    {
        public override void InitHex()
        {
            this.HexCost = new HexCost(0, 1, 1, 2);
            this.AttackPoints = 4;
            this.LifePoints = 10;
        }
        public override void EnterOnSpecifiedTile(GameObject tile)
        {

        }
        public override void Attack(GameObject target)
        {
            target.GetComponent<UnitHex>().LifePoints -= AttackPoints;
        }

        public override void Die()
        {
        
        }
    }
}
