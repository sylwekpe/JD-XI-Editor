using System;
using JD_XI_Editor.Managers.Abstract;
using JD_XI_Editor.Models.Patches;
using JD_XI_Editor.Utils;
using Sanford.Multimedia.Midi;

namespace JD_XI_Editor.Managers
{
    internal class AnalogPatchManager : IPatchManager
    {
        /// <summary>
        ///     Address offset
        /// </summary>
        private static readonly byte[] AddressOffset = {0x19, 0x42, 0x00, 0x00};

        /// <summary>
        ///     SysEx message length
        /// </summary>
        private static readonly byte[] SysExMessageLength = {0x00, 0x00, 0x00, 0x40};

        /// <inheritdoc />
        public event EventHandler<PatchDumpReceivedEventArgs> DataDumpReceived;

        /// <inheritdoc />
        public void Dump(IPatch analogPatch, int deviceId)
        {
            using (var output = new OutputDevice(deviceId))
            {
                output.Send(SysExUtils.GetMessage(analogPatch.GetBytes(), AddressOffset));
            }
        }

        /// <inheritdoc />
        public void Read(int inputDeviceId, int outputDeviceId)
        {
        }
    }
}