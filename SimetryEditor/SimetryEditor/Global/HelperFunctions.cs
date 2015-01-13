using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Simetry.Interface.Serialization;
using Simetry.Interface.Globals;

namespace SimetryEditor
{
    public static class HelperFunctions
    {
        public static class MessageTexts
        {
            public static string GetDeleteSlicesWarning(int slicesToDelete)
            {
                return slicesToDelete + " slice" + (slicesToDelete > 1 ? "s" : "") + " will be deleted.";
            }

            public static string GetDeleteGameObjectsWarning(int gameObjectsToDelete)
            {
                return gameObjectsToDelete + " Game Object" + (gameObjectsToDelete > 1 ? "s" : "") + " will be deleted.";
            }

            public static string GetDeleteTriggerZonesWarning(int triggerZonesToDelete)
            {
                return triggerZonesToDelete + " Trigger Zone" + (triggerZonesToDelete > 1 ? "s" : "") + " will be deleted.";
            }

            public static string GetMoveSelectedSlicesToFormMessage(int selectedSlices, string newFormName)
            {
                return "Move " + selectedSlices + " Slice" + (selectedSlices > 1 ? "s" : "") + " to new Form " + newFormName + "?";
            }

            public static string GetNoEntryInSliceDictionaryError(SliceValue.SliceType type)
            {
                return "No Entry for " + type + " in sliceTextureDictionary!";
            }

            public static string GetNoEntryInSpecialSliceDictionaryError(SpecialSliceValue.SpecialType special)
            {
                return "No Entry for " + special + " in specialSliceTextureDictionary!";
            }

            public static string GetSaveFailedError(string fileName)
            {
                return "Failed saving " + fileName + "!";
            }

            public static string GetLoadFailedError(string fileName, string reason)
            {
                return "Failed loading " + fileName + "! Reason: " + reason;
            }

            public static string GetActionsTooltipText()
            {
                return  "ActionSetSliceState - Slice States:\n" +
                        "DESTROY = -1\nLIGHT = 0\nHEAVY = 1\nLETHAL = 2\nLETHAL SOLID = 3\nSOLID = 4\nSLIPPERY = 5\n\n" +
                        "ActionShowFullScreenTexture - AlphaMode:\n" +
                        "STAY = 0\nINCREASE = 1\nSINK = 2";
            }
        }
        
        public static void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult ShowWarningMessage(string message)
        {
            return MessageBox.Show(message, "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult ShowYesNoMessage(string message)
        {
            return MessageBox.Show(message, "", MessageBoxButtons.YesNo);
        }

        public static int TruncateToGrid(float value)
        {
            return Convert.ToInt32(value / GlobalValues.Instance.GridSize) * GlobalValues.Instance.GridSize;
        }

        public static Vector2 TruncateToGrid(Vector2 value)
        {
            return new Vector2(TruncateToGrid(value.X), TruncateToGrid(value.Y));
        }

        public static Vector2 Vector3ToVector2(Vector3 vector)
        {
            return new Vector2(vector.X, vector.Y);
        }

        public static string Vector4ToString(Vector4 vector)
        {
            return "[" + vector.X + "," + vector.Y + "," + vector.Z + "," + vector.W + "]";
        }

        public static string Vector3ToString(Vector3 vector)
        {
            return "[" + vector.X + "," + vector.Y + "," + vector.Z + "]";
        }

        public static string Vector2ToString(Vector2 vector)
        {
            return "[" + vector.X + "," + vector.Y + "]";
        }

        public static void DrawLine(Texture2D texture, Color color, int width, Vector2 start, Vector2 end)
        {
            Vector2 edge = end - start;

            GlobalValues.Instance.GlobalSpriteBatch.Draw(texture,
                new Rectangle((int)start.X, (int)start.Y, (int)edge.Length(), width),
                null,
                color,
                (float)Math.Atan2(edge.Y, edge.X),
                new Vector2(0, 0),
                SpriteEffects.None,
                0);
        }

        // see http://stackoverflow.com/questions/2983809/how-to-draw-circle-with-specific-color-in-xna
        public static Texture2D CreateCircleTexture(int radius)
        {
            int outerRadius = radius * 2 + 2; // So circle doesn't go out of bounds
            Texture2D texture = new Texture2D(GlobalValues.Instance.GlobalSpriteBatch.GraphicsDevice, outerRadius, outerRadius);

            Color[] data = new Color[outerRadius * outerRadius];
            // Colour the entire texture transparent first.
            for (int i = 0; i < data.Length; i++)
                data[i] = Color.Transparent;

            // Work out the minimum step necessary using trigonometry + sine approximation.
            double angleStep = 1f / radius;

            for (double angle = 0; angle < Math.PI * 2; angle += angleStep)
            {
                // Use the parametric definition of a circle: http://en.wikipedia.org/wiki/Circle#Cartesian_coordinates
                int x = (int)Math.Round(radius + radius * Math.Cos(angle));
                int y = (int)Math.Round(radius + radius * Math.Sin(angle));

                data[y * outerRadius + x + 1] = Color.White;
            }

            texture.SetData(data);
            return texture;
        }

        public static string BuildBackgroundParameters(string asset, string position, string rotation, string scale, string repeat, string repeatGap, int animationDelay)
        {
            return "{\"" + SerializationConstants.JSON_PROPERTY_BACKGROUND_ASSET + "\":\"" + asset + "\",\"" +
                SerializationConstants.JSON_PROPERTY_GAME_OBJECT_POSITION + "\":" + position + ",\"" + 
                SerializationConstants.JSON_PROPERTY_GAME_OBJECT_ROTATION + "\":" + rotation + ",\"" + 
                SerializationConstants.JSON_PROPERTY_BACKGROUND_SCALE + "\":" + scale + ",\"" + 
                SerializationConstants.JSON_PROPERTY_BACKGROUND_REPEAT + "\":" + repeat + ",\"" +
                SerializationConstants.JSON_PROPERTY_BACKGROUND_REPEAT_GAP + "\":" + repeatGap + ",\"" +
                SerializationConstants.JSON_PROPERTY_BACKGROUND_ANIMATION_DELAY + "\":" + animationDelay + "}";
        }

        public static string BuildPointLightParameters(string position, float radius, string color, float intensity, float attenuation, bool shadows, int resolution)
        {
            return "{\"" + SerializationConstants.JSON_PROPERTY_GAME_OBJECT_POSITION + "\":" + position + ",\"" +
                SerializationConstants.JSON_PROPERTY_POINT_LIGHT_RADIUS + "\":" + radius + ",\"" +
                SerializationConstants.JSON_PROPERTY_POINT_LIGHT_COLOR + "\":" + color + ",\"" +
                SerializationConstants.JSON_PROPERTY_POINT_LIGHT_INTENSITY + "\":" + intensity + ",\"" +
                SerializationConstants.JSON_PROPERTY_POINT_LIGHT_ATTENUATION + "\":" + attenuation + ",\"" +
                SerializationConstants.JSON_PROPERTY_POINT_LIGHT_SHADOWS + "\":" + shadows.ToString().ToLower() + ",\"" +
                SerializationConstants.JSON_PROPERTY_POINT_LIGHT_RESOLUTION + "\":" + resolution + "}";
        }
    }
}
