// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: zone.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace OmniBot.ActionRpg.Game.Requests {

  /// <summary>Holder for reflection information generated from zone.proto</summary>
  public static partial class ZoneReflection {

    #region Descriptor
    /// <summary>File descriptor for zone.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static ZoneReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cgp6b25lLnByb3RvEh5vbW5pYm90LmFjdGlvbnJwZy5nYW1lLmludGVyb3Ai",
            "UQoVUmVwb3J0Wm9uZUNoYW5nZUlucHV0EhIKCm1lc3NhZ2VfaWQYASABKAkS",
            "EQoJdGltZXN0YW1wGAIgASgJEhEKCXpvbmVfbmFtZRgDIAEoCSKUAQoWUmVw",
            "b3J0Wm9uZUNoYW5nZU91dHB1dBISCgptZXNzYWdlX2lkGAEgASgJEhEKCXRp",
            "bWVzdGFtcBgCIAEoCRIeChZyZXNwb25zZV90b19tZXNzYWdlX2lkGAMgASgJ",
            "EhIKCmlzX3N1Y2Nlc3MYBCABKAgSDgoGc3RhdHVzGAUgASgJEg8KB21lc3Nh",
            "Z2UYBiABKAlCIqoCH09tbmlCb3QuQWN0aW9uUnBnLkdhbWUuUmVxdWVzdHNi",
            "BnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::OmniBot.ActionRpg.Game.Requests.ReportZoneChangeInput), global::OmniBot.ActionRpg.Game.Requests.ReportZoneChangeInput.Parser, new[]{ "MessageId", "Timestamp", "ZoneName" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::OmniBot.ActionRpg.Game.Requests.ReportZoneChangeOutput), global::OmniBot.ActionRpg.Game.Requests.ReportZoneChangeOutput.Parser, new[]{ "MessageId", "Timestamp", "ResponseToMessageId", "IsSuccess", "Status", "Message" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class ReportZoneChangeInput : pb::IMessage<ReportZoneChangeInput> {
    private static readonly pb::MessageParser<ReportZoneChangeInput> _parser = new pb::MessageParser<ReportZoneChangeInput>(() => new ReportZoneChangeInput());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<ReportZoneChangeInput> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::OmniBot.ActionRpg.Game.Requests.ZoneReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ReportZoneChangeInput() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ReportZoneChangeInput(ReportZoneChangeInput other) : this() {
      messageId_ = other.messageId_;
      timestamp_ = other.timestamp_;
      zoneName_ = other.zoneName_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ReportZoneChangeInput Clone() {
      return new ReportZoneChangeInput(this);
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

    /// <summary>Field number for the "zone_name" field.</summary>
    public const int ZoneNameFieldNumber = 3;
    private string zoneName_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string ZoneName {
      get { return zoneName_; }
      set {
        zoneName_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as ReportZoneChangeInput);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(ReportZoneChangeInput other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (MessageId != other.MessageId) return false;
      if (Timestamp != other.Timestamp) return false;
      if (ZoneName != other.ZoneName) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (MessageId.Length != 0) hash ^= MessageId.GetHashCode();
      if (Timestamp.Length != 0) hash ^= Timestamp.GetHashCode();
      if (ZoneName.Length != 0) hash ^= ZoneName.GetHashCode();
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
      if (ZoneName.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(ZoneName);
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
      if (ZoneName.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ZoneName);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(ReportZoneChangeInput other) {
      if (other == null) {
        return;
      }
      if (other.MessageId.Length != 0) {
        MessageId = other.MessageId;
      }
      if (other.Timestamp.Length != 0) {
        Timestamp = other.Timestamp;
      }
      if (other.ZoneName.Length != 0) {
        ZoneName = other.ZoneName;
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
            ZoneName = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class ReportZoneChangeOutput : pb::IMessage<ReportZoneChangeOutput> {
    private static readonly pb::MessageParser<ReportZoneChangeOutput> _parser = new pb::MessageParser<ReportZoneChangeOutput>(() => new ReportZoneChangeOutput());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<ReportZoneChangeOutput> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::OmniBot.ActionRpg.Game.Requests.ZoneReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ReportZoneChangeOutput() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ReportZoneChangeOutput(ReportZoneChangeOutput other) : this() {
      messageId_ = other.messageId_;
      timestamp_ = other.timestamp_;
      responseToMessageId_ = other.responseToMessageId_;
      isSuccess_ = other.isSuccess_;
      status_ = other.status_;
      message_ = other.message_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ReportZoneChangeOutput Clone() {
      return new ReportZoneChangeOutput(this);
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
      return Equals(other as ReportZoneChangeOutput);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(ReportZoneChangeOutput other) {
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
    public void MergeFrom(ReportZoneChangeOutput other) {
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
