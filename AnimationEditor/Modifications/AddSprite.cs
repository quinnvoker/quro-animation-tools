using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using QURO;
using QURO.Animation;
using System.Windows.Forms;
using Microsoft.Xna.Framework;

namespace AnimationEditor.Modifications
{
    class AddSprite : IModification
    {
        private SelectionState preChangeSelection;
        private SelectionState postChangeSelection;

        private BindingList<Sprite> sprites;
        private Frame currentFrame;
        private ListBox spriteBox;
        private Sprite spriteToAdd;

        public AddSprite(BindingList<Sprite> spriteList, ListBox sprBox, Frame currFrame, Sprite sprite = null)
        {
            sprites = spriteList;
            spriteBox = sprBox;
            currentFrame = currFrame;
            if (sprite != null)
                spriteToAdd = sprite;
            else spriteToAdd = new Sprite();
        }

        public void Do()
        {
            if (sprites.Count == 1 && sprites[0].Bounds == Rectangle.Empty)
                sprites.Clear();

            sprites.Add(spriteToAdd);
            currentFrame.Sprites = sprites.ToList();
            ModHelper.SetSingleSelection(spriteBox, sprites.Count - 1);
        }

        public void Undo()
        {
            sprites.RemoveAt(sprites.Count - 1);
            if (sprites.Count == 0)
                sprites.Add(new Sprite());
            currentFrame.Sprites = sprites.ToList();
        }

        public SelectionState GetPreChangeSelection()
        {
            return preChangeSelection;
        }
        public void SetPreChangeSelection(SelectionState currentSelection)
        {
            preChangeSelection = currentSelection;
        }
        public SelectionState GetPostChangeSelection()
        {
            return postChangeSelection;
        }
        public void SetPostChangeSelection(SelectionState currentSelection)
        {
            postChangeSelection = currentSelection;
        }


        public override string ToString()
        {
            return "Add Sprite";
        }
    }
}
