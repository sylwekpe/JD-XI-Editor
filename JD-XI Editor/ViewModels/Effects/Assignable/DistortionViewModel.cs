﻿using Caliburn.Micro;
using JD_XI_Editor.Models.Patches.Program.Effects.Effect1;

namespace JD_XI_Editor.ViewModels.Effects.Assignable
{
    internal class DistortionViewModel : Screen
    {
        /// <summary>
        ///     Distortion parameters
        /// </summary>
        public DistortionParameters DistortionParameters { get; }

        public DistortionViewModel(DistortionParameters parameters)
        {
            DistortionParameters = parameters;
        }
    }
}