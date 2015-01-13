using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Simetry.Interface.Actions
{
    // for movement with velocity
    public delegate void NotifySetMovementValues(Vector3 endPosition, int speed);
    // for movement set directly in update
    public delegate void NotifySetPosition(Vector3 position);
    public delegate void NotifySetRotation(float rotation);
    public delegate void NotifyEnableDisable(bool enable);
    public delegate void NotifyPlayAnimationClip(int clip, out float duration);
    public delegate void NotifyPlayAnimationClipReverse(out float duration);
    public delegate void NotifyPlaySound(string assetName, float volume, bool loop, bool fadeIn);
    public delegate void NotifyArriveCheckpoint(int number);
    public delegate void NotifySetSliceState(ActionSetSliceState.SliceState state);
    public delegate void NotifySetWanderSliceState(ActionSetSliceState.SliceState state, int currentSlice, int width);
    public delegate void NotifySetCameraZoom(float zoom);
    public delegate void NotifySpawnQuad(ActionSetSliceState.SliceState state, Vector3 position);
    public delegate void NotifySpawnTriangle(ActionSetSliceState.SliceState state, Vector3 position);
    public delegate void NotifySetAllowBuilding(bool allow);
    public delegate void NotifySetAllowWeaponReel(bool allow);
    public delegate void NotifySetAllowBuildingHeavySlices(bool allow);
    public delegate void NotifySetAllowCollecting(bool allow);
    public delegate void NotifySetIsTutorial(bool isTutorial);
    public delegate void NotifyDestroyVisibleSlices(Vector3 origin);
    public delegate void NotifyDestroySlicesInTriggerZone();
    public delegate void NotifyScaleAndMoveToPlayer(Vector3 currentPosition, out Vector3 playerPosition, float currentScale);
    public delegate void NotifyShowFullScreenTexture(String textureString, ActionShowFullscreenTexture.AlphaMode mode, float startAlpha, float alphaSpeed);
    public delegate void NotifyChangeAmbientLight(Vector4 color, float speed);
}
