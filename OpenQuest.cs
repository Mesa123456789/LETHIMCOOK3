using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LETHIMCOOK3
{
    public class OpenQuest
    {
        public Texture2D quest1, quest2, quest3;
        public bool onCursor;
        public Rectangle QuestRec;
        public bool Menuname;
        public OpenQuest(bool Menuname, Texture2D quest1, Texture2D quest2, Texture2D quest3, Rectangle QuestRec,bool onCursor)
        {
            this.Menuname = Menuname;
            this.quest1 = quest1;
            this.quest2 = quest2;
            this.quest3 = quest3;
            this.QuestRec = QuestRec;
            this.onCursor = onCursor;
        }
    }
}
