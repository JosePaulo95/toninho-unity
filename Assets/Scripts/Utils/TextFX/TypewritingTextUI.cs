using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

namespace Toninho
{
    public class TypewritingTextUI : MonoBehaviour
    {
        public bool IsPlaying { get { return m_isPlaying; } }

        public float StepTime = 0.3f;
        public float DelayTime = 0f;
        public bool PlayOnEnable = false;

        public UnityEvent OnStart;
        public UnityEvent OnFinish;

        TextMeshProUGUI m_text;
        string m_originalText;
        List<string> m_tokenizedText;
        bool m_configured = false;
        bool m_isPlaying;
        Coroutine m_playCo;

        void OnEnable()
        {
            Configure();

            if (PlayOnEnable)
            {
                m_playCo = StartCoroutine(PlayCo());
            }
        }

        void Configure()
        {
            if (!m_configured)
            {
                m_tokenizedText = new List<string>();
                m_text = GetComponent<TextMeshProUGUI>();

                m_originalText = m_text.text;
                m_text.text = "";

                Tokenize();

                m_configured = true;
            }
        }

        public void SetText(string newText)
        {
            Configure();

            m_originalText = newText;

            if (m_playCo != null)
            {
                StopCoroutine(m_playCo);
                m_playCo = null;
            }

            Tokenize();

            m_configured = true;
        }

        public void Play()
        {
            if (!m_configured)
                return;

            m_playCo = StartCoroutine(PlayCo());
        }

        public void Stop()
        {
            if (m_playCo == null || !m_configured)
                return;

            StopCoroutine(m_playCo);

            m_text.text = m_originalText;
            m_isPlaying = false;
            OnFinish?.Invoke();
        }

        IEnumerator PlayCo()
        {
            m_text.text = "";
            m_isPlaying = true;

            yield return new WaitForSeconds(DelayTime);

            OnStart?.Invoke();

            foreach (string token in m_tokenizedText)
            {
                m_text.text += token;

                yield return new WaitForSeconds(StepTime);
            }

            m_isPlaying = false;
            OnFinish?.Invoke();
        }

        void Tokenize()
        {
            bool OpeningTag = false;
            bool ReadingTagContent = false;
            bool BetweenTag = false;

            string currentOpenTag = "";
            string currentCloseTag = "";
            List<string> pendingString = new List<string>();

            m_tokenizedText.Clear();

            for (int i = 0; i < m_originalText.Length; i++)
            {
                if (m_originalText[i] == '<')
                {
                    if (m_originalText[i + 1] != '/')
                        OpeningTag = true;

                    BetweenTag = false;
                    ReadingTagContent = true;
                }

                if (ReadingTagContent)
                {
                    if (OpeningTag)
                        currentOpenTag += m_originalText[i];
                    else
                        currentCloseTag += m_originalText[i];
                }
                else if (BetweenTag)
                {
                    pendingString.Add(currentOpenTag + m_originalText[i]);
                }
                else
                {
                    m_tokenizedText.Add(m_originalText[i].ToString());
                }

                if (m_originalText[i] == '>')
                {
                    if (OpeningTag)
                    {
                        OpeningTag = false;
                        BetweenTag = true;
                    }
                    else
                    {
                        foreach (string item in pendingString)
                        {
                            m_tokenizedText.Add(item + currentCloseTag);
                        }

                        currentOpenTag = "";
                        currentCloseTag = "";
                        pendingString.Clear();
                    }

                    ReadingTagContent = false;
                }
            }
        }
    }
}