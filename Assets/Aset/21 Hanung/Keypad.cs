using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    [SerializeField] private Text Ans;
    public GameObject salah;
    public GameObject benar;

    void Start()
    {
        
    }

    public void Number(int number)
    {
        int panjang = Ans.text.Length;
        if(panjang <= 4){
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
            benar.SetActive(false);
        }else{
            string text = Ans.text;
            string textjadi = Ans.text.Substring(0, Ans.text.Length - 5);
            Ans.text = textjadi;
            salah.SetActive(true);
            Invoke("tutup", 2);
        }
    }

    public void tutup(){
        salah.SetActive(false);
    }


}
