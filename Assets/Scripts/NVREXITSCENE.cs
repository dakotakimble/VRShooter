using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewtonVR.example
{

    public class NVREXITSCENE : MonoBehaviour
    {
        public class NVRCustom2 : MonoBehaviour
        {
            public NVRButton Button;
            public Spawner _hSpawner;


            private void Update()
            {
                if (Button.ButtonDown)
                {
                    Application.Quit();
                }
            }

        }
    }
}
