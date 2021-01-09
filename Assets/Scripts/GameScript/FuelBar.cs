using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    public Slider fuelBar;
    private GameObject player;
    private int curfuel;
    // Start is called before the first frame update
    void Start()
    {
        fuelBar = gameObject.GetComponent<Slider>();
        player = Player.s_Singleton.gameObject;
        fuelBar.maxValue = player.GetComponent<Player>().maxFuel;
        fuelBar.value = player.GetComponent<Player>().fuel;
        curfuel = (int)fuelBar.maxValue;
    }

    private void FixedUpdate()
    {
        if (fuelBar.value > curfuel)
        {
            fuelBar.value = fuelBar.value - 1;
        }
        else if (fuelBar.value < curfuel)
        {
            fuelBar.value = fuelBar.value + 1;
        }
    }

    public void SetFuel(int fuel)
    {
        curfuel = fuel;
    }
}
