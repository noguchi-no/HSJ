using UnityEngine;

public class PanelOpen : MonoBehaviour
{
    [SerializeField]
    GameObject targetObj;
    public void Onclick(bool active)
    {
        targetObj.SetActive(active);
    }
}
