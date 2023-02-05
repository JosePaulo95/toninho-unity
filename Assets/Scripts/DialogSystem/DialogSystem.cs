using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toninho
{
    [System.Serializable]
    public class DialogNode
    {
        public DialogSystem.DialogPanelType dialogType = DialogSystem.DialogPanelType.LEFTPICTURE;
        public Sprite picture;
        public string text;
        //public bool autoClose = false;
        //public float timeToAutoClose = 1f;
    }

    public class DialogSystem : MonoBehaviour
    {
        public enum DialogPanelType { LEFTPICTURE, RIGHTPICTURE }
        public List<DialogNode> dialogs;
        public GameObject refEnemySpawner;

        [Header("Panel Types")]
        public DialogPanel panelLeftPicture;
        public DialogPanel panelRightPicture;

        private void OnEnable()
        {
            panelLeftPicture.SetActive(false);
            panelRightPicture.SetActive(false);
            StartCoroutine(RunDialoguesCo());
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
                GameEvent.Trigger("AvancarDialogo");
        }

        IEnumerator RunDialoguesCo()
        {
            foreach (var dialog in dialogs)
            {
                DialogPanel pnl = LoadNode(dialog);

                pnl.SetActive(true);
                   
                yield return new WaitForGameEvent("AvancarDialogo");

                if (pnl.IsPlaying)
                {
                    pnl.SetFullText();

                    yield return new WaitForGameEvent("AvancarDialogo");
                }

                pnl.SetActive(false);
            }

            this.gameObject.SetActive(false);
            refEnemySpawner.GetComponent<EnemySpawner>().begin();
        }

        public DialogPanel LoadNode(DialogNode dialogNode)
        {
            DialogPanel panel = dialogNode.dialogType == DialogPanelType.LEFTPICTURE ? panelLeftPicture : panelRightPicture;

            panel.Load(dialogNode.picture, dialogNode.text);

            return panel;
        }
    }
}