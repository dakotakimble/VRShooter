using UnityEngine;
using System.Collections;
using NewtonVR;
using UnityEngine.SceneManagement;



namespace NewtonVR.Example
{
    public class NVRCustom2 : MonoBehaviour
    {
        public NVRButton Button;
        public Spawner _hSpawner;
        

        private void Update()
        {
            if (Button.ButtonDown)
            {
                _hSpawner.totalEnemy++;
                _hSpawner.totalWaves++;
            }
        }

    }

}

