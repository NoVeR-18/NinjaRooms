using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayersHealth : MonoBehaviour{
    [SerializeField]
    static public int MaxHealth = 100;
    static public int curHealth = 100;
    void Start(){
        
    }
    void Update(){
        AddjustCurrentHealth(0);
        if (curHealth <= 0){
           SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void AddjustCurrentHealth(int adj)
    {
        curHealth -= adj;
        if (curHealth < 0)
            curHealth = 0;

        if (curHealth > MaxHealth)
            curHealth = MaxHealth;

        if (MaxHealth < 1)
            MaxHealth = 1;
    }
}
