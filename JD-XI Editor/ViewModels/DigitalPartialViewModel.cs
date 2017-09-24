﻿using Caliburn.Micro;
using JD_XI_Editor.Models.Enums.Common;
using JD_XI_Editor.Models.Enums.Digital;
using JD_XI_Editor.Models.Patches.Digital;

// ReSharper disable InvertIf

namespace JD_XI_Editor.ViewModels
{
    internal sealed class DigitalPartialViewModel : Screen
    {
        /// <inheritdoc />
        public DigitalPartialViewModel(Partial partial, string title)
        {
            DisplayName = title;
            Partial = partial;

            Partial.Oscillator.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(Partial.Oscillator.WaveVariation))
                {
                    NotifyOfPropertyChange(nameof(VariationASelected));
                    NotifyOfPropertyChange(nameof(VariationBSelected));
                    NotifyOfPropertyChange(nameof(VariationCSelected));
                }
            };

            Partial.Other.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(Partial.Other.WaveGain))
                {
                    NotifyOfPropertyChange(nameof(WaveGainNegativeSixSelected));
                    NotifyOfPropertyChange(nameof(WaveGainZeroSelected));
                    NotifyOfPropertyChange(nameof(WaveGainPositiveSixSelected));
                    NotifyOfPropertyChange(nameof(WaveGainPositiveTwelveSelected));
                }
            };

            Partial.Filter.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(Partial.Filter.Slope))
                {
                    NotifyOfPropertyChange(nameof(SlopeNegativeTwelveSelected));
                    NotifyOfPropertyChange(nameof(SlopeNegativeTwentyFourSelected));
                }
            };
        }

        #region Fields

        /// <summary>
        ///     Partial
        /// </summary>
        private Partial _partial;

        #endregion

        #region Properties

        /// <summary>
        ///     Partial
        /// </summary>
        public Partial Partial
        {
            get => _partial;
            private set
            {
                if (value != _partial)
                {
                    _partial = value;
                    NotifyOfPropertyChange(nameof(Partial));
                }
            }
        }

        /// <summary>
        ///     Wave variation A checked
        /// </summary>
        public bool VariationASelected
        {
            get => Partial.Oscillator.WaveVariation == WaveVariation.A;
            set => Partial.Oscillator.WaveVariation = value ? WaveVariation.A : Partial.Oscillator.WaveVariation;
        }

        /// <summary>
        ///     Wave variation B checked
        /// </summary>
        public bool VariationBSelected
        {
            get => Partial.Oscillator.WaveVariation == WaveVariation.B;
            set => Partial.Oscillator.WaveVariation = value ? WaveVariation.B : Partial.Oscillator.WaveVariation;
        }

        /// <summary>
        ///     Wave variation C checked
        /// </summary>
        public bool VariationCSelected
        {
            get => Partial.Oscillator.WaveVariation == WaveVariation.C;
            set => Partial.Oscillator.WaveVariation = value ? WaveVariation.C : Partial.Oscillator.WaveVariation;
        }

        /// <summary>
        ///     -6 Wave gain selected
        /// </summary>
        public bool WaveGainNegativeSixSelected
        {
            get => Partial.Other.WaveGain == WaveGain.NegativeSix;
            set => Partial.Other.WaveGain = value ? WaveGain.NegativeSix : Partial.Other.WaveGain;
        }

        /// <summary>
        ///     0 Wave gain selected
        /// </summary>
        public bool WaveGainZeroSelected
        {
            get => Partial.Other.WaveGain == WaveGain.Zero;
            set => Partial.Other.WaveGain = value ? WaveGain.Zero : Partial.Other.WaveGain;
        }

        /// <summary>
        ///     +6 Wave gain selected
        /// </summary>
        public bool WaveGainPositiveSixSelected
        {
            get => Partial.Other.WaveGain == WaveGain.PositiveSix;
            set => Partial.Other.WaveGain = value ? WaveGain.PositiveSix : Partial.Other.WaveGain;
        }

        /// <summary>
        ///     +12 Wave gain selected
        /// </summary>
        public bool WaveGainPositiveTwelveSelected
        {
            get => Partial.Other.WaveGain == WaveGain.PositiveTwelve;
            set => Partial.Other.WaveGain = value ? WaveGain.PositiveTwelve : Partial.Other.WaveGain;
        }

        /// <summary>
        ///     -12dB slope selected
        /// </summary>
        public bool SlopeNegativeTwelveSelected
        {
            get => Partial.Filter.Slope == FilterSlope.NegativeTwelve;
            set => Partial.Filter.Slope = value ? FilterSlope.NegativeTwelve : Partial.Filter.Slope;
        }

        /// <summary>
        ///     -24dB slope selected
        /// </summary>
        public bool SlopeNegativeTwentyFourSelected
        {
            get => Partial.Filter.Slope == FilterSlope.NegativeTwentyFour;
            set => Partial.Filter.Slope = value ? FilterSlope.NegativeTwentyFour : Partial.Filter.Slope;
        }

        #endregion
    }
}