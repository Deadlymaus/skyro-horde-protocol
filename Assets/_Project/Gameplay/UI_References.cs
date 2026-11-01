using TMPro;
using UnityEngine;

namespace HordeProtocol.Gameplay
{
    public class UI_References : MonoBehaviour
    {
        public GameObject Pause;
        public GameObject GameOverText;

        public TMP_Text EnemiesKilledText;
        private int EnemiesKilled;


        private void OnEnable()
        {
            EnemyScript.EnemyHasDied += ChangeEnemiesCountKilled;
        }

        private void OnDisable()
        {
            EnemyScript.EnemyHasDied -= ChangeEnemiesCountKilled;
        }

        public void ChangeEnemiesCountKilled()
        {
            EnemiesKilled += 1;
            EnemiesKilledText.text = "Enemies killed: " + EnemiesKilled.ToString();
        }

        public void SendPauseCommand()
        {
            ICommand PauseCommand = new Pause(Pause);
            PauseCommand.Execute();
        }
    }
}
