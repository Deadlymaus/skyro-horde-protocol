using UnityEngine;
using VContainer;

namespace HordeProtocol.Gameplay
{
    public class GameState : MonoBehaviour
    {
        public bool isPlaying;
        public bool isPaused;
        public bool hasDied;

        [Inject]
        private UI_References uiReferences;

        public State state = State.Run;

        public void Awake()
        {
        }

        public void ChangeState()
        {
            switch (state)
            {
                case State.Run:

                    Time.timeScale = 1f;

                    if (isPaused) state = State.Pause;
                    else if (hasDied) state = State.GameOver;
                    break;
                case State.Pause:

                    Time.timeScale = 0f;

                    if (isPlaying) state = State.Run;
                    else if (hasDied) state = State.GameOver;
                    break;
                case State.GameOver:

                    Time.timeScale = 0f;
                    uiReferences.GameOverText.SetActive(true);

                    if (isPlaying) state = State.Run;
                    else if (isPaused) state = State.Pause;
                    break;
            }
        }
    }

    public enum State
    {
        Run,
        Pause,
        GameOver,

    }

    public interface ICommand
    {
        public void Execute();
    }
}
