using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Actions
{
    public class ChangeCharacter : MonoBehaviour
    {
        private List<GameObject> characters;
        private int currentCharacter;

        private void Start()
        {
            currentCharacter = 0;
            characters = new List<GameObject>();

            foreach (Transform child in transform)
            {
                characters.Add(child.gameObject);
            }
            characters[currentCharacter].SetActive(true);
        }

        private void OnCharacterChange(InputValue value)
        {
            GetComponentInChildren<Hook>()?.StopHook();
            
            if (value.Get<Vector2>().y > 0f)
            {
                SwitchToNextCharacter();
            }

            if (value.Get<Vector2>().y < 0f)
            {
                SwitchToPreviousCharacter();
            }
        }

        private void SwitchToNextCharacter()
        {
            currentCharacter++;
            
            if (currentCharacter > characters.Count - 1)
            {
                currentCharacter = 0;
            }

            SetActiveCharacter();
        }

        private void SwitchToPreviousCharacter()
        {
            currentCharacter--;
                        
            if (currentCharacter < 0)
            {
                currentCharacter = characters.Count - 1;
            }

            SetActiveCharacter();
        }

        private void SetActiveCharacter()
        {
            foreach (GameObject t in characters)
            {
                t.SetActive(false);
            }
            
            characters[currentCharacter].SetActive(true);
        }
    }
}
