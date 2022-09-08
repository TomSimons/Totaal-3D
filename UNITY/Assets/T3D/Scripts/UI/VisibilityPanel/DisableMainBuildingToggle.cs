using System.Collections;
using System.Collections.Generic;
using Netherlands3D.T3D.Uitbouw;
using T3D.Uitbouw;
using UnityEngine;
using UnityEngine.UI;

public class DisableMainBuildingToggle : UIToggle
{
    private int activeLod;

    private void Start()
    {
        var uploadedUitbouw = ServiceLocator.GetService<T3DInit>().HTMLData.HasFile;
        var drawChange = ServiceLocator.GetService<T3DInit>().HTMLData.Add3DModel;
        gameObject.SetActive(uploadedUitbouw && drawChange);
        if (!(uploadedUitbouw && drawChange))
        {
            var sd = transform.parent.GetComponent<RectTransform>().sizeDelta;
            //sizeDelta is a value type so cannot directly assign it
            transform.parent.GetComponent<RectTransform>().sizeDelta = new Vector2(sd.x, sd.y - GetComponent<RectTransform>().sizeDelta.y);
        }
    }

    protected override void ToggleAction(bool active)
    {
        CityJSONToCityObject building = RestrictionChecker.ActiveBuilding.GetComponent<CityJSONToCityObject>();
        var uitbouw = RestrictionChecker.ActiveUitbouw as UploadedUitbouw;//.GetComponent<CityObject>();
        if (active)
        {
            building.SetMeshActive(activeLod);
            CityJSONFormatter.AddCityObejct(building);
            //uitbouw.Type = uitbouwType;
            uitbouw.ReparentToMainBuilding(building);
        }
        else
        {
            //save data to set back when toggle is turned on again
            activeLod = building.ActiveLod;
            //uitbouwType = uitbouw.Type;

            building.SetMeshActive(-1);
            CityJSONFormatter.RemoveCityObject(building);
            //uitbouw.Type = CityObjectType.Building;
            uitbouw.UnparentFromMainBuilding();
        }
    }
}