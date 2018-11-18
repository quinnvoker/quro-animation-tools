using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using QURO;
using QURO.AnimationLibrary;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;

namespace AnimationGenerator
{
    class Program
    {
        public static Dictionary<string, Rectangle> loadedFrames;
        public static AnimationSet output;

        public static void Main(string[] args)
        {
            using(XmlReader xmlRead = XmlReader.Create("Content/boardMap.xml"))
            {
                loadedFrames = IntermediateSerializer.Deserialize<Dictionary<string, Rectangle>>(xmlRead, null);
            }

            output = new AnimationSet();

            Frame[] soloCursor_pulse_frames = new Frame[]
            {
                new Frame(loadedFrames["soloCursor"], FrameTime.FramesToSeconds(20)),
                new Frame(loadedFrames["soloCursor_pulse"], FrameTime.FramesToSeconds(20)),
            };
            output.Add(new Animation("soloCursor_pulse", soloCursor_pulse_frames, true));

            Frame[] twinCursor_pulse_frames = new Frame[]
            {
                new Frame(loadedFrames["twinCursor"], FrameTime.FramesToSeconds(20)),
                new Frame(loadedFrames["twinCursor_pulse"], FrameTime.FramesToSeconds(20)),
            };
            output.Add(new Animation("twinCursor_pulse", twinCursor_pulse_frames, true));

            Frame[] block_default_frames = new Frame[]
            {
                new Frame(loadedFrames["block0"], 0),
            };
            output.Add(new Animation("block_default", block_default_frames, false));

            Frame[] block_matched_frames = new Frame[]
            {
                new Frame(loadedFrames["block0"], 0),
                new Frame(loadedFrames["block0_flash"], 0)
            };
            output.Add(new Animation("block_matched", block_matched_frames, true));

            Frame[] block_pop_frames = new Frame[]
            {
                new Frame(loadedFrames["block0_pop"], 0),
            };
            output.Add(new Animation("block_pop", block_pop_frames, false));

            Frame[] block_fall_frames = new Frame[]
            {
                new Frame(loadedFrames["block0"], 0),
                new Frame(loadedFrames["block0_bounce1"], 0),
                new Frame(loadedFrames["block0_bounce2"], 0),
            };
            output.Add(new Animation("block_fall", block_fall_frames, false));

            Frame[] block_squished_frames = new Frame[]
            {
                new Frame(loadedFrames["block0_squish"], 0),
            };
            output.Add(new Animation("block_squished", block_squished_frames, false));

            Frame[] block_bounce_frames = new Frame[]
            {
                new Frame(loadedFrames["block0_bounce2"], FrameTime.FramesToSeconds(1)),
                new Frame(loadedFrames["block0"], FrameTime.FramesToSeconds(1)),
                new Frame(loadedFrames["block0_squish"], FrameTime.FramesToSeconds(1)),
                new Frame(loadedFrames["block0"], FrameTime.FramesToSeconds(1)),
                new Frame(loadedFrames["block0_bounce1"], FrameTime.FramesToSeconds(2)),
                new Frame(loadedFrames["block0"], FrameTime.FramesToSeconds(0)),
            };
            output.Add(new Animation("block_bounce", block_bounce_frames, false));

            Frame[] tiledBG_default_frames = new Frame[]
            {
                new Frame(loadedFrames["tiledBG_default"], 0),
            };
            output.Add(new Animation("tiledBG_default", tiledBG_default_frames, false));

            var xmlSettings = new XmlWriterSettings();
            xmlSettings.Indent = true;
            using(XmlWriter writer = XmlWriter.Create("output.xml"))
            {
                IntermediateSerializer.Serialize(writer, output, null);
            }
            
        }
         /*
        public Animation TwinCursor_pulse => new Animation("twinCursor_pulse", textureAtlas, twinCursor_pulse_frames, FrameTimerUtility.FramesToSeconds(20), true);
        private readonly string[] twinCursor_pulse_frames = new string[]
        {
            SpriteNames.TwinCursor,
            SpriteNames.TwinCursor_pulse
        };

        //red blocks
        public Animation Block_default => new Animation("block_default", textureAtlas, block_default_frames, defaultDelay, false);
        private readonly string[] block_default_frames = new string[]
        {
            SpriteNames.Block0
        };

        public Animation Block_matched => new Animation("block_matched", textureAtlas, block_matched_frames, defaultDelay, true);
        private readonly string[] block_matched_frames = new string[]
        {
            SpriteNames.Block0,
            SpriteNames.Block0_flash
        };

        public Animation Block_pop => new Animation("block_pop", textureAtlas, block_pop_frames, defaultDelay, true);
        private readonly string[] block_pop_frames = new string[]
        {
            SpriteNames.Block0_pop
        };

        public Animation Block_fall => new Animation("block_fall", textureAtlas, block_fall_frames, defaultDelay, false);
        private readonly string[] block_fall_frames = new string[]
        {
            SpriteNames.Block0,
            SpriteNames.Block0_bounce1,
            SpriteNames.Block0_bounce2,
        };

        public Animation Block_squished => new Animation("block_squished", textureAtlas, block_squished_frames, defaultDelay, false);
        private readonly string[] block_squished_frames = new string[]
        {
            SpriteNames.Block0_squish
        };

        public Animation Block_bounce => new Animation("block_bounce", textureAtlas, block_bounce_frames, defaultDelay, false);
        private readonly string[] block_bounce_frames = new string[]
        {
            SpriteNames.Block0_bounce2,
            SpriteNames.Block0,
            SpriteNames.Block0_squish,
            SpriteNames.Block0,
            SpriteNames.Block0_bounce1,
            SpriteNames.Block0_bounce1,
            SpriteNames.Block0
        };

        public Animation TiledBG_default => new Animation("tiledBG_default", textureAtlas, tiledBG_default_frames, defaultDelay, false);
        private readonly string[] tiledBG_default_frames = new string[]
        {
            SpriteNames.TiledBG_default
        };
        */
    }
}
