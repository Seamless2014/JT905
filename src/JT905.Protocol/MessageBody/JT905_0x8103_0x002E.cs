﻿using System.Text.Json;

using JT905.Protocol.Extensions;

using JT905.Protocol.Interfaces;
using JT905.Protocol.MessagePack;

namespace JT905.Protocol.MessageBody
{
    /// <summary>
    /// 休眠时汇报距离间隔，单位为米（m），>0
    /// </summary>
    public class JT905_0x8103_0x002E : JT905_0x8103_BodyBase, IJT905MessagePackFormatter<JT905_0x8103_0x002E>, IJT905Analyze
    {
        /// <summary>
        /// 0x002E
        /// </summary>
        public override uint ParamId { get; set; } = 0x002E;
        /// <summary>
        /// 数据长度
        /// 4 byte
        /// </summary>
        public override byte ParamLength { get; set; } = 4;
        /// <summary>
        /// 休眠时汇报距离间隔，单位为米（m），>0
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
            JT905_0x8103_0x002E JT905_0x8103_0x002E = new JT905_0x8103_0x002E();
            JT905_0x8103_0x002E.ParamId = reader.ReadUInt32();
            JT905_0x8103_0x002E.ParamLength = reader.ReadByte();
            JT905_0x8103_0x002E.ParamValue = reader.ReadUInt32();
            writer.WriteNumber($"[{ JT905_0x8103_0x002E.ParamId.ReadNumber()}]参数ID", JT905_0x8103_0x002E.ParamId);
            writer.WriteNumber($"[{JT905_0x8103_0x002E.ParamLength.ReadNumber()}]参数长度", JT905_0x8103_0x002E.ParamLength);
            writer.WriteNumber($"[{ JT905_0x8103_0x002E.ParamValue.ReadNumber()}]参数值[休眠时汇报距离间隔m]", JT905_0x8103_0x002E.ParamValue);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public JT905_0x8103_0x002E Deserialize(ref JT905MessagePackReader reader, IJT905Config config)
        {
            JT905_0x8103_0x002E JT905_0x8103_0x002E = new JT905_0x8103_0x002E();
            JT905_0x8103_0x002E.ParamId = reader.ReadUInt32();
            JT905_0x8103_0x002E.ParamLength = reader.ReadByte();
            JT905_0x8103_0x002E.ParamValue = reader.ReadUInt32();
            return JT905_0x8103_0x002E;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="config"></param>
        public void Serialize(ref JT905MessagePackWriter writer, JT905_0x8103_0x002E value, IJT905Config config)
        {
            writer.WriteUInt32(value.ParamId);
            writer.WriteByte(value.ParamLength);
            writer.WriteUInt32(value.ParamValue);
        }
    }
}
