using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characters;
    int selectedCharacter = 0;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var sel in characters)
        {
            sel.SetActive(false);
        }
        characters[selectedCharacter].SetActive(true);
    }

    public void ChangeCharacter(int newCharacter)
    {
        characters[selectedCharacter].SetActive(false);
        characters[newCharacter].SetActive(true);
        selectedCharacter = newCharacter;
    }
   
}
