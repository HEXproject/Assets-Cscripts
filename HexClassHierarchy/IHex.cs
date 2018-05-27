using System.Collections.Generic;
using Assets.HexClassHierarchy;
using UnityEngine;

public abstract class IHex : MonoBehaviour{
    private List<string> _hexTags;
    private string _hexDescription;

    public string HexName { get; set; }

    public HexCost HexCost { get; set; }

    protected void ChangeAttackPoints(UnitHex aUnit, int valueToChange)
    {
        aUnit.AttackPoints += valueToChange;
        if (aUnit.AttackPoints < 0) aUnit.AttackPoints = 0;
    }
    protected void ChangeLifePoints(UnitHex aUnit, int valueToChange)
    {
        aUnit.LifePoints += valueToChange;
        if (aUnit.LifePoints < 0)
        {
            DestroyUnit(aUnit);
        }
    }
    protected void ChangeFaithCost(IHex aUnit, int valueToChange)
    {
        aUnit.HexCost.FaithPoints += valueToChange;
        if (aUnit.HexCost.FaithPoints < 0) aUnit.HexCost.FaithPoints = 0;
    }
    protected void ChangeCommandCost(IHex aUnit, int valueToChange)
    {
        aUnit.HexCost.CommandPoints += valueToChange;
        if (aUnit.HexCost.CommandPoints < 0) aUnit.HexCost.CommandPoints = 0;
    }
    protected void ChangeTalentCost(IHex aUnit, int valueToChange)
    {
        aUnit.HexCost.TalentPoints += valueToChange;
        if (aUnit.HexCost.TalentPoints < 0) aUnit.HexCost.TalentPoints = 0;
    }
    protected void ChangeSpecialCost(IHex aUnit, int valueToChange)
    {
        aUnit.HexCost.SpecialPoints += valueToChange;
        if (aUnit.HexCost.SpecialPoints < 0) aUnit.HexCost.SpecialPoints = 0;
    }
    protected void ChangeMovement(UnitHex aUnit, int valueToChange)
    {
        aUnit.Movement += valueToChange;
        if (aUnit.Movement < 0) aUnit.Movement = 0;
    }
    
    protected void DestroyUnit(UnitHex unitToDestroy)
    {
        GameObject hexContainer = GetHexContainer("/Main Camera/HexUI/Graveyard");
        unitToDestroy.GetComponent<Transform>().parent.gameObject.GetComponent<Transform>().SetParent(null);
        unitToDestroy.GetComponent<Transform>().parent.gameObject.GetComponent<Transform>().position = hexContainer.GetComponent<Transform>().position;
        unitToDestroy.GetComponent<Transform>().parent.gameObject.GetComponent<Transform>().SetParent(hexContainer.GetComponent<Transform>());
        return;
    }

    //better move to other class
    protected GameObject GetHexContainer(string hexContainerName)
    {
        return this.GetComponent<Transform>().parent.Find(hexContainerName).gameObject; 
    }
    
    protected List<IHex> GetHexByTypeFromContainer(GameObject hexContainer, string hexType)
    {
        var listOfHexes = new List<IHex>();
        if(hexContainer == null)
        {
            Debug.Log("hexContainer == null");
            return null;
        }
        else
        {
            for(var i = 0; i < hexContainer.GetComponent<Transform>().childCount - 1; ++i)
            {
                if(hexContainer.GetComponent<Transform>().GetChild(i).GetComponent<IHex>()!=null 
                    && hexContainer.GetComponent<Transform>().GetChild(i).GetComponent<IHex>().GetType().Name==hexType)
                listOfHexes.Add(hexContainer.GetComponent<Transform>().GetChild(i).GetComponent<IHex>());
            }
        }        
        return listOfHexes;
    }
    
    protected List<IHex> GetHexByTagFromIHexList(List<IHex> ihexList, string tags)
    {
        var listOfIHexWithProperTag = new List<IHex>();
        for(var i = ihexList.Count-1; i >= 0; --i)
        {
            foreach(var t in ihexList[i]._hexTags)
            {
                if(t == tags)
                {
                    listOfIHexWithProperTag.Add(ihexList[i]);
                    break;
                }
            }
        }
        return listOfIHexWithProperTag;
    }

    //find neighbour hexTiles
    //find neighbour hexUnits

    public abstract void EnterOnSpecifiedTile(GameObject tile);
    public abstract void InitHex();

}
