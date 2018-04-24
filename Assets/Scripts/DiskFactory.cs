using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskFactory : MonoBehaviour
{
    public GameObject disk_prefab = null;                 //飞碟预制体
    private List<DiskData> used = new List<DiskData>();   //正在被使用的飞碟列表
    private List<DiskData> free = new List<DiskData>();   //空闲的飞碟列表

    public GameObject GetDisk(int round) {
         
		float start_y = UnityEngine.Random.Range(-10f,-7f);                             //刚实例化时的飞碟的竖直位置
     
        disk_prefab = null;
	
		disk_prefab = Instantiate(Resources.Load<GameObject>("Prefabs/disk1"), new Vector3(0, start_y, 0), Quaternion.identity);
		Color[] colors = { Color.black, Color.blue, Color.red, Color.yellow };
		//给新实例化的飞碟赋予其他属性
		float ran_x = Random.Range(-15f, 15f) ;
		disk_prefab.GetComponent<Renderer>().material.color = colors[UnityEngine.Random.Range(0,3)];
		disk_prefab.GetComponent<DiskData>().direction = new Vector3(ran_x, start_y, 0);
		disk_prefab.transform.localScale = disk_prefab.GetComponent<DiskData>().scale;
      
            
       
        //添加到使用列表中
        used.Add(disk_prefab.GetComponent<DiskData>());
        return disk_prefab;
    }

    //回收飞碟
    public void FreeDisk(GameObject disk)
    {
        for(int i = 0;i < used.Count; i++)
        {
            if (disk.GetInstanceID() == used[i].gameObject.GetInstanceID())
            {
                used[i].gameObject.SetActive(false);
                free.Add(used[i]);
                used.Remove(used[i]);
                break;
            }
        }
    }
}

