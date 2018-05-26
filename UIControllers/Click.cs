using UnityEngine;
using UnityEngine.UI;

namespace Assets.UIControllers
{
    public class Click : MonoBehaviour {

        public Button YourButton;

        void Start()
        {
            var btn = YourButton.GetComponent<Button>();
            btn.onClick.AddListener(TaskOnClick);
        }

        void TaskOnClick()
        {
            Debug.Log("KLIK!");
        }
    }
}
