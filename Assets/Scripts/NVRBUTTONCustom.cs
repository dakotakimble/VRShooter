using UnityEngine;
using System.Collections;
using NewtonVR;
using UnityEngine.SceneManagement;



namespace NewtonVR.Example
{
    public class NVRBUTTONCustom : MonoBehaviour
    {
        public NVRButton Button;
        public GameObject _hSpawner;
        public NVRExampleButtonResetScene _resetButton;

        private void Update()
        {
            if (Button.ButtonDown)
            {
                _resetButton.ResetScene();
            }
        }

    }

}
