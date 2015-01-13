using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Simetry.Interface.Serialization;
using Microsoft.Xna.Framework;

namespace SimetryEditor
{
    public class GlobalValues
    {
        #region Singleton Pattern
        private static readonly GlobalValues instance = new GlobalValues();
        public static GlobalValues Instance { get { return instance; } }
        #endregion

        #region Global Constants
        public const string ASSET_NAME_FONT = "Metadata Font";
        public const string ASSET_NAME_QUAD = "Quad";
        public const string ASSET_NAME_TRIANGLE_1 = "Triangle 1";
        public const string ASSET_NAME_TRIANGLE_2 = "Triangle 2";
        public const string ASSET_NAME_TRIANGLE_3 = "Triangle 3";
        public const string ASSET_NAME_TRIANGLE_4 = "Triangle 4";
        public const string ASSET_NAME_CIRCLE = "Circle";
        public const string ASSET_NAME_HEAVY = "Heavy";
        public const string ASSET_NAME_BREAKABLE = "Breakable";
        public const string ASSET_NAME_SLIPPERY = "Slippery";
        public const string ASSET_NAME_CHECKPOINT = "Checkpoint";
        public const string ASSET_NAME_STAMPER = "Stamper";
        public const string ASSET_NAME_SWITCH = "Switch";
        public const string ASSET_NAME_DOOR = "Door";
        public const string ASSET_NAME_TREADMILL_RIGHT = "Treadmill Right";
        public const string ASSET_NAME_TREADMILL_LEFT = "Treadmill Left";
        public const string ASSET_NAME_SCALE = "Scale";

        public const string BUTTON_ADD = "Add";
        public const string BUTTON_EDIT = "Edit";
        #endregion

        #region Values for XNA Drawing
        public ContentManager GlobalContent { get; set; }
        public SpriteBatch GlobalSpriteBatch { get; set; }
        public Size DrawCanvasSize { get; set; }
        // in relation to grid size
        public float MetaDataDrawSize { get; set; }
        public bool ShowFormTags { get; set; }
        public bool ShowSliceTags { get; set; }
        public bool ShowMetadataTags { get; set; }
        public bool ShowObjectTags { get; set; }
        public bool DrawBackground { get; set; }
        #endregion

        #region Other Global Values and Settings
        private int gridSize;
        public int GridSize
        { 
            get { return gridSize; }
            set
            {
                gridSize = value;

                if(Notifier.GridSizeChanged != null)
                    Notifier.GridSizeChanged();
            }
        }

        private int zValue;
        public int ZValue 
        {
            get { return zValue; }
            set
            {
                zValue = value;

                if (Notifier.ZValueChanged != null)
                    Notifier.ZValueChanged();
            }
        }

        // level size in grid units
        private Vector2 levelSize;
        public Vector2 LevelSize 
        {
            get { return levelSize; }
            set
            {
                levelSize = value;
                
                if (Notifier.LevelSizeChanged != null)
                    Notifier.LevelSizeChanged();
            }
        }

        public bool ShowAll { get; set; }

        public enum CreationModeType
        {
            CREATE_FORMS = 0,
            CREATE_METADATA,
        }

        private CreationModeType creationMode;
        public CreationModeType CreationMode
        {
            get { return creationMode; }
            set
            {
                if (creationMode != value)
                {
                    creationMode = value;

                    if (Notifier.CreationModeChanged != null)
                        Notifier.CreationModeChanged();
                }
            }
        }

        #endregion

        // TODO read default settings from configuration file
        // default settings
        private GlobalValues()
        {
            GridSize = 30;
            LevelSize = new Vector2(40, 40);
            CreationMode = CreationModeType.CREATE_FORMS;
            MetaDataDrawSize = .4f;
            ShowFormTags = true;
            ShowSliceTags = true;
            ShowMetadataTags = true;
            ShowObjectTags = true;
        }
    }
}
