using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAnimation : MonoBehaviour {
    //FONCTIONNEMENT DE MON PROGRAMME GENIAL
    //Active Spot : Active la fluctuation des limieres type Spot
    //Active Point : Active la fluctuation des lumieres type Point (cest genre effet lamp normal)
    //BoolWithLowerPoint : Active la fluctuation des deux type mais diminue l'intensité de fluctuation des Point de 3.0
    //BoolWithLowerPoint permet d'etre plus realiste pour l'eclairement dans la lampe

    private List<Light> lumieres;
    [SerializeField]
    float MaxIntensity, MinIntensity;
    [SerializeField]
    bool ActiveSpot, ActivePoint,BoolWithLowerPoint;

    void Start ()
    {
        lumieres = new List<Light>(this.gameObject.GetComponentsInChildren<Light>());
        if (BoolWithLowerPoint)
        {
            ActiveSpot = true;
            ActivePoint = false;
        }
    }
	
	void Update ()
    { 
        float numberrand = Random.Range(0.0f, 5.0f);
        float intensity = Random.Range(MinIntensity, MaxIntensity);
        if (numberrand>=4.3)
        {
            foreach(Light lumiere in this.lumieres)
            {
                if (lumiere.type == LightType.Spot && ActiveSpot)
                    lumiere.intensity = intensity;

                if (lumiere.type == LightType.Point && ActivePoint)
                    lumiere.intensity = intensity;

                if (lumiere.type == LightType.Point && BoolWithLowerPoint)
                    lumiere.intensity = intensity-3.0f;
            }
        }
	}
}
