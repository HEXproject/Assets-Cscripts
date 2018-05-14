using UnityEngine;

namespace Assets.HexClassHierarchy
{
    public abstract class UnitHex : IHex
    {
        public bool IsExhausted;
        public int LifePoints { get; set; }
        public int AttackPoints { get; set; }
        public HexCost Cost { get; set; }
        public int Movement { get; set; }
        public int LifeTime { get; set; }
        public abstract void Attack(GameObject target);
        public abstract void Die();
    }
}
