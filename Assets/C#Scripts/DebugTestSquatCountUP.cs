using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTestSquatCountUP : MonoBehaviour
{
 
    public void TotalUP (){
        LoginBonus.LoginInt=8;
        PlayerPrefs.SetInt("LoginPoint", LoginBonus.LoginInt);
        PlayerPrefs.Save();
        CostumeChange.release = true;
        CharacterManager.allSquatTotal += 1;
        PlayerPrefs.SetInt("AllSqwat", CharacterManager.allSquatTotal);
        PlayerPrefs.Save();
    }

    public void NUP()
    {
        CostumeChange.release = true;
        CharacterManager.NormalSquatTotal += 1;
        PlayerPrefs.SetInt("NormalSqwat", CharacterManager.NormalSquatTotal);
        PlayerPrefs.Save();
    }

    public void QUP()
    {
        CostumeChange.release = true;
        CharacterManager.quarterSquatTotal += 1;
        PlayerPrefs.SetInt("QuarterSqwat", CharacterManager.quarterSquatTotal);
        PlayerPrefs.Save();
    }

    public void WUP()
    {
        CostumeChange.release = true;
        CharacterManager.wideSquatTotal += 1;
        PlayerPrefs.SetInt("WideSqwat", CharacterManager.wideSquatTotal);
        PlayerPrefs.Save();
    }
}
