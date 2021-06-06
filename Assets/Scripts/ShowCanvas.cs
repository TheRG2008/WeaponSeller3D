using UnityEngine;
using UnityEngine.Events;

public class ShowCanvas : MonoBehaviour
{
    public UnityEvent ClickGameObject;
    private void OnMouseDown()
    {
        ClickGameObject.Invoke();        
    }
   
    
}
