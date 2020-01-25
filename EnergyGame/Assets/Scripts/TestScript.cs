using UnityEngine;

namespace EnergyGame
{
    public class TestScript : MonoBehaviour
    {
        GameLogicHandler _GLHandler;


        void Start()
        {
            if (SceneRegistrator.Current.GetObject(out _GLHandler))
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

        // Tests //
        [ContextMenu("TEST_SAVEGAME")]
        private void SaveGame()
        {
            string name = "Save " + Random.Range(0, 100000);
            bool success = GameManager.Instance.SaveGame(name);

            if (success) Debug.Log("Game saved");
            else
                Debug.LogWarning("Game not saved");
        }

    }
}
