using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {
    [Serializable]
    public class Count
    {
        public int maxi;
        public int mini;
        public Count(int min, int max)
        {
            mini = min;
            maxi = max;
        }
        public int colum = 8; // number we can choose
        public int raw = 8; // we can choose as well
        public Count wallcount = new Count(5, 9); // we choose randomly the number of walls
        public Count foodcount = new Count(1, 5); //number of foods
        public GameObject exit;
        public GameObject[] Floortiles;
        public GameObject[] walltiles;
        public GameObject[] Foodt;
        public GameObject[] ennemy;
        public GameObject[] outerwall;

        private Transform Boardhold; //keep it clean
        private List<Vector3> gridpos = new List<Vector3>();
        void Initional_list()
        {
            gridpos.Clear();
            for (int x = 1; x < colum; x++)
            {
                for (int y = 1; y < raw; y++)
                {
                    gridpos.Add(new Vector3(x, y, 0f));

                }
            }
        }
        void Boardsetup()
        {
            Boardhold = new GameObject("Board").transform;
            for (int x = -1; x < colum; x++)
            {
                for(int y = -1;y<raw;y++)
                {
                    GameObject Instence = Floortiles[Random.Range(0, Floortiles.Length)];
                    if(x == -1 || x == colum || y==-1 || y == raw)
                    {
                        Instence = outerwall[Random.Range(0, outerwall.Length)];
                    }
                    GameObject inst = Instantiate(Instence, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                    inst.transform.SetParent(Boardhold);
                }
            }
        }
        Vector3 randomp()
        {
            int rindex = Random.Range(0, gridpos.Count);
            Vector3 rposi = gridpos[rindex];
            gridpos.RemoveAt(rindex);
            return rposi;
        }
        void layatran(GameObject[] arr,int minim,int mixim )
        {
            int oc = Random.Range(minim, mixim + 1);
            for(int i = 0;i < oc;i++)
            {
                Vector3 rpos = randomp();
                GameObject tc = arr[Random.Range(0, arr.Length)];
                Instantiate(tc, rpos, Quaternion.identity);
            }
        }
        public void Sscene(int lvl)
        {
            Boardsetup();
            Initional_list();
            layatran(walltiles, wallcount.mini, wallcount.maxi);
            layatran(Foodt, foodcount.mini, foodcount.maxi);
            int ennemyc = (int)Mathf.Log(lvl, 2f);
            layatran(ennemy, ennemyc, ennemyc);
            Instantiate(exit,new Vector3(colum - 1, raw - 1, 0f), Quaternion.identity);
        }
    }

    
  
	
	
}
