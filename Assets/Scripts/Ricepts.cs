using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Ricepts : MonoBehaviour
{
    public Text[] textCountResorse; 
    public GameObject[] resourse;
    public Transform[] pointForResourse;
    public GameObject notHaveResurseCanvas;
   
    private int _currentDrawingNumber;
    public int drawingNumber;

    private static bool _bronzeSword = false;
    private static bool _bronzeAxe = false;
    private static bool _bronzeMace = false;
    private static bool _ironSword = false;
    private static bool _ironAxe = false;
    private static bool _ironMace = false;
    private static bool _bow = false;


    private int _count = 0;
    private int _NumberDrawing = 0;
    private int _currentTransform = 0;

    //Порядковый номер чертежа(0) и колличество необходимых ресурсов для крафта этого чертежа(1....n)
    //Последовательность ресурсов в массиве, начиная с 1-го элемента:
    //бронза-1, железо-2, серебро-3, уголь-4, золото-5, рубин-6, алмаз-7, изумруд-8
    private static int[] _bronzeSwordNumberAndResourse = { 0, 2, 0, 0, 1, 0, 0, 0, 0 };
    private static int[] _bronzeAxeNumberAndResourse = { 1, 3, 0, 0, 2, 0, 0, 0, 0 };
    private static int[] _bronzeMaceNumberAndResourse = { 2, 2, 0, 0, 4, 0, 0, 0, 0 };
    private static int[] _ironSwordNumberAndResourse = { 3, 0, 2, 0, 2, 0, 0, 0, 0 };
    private static int[] _ironAxeNumberAndResourse = { 4, 0, 3, 0, 2, 0, 0, 0, 0 };
    private static int[] _ironMaceNumberAndResourse = { 5, 1, 3, 0, 2, 0, 0, 0, 0 };
    private static int[] _bowNumberAndResourse = { 6, 0, 0, 0, 0, 2, 0, 0, 0 };

    // Массив всех Item
    private int[][] _arrayItems = { _bronzeSwordNumberAndResourse , _bronzeAxeNumberAndResourse , 
        _bronzeMaceNumberAndResourse, _ironSwordNumberAndResourse, _ironAxeNumberAndResourse, 
        _ironMaceNumberAndResourse, _bowNumberAndResourse};

    //Поля куда присваиваем текущее значение колличества ресурсов для крафта, в зависимости от выбранного черетежа
    public int bronzeForCrafting = 0;
    public int ironForCrafting = 0;
    public int silverForCrafting = 0;
    public int coalForCrafting = 0;
    public int goldForCrafting = 0;
    public int rubyForCrafting = 0;
    public int dimondForCrafting = 0;
    public int emeraldForCrafting = 0;



    public static bool[] _drawingIsActive = { _bronzeSword, _bronzeAxe, _bronzeMace, _ironSword, _ironAxe, _ironMace, _bow };

    private void Awake()
    {
        _currentDrawingNumber = drawingNumber;
       
    }
    public void FindDrawing ()
    {
        for (int i = 0; i < _drawingIsActive.Length; i++)
        {
            _drawingIsActive[i] = false;
        }

        for (int i = 0; i < _drawingIsActive.Length; i++)
        {
            if (_count == _currentDrawingNumber)
            {
                _drawingIsActive[i] = true;
                
            }
            _count++;
        }
        _count = 0;
        ShowResourceForCraft(_currentDrawingNumber);
    }

    public void ShowResourceForCraft(int currentDrawing)
    {
        ClearPanel();

        for (int i = 0; i < _drawingIsActive.Length; i++)
        {
            if (_drawingIsActive[i])
            {
                _NumberDrawing = i;
            }
            
        }

        for (int i = 0; i < _arrayItems.Length; i++)
        {
            if (_arrayItems[i][0] == _NumberDrawing)
            {
                bronzeForCrafting = _arrayItems[i][1];              
                ironForCrafting = _arrayItems[i][2];              
                silverForCrafting = _arrayItems[i][3];
                coalForCrafting = _arrayItems[i][4];
                goldForCrafting = _arrayItems[i][5];
                rubyForCrafting = _arrayItems[i][6];
                dimondForCrafting = _arrayItems[i][7];
                emeraldForCrafting = _arrayItems[i][8];


                for (int j = 0; j < _arrayItems[i].Length; j++)
                {
                    
                    if (_arrayItems[i][j] > 0 && j != 0)
                    {
                        GetResourseAndTransform(j, _currentTransform, $"{_arrayItems[i][j]}");
                        _currentTransform++;
                    }
                }
            }
        }
        _currentTransform = 0;       
    }


    private void GetResourseAndTransform(int numberOfResourse, int transformPoint, string quantityResourseForCraft)
    {
        resourse[numberOfResourse].SetActive(true);
        resourse[numberOfResourse].transform.position = pointForResourse[transformPoint].transform.position;
        textCountResorse[numberOfResourse].text = quantityResourseForCraft;
    }

    public void ClearPanel()
    {
        bronzeForCrafting = 0;
        ironForCrafting = 0;
        silverForCrafting = 0;
        coalForCrafting = 0;
        goldForCrafting = 0;
        rubyForCrafting = 0;
        dimondForCrafting = 0;
        emeraldForCrafting = 0;

        for (int i = 0; i < resourse.Length; i++)
        {
            resourse[i].SetActive(false);
        }
    }

    public void BuyResourse ()
    {
        Resurse curentResurse = new Resurse();
        

        for (int i = 0; i < _arrayItems.Length; i++)
        {
            if (_arrayItems[i][0] == _NumberDrawing)
            {
                for (int j = 0; j < _arrayItems[i].Length; j++)
                {
                    if (_arrayItems[i][j] > 0 && j == 1)
                    {
                        if (curentResurse.Bronze >= _arrayItems[i][j])
                        {
                            curentResurse.Bronze -= _arrayItems[i][j];
                        }
                        else notHaveResurseCanvas.SetActive(true);
                    }

                    if (_arrayItems[i][j] > 0 && j == 2)
                    {
                        if (curentResurse.Iron >= _arrayItems[i][j])
                        {
                            curentResurse.Iron -= _arrayItems[i][j];
                        }
                        else notHaveResurseCanvas.SetActive(true);
                    }

                    if (_arrayItems[i][j] > 0 && j == 3)
                    {
                        if (curentResurse.Silver >= _arrayItems[i][j])
                        {
                            curentResurse.Silver -= _arrayItems[i][j];
                        }
                        else notHaveResurseCanvas.SetActive(true);
                    }

                    if (_arrayItems[i][j] > 0 && j == 4)
                    {
                        if (curentResurse.Coal >= _arrayItems[i][j])
                        {
                            curentResurse.Coal -= _arrayItems[i][j];
                        }
                        else notHaveResurseCanvas.SetActive(true);
                    }

                    if (_arrayItems[i][j] > 0 && j == 5)
                    {
                        if (curentResurse.Gold >= _arrayItems[i][j])
                        {
                            curentResurse.Gold -= _arrayItems[i][j];
                        }
                        else notHaveResurseCanvas.SetActive(true);
                    }

                    if (_arrayItems[i][j] > 0 && j == 6)
                    {
                        if (curentResurse.Ruby >= _arrayItems[i][j])
                        {
                            curentResurse.Ruby -= _arrayItems[i][j];
                        }
                        else notHaveResurseCanvas.SetActive(true);
                    }

                    if (_arrayItems[i][j] > 0 && j == 7)
                    {
                        if (curentResurse.Dimond >= _arrayItems[i][j])
                        {
                            curentResurse.Dimond -= _arrayItems[i][j];
                        }
                        else notHaveResurseCanvas.SetActive(true);
                    }

                    if (_arrayItems[i][j] > 0 && j == 8)
                    {
                        if (curentResurse.Emerald >= _arrayItems[i][j])
                        {
                            curentResurse.Emerald -= _arrayItems[i][j];
                        }
                        else notHaveResurseCanvas.SetActive(true);
                    }


                }
            }
        }
    }

  

}
