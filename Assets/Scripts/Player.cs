using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public CharacterDatabase characterDB;

    public SpriteRenderer artworkSprite;
    
    private int selectedOption=0;
    
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption =0;
        }
        else
        {
            Load();
        }

        UpdateCharacter(selectedOption);
        


    }
    
      private void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.characterSprite; 
    }
    
    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    /*
    private void ChargeScene(int selectedOption)
    {
        if(selectedOption == 0)
        {
            SceneManager.LoadScene("jungle");
        }
        else
        {
            SceneManager.LoadScene("graveyard");
        }
    }
    */
}
