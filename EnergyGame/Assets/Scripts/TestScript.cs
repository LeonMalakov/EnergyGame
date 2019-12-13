using UnityEngine;

namespace EnergyGame
{
    public class TestScript : MonoBehaviour
    {
        GameLogicHandler _GLHandler;


        void Start()
        {
            if(SceneRegistrator.Current.GetObject(out _GLHandler))
            Debug.Log(_GLHandler.GameLogic.IsStarted);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                // Player Input ?
               // _GLHandler.
            }
        }

    }
}