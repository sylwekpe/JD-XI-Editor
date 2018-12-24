﻿using System;
using Caliburn.Micro;
using JD_XI_Editor.Models.Patches.Program.Effects;
using PropertyChanged;

namespace JD_XI_Editor.Models.Patches.Program.Abstract
{
    internal abstract class EffectPatch : PropertyChangedBase, IPatch
    {
        /// <inheritdoc />
        public void Reset()
        {
            Basic.Reset();
            Parameters.Reset();
        }

        /// <inheritdoc />
        public void CopyFrom(IPatch patch)
        {
            if (!(patch is Patch))
            {
                throw new NotSupportedException("Copying from that type is not supported");
            }

            var castPatch = (Patch) patch;

            //TODO: Copy from inner objects
        }

        /// <inheritdoc />
        public abstract byte[] GetBytes();

        #region Properties

        /// <summary>
        ///     Basic Data
        /// </summary>
        [DoNotNotify]
        public IPatchPart Basic { get; protected set; }

        /// <summary>
        ///     Delay parameters
        /// </summary>
        [DoNotNotify]
        public EffectParameters Parameters { get; protected set; }

        #endregion
    }
}