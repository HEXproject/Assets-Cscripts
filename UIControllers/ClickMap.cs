using UnityEngine;

namespace Assets.UIControllers
{
    public class ClickMap : MonoBehaviour {

        // Use this for initialization
        void Start () {
		
        }
	
        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var hitInfo = new RaycastHit();
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
                {
                    print ("It's working");
                }
            }
        }
    }
}

