//using config;
//using System.Collections;
//using UnityEngine;

//namespace common
//{
//    public class LevelView : MonoBehaviour 
//    {
//        int level;
//        bool autoRemove = true;

//        public void moveUp()
//        {
//            level--;
//            setPosition(Positions.fromLevel(level), Timing.FLOOR_CHANGE);
//        }

//        public void setLevel(int lvl)
//        {
//            level = lvl;
//            setPosition(Positions.fromLevel(level));
//        }

//        public void setPosition(Vector3 endPos, float time = 0)
//        {
//            if (time <= 0)
//            {
//                this.transform.localPosition = endPos;
//                afterMove();
//            }
//            else
//            {
//                StartCoroutine(moveOverTime(endPos, time));
//            }
//        }

//        private IEnumerator moveOverTime(Vector3 endPos,  float time)
//        {
//            // make non-interactable during moving
//            float progress = 0f;
//            Vector3 startPos = transform.localPosition;

//            while (progress < time){
//                progress += Time.deltaTime;
//                transform.localPosition = Vector3.Lerp(startPos, endPos, progress / time);
//                yield return new WaitForSeconds(0.0f);
//            }

//            transform.localPosition = endPos;
//            afterMove();
//        }
        
//        private void afterMove(){
//            if (level < 0 && autoRemove){
//                Destroy(this.gameObject);
//            }
//        }
//    }
//}
