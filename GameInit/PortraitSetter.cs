using UnityEngine;

namespace Assets.GameInit
{
    public class PortraitSetter : InitializePlayersGameObjects
    {

        public override void Initialize(GameObject g)
        {
            GetValues();
            MakeGameObjectsFromValues();
            AttachTraitsToPortrait();
            GetPortraitModel();
            AttachModelToPortraitGameObject();
        }

        private void AttachModelToPortraitGameObject()
        {
        
        }

        private void GetPortraitModel()
        {
        
        }

        private void AttachTraitsToPortrait()
        {
        
        }

        private void MakeGameObjectsFromValues()
        {
        
        }

        private void GetValues()
        {
        
        }
    }
}
