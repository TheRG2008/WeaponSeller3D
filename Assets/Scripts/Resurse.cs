using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resurse : MonoBehaviour
{
    public Text[] quantityResurseText;
    public GameObject[] hidePanel;
   
    private int _bronze = 43;
    private int _iron = 32;
    private int _silver = 23;
    private int _coal = 43;
    private int _gold = 23;
    private int _ruby = 0;
    private int _dimond = 0;
    private int _emerald = 0;

    public int Bronze { get; set; }
    public int Iron { get; set; }
    public int Silver { get; set; }
    public int Coal { get; set; }
    public int Gold { get; set; }
    public int Ruby { get; set; }
    public int Dimond { get; set; }
    public int Emerald { get; set; }

    

    private void Awake()
    {
        Bronze = _bronze;
        Iron = _iron;
        Silver = _silver;
        Coal = _coal;
        Gold = _gold;
        Ruby = _ruby;
        Dimond = _dimond;
        Emerald = _emerald;
        ChangeCountResourse();
    }
    
    public void ChangeCountResourse ()
    {
       
        quantityResurseText[0].text = Bronze.ToString();
        HidePanel(Bronze, 0);
        quantityResurseText[1].text = Iron.ToString();
        HidePanel(Iron, 1);
        quantityResurseText[2].text = Silver.ToString();
        HidePanel(Silver, 2);
        quantityResurseText[3].text = Coal.ToString();
        HidePanel(Coal, 3);
        quantityResurseText[4].text = Gold.ToString();
        HidePanel(Gold, 4);
        quantityResurseText[5].text = Ruby.ToString();
        HidePanel(Ruby, 5);
        quantityResurseText[6].text = Dimond.ToString();
        HidePanel(Dimond, 6);
        quantityResurseText[7].text = Emerald.ToString();
        HidePanel(Emerald, 7);


    }

    private void HidePanel (int resourse, int numberPanel) 
    {
        if (resourse > 0)
        {
            hidePanel[numberPanel].SetActive(false);
        }
        else
        {
            hidePanel[numberPanel].SetActive(true);
        }
    }

    public void EnterResourse ()
    {
        Bronze = _bronze;
        Iron = _iron;
        Silver = _silver;
        Coal = _coal;
        Gold = _gold;
        Ruby = _ruby;
        Dimond = _dimond;
        Emerald = _emerald;
    } 

}
    

 
  

