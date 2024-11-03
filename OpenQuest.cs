using LETHIMCOOK3.Screen;
using LETHIMCOOK3.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

using MonoGame.Extended.Collisions;
using MonoGame.Extended.Tiled.Renderers;
using MonoGame.Extended.Tiled;
using MonoGame.Extended;
using MonoGame.Extended.Timers;
using MonoGame.Extended.ViewportAdapters;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Input;

namespace LETHIMCOOK3
{
    public class OpenQuest
    {
        public Texture2D quest1, quest2, quest3;
        public bool onCursor;
        public Rectangle QuestRec;
        public bool Menuname;
        public bool iscomplet = false;
        public bool isActive = false;
        public bool isspaw = false;
        public OpenQuest(bool Menuname, Texture2D quest1, Texture2D quest2, Texture2D quest3,Rectangle QuestRec,bool onCursor)
        {
            this.Menuname = Menuname;
            this.quest1 = quest1;
            this.quest2 = quest2;    
            this.quest3 = quest3;
            this.QuestRec = QuestRec;
            this.onCursor = onCursor;
        }
        public void spawEnemy(int quest)
        {
            //{
            //if (quest == 3)
            //    isspaw = true;
            //    int countEnemy = 1;
            //    for (int i = 0; i < countEnemy; i++)
            //    {
            //        Game1.enemyList.Add(new Enemy("temura", GameplayScreen.tempura, new Food[1] { new Food("tempura", GameplayScreen.tempura, new Rectangle(0, 0, 32, 32), false) }, 5, new RectangleF(400, 300, 64, 64)));
            //    }
            //}
            //if (quest == 9)
            //{
            //    isspaw = true;
            //    int countEnemy = 1;
            //    for (int i = 0; i < countEnemy; i++)
            //    {
            //        Game1.enemyList.Add(new Enemy("temura", GameplayScreen.tempura, new Food[1] { new Food("tempura", GameplayScreen.tempura, new Rectangle(0, 0, 32, 32), false) }, 5, new RectangleF(400, 300, 64, 64)));
            //    }
            //}
        }

    }
}
