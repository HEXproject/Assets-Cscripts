using UnityEngine;

namespace Assets.HexClassHierarchy
{
    public class BrokenMinersCarrier : UnitHex
    {
        public override void InitHex()
        {
            HexCost = new HexCost(3, 0, 0, 1);
            AttackPoints = 1;
            LifePoints = 6;
        }

        public override void EnterOnSpecifiedTile(GameObject tile)
        {
            ChangeLifePoints(this, -4);
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
