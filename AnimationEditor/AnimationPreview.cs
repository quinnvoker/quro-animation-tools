using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Forms.Controls;
using QURO.AnimationLibrary;

namespace AnimationEditor
{
    class AnimationPreview : UpdateWindow
    {
        public Texture2D SpriteSheet { get; set; }
        public AnimatedSprite PreviewSprite { get; set; }
        public Animation CurrentAnimation { get; set; }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            PreviewSprite?.Update(gameTime);
        }

        protected override void Draw()
        {
            base.Draw();

            Editor.spriteBatch.Begin();
            PreviewSprite?.Draw(Editor.spriteBatch, new Vector2(10, 10), Color.White);
            Editor.spriteBatch.End();
        }
    }
}
