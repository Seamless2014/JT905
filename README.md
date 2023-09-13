# JT905 Э��

[![MIT Licence](https://img.shields.io/github/license/mashape/apistatus.svg)](https://github.com/SmallChi/JT905/blob/main/LICENSE)![.NET Core](https://github.com/SmallChi/JT905/workflows/.NET%20Core/badge.svg?branch=main)

## ǰ������

1. ���ս���ת����������תʮ�����ƣ�
2. ���� BCD ���롢Hex ���룻
3. ���ո���λ�ơ����
4. ���ճ��÷��䣻
5. ���� JObject ���÷���
6. ���տ��� ctrl+c��ctrl+v��
7. ���� Span\<T\>�Ļ����÷�
8. ��������װ�Ƽ��ܣ��Ϳ��Կ�ʼ��ש�ˡ�

## JT905 ���ݽṹ����

### ���ݰ�[JT905Package]

| ͷ��ʶ |   ����ͷ    |   ������    |  У����   | β��ʶ |
| :----: | :---------: | :---------: | :-------: | :----: |
| Begin  | JT905Header | JT905Bodies | CheckCode |  End   |
|   7E   |      -      |      -      |     -     |   7E   |

### ����ͷ[JT905Header]

| ��Ϣ ID | ��Ϣ�峤�� | ISU ��ʶ | ��Ϣ��ˮ�� |
| :-----: | :--------: | :------: | :--------: |
|  MsgId  | DataLength |   ISU    |   MsgNum   |

#### ��Ϣ������[JT905Bodies]

> ���ݶ�Ӧ��Ϣ ID��MsgId

**_ע�⣺��������(��ȥͷ��β��ʶ)����ת���ж�_**

ת���������:

1. �������������г����ַ� 0x7e �ģ����滻Ϊ�ַ� 0x7d �����ַ� 0x02;
2. �������������г����ַ� 0x7d �ģ����滻Ϊ�ַ� 0x7d �����ַ� 0x01;

��ת���ԭ��ȷ�� JT905 Э��� TCP ��Ϣ�߽硣

### �ٸ����� 1

#### 1.�����

> MsgId 0x0200:λ����Ϣ�㱨

```csharp

JT905Package JT905Package = new JT905Package();

JT905Package.Header = new JT905Header
{
    MsgId = Enums.JT905MsgId.λ����Ϣ�㱨.ToUInt16Value(),
    ManualMsgNum = 126,
    ISU = "103456789012"
};

JT905_0x0200 JT905_0x0200 = new JT905_0x0200
{
    AlarmFlag = 1,
    GPSTime = DateTime.Parse("2021-10-15 21:10:10"),
    Lat = 12222222,
    Lng = 132444444,
    Speed = 60,
    Direction = 0,
    StatusFlag = 2,
    BasicLocationAttachData = new Dictionary<byte, JT905_0x0200_BodyBase>()
};

JT905_0x0200.BasicLocationAttachData.Add(JT905Constants.JT905_0x0200_0x01, new JT905_0x0200_0x01
{
    Mileage = 100
});

JT905_0x0200.BasicLocationAttachData.Add(JT905Constants.JT905_0x0200_0x02, new JT905_0x0200_0x02
{
    Oil = 125
});

JT905Package.Bodies = JT905_0x0200;

byte[] data = JT905Serializer.Serialize(JT905Package);

var hex = data.ToHexString();

// ������Hex��
// 7E02000023103456789012007D02000000010000000200BA7F0E07E4F11C003C002110152110100104000000640202007D01347E
```

#### 2.�ֶ������

```csharp
1.ԭ����
7E 02 00 00 23 10 34 56 78 90 12 00 (7D 02) 00 00 00 01 00 00 00 02 00 BA 7F 0E 07 E4 F1 1C 00 3C 00 21 10 15 21 10 10 01 04 00 00 00 64 02 02 00 (7D 01) 34 7E

2.���з�ת��
7D 02 ->7E
7D 01 ->7D
��ת���
7E 02 00 00 23 10 34 56 78 90 12 00 7E 00 00 00 01 00 00 00 02 00 BA 7F 0E 07 E4 F1 1C 00 3C 00 21 10 15 21 10 10 01 04 00 00 00 64 02 02 00 7D 34 7E

3.���
7E                  --ͷ��ʶ
02 00               --����ͷ->��ϢID
00 23               --����ͷ->��Ϣ������
10 34 56 78 90 12   --����ͷ->�ն��ֻ���
00 7E               --����ͷ->��Ϣ��ˮ��
00 00 00 01         --��Ϣ��->������־
00 00 00 02         --��Ϣ��->״̬λ��־
00 BA 7F 0E         --��Ϣ��->γ��
07 E4 F1 1C         --��Ϣ��->����
00 3C               --��Ϣ��->�ٶ�
00                  --��Ϣ��->����
21 10 15 21 10 10   --��Ϣ��->GPSʱ��
01                  --��Ϣ��->������Ϣ->���
04                  --��Ϣ��->������Ϣ->����
00 00 00 64         --��Ϣ��->������Ϣ->����
02                  --��Ϣ��->������Ϣ->����
02                  --��Ϣ��->������Ϣ->����
00 7D               --��Ϣ��->������Ϣ->����
34                  --������
7E                  --β��ʶ
```

#### 3.��������

```csharp
//1.ת��byte����
byte[] bytes = "7E02000023103456789012007D02000000010000000200BA7F0E07E4F11C003C002110152110100104000000640202007D01347E".ToHexBytes();

//2.�����鷴���л�
var jT905Package = JT905Serializer.Deserialize<JT905Package>(bytes);

//3.���ݰ�ͷ
Assert.Equal(Enums.JT905MsgId.λ����Ϣ�㱨.ToValue(), jT905Package.Header.MsgId);
Assert.Equal(0x23, jT905Package.Header.DataLength);
Assert.Equal(126, jT905Package.Header.MsgNum);
Assert.Equal("103456789012", jT905Package.Header.ISU);

//4.���ݰ���
JT905_0x0200 jT905_0x0200 = (JT905_0x0200)jT905Package.Bodies;
Assert.Equal((uint)1, jT905_0x0200.AlarmFlag);
Assert.Equal(DateTime.Parse("2021-10-15 21:10:10"), jT905_0x0200.GPSTime);
Assert.Equal(12222222, jT905_0x0200.Lat);
Assert.Equal(132444444, jT905_0x0200.Lng);
Assert.Equal(60, jT905_0x0200.Speed);
Assert.Equal(0, jT905_0x0200.Direction);
Assert.Equal((uint)2, jT905_0x0200.StatusFlag);
//4.1.������Ϣ1
Assert.Equal(100, ((JT905_0x0200_0x01)jT905_0x0200.BasicLocationAttachData[JT905Constants.JT905_0x0200_0x01]).Mileage);
//4.2.������Ϣ2
Assert.Equal(125, ((JT905_0x0200_0x02)jT905_0x0200.BasicLocationAttachData[JT905Constants.JT905_0x0200_0x02]).Oil);
```

## NuGet ��װ

| Package Name          | Version                                            | Preview Version                                       | Downloads                                           | Remark |
| --------------------- | -------------------------------------------------- | ----------------------------------------------------- | --------------------------------------------------- | ------ |
| Install-Package JT905 | ![JT905](https://img.shields.io/nuget/v/JT905.svg) | ![JT905](https://img.shields.io/nuget/vpre/JT905.svg) | ![JT905](https://img.shields.io/nuget/dt/JT905.svg) | JT905  |

## ʹ�� BenchmarkDotNet ���ܲ��Ա��棨ֻ�����棬���ܵ��棩

> todo:

## JT905 �ն�ͨѶЭ����Ϣ���ձ�

| ��� | ��Ϣ ID | ������ | ������� | ��Ϣ������              |
| :--: | :-----: | :------: | :------: | :---------------------- |
|  1   | 0x0001  |    ��     |    ��     | ISU ͨ��Ӧ��            |
|  2   | 0x8001  |    ��     |    ��     | ����ͨ��Ӧ��            |
|  3   | 0x0002  |    ��     |    ��     | ISU ����                |
|  4   | 0x8103  |    ��     |    ��     | ���ò���                |
|  5   | 0x8104  |    ��     |    ��     | ��ѯ ISU ����           |
|  6   | 0x0104  |    ��     |    ��     | ��ѯ ISU ����Ӧ��       |
|  7   | 0x8105  |    ��     |    ��     | ISU ����                |
|  8   | 0x0105  |    ��     |    ��     | ISU �������������Ϣ    |
|  9   | 0x0200  |    ��     |    ��     | λ����Ϣ�㱨            |
|  10  | 0x8201  |    ��     |    ��     | λ����Ϣ��ѯ            |
|  11  | 0x0201  |    ��     |    ��     | λ����Ϣ��ѯӦ��        |
|  12  | 0x8202  |    ��     |    ��     | λ�ø��ٿ���            |
|  13  | 0x0202  |    ��     |    ��     | λ�ø�����Ϣ�㱨        |
|  14  | 0x0203  |    ��     |    ��     | λ�û�㱨���ݲ���      |
|  15  | 0x8300  |    ��     |    ��     | �ı���Ϣ�·�            |
|  16  | 0x8301  |    ��     |    ��     | �¼�����                |
|  17  | 0x0301  |    ��     |    ��     | �¼�����                |
|  18  | 0x8302  |    ��     |    ��     | �����·�                |
|  19  | 0x0302  |    ��     |    ��     | ����Ӧ��                |
|  20  | 0x8400  |    ��     |    ��     | �绰�ز�                |
|  21  | 0x8401  |    ��     |    ��     | ���õ绰��              |
|  22  | 0x8500  |    ��     |    ��     | ��������                |
|  23  | 0x0500  |    ��     |    ��     | ��������Ӧ��            |
|  24  | 0x0800  |    ��     |    ��     | ����ͷͼ���ϴ�          |
|  25  | 0x8801  |    ��     |    ��     | ����ͷ������������      |
|  26  | 0x8802  |    ��     |    ��     | �洢ͼ�����            |
|  27  | 0x0802  |    ��     |    ��     | �洢ͼ�����Ӧ��        |
|  28  | 0x8803  |    ��     |    ��     | �洢ͼ��/����Ƶ�ϴ����� |
|  29  | 0x8B00  |    ��     |    ��     | ���������·�            |
|  30  | 0x8B01  |    ��     |    ��     | �·���������Ϣ        |
|  31  | 0x0B01  |    ��     |    ��     | ��ʻԱ����              |
|  32  | 0x0B07  |    ��     |    ��     | ��ʻԱ�����������ȷ��  |
|  33  | 0x0B08  |    ��     |    ��     | ��ʻԱȡ������          |
|  34  | 0x8B09  |    ��     |    ��     | ����ȡ������            |
|  35  | 0x0B03  |    ��     |    ��     | �ϰ�ǩ����Ϣ�ϴ�        |
|  36  | 0x0B04  |    ��     |    ��     | �°�ǩ����Ϣ�ϴ�        |
|  37  | 0x0B05  |    ��     |    ��     | ��Ӫ�����ϴ�            |
|  38  | 0x8B10  |    ��     |    ��     | ��Χ�豸ָ������͸��    |
|  39  | 0x0B10  |    ��     |    ��     | ��Χ�豸ָ������͸��    |
|  40  | 0x8850  |          |          | ��Ƶ����                |
|  41  | 0x0805  |          |          | �洢��Ƶ����Ӧ��        |
|  42  | 0x0806  |          |          | ��Ƶ�ϴ�                |
|  43  | 0x8B0A  |    ��     |    ��     | ���ı���ȷ��            |
|  44  | 0x8B0B  |    ��     |    ��     | ���ı������            |
|  45  | 0x8B11  |    ��     |    ��     | ����Ѳ���豸            |
|  46  | 0x0B11  |          |          | �豸Ѳ��Ӧ��            |

> todo:

## �������ݽ���

### �Ƽ������ݽ���

��Ӫ������Ϊ��������ʹ�÷��������

- [��������Ӫ�����ݽ���](src/JT905.Protocol.Test/SerialPort/Taximeter_0x00E8_Up_Test.cs#L43)
- [Ӫ�����ݽ���](src/JT905.Protocol.Test/SerialPort/Taximeter_0x00E8_Up_Test.cs#L90)
- [�����豸Ӫ�����ݽ���](src/JT905.Protocol.Test/SerialPort/Taximeter_0x00E8_Up_Test.cs#L111)
