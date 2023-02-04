using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Toninho
{
    public class DialogPanel : MonoBehaviour
    {
        public Image picture;
        public TextMeshProUGUI text;

        public bool IsPlaying { get => this.text.GetComponent<TypewritingTextUI>().IsPlaying;  }

        public void SetActive(bool state)
        {
            gameObject.SetActive(state);
        }

        internal void Load(Sprite picture, string text)
        {
            this.picture.sprite = picture;
            this.text.GetComponent<TypewritingTextUI>().SetText(text);
            this.text.GetComponent<TypewritingTextUI>().PlayOnEnable = true;
        }

        internal void SetFullText()
        {
            this.text.GetComponent<TypewritingTextUI>().Stop();
        }
    }
}