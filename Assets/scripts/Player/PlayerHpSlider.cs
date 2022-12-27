using UnityEngine;
using UnityEngine.UI;
public class PlayerHpSlider : MonoBehaviour{
    public Slider slider;
    private PlayersHealth PlayersHealth;
    void Start(){

    }
    void Update(){
        slider.maxValue = PlayersHealth.MaxHealth;
        slider.value = PlayersHealth.curHealth;
    }
}
