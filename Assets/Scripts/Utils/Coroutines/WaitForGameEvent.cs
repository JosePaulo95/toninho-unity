using UnityEngine;

namespace Toninho
{
    public class WaitForGameEvent : CustomYieldInstruction, EventListener<GameEvent>
    {
        string m_gameEvent;
        bool m_gameEventHappened;

        public override bool keepWaiting
        {
            get
            {
                return !m_gameEventHappened;
            }
        }

        public WaitForGameEvent(string gameEvent)
        {
            m_gameEvent = gameEvent;
            m_gameEventHappened = false;

            EventManager.AddListener<GameEvent>(this);
        }

        public void OnEvent(GameEvent gameEvent)
        {
            if (gameEvent.EventName.Equals(m_gameEvent))
            {
                m_gameEventHappened = true;
            }
        }
    }
}