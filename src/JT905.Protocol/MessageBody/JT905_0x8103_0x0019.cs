﻿using System.Text.Json;
using JT905.Protocol.Extensions;
using JT905.Protocol.Interfaces;
using JT905.Protocol.MessagePack;

namespace JT905.Protocol.MessageBody
{
    /// <summary>
    /// 备份服务器TCP端口
    /// 0x8103_=0x0019
    /// </summary>
    public class JT905_0x8103_0x0019 : JT905_0x8103_BodyBase, IJT905MessagePackFormatter<JT905_0x8103_0x0019>, IJT905Analyze
    {
        /// <summary>
        ///Int32
        ///System.Int32
        /// 0x0019
        /// </summary>
        public override ushort ParamId { get; set; } = JT905Constants.JT905_0x8103_0x0019;
        /// <summary>
        /// 数据长度
        /// 4 byte
        /// </summary>
        public override byte ParamLength { get; set; } = 4;
        
        /// <summary>
        /// 备份服务器TCP端口
        /// </summary>
        public uint ParamValue { get; set; }
        
        /// <summary>
        /// 解析数据
        /// 备份服务器TCP端口
        /// 0x8103_0x0019        
        /// </summary>
        /// <param name="reader">JT905消息读取器</param>
        /// <param name="writer">消息写入</param>
        /// <param name="config">JT905接口配置</param>
        public void Analyze(ref JT905MessagePackReader reader, Utf8JsonWriter writer, IJT905Config config)
        {
            JT905_0x8103_0x0019 JT905_0x8103_0x0019 = new JT905_0x8103_0x0019();
            JT905_0x8103_0x0019.ParamId = reader.ReadUInt16();
            JT905_0x8103_0x0019.ParamLength = reader.ReadByte();            
            writer.WriteNumber($"[{JT905_0x8103_0x0019.ParamId.ReadNumber()}]参数ID", JT905_0x8103_0x0019.ParamId);
            writer.WriteNumber($"[{JT905_0x8103_0x0019.ParamLength.ReadNumber()}]参数长度", JT905_0x8103_0x0019.ParamLength);
            JT905_0x8103_0x0019.ParamValue = reader.ReadUInt32();
            writer.WriteNumber($"[{JT905_0x8103_0x0019.ParamValue.ReadNumber()}]参数值[备份服务器TCP端口]", JT905_0x8103_0x0019.ParamValue);
            
        }
        /// <summary>
        /// 消息反序列化
        /// 备份服务器TCP端口
        /// 0x8103_0x0019        
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public JT905_0x8103_0x0019 Deserialize(ref JT905MessagePackReader reader, IJT905Config config)
        {
            JT905_0x8103_0x0019 JT905_0x8103_0x0019 = new JT905_0x8103_0x0019();
            JT905_0x8103_0x0019.ParamId = reader.ReadUInt16();
            JT905_0x8103_0x0019.ParamLength = reader.ReadByte();
            JT905_0x8103_0x0019.ParamValue = reader.ReadUInt32();
            
            return JT905_0x8103_0x0019;
        }
        /// <summary>
        /// 消息序列化
        /// 备份服务器TCP端口
        /// 0x8103_0x0019        
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="config"></param>
        public void Serialize(ref JT905MessagePackWriter writer, JT905_0x8103_0x0019 value, IJT905Config config)
        {
                       
            writer.WriteUInt16(value.ParamId);
            writer.WriteByte(value.ParamLength); 
            writer.WriteUInt32(value.ParamValue);
        }
    }
}

                    
