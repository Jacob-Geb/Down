using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace dungeon.objects
{
    public class LootContainer : MonoBehaviour {

        [SerializeField]
        private Image containerIng;

        [SerializeField]
        private Sprite openSourceImg;

	    public void open () {
            containerIng.sprite = openSourceImg;
	    }
    }
}
