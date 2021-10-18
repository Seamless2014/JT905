﻿using System.Text.Json;

using JT905.Protocol.Extensions;

using JT905.Protocol.Interfaces;
using JT905.Protocol.MessagePack;

namespace JT905.Protocol.MessageBody
{
    /// <summary>
    /// 色度，0-255
    /// </summary>
    public class JT905_0x8103_0x0074 : JT905_0x8103_BodyBase, IJT905MessagePackFormatter<JT905_0x8103_0x0074>, IJT905Analyze
    {
        /// <summary>
        /// 0x0074
        /// </summary>
        public override uint ParamId { get; set; } = 0x0074;
        /// <summary>
        /// 数据长度
        /// 4 byte
        /// </summary>
        public override byte ParamLength { get; set; } = 4;
        /// <summary>
        /// 色度，0-255
        /// </summary>
        public uint ParamValue { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="writer"></param>
        /// <param name="config"></param>
        public void Analyze(ref JT905MessagePackReader reader, Utf8JsonWriter writer, IJT905Config config)
        {
            JT905_0x8103_0x0074 JT905_0x8103_0x0074 = new JT905_0x8103_0x0074();
            JT905_0x8103_0x0074.ParamId = reader.ReadUInt32();
            JT905_0x8103_0x0074.ParamLength = reader.ReadByte();
            JT905_0x8103_0x0074.ParamValue = reader.ReadUInt32();
            writer.WriteNumber($"[{ JT905_0x8103_0x0074.ParamId.ReadNumber()}]参数ID", JT905_0x8103_0x0074.ParamId);
            writer.WriteNumber($"[{JT905_0x8103_0x0074.ParamLength.ReadNumber()}]参数长度", JT905_0x8103_0x0074.ParamLength);
            writer.WriteNumber($"[{ JT905_0x8103_0x0074.ParamValue.ReadNumber()}]参数值[色度]", JT905_0x8103_0x0074.ParamValue);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public JT905_0x8103_0x0074 Deserialize(ref JT905MessagePackReader reader, IJT905Config config)
        {
            JT905_0x8103_0x0074 JT905_0x8103_0x0074 = new JT905_0x8103_0x0074();
            JT905_0x8103_0x0074.ParamId = reader.ReadUInt32();
            JT905_0x8103_0x0074.ParamLength = reader.ReadByte();
            JT905_0x8103_0x0074.ParamValue = reader.ReadUInt32();
            return JT905_0x8103_0x0074;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="config"></param>
        public void Serialize(ref JT905MessagePackWriter writer, JT905_0x8103_0x0074 value, IJT905Config config)
        {
            writer.WriteUInt32(value.ParamId);
            writer.WriteByte(value.ParamLength);
            writer.WriteUInt32(value.ParamValue);
        }
    }
}
