using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    [SerializeField] private GameObject _volume;
    [SerializeField] private float _value;
    [SerializeField] private Slider _slider;

   

    void Update()
    {

        _value = _slider.value;
        _volume.GetComponent<AudioSource>().volume = _value;
    }
}
