using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Station
    {
        /*public class Consumables
        {
            int position;
            object[] data = new object[3];
            public void Push(object obj)
            {
                data[position++] = obj;
            }
            public object Pop()
            {
                return data[--position];
            }
        }*/
        public List<consumable> CUM = new List<consumable>();
        public List<reagent> RGT = new List<reagent>();
        public stack Stack = new stack();
        public class consumable
        {
            public int x { get; set; }
            public int y { get; set; }
            public string type { get; set; }
        }
        public class reagent
        {
            public int x;
            public int y;
            public char[] type { get; set; }
            public float[] volume { get; set; }
        }
        public class stack
        {
            public int Tip { get; set; }
            public int D96 { get; set; }
            public int S96 { get; set; }
        }
        public void record1(int x, int y, string type)
        {
            consumable consumables = new consumable();
            consumables.x = x;
            consumables.y = y;
            consumables.type = type;
            CUM.Add(consumables);
        }
        public void record2(int x,int y,char[] value1,float[] value2)
        {
            reagent rea = new reagent();
            rea.x = x;
            rea.y = y;
            rea.type = value1;
            rea.volume = value2;
            RGT.Add(rea);
        }
        public void record3(int x,int y,int z)
        {
            Stack.Tip = x;
            Stack.D96 = y;
            Stack.S96 = z;
        }
        public void delete(int x, int y)
        {
            bool deleted = false;
            for (var i = 0; i < CUM.Count; i++)
            {
                if ((CUM[i].x == x) & CUM[i].y == y)
                {
                    CUM.Remove(CUM[i]);
                    deleted = true;
                    break;
                }
            }
            if (!deleted)
            {
                for (var i = 0; i < RGT.Count; i++)
                {
                    if ((RGT[i].x == x) & RGT[i].y == y)
                    {
                        RGT.Remove(RGT[i]);
                        deleted = true;
                        break;
                    }
                }
            }
        }
    }
}
