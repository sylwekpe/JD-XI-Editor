﻿using Caliburn.Micro;
using JD_XI_Editor.Models.Patches.Program.Effects.Effect1;

namespace JD_XI_Editor.ViewModels.Effects.Assignable
{
    internal class BitCrusherViewModel : Screen
    {
        /// <summary>
        ///     Bit Crusher parameters
        /// </summary>
        public BitCrusherParameters BitCrusherParameters { get; }

        public BitCrusherViewModel(BitCrusherParameters parameters)
        {
            BitCrusherParameters = parameters;
        }
    }
}