using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    public Slider fuelBar;
    private GameObject player;
    private float health;
    // Start is called before the first frame update
    void Start()
    {
        fuelBar = gameObject.GetComponent<Slider>();
        player = Player.s_Singleton.gameObject;
        fuelBar.maxValue = player.GetComponent<Player>().maxFuel;
        fuelBar.value = player.GetComponent<Player>().fuel;
    }

    public void SetFuel(float fuel)
    {
        fuelBar.value = fuel;
    }
}
