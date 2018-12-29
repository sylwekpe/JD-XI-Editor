﻿using System;
using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using JD_XI_Editor.Exceptions;
using JD_XI_Editor.Models.Patches.DrumKit.Partial.Wmt;
using PropertyChanged;

namespace JD_XI_Editor.Models.Patches.DrumKit.Partial
{
    internal class Partial : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        public Partial()
        {
            Basic = new Basic();
            Assign = new Assign();
            Amplifier = new Amplifier();
            Output = new Output();
            Expression = new Expression();
            VelocityControl = new VelocityControl();
            Wmt1 = new Wmt.Wmt();
            Wmt2 = new Wmt.Wmt();
            Wmt3 = new Wmt.Wmt();
            Wmt4 = new Wmt.Wmt();
            Pitch = new Pitch();
            Tvf = new Tvf();
            Tva = new Tva();
            Other = new Other();

            Basic.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Basic));
            Assign.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Assign));
            Amplifier.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Amplifier));
            Output.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Output));
            Expression.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Expression));
            VelocityControl.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(VelocityControl));
            Wmt1.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Wmt1));
            Wmt2.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Wmt2));
            Wmt3.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Wmt3));
            Wmt4.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Wmt4));
            Pitch.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Pitch));
            Tvf.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Tvf));
            Tva.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Tva));
            Other.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Other));
        }

        /// <inheritdoc />
        public void CopyFrom(IPatchPart part)
        {
            if (part is Partial p)
            {
                Basic.CopyFrom(p.Basic);
                Assign.CopyFrom(p.Assign);
                Amplifier.CopyFrom(p.Amplifier);
                Output.CopyFrom(p.Output);
                Expression.CopyFrom(p.Expression);
                VelocityControl.CopyFrom(p.VelocityControl);
                Wmt1.CopyFrom(p.Wmt1);
                Wmt2.CopyFrom(p.Wmt2);
                Wmt3.CopyFrom(p.Wmt3);
                Wmt4.CopyFrom(p.Wmt4);
                Pitch.CopyFrom(p.Pitch);
                Tvf.CopyFrom(p.Tvf);
                Tva.CopyFrom(p.Tva);
                Other.CopyFrom(p.Other);
            }
            else
            {
                throw new NotSupportedException("Copying from that type is not supported");
            }
        }

        /// <inheritdoc />
        public void CopyFrom(byte[] data)
        {
            if (data.Length != DumpLength)
            {
                throw new InvalidDumpSizeException(DumpLength, data.Length);
            }

            Basic.CopyFrom(data.Take(12).ToArray());
            Assign.CopyFrom(data.Skip(12).Take(2).ToArray());
            Amplifier.CopyFrom(data.Skip(14).Take(8).ToArray());
            Output.CopyFrom(data.Skip(22).Take(6).ToArray());
            Expression.CopyFrom(data.Skip(28).Take(4).ToArray());
            VelocityControl.CopyFrom(data.Skip(32).Take(1).ToArray());
            Wmt1.CopyFrom(data.Skip(33).Take(29).ToArray());
            Wmt2.CopyFrom(data.Skip(62).Take(29).ToArray());
            Wmt3.CopyFrom(data.Skip(91).Take(29).ToArray());
            Wmt4.CopyFrom(data.Skip(120).Take(29).ToArray());
            Pitch.CopyFrom(data.Skip(149).Take(13).ToArray());
            Tvf.CopyFrom(data.Skip(162).Take(20).ToArray());
            Tva.CopyFrom(data.Skip(182).Take(11).ToArray());
            Other.CopyFrom(data.Skip(193).Take(2).ToArray());
        }

        /// <inheritdoc />
        public void Reset()
        {
            Basic.Reset();
            Assign.Reset();
            Amplifier.Reset();
            Output.Reset();
            Expression.Reset();
            VelocityControl.Reset();
            Wmt1.Reset();
            Wmt2.Reset();
            Wmt3.Reset();
            Wmt4.Reset();
            Pitch.Reset();
            Tvf.Reset();
            Tva.Reset();
            Other.Reset();
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            var bytes = new List<byte>();

            bytes.AddRange(Basic.GetBytes());
            bytes.AddRange(Assign.GetBytes());
            bytes.AddRange(Amplifier.GetBytes());
            bytes.AddRange(Expression.GetBytes());
            bytes.AddRange(VelocityControl.GetBytes());
            bytes.AddRange(Wmt1.GetBytes());
            bytes.AddRange(Wmt2.GetBytes());
            bytes.AddRange(Wmt3.GetBytes());
            bytes.AddRange(Wmt4.GetBytes());
            bytes.AddRange(Pitch.GetBytes());
            bytes.AddRange(Tvf.GetBytes());
            bytes.AddRange(Tva.GetBytes());
            bytes.AddRange(Other.GetBytes());

            return bytes.ToArray();
        }

        #region Fields

        #endregion

        #region Properties

        /// <inheritdoc />
        public int DumpLength { get; } = 323;

        /// <summary>
        ///     Basic
        /// </summary>
        [DoNotNotify]
        public Basic Basic { get; }

        /// <summary>
        ///     Assign
        /// </summary>
        [DoNotNotify]
        public Assign Assign { get; }

        /// <summary>
        ///     Amplifier
        /// </summary>
        [DoNotNotify]
        public Amplifier Amplifier { get; }

        /// <summary>
        ///     Output
        /// </summary>
        [DoNotNotify]
        public Output Output { get; }

        /// <summary>
        ///     Expression
        /// </summary>
        [DoNotNotify]
        public Expression Expression { get; }

        /// <summary>
        ///     WMT Velocity control
        /// </summary>
        [DoNotNotify]
        public VelocityControl VelocityControl { get; }

        /// <summary>
        ///     WMT 1
        /// </summary>
        [DoNotNotify]
        public Wmt.Wmt Wmt1 { get; }

        /// <summary>
        ///     WMT 2
        /// </summary>
        [DoNotNotify]
        public Wmt.Wmt Wmt2 { get; }

        /// <summary>
        ///     WMT 3
        /// </summary>
        [DoNotNotify]
        public Wmt.Wmt Wmt3 { get; }

        /// <summary>
        ///     WMT 4
        /// </summary>
        [DoNotNotify]
        public Wmt.Wmt Wmt4 { get; }

        /// <summary>
        ///     Pitch
        /// </summary>
        [DoNotNotify]
        public Pitch Pitch { get; }

        /// <summary>
        ///     TVF
        /// </summary>
        [DoNotNotify]
        public Tvf Tvf { get; }

        /// <summary>
        ///     TVA
        /// </summary>
        [DoNotNotify]
        public Tva Tva { get; }

        /// <summary>
        ///     Other
        /// </summary>
        [DoNotNotify]
        public Other Other { get; }

        #endregion
    }
}