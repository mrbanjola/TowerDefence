
using UnityEngine;
using TMPro;

public class MoneyTracker : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateMoney(int money)
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = string.Format("$ {0}",money);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
