﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using QURO;
using System.Windows.Forms;

namespace SpriteMapEditor.SpriteMapModifications
{
    class AddSprite : ISpriteMapModification
    {
        private readonly BindingList<Sprite> allSprites;

        private readonly Sprite selectedSprite;

        private List<int> preChangeSelection;
        private List<int> postChangeSelection;

        public AddSprite(BindingList<Sprite> spriteList, Sprite selected = null)
        {
            allSprites = spriteList;

            selectedSprite = selected;
        }

        public void Do()
        {
            if (selectedSprite != null)
                allSprites.Add(new Sprite(selectedSprite.Name, selectedSprite.Bounds, selectedSprite.Origin));
            else
                allSprites.Add(new Sprite());
        }

        public void Undo()
        {
            allSprites.RemoveAt(allSprites.Count - 1);
        }

        public List<int> GetPreChangeSelection()
        {
            return preChangeSelection;
        }
        public void SetPreChangeSelection(List<int> currentSelection)
        {
            preChangeSelection = currentSelection;
        }
        public List<int> GetPostChangeSelection()
        {
            return postChangeSelection;
        }
        public void SetPostChangeSelection(List<int> currentSelection)
        {
            postChangeSelection = currentSelection;
        }


        public override string ToString()
        {
            return "Add Sprite";
        }
    }
}
