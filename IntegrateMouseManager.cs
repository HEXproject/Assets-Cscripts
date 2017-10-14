//using system.collections;
//using system.collections.generic;
//using unityengine;
//using unityengine.eventsystems;

//public class mousemanager : monobehaviour
//{
//    public gameobject lasthitobject;
//    public gameobject lastclickedobject;
//    public gameobject chosenhexfromhand;
//    int a = 0;
//    public int range;
//    public int ksztalt;

//    void update()
//    {

//        ray mouseray = camera.main.screenpointtoray(input.mouseposition);
//        raycasthit hitinfo;


//        // lets check if we are over ui element or game object

//        if (eventsystem.current.ispointerovergameobject())
//        {
//            return;
//        }




//        if (physics.raycast(mouseray, out hitinfo))
//        {


//            gameobject ourhitobject = hitinfo.collider.transform.parent.gameobject;

//            if (ourhitobject.getcomponent<hex>() != null)
//            {
//                mouseover_hex(ourhitobject);

//            }



//        }
//    }



//    void mouseover_hex(gameobject ourhitobject)

//    {
//        //debug.log("raycast hit " + ourhitobject.name);

//        meshrenderer activetile = ourhitobject.getcomponentinchildren<meshrenderer>();
//        activetile.material.color = color.yellow;

//        if (input.getmousebuttondown(0) && chosenhexfromhand != null)
//        {
//            chosenhexfromhand.getcomponent<transform>().rotate(vector3.right * 90);
//            vector3 newposition = new vector3(lasthitobject.transform.position.x, lasthitobject.transform.position.y + 1, lasthitobject.transform.position.z);
//            chosenhexfromhand.getcomponent<transform>().position = newposition;

//        }
//        if (input.getmousebuttondown(0))
//        {
//            if (ksztalt == 0)
//            {
//                if (ourhitobject != lastclickedobject && lastclickedobject != null)
//                {
//                    color_line(ourhitobject);
//                }
//                lastclickedobject = ourhitobject;
//            }
//            else
//                color_circle(ourhitobject);

//        }


//        if (a == 1 && lasthitobject != ourhitobject && activetile.material.color == color.yellow)
//        {
//            meshrenderer lasttile = lasthitobject.getcomponentinchildren<meshrenderer>();
//            lasttile.material.color = color.white;
//        }
//        lasthitobject = ourhitobject;
//        a = 1;


//    }
//    void color_circle(gameobject ourhitobject)
//    {
//        int x = ourhitobject.getcomponent<hex>().x;
//        int y = ourhitobject.getcomponent<hex>().y;

//        int a = -range + range / 2;
//        int b = range - ((range + 1) / 2);

//        if (y % 2 == 0)
//        {

//            for (int i = -range; i <= range; i++)
//            {
//                for (int j = a; j <= b; j++)
//                {

//                    if (gameobject.find("hex_" + (x + j) + "_" + (y + i)) != null)
//                    {
//                        hex active = gameobject.find("hex_" + (x + j) + "_" + (y + i)).getcomponent<hex>();
//                        meshrenderer mr = active.getcomponentinchildren<meshrenderer>();
//                        mr.material.color = color.red;
//                    }



//                }

//                if (i < 0)
//                {
//                    if (i % 2 == -1)
//                    {
//                        b++;
//                    }
//                    else
//                    {
//                        a--;
//                    }
//                }
//                else
//                {
//                    if (i % 2 == 1)
//                    {
//                        a++;
//                    }
//                    else
//                    {
//                        b--;
//                    }
//                }
//            }
//        }
//        else
//        {
//            if (range % 2 == 0)
//            {
//                a--;
//                b--;
//            }
//            for (int i = -range; i <= range; i++)
//            {
//                for (int j = a + 1; j <= b + 1; j++)
//                {
//                    if (gameobject.find("hex_" + (x + j) + "_" + (y + i)) != null)
//                    {
//                        hex active = gameobject.find("hex_" + (x + j) + "_" + (y + i)).getcomponent<hex>();
//                        meshrenderer mr = active.getcomponentinchildren<meshrenderer>();
//                        mr.material.color = color.red;
//                    }
//                }

//                if (i < 0)
//                {
//                    if (i % 2 == 0)
//                    {
//                        b++;
//                    }
//                    else
//                    {
//                        a--;
//                    }
//                }
//                else
//                {
//                    if (i % 2 == 0)
//                    {
//                        a++;
//                    }
//                    else
//                    {
//                        b--;
//                    }
//                }
//            }
//        }
//    }


//    void color_line(gameobject ourhitobject)
//    {

//        int ax = ourhitobject.getcomponent<hex>().x;
//        int ay = ourhitobject.getcomponent<hex>().y;

//        int bx = lastclickedobject.getcomponent<hex>().x;
//        int by = lastclickedobject.getcomponent<hex>().y;

//        draw_line(ourhitobject, lastclickedobject);

//    }

//    float lerp(float a, float b, float t)
//    {
//        //debug.log((float)(a + (b - a) * t));
//        return mathf.round(a + 0.0001f + (b - a) * t);


//    }


//    void draw_line(gameobject ourhitobject, gameobject lastclickobject)
//    {
//        int qa = ourhitobject.getcomponent<hex>().x;
//        int ra = ourhitobject.getcomponent<hex>().y;
//        int ax = (int)(qa - (ra - (ra & 1)) / 2);
//        int az = ra;
//        int ay = -ax - az;


//        int qb = lastclickedobject.getcomponent<hex>().x;
//        int rb = lastclickedobject.getcomponent<hex>().y;
//        int bx = (int)(qb - (rb - (rb & 1)) / 2);
//        int bz = rb;
//        int by = -bx - bz;

//        float n = mathf.max(mathf.abs(ax - bx), mathf.abs(ay - by), mathf.abs(az - bz));
//        debug.log("n=" + n);
//        float t = 1.0f / n;

//        for (int i = 0; i <= n; i++)
//        {
//            float x = lerp(ax, bx, t * i);
//            float z = lerp(az, bz, t * i);
//            debug.log("x+z=" + x + " " + z);
//            float q = (x + (z - (z % 2)) / 2);
//            float r = z;
//            debug.log("q+r=" + q + " " + r);
//            if (gameobject.find("hex_" + q + "_" + r) != null)
//            {
//                hex active = gameobject.find("hex_" + q + "_" + r).getcomponent<hex>();
//                meshrenderer mr = active.getcomponentinchildren<meshrenderer>();
//                mr.material.color = color.red;
//            }

//        }


//    }




//}