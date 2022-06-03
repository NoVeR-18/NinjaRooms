using UnityEngine;
using UnityEngine.UI;
public class EnemyHPSlider : MonoBehaviour{
    public Slider slider;
    private EnemyHealth EnemyHealth;
    void Start(){

    }
    void Update()
    {
        slider.maxValue = EnemyHealth.maxHealth;
        slider.value = EnemyHealth.curHealth;
    }
}
