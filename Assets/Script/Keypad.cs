using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    [SerializeField] private Text Ans;

    public void Number(int number)
    {
        int panjang = Ans.text.Length;
        if(panjang <= 7){
            Ans.text += number.ToString();
        }
        

        
        
    }

    public void Hapus()
    {
        string text = Ans.text;
        string textjadi = Ans.text.Substring(0, Ans.text.Length - 1);
        Ans.text = textjadi;
    }

    public void Cek()
    {
        string jawaban = Ans.text;
        if(jawaban == "24434"){
            Debug.Log("Benar");
        }else{
            Debug.Log("Salah");
        }
    }


}
