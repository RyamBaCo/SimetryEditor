using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Simetry.Interface.Globals
{
    public static class SerializationConstants
    {
        #region Default Values
        public const string             DEFAULT_VALUE_GAME_OBJECT_ID = "";
        public static readonly Vector3  DEFAULT_VALUE_GAME_OBJECT_POSITION = Vector3.Zero;
        public const int                DEFAULT_VALUE_GAME_OBJECT_POSITION_Z = 0;
        public const int                DEFAULT_VALUE_GAME_OBJECT_ROTATION = 0;

        public const string             DEFAULT_VALUE_METADATA_GAME_OBJECT_TYPE = METADATA_TYPE_POSITION;
        public const string             DEFAULT_VALUE_METADATA_GAME_OBJECT_PARAMETERS = "";

        public const bool               DEFAULT_VALUE_SLICE_BREAKABLE = false;
        public const bool               DEFAULT_VALUE_SLICE_HEAVY = false;
        public const bool               DEFAULT_VALUE_SLICE_LETHAL = false;
        public const bool               DEFAULT_VALUE_SLICE_SLIPPERY = false;

        public static readonly Vector2  DEFAULT_VALUE_TRIGGER_ZONE_SIZE = new Vector2(1, 1);
        public const bool               DEFAULT_VALUE_TRIGGER_ZONE_TRIGGER_BY_ALL = true;
        public const bool               DEFAULT_VALUE_TRIGGER_ZONE_EXECUTE_ONCE = true;
        public const bool               DEFAULT_VALUE_TRIGGER_ZONE_EXECUTE_PARALLEL = false;

        public const bool               DEFAULT_VALUE_BASE_ACTION_EXECUTE_ON_ENTER = true;
        public const bool               DEFAULT_VALUE_BASE_ACTION_EXECUTE_ON_EXIT = false;
        public const bool               DEFAULT_VALUE_BASE_ACTION_EXECUTE_ON_KEY = false;

        public static readonly Vector2  DEFAULT_VALUE_SPECIAL_SLICE_SIZE = new Vector2(1, 1);
        public const string             DEFAULT_VALUE_SPECIAL_SLICE_PARAMETERS = "";

        #endregion

        public class ActionValue
        {
            public string Name { get; set; }
            public string Parameters { get; set; }

            public ActionValue() : this("", "") { }

            public ActionValue(ActionValue actionValues) : this(actionValues.Name, actionValues.Parameters) { }

            public ActionValue(string name, string parameters)
            {
                Name = name;
                Parameters = parameters;
            }
        }

        public const string JSON_PROPERTY_ACTION_PROPERTY_ID = "id";
        public const string JSON_PROPERTY_ACTION_PROPERTY_ANIMATION_CLIP = "clip";
        public const string JSON_PROPERTY_ACTION_PROPERTY_TARGET_ID = "target_id";
        public const string JSON_PROPERTY_ACTION_PROPERTY_SPEED = "speed";
        public const string JSON_PROPERTY_ACTION_PROPERTY_NUMBER = "number";
        public const string JSON_PROPERTY_ACTION_PROPERTY_USE_VELOCITY = "use_velocity";
        public const string JSON_PROPERTY_ACTION_PROPERTY_REPEAT = "repeat";
        public const string JSON_PROPERTY_ACTION_PROPERTY_INTERVAL = "interval";
        public const string JSON_PROPERTY_ACTION_PROPERTY_STEPPING = "stepping";
        public const string JSON_PROPERTY_ACTION_PROPERTY_STATES = "states";
        public const string JSON_PROPERTY_ACTION_PROPERTY_STATE = "state";
        public const string JSON_PROPERTY_ACTION_PROPERTY_START_LEFT = "start_left";
        public const string JSON_PROPERTY_ACTION_PROPERTY_CYCLE = "cycle";
        public const string JSON_PROPERTY_ACTION_PROPERTY_WIDTH = "width";
        public const string JSON_PROPERTY_ACTION_PROPERTY_FORM_WIDTH = "form_width";
        public const string JSON_PROPERTY_ACTION_PROPERTY_FROM = "from";
        public const string JSON_PROPERTY_ACTION_PROPERTY_ZOOM = "zoom";
        public const string JSON_PROPERTY_ACTION_PROPERTY_ALLOW = "allow";
        public const string JSON_PROPERTY_ACTION_PROPERTY_ENABLE = "enable";
        public const string JSON_PROPERTY_ACTION_PROPERTY_DELAY = "delay";
        public const string JSON_PROPERTY_ACTION_PROPERTY_ASSET = "asset";
        public const string JSON_PROPERTY_ACTION_PROPERTY_VOLUME = "volume";
        public const string JSON_PROPERTY_ACTION_PROPERTY_LOOP = "loop";
        public const string JSON_PROPERTY_ACTION_PROPERTY_FADE_IN = "fade_in";
        public const string JSON_PROPERTY_ACTION_PROPERTY_TEXTURE = "texture";
        public const string JSON_PROPERTY_ACTION_PROPERTY_ALPHAMODE = "alphamode";
        public const string JSON_PROPERTY_ACTION_PROPERTY_ALPHASTART = "alpha_start";
        public const string JSON_PROPERTY_ACTION_PROPERTY_ALPHASPEED = "alpha_speed";
        public const string JSON_PROPERTY_ACTION_PROPERTY_COLOR = "color";

        public static readonly ActionValue ACTION_BASE = new ActionValue("action_base", "{}");
        public static readonly ActionValue ACTION_PLAY_ANIMATION = new ActionValue(
            "action_play_animation", 
            "{\"" + JSON_PROPERTY_ACTION_PROPERTY_ID + "\":\"\",\"" + JSON_PROPERTY_ACTION_PROPERTY_ANIMATION_CLIP + "\":0}");
        public static readonly ActionValue ACTION_PLAY_ANIMATION_REVERSE = new ActionValue(
            "action_play_animation_reverse",
            "{\"" + JSON_PROPERTY_ACTION_PROPERTY_ID + "\":\"\"}");
        public static readonly ActionValue ACTION_PLAY_SOUND = new ActionValue(
            "action_play_sound",
            "{\"" + JSON_PROPERTY_ACTION_PROPERTY_ASSET + "\":\"\",\"" + JSON_PROPERTY_ACTION_PROPERTY_VOLUME + "\":0.5,\"" + JSON_PROPERTY_ACTION_PROPERTY_LOOP + "\":false,\"" + JSON_PROPERTY_ACTION_PROPERTY_FADE_IN + "\":false}");
        public static readonly ActionValue ACTION_DELAY = new ActionValue(
            "action_delay",
            "{\"" + JSON_PROPERTY_ACTION_PROPERTY_DELAY + "\":1.0}");
        public static readonly ActionValue ACTION_MOVE_OBJECT = new ActionValue(
            "action_move_object",
            "{\"" + JSON_PROPERTY_ACTION_PROPERTY_ID + "\":\"\",\"" + JSON_PROPERTY_ACTION_PROPERTY_TARGET_ID + "\":\"\",\"" + JSON_PROPERTY_ACTION_PROPERTY_SPEED + "\":10,\"" + JSON_PROPERTY_ACTION_PROPERTY_USE_VELOCITY + "\":true}");
        public static readonly ActionValue ACTION_SCALE_AND_MOVE_TO_PLAYER = new ActionValue(
            "action_scale_and_move_to_player",
            "{\"" + JSON_PROPERTY_ACTION_PROPERTY_ID + "\":\"\",\"" + JSON_PROPERTY_ACTION_PROPERTY_SPEED + "\":10}");
        public static readonly ActionValue ACTION_ROTATE_OBJECT = new ActionValue(
            "action_rotate_object",
            "{\"" + JSON_PROPERTY_ACTION_PROPERTY_ID + "\":\"\",\"" + JSON_PROPERTY_ACTION_PROPERTY_SPEED + "\":100,\"" + JSON_PROPERTY_ACTION_PROPERTY_STEPPING + "\":0,\"" + JSON_PROPERTY_ACTION_PROPERTY_REPEAT + "\":-1}");
        public static readonly ActionValue ACTION_ENABLE_DISABLE = new ActionValue(
            "action_enable_disable",
            "{\"" + JSON_PROPERTY_ACTION_PROPERTY_ID + "\":\"\",\"" + JSON_PROPERTY_ACTION_PROPERTY_ENABLE + "\":false}");
        public static readonly ActionValue ACTION_ARRIVE_CHECKPOINT = new ActionValue(
            "action_arrive_checkpoint",
            "{\"" + JSON_PROPERTY_ACTION_PROPERTY_ID + "\":\"\",\"" + JSON_PROPERTY_ACTION_PROPERTY_NUMBER + "\":0}");
        public static readonly ActionValue ACTION_SET_SLICE_STATE = new ActionValue(
            "action_set_slice_state",
            "{\"" + JSON_PROPERTY_ACTION_PROPERTY_ID + "\":\"\",\"" + JSON_PROPERTY_ACTION_PROPERTY_STATES + "\":[3,2],\"" + JSON_PROPERTY_ACTION_PROPERTY_INTERVAL + "\":1.0,\"" + JSON_PROPERTY_ACTION_PROPERTY_REPEAT + "\":1}");
        public static readonly ActionValue ACTION_SET_WANDER_SLICE_STATE = new ActionValue(
            "action_set_wander_slice_state",
            "{\"" + JSON_PROPERTY_ACTION_PROPERTY_ID + "\":\"\",\"" + JSON_PROPERTY_ACTION_PROPERTY_STATE + "\":2,\"" + JSON_PROPERTY_ACTION_PROPERTY_START_LEFT + "\":true,\"" + JSON_PROPERTY_ACTION_PROPERTY_CYCLE + "\":false,\"" + JSON_PROPERTY_ACTION_PROPERTY_INTERVAL + "\":1.0,\"" + JSON_PROPERTY_ACTION_PROPERTY_WIDTH + "\":3,\"" + JSON_PROPERTY_ACTION_PROPERTY_FORM_WIDTH + "\":9,\"" + JSON_PROPERTY_ACTION_PROPERTY_REPEAT + "\":1}");
        public static readonly ActionValue ACTION_ZOOM_CAMERA = new ActionValue(
            "action_zoom_camera",
            "{\"" + JSON_PROPERTY_ACTION_PROPERTY_FROM + "\":1.0,\"" + JSON_PROPERTY_ACTION_PROPERTY_ZOOM + "\":1.0,\"" + JSON_PROPERTY_ACTION_PROPERTY_SPEED + "\":10}");
        public static readonly ActionValue ACTION_SPAWN_QUAD = new ActionValue(
            "action_spawn_quad",
            "{\"" + JSON_PROPERTY_ACTION_PROPERTY_TARGET_ID + "\":\"\",\"" + JSON_PROPERTY_ACTION_PROPERTY_STATE + "\":2,\"" + JSON_PROPERTY_ACTION_PROPERTY_INTERVAL + "\":1.0}");
        public static readonly ActionValue ACTION_SPAWN_TRIANGLE = new ActionValue(
            "action_spawn_triangle",
            "{\"" + JSON_PROPERTY_ACTION_PROPERTY_TARGET_ID + "\":\"\",\"" + JSON_PROPERTY_ACTION_PROPERTY_STATE + "\":2,\"" + JSON_PROPERTY_ACTION_PROPERTY_INTERVAL + "\":1.0}");
        public static readonly ActionValue ACTION_ALLOW_BUILDING = new ActionValue(
            "action_allow_building",
            "{\"" + JSON_PROPERTY_ACTION_PROPERTY_ALLOW + "\":false}");
        public static readonly ActionValue ACTION_ALLOW_WEAPON_REEL = new ActionValue(
            "action_allow_weapon_reel",
            "{\"" + JSON_PROPERTY_ACTION_PROPERTY_ALLOW + "\":false}");
        public static readonly ActionValue ACTION_ALLOW_BUILDING_HEAVY_SLICES = new ActionValue(
            "action_allow_building_heavy_slices",
            "{\"" + JSON_PROPERTY_ACTION_PROPERTY_ALLOW + "\":false}");
        public static readonly ActionValue ACTION_ALLOW_COLLECTING = new ActionValue(
            "action_allow_collecting",
            "{\"" + JSON_PROPERTY_ACTION_PROPERTY_ALLOW + "\":false}");
        public static readonly ActionValue ACTION_ALLOW_TUTORIAL = new ActionValue(
            "action_allow_tutorial",
            "{\"" + JSON_PROPERTY_ACTION_PROPERTY_ALLOW + "\":false}");
        public static readonly ActionValue ACTION_SHOW_FULLSCREEN_TEXTURE = new ActionValue(
            "action_show_fullscreen_texture",
            "{\"" + JSON_PROPERTY_ACTION_PROPERTY_TEXTURE + "\":\"\",\"" + JSON_PROPERTY_ACTION_PROPERTY_ALPHAMODE + "\":1,\"" + JSON_PROPERTY_ACTION_PROPERTY_ALPHASTART + "\":1.0,\"" + JSON_PROPERTY_ACTION_PROPERTY_ALPHASPEED + "\":10}");
        public static readonly ActionValue ACTION_DESTROY_VISIBLE_SLICES = new ActionValue(
            "action_destroy_visible_slices",
            "{\"" + JSON_PROPERTY_ACTION_PROPERTY_ID + "\":\"\"}");
        public static readonly ActionValue ACTION_DESTROY_SLICES_IN_TRIGGER_ZONE = new ActionValue(
            "action_destroy_slices_in_trigger_zone",
            "{\"" + JSON_PROPERTY_ACTION_PROPERTY_ID + "\":\"\"}");
        public static readonly ActionValue ACTION_CHANGE_AMBIENT_LIGHT = new ActionValue(
            "action_change_ambient_light",
            "{\"" + JSON_PROPERTY_ACTION_PROPERTY_COLOR + "\":[1,1,1,1],\"" + JSON_PROPERTY_ACTION_PROPERTY_SPEED + "\":10}");

        public const string JSON_PROPERTY_GLOBAL_JUNK_VALUES = "global_values";
        public const string JSON_PROPERTY_LEVEL_JUNK_SIZE = "size";

        public const string JSON_PROPERTY_GAME_OBJECT_ID = "id";
        public const string JSON_PROPERTY_GAME_OBJECT_POSITION = "position";
        public const string JSON_PROPERTY_GAME_OBJECT_ROTATION = "rotation";

        public const string JSON_PROPERTY_METADATA_GAME_OBJECT_TYPE = "type";
        public const string JSON_PROPERTY_METADATA_GAME_OBJECT_PARAMETERS = "parameters";

        public const string JSON_PROPERTY_FORMS = "forms";
        public const string JSON_PROPERTY_GAME_OBJECTS = "game_objects";
        public const string JSON_PROPERTY_TRIGGER_ZONES = "trigger_zones";

        public const string JSON_PROPERTY_FORM_SLICES = "slices";
        public const string JSON_PROPERTY_FORM_SPECIAL_SLICES = "special_slices";

        public const string JSON_PROPERTY_SLICE_TYPE = "slice_type";
        public const string JSON_PROPERTY_SLICE_AREA_SIZE = "area_size";
        public const string JSON_PROPERTY_SLICE_BREAKABLE = "breakable";
        public const string JSON_PROPERTY_SLICE_LETHAL = "lethal";
        public const string JSON_PROPERTY_SLICE_HEAVY = "heavy";
        public const string JSON_PROPERTY_SLICE_SLIPPERY = "slippery";

        public const string JSON_PROPERTY_SPECIAL_SLICE_TYPE = "special_type";
        public const string JSON_PROPERTY_SPECIAL_SLICE_SIZE = "special_size";
        public const string JSON_PROPERTY_SPECIAL_SLICE_PARAMETERS = "special_parameters";

        public const string JSON_PROPERTY_SPECIAL_SLICE_PARAMETER_INTERVAL = "interval";
        public const string JSON_PROPERTY_SPECIAL_SLICE_PARAMETER_OFFSET = "offset";
        public const string JSON_PROPERTY_SPECIAL_SLICE_PARAMETER_SPEED = "speed";
        public const string JSON_PROPERTY_SPECIAL_SLICE_PARAMETER_CONNECTED_TO = "connected_to";

        public const string JSON_PROPERTY_TRIGGER_ZONE_SIZE = "size";
        public const string JSON_PROPERTY_TRIGGER_ZONE_TRIGGER_BY_ALL = "trigger_by_all";
        public const string JSON_PROPERTY_TRIGGER_ZONE_EXECUTE_ONCE = "execute_once";
        public const string JSON_PROPERTY_TRIGGER_ZONE_EXECUTE_PARALLEL = "execute_parallel";
        public const string JSON_PROPERTY_TRIGGER_ZONE_ACTIONS = "actions";

        public const string JSON_PROPERTY_ACTION_NAME = "name";
        public const string JSON_PROPERTY_ACTION_PARAMETERS = "parameters";
        public const string JSON_PROPERTY_ACTION_EXECUTE_ON_ENTER = "execute_on_enter";
        public const string JSON_PROPERTY_ACTION_EXECUTE_ON_EXIT = "execute_on_exit";
        public const string JSON_PROPERTY_ACTION_EXECUTE_ON_KEY = "execute_on_key";

        public const string JSON_PROPERTY_BACKGROUND_ASSET = "asset";
        public const string JSON_PROPERTY_BACKGROUND_SCALE = "scale";
        public const string JSON_PROPERTY_BACKGROUND_REPEAT = "repeat";
        public const string JSON_PROPERTY_BACKGROUND_REPEAT_GAP = "repeat_gap";
        public const string JSON_PROPERTY_BACKGROUND_ANIMATION_DELAY = "animation_delay";

        public const string JSON_PROPERTY_POINT_LIGHT_RADIUS = "radius";
        public const string JSON_PROPERTY_POINT_LIGHT_COLOR = "color";
        public const string JSON_PROPERTY_POINT_LIGHT_INTENSITY = "intensity";
        public const string JSON_PROPERTY_POINT_LIGHT_ATTENUATION = "attenuation";
        public const string JSON_PROPERTY_POINT_LIGHT_SHADOWS = "shadows";
        public const string JSON_PROPERTY_POINT_LIGHT_RESOLUTION = "resolution";

        public const string METADATA_TYPE_POSITION = "position";
        public const string METADATA_TYPE_BACKGROUND = "background";
        public const string METADATA_TYPE_POINT_LIGHT = "point_light";

        public static readonly Dictionary<string, Vector2> BackgroundAssetNames = new Dictionary<string,Vector2>()
        {
            { "Landscape_001_single",    new Vector2(10, 10) },
            { "Background_010_repeat",   new Vector2(10, 10) },
            { "Background_015_repeat",   new Vector2(10, 10) },
            { "Background_016_repeat",   new Vector2(10, 10) },
            { "Background_018_single",   new Vector2(10, 10) },
            { "Background_028_single",   new Vector2(10, 10) },
            { "Background_029_single",   new Vector2(10, 10) },
            { "Background_039_single",   new Vector2(10, 10) },
            { "Background_040_repeat",   new Vector2(21, 21) },
            { "Wall_01",                 new Vector2(10, 10) },
            { "Wall_02",                 new Vector2(10, 10) },
            { "Decoration_Mask",         new Vector2(10, 10) },
            { "Collect Upgrade",         new Vector2(10, 10) },
            { "Building Upgrade",         new Vector2(10, 10) }//,
            //{ "TutorialScreen_WalkJump", new Vector2(13, 7) },
            //{ "TutorialScreen_Collect1", new Vector2(13, 7) },
            //{ "TutorialScreen_Collect2", new Vector2(13, 7) },
            //{ "TutorialScreen_WallJump", new Vector2(13, 7) },
            //{ "TutorialScreen_BuildStart", new Vector2(13, 7) },
            //{ "TutorialScreen_HeavySlices", new Vector2(13, 7) }
        };
    }
}
