using battle;
using config;
using UnityEngine;

namespace battle
{ 
    public class BattleManager : MonoBehaviour
    {

        BattleView battleView; 

        public void OnEnterBattle()
        {
            GameObject battleViewObj = GameObject.Instantiate(Resources.Load("battle/BattleView", typeof(GameObject))) as GameObject;
            battleViewObj.transform.SetParent(transform);
            battleViewObj.transform.localScale = Vector3.one;
            battleViewObj.transform.localPosition = Positions.CENTER;

            battleView = battleViewObj.GetComponent<BattleView>();
        }

        public void OnLeaveBattle()
        {
            if (battleView)
                Destroy(battleView.gameObject);
        }
    }
}
