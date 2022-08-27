// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: region.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace OmniBot.ActionRpg.Game.Requests {

  /// <summary>Holder for reflection information generated from region.proto</summary>
  public static partial class RegionReflection {

    #region Descriptor
    /// <summary>File descriptor for region.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static RegionReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CgxyZWdpb24ucHJvdG8SHm9tbmlib3QuYWN0aW9ucnBnLmdhbWUuaW50ZXJv",
            "cCJVChdSZXBvcnRSZWdpb25DaGFuZ2VJbnB1dBISCgptZXNzYWdlX2lkGAEg",
            "ASgJEhEKCXRpbWVzdGFtcBgCIAEoCRITCgtyZWdpb25fbmFtZRgDIAEoCSKW",
            "AQoYUmVwb3J0UmVnaW9uQ2hhbmdlT3V0cHV0EhIKCm1lc3NhZ2VfaWQYASAB",
            "KAkSEQoJdGltZXN0YW1wGAIgASgJEh4KFnJlc3BvbnNlX3RvX21lc3NhZ2Vf",
            "aWQYAyABKAkSEgoKaXNfc3VjY2VzcxgEIAEoCBIOCgZzdGF0dXMYBSABKAkS",
            "DwoHbWVzc2FnZRgGIAEoCUIiqgIfT21uaUJvdC5BY3Rpb25ScGcuR2FtZS5S",
            "ZXF1ZXN0c2IGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::OmniBot.ActionRpg.Game.Requests.ReportRegionChangeInput), global::OmniBot.ActionRpg.Game.Requests.ReportRegionChangeInput.Parser, new[]{ "MessageId", "Timestamp", "RegionName" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::OmniBot.ActionRpg.Game.Requests.ReportRegionChangeOutput), global::OmniBot.ActionRpg.Game.Requests.ReportRegionChangeOutput.Parser, new[]{ "MessageId", "Timestamp", "ResponseToMessageId", "IsSuccess", "Status", "Message" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class ReportRegionChangeInput : pb::IMessage<ReportRegionChangeInput> {
    private static readonly pb::MessageParser<ReportRegionChangeInput> _parser = new pb::MessageParser<ReportRegionChangeInput>(() => new ReportRegionChangeInput());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<ReportRegionChangeInput> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::OmniBot.ActionRpg.Game.Requests.RegionReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ReportRegionChangeInput() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ReportRegionChangeInput(ReportRegionChangeInput other) : this() {
      messageId_ = other.messageId_;
      timestamp_ = other.timestamp_;
      regionName_ = other.regionName_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ReportRegionChangeInput Clone() {
      return new ReportRegionChangeInput(this);
    }

    /// <summary>Field number for the "message_id" field.</summary>
    public const int MessageIdFieldNumber = 1;
    private string messageId_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string MessageId {
      get { return messageId_; }
      set {
        messageId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "timestamp" field.</summary>
    public const int TimestampFieldNumber = 2;
    private string timestamp_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Timestamp {
      get { return timestamp_; }
      set {
        timestamp_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "region_name" field.</summary>
    public const int RegionNameFieldNumber = 3;
    private string regionName_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string RegionName {
      get { return regionName_; }
      set {
        regionName_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as ReportRegionChangeInput);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(ReportRegionChangeInput other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (MessageId != other.MessageId) return false;
      if (Timestamp != other.Timestamp) return false;
      if (RegionName != other.RegionName) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (MessageId.Length != 0) hash ^= MessageId.GetHashCode();
      if (Timestamp.Length != 0) hash ^= Timestamp.GetHashCode();
      if (RegionName.Length != 0) hash ^= RegionName.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (MessageId.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(MessageId);
      }
      if (Timestamp.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Timestamp);
      }
      if (RegionName.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(RegionName);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (MessageId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(MessageId);
      }
      if (Timestamp.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Timestamp);
      }
      if (RegionName.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(RegionName);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(ReportRegionChangeInput other) {
      if (other == null) {
        return;
      }
      if (other.MessageId.Length != 0) {
        MessageId = other.MessageId;
      }
      if (other.Timestamp.Length != 0) {
        Timestamp = other.Timestamp;
      }
      if (other.RegionName.Length != 0) {
        RegionName = other.RegionName;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            MessageId = input.ReadString();
            break;
          }
          case 18: {
            Timestamp = input.ReadString();
            break;
          }
          case 26: {
            RegionName = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class ReportRegionChangeOutput : pb::IMessage<ReportRegionChangeOutput> {
    private static readonly pb::MessageParser<ReportRegionChangeOutput> _parser = new pb::MessageParser<ReportRegionChangeOutput>(() => new ReportRegionChangeOutput());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<ReportRegionChangeOutput> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::OmniBot.ActionRpg.Game.Requests.RegionReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ReportRegionChangeOutput() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ReportRegionChangeOutput(ReportRegionChangeOutput other) : this() {
      messageId_ = other.messageId_;
      timestamp_ = other.timestamp_;
      responseToMessageId_ = other.responseToMessageId_;
      isSuccess_ = other.isSuccess_;
      status_ = other.status_;
      message_ = other.message_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ReportRegionChangeOutput Clone() {
      return new ReportRegionChangeOutput(this);
    }

    /// <summary>Field number for the "message_id" field.</summary>
    public const int MessageIdFieldNumber = 1;
    private string messageId_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string MessageId {
      get { return messageId_; }
      set {
        messageId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "timestamp" field.</summary>
    public const int TimestampFieldNumber = 2;
    private string timestamp_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Timestamp {
      get { return timestamp_; }
      set {
        timestamp_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "response_to_message_id" field.</summary>
    public const int ResponseToMessageIdFieldNumber = 3;
    private string responseToMessageId_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string ResponseToMessageId {
      get { return responseToMessageId_; }
      set {
        responseToMessageId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "is_success" field.</summary>
    public const int IsSuccessFieldNumber = 4;
    private bool isSuccess_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool IsSuccess {
      get { return isSuccess_; }
      set {
        isSuccess_ = value;
      }
    }

    /// <summary>Field number for the "status" field.</summary>
    public const int StatusFieldNumber = 5;
    private string status_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Status {
      get { return status_; }
      set {
        status_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "message" field.</summary>
    public const int MessageFieldNumber = 6;
    private string message_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Message {
      get { return message_; }
      set {
        message_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as ReportRegionChangeOutput);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(ReportRegionChangeOutput other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (MessageId != other.MessageId) return false;
      if (Timestamp != other.Timestamp) return false;
      if (ResponseToMessageId != other.ResponseToMessageId) return false;
      if (IsSuccess != other.IsSuccess) return false;
      if (Status != other.Status) return false;
      if (Message != other.Message) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (MessageId.Length != 0) hash ^= MessageId.GetHashCode();
      if (Timestamp.Length != 0) hash ^= Timestamp.GetHashCode();
      if (ResponseToMessageId.Length != 0) hash ^= ResponseToMessageId.GetHashCode();
      if (IsSuccess != false) hash ^= IsSuccess.GetHashCode();
      if (Status.Length != 0) hash ^= Status.GetHashCode();
      if (Message.Length != 0) hash ^= Message.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (MessageId.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(MessageId);
      }
      if (Timestamp.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Timestamp);
      }
      if (ResponseToMessageId.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(ResponseToMessageId);
      }
      if (IsSuccess != false) {
        output.WriteRawTag(32);
        output.WriteBool(IsSuccess);
      }
      if (Status.Length != 0) {
        output.WriteRawTag(42);
        output.WriteString(Status);
      }
      if (Message.Length != 0) {
        output.WriteRawTag(50);
        output.WriteString(Message);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (MessageId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(MessageId);
      }
      if (Timestamp.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Timestamp);
      }
      if (ResponseToMessageId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ResponseToMessageId);
      }
      if (IsSuccess != false) {
        size += 1 + 1;
      }
      if (Status.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Status);
      }
      if (Message.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Message);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(ReportRegionChangeOutput other) {
      if (other == null) {
        return;
      }
      if (other.MessageId.Length != 0) {
        MessageId = other.MessageId;
      }
      if (other.Timestamp.Length != 0) {
        Timestamp = other.Timestamp;
      }
      if (other.ResponseToMessageId.Length != 0) {
        ResponseToMessageId = other.ResponseToMessageId;
      }
      if (other.IsSuccess != false) {
        IsSuccess = other.IsSuccess;
      }
      if (other.Status.Length != 0) {
        Status = other.Status;
      }
      if (other.Message.Length != 0) {
        Message = other.Message;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            MessageId = input.ReadString();
            break;
          }
          case 18: {
            Timestamp = input.ReadString();
            break;
          }
          case 26: {
            ResponseToMessageId = input.ReadString();
            break;
          }
          case 32: {
            IsSuccess = input.ReadBool();
            break;
          }
          case 42: {
            Status = input.ReadString();
            break;
          }
          case 50: {
            Message = input.ReadString();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
