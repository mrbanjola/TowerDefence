using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    StartGame startGame; // todo Please fix this..

    // Start is called before the first frame update
    void Start()
    {
        
        DontDestroyOnLoad(gameObject);
        startGame = gameObject.GetComponent<StartGame>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            SceneManager.LoadScene(1);
            Destroy(startGame);
            

        }
    }
}
